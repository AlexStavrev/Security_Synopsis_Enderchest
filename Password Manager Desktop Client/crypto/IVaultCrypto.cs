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
        public EncryptedFileDtoNoGuid EncryptFile(DecryptedFileDtoNoGuid file, string username, string password);
        public DecryptedFileDto DecryptFile(EncryptedFileDto file, string username, string password);
        public byte[] RetrieveSalt(byte[] property);
        public byte[] DeriveSecterKey(string username, string password, byte[] salt);
        public byte[] EncryptFile(string plainText, byte[] key, byte[] salt);
        public byte[] DecryptProperty(byte[] encryptedProp, byte[] key);
        public byte[] GenerateSalt();
        public byte[] ConcatCypher(byte[] salt, byte[] nonce, byte[] tag, byte[] cypher);

    }
}
