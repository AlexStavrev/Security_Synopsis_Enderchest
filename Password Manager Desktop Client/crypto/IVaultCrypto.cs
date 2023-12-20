using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client.crypto
{
    public interface IVaultCrypto
    {
        public EncryptedFileDto EncryptSingleFile(DecryptedFileDto file, string username, string password);
        public DecryptedFileDto DecryptSingleFile(EncryptedFileDto file, string username, string password);
        public SharedFolderDto EncryptSharedFolder(SharedFolderDto folder, string ownerUsername, string shareCode);
        public SharedFolderDto DecryptSharedFolder(SharedFolderDto folder, string ownerUsername, string shareCode);
        public byte[] RetrieveSalt(byte[] property);
        public byte[] DeriveSecterKey(string username, string password, byte[] salt);
        public byte[] EncryptFile(string plainText, byte[] key, byte[] salt);
        public byte[] DecryptFile(byte[] encryptedProp, byte[] key);
        public byte[] GenerateSalt();
        public byte[] ConcatCypher(byte[] salt, byte[] nonce, byte[] tag, byte[] cypher);

    }
}
