using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Password_Manager_Desktop_Client.crypto;

internal static class VaultKeyGenerator
{
    public static byte[] GenerateVaultKey(string username, string password, byte[] salt)
    {
        byte[] usernameBytes = Encoding.UTF8.GetBytes(username);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        var firstKeyByteArr = ConcatenateByteArrays(usernameBytes, passwordBytes);
        var singleHashedKey = HashKey(firstKeyByteArr, salt);

        var secondKeyByteArr = ConcatenateByteArrays(singleHashedKey, passwordBytes);
        var doubleHashedKey = HashKey(secondKeyByteArr, salt);

        return doubleHashedKey;
    }

    private static byte[] HashKey(byte[] key, byte[] salt)
    {
        var argon2id = new Argon2id(key);
        argon2id.Salt = salt;
        argon2id.DegreeOfParallelism = 4;
        argon2id.Iterations = 4;
        argon2id.MemorySize = 128;

        return argon2id.GetBytes(32);
    }

    public static byte[] ConcatenateByteArrays(byte[] byteArr1, byte[] byteArr2)
    {
        return byteArr1.Concat(byteArr2).ToArray();
    }
}
