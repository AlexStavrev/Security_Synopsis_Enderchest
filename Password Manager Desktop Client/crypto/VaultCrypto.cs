using System.Security.Cryptography;
using System.Text;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client.crypto;

public class VaultCrypto : IVaultCrypto
{

    public PasswordVaultDto EncryptVault(PasswordVaultDto vault, string username, string password)
    {
            if (vault != null || vault.DecryptedVault.Any())
            {
            List<HashedCredentialsDto> encrypedCredentialsDtos = new();

                foreach (var credentials in vault.DecryptedVault)
                {
                var encryptedCredential = new HashedCredentialsDto();

                    foreach (var property in typeof(DecryptedCredentialsDto).GetProperties())
                    {
                    var propertyName = property.Name;
                    if (property.PropertyType == typeof(int?))
                        {
                            if(property.GetValue(credentials) == null)
                            {
                                continue;
                            }
                            encryptedCredential.Vaultid = (int)property.GetValue(credentials);
                            continue;
                        }
                        var salt = GenerateSalt();
                        var secretKey = DeriveSecterKey(username, password, salt);
                        var propertyValue = (string)property.GetValue(credentials);

                        if(propertyValue != null)
                        {
                        var encryptedProperty = EncryptProperty(propertyValue, secretKey, salt);
                        typeof(HashedCredentialsDto).GetProperty(propertyName)?.SetValue(encryptedCredential, encryptedProperty);
                        }

                    }
                encrypedCredentialsDtos.Add(encryptedCredential);
                
                }
            vault.EncryptedVault = encrypedCredentialsDtos;
            return vault;
            }
            else
            {
                return new PasswordVaultDto();
            }
    }

    public PasswordVaultDto DecryptVault(PasswordVaultDto vault, string username, string password)
    {
        if (vault != null || vault.EncryptedVault.Any())
        {
            List<DecryptedCredentialsDto> decrypredCredentialsDtos = new();
            foreach (var credentials in vault.EncryptedVault)
            {
                var decryptedCredential = new DecryptedCredentialsDto();

                foreach (var property in typeof(HashedCredentialsDto).GetProperties())
                {
                    if (property.PropertyType != typeof(byte[]))
                    {
                        if (property.GetValue(credentials) == null)
                        {
                            continue;
                        }
                        decryptedCredential.Vaultid = (int)property.GetValue(credentials);
                        continue;
                    }
                    var encryptedProp = (byte[])property.GetValue(credentials);

                    if(encryptedProp != null)
                    {
                        var salt = RetrieveSalt(encryptedProp);
                        var secretKey = DeriveSecterKey(username, password, salt);

                        var decryptedPropertyByteArr = DecryptProperty(encryptedProp, secretKey);

                        string decryptedProperty = Encoding.UTF8.GetString(decryptedPropertyByteArr);
                        var propertyName = property.Name;
                        typeof(DecryptedCredentialsDto).GetProperty(propertyName)?.SetValue(decryptedCredential, decryptedProperty);
                    }
                }
                decrypredCredentialsDtos.Add(decryptedCredential);
            }
            vault.DecryptedVault = decrypredCredentialsDtos;
            return vault;
        }
        else
        {
            return new PasswordVaultDto();
        }
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

    public byte[] EncryptProperty(string plainText, byte[] key, byte[] salt)
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

    public byte[] DecryptProperty(byte[] encryptedProp, byte[] key)
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
