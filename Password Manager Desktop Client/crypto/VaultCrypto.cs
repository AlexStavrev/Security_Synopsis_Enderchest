using System.Security.Cryptography;
using System.Text;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client.crypto;

public class VaultCrypto : IVaultCrypto
{

    public EncryptedFileDto EncryptSingleFile(DecryptedFileDto file, string username, string password)
    {
        if (file != null)
        {
            var salt = GenerateSalt();
            var secretKey = DeriveSecterKey(username, password, salt);
            var encryptedFile = EncryptFile(file.File, secretKey, salt);

            return new EncryptedFileDto
            {
                OwnerGuid = file.OwnerGuid,
                File = encryptedFile
            };
        }
        return new EncryptedFileDto();
    }

    public DecryptedFileDto DecryptSingleFile(EncryptedFileDto file, string username, string password)
    {
        if (file != null)
        {

            var salt = RetrieveSalt(file.File);
            var secretKey = DeriveSecterKey(username, password, salt);
            var decryptedPropertyByteArr = DecryptFile(file.File, secretKey);
            string decryptedProperty = Encoding.UTF8.GetString(decryptedPropertyByteArr);

            return new DecryptedFileDto
            {
                Guid = file.Guid,
                File = decryptedProperty
            };
        }
        return new DecryptedFileDto();
    }

    public SharedFolderDto EncryptSharedFolder(SharedFolderDto folder, string ownerUsername, string shareCode)
    {
        if (folder != null)
        {
            var salt = GenerateSalt();
            var secretKey = DeriveSecterKey(ownerUsername, shareCode, salt);
            var encryptedFiles = new List<EncryptedFileDto>();
            for (var i = 0; i < folder.DecryptedFiles.Count(); i++){
                var ecryptedFileDto = new EncryptedFileDto
                {
                    Guid = folder.DecryptedFiles.ElementAt(i).Guid,
                    OwnerGuid = folder.DecryptedFiles.ElementAt(i).OwnerGuid,
                    File = EncryptFile(folder.DecryptedFiles.ElementAt(i).File, secretKey, salt)
                };  

                encryptedFiles.Add(ecryptedFileDto);
            }
            

            return new SharedFolderDto
            {
                Guid = folder.Guid,
                OwenerGuid = folder.OwenerGuid,
                HashedShareCode = secretKey,
                EncryptedFiles = encryptedFiles
            };
        }
        return new SharedFolderDto();
    }

    public SharedFolderDto DecryptSharedFolder(SharedFolderDto folder, string ownerUsername, string shareCode)
    {
        if (folder != null)
        {
            var salt = RetrieveSalt(folder.EncryptedFiles.FirstOrDefault().File);
            var secretKey = DeriveSecterKey(ownerUsername, shareCode, salt);
            var decryptedFiles = new List<DecryptedFileDto>();
            for (var i = 0; i < folder.DecryptedFiles.Count(); i++)
            {
                
                var deryptedFileDto = new DecryptedFileDto
                {
                    Guid = folder.DecryptedFiles.ElementAt(i).Guid,
                    OwnerGuid = folder.DecryptedFiles.ElementAt(i).OwnerGuid,
                    File = Encoding.UTF8.GetString(DecryptFile(folder.EncryptedFiles.ElementAt(i).File, secretKey))
                };

                decryptedFiles.Add(deryptedFileDto);
            }


            return new SharedFolderDto
            {
                Guid = folder.Guid,
                OwenerGuid = folder.OwenerGuid,
                HashedShareCode = secretKey,
                DecryptedFiles = decryptedFiles
            };
        }
        return new SharedFolderDto();
    }

    public byte[] RetrieveSalt(byte[] property)
    {
        byte[] salt = property.Take(16).ToArray();
        return salt;
    }

    public byte[] DeriveSecterKey(string username, string password, byte[] salt)
    {
        var secretKey = VaultKeyGenerator.GenerateVaultKey(username, password, salt);
        return secretKey;
    }

    public byte[] EncryptFile(string plainText, byte[] key, byte[] salt)
    {
        using var aes = new AesGcm(key);

        var nonce = RandomNumberGenerator.GetBytes(AesGcm.NonceByteSizes.MaxSize);
        var bytesText = Encoding.UTF8.GetBytes(plainText);
        var cipher = new byte[bytesText.Length];
        var tag = new byte[AesGcm.TagByteSizes.MaxSize];

        aes.Encrypt(nonce: nonce, plaintext: bytesText, ciphertext: cipher, tag: tag);

        var encryptedProp = ConcatCypher(salt, nonce, tag, cipher);
        return encryptedProp;
    }

    public byte[] DecryptFile(byte[] encryptedProp, byte[] key)
    {
        using var aes = new AesGcm(key);

        var nonce = encryptedProp.Skip(16).Take(12).ToArray();
        var tag = encryptedProp.Skip(28).Take(16).ToArray();
        var textToDecrypt = encryptedProp.Skip(44).ToArray();
        var decryptedProp = new byte[textToDecrypt.Length];
        try
        {
            aes.Decrypt(nonce: nonce, ciphertext: textToDecrypt, tag: tag, plaintext: decryptedProp);
        }catch (CryptographicException ex) 
        {
            throw new Exception("Tag missmatch!", ex);
        }
       

        return decryptedProp;
    }

    public byte[] GenerateSalt()
    {
        var buffer = new byte[16];

        RNGCryptoServiceProvider rng = new();

        rng.GetBytes(buffer);

        return buffer;
    }

    public byte[] ConcatCypher(byte[] salt, byte[] nonce, byte[] tag, byte[] cypher)
    {
        return salt.Concat(nonce).Concat(tag).Concat(cypher).ToArray();
    }
}
