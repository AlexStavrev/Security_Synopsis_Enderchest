﻿using Konscious.Security.Cryptography;
using System.Text;

namespace Password_Manager_Desktop_Client.crypto;

internal static class MasterPasswrodHelper
{
    public static byte[] DerivePasswordKey(byte[] salt, string password)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        var singleHashedKey = HashPassword(salt, passwordBytes);

        var saltSingleHashedKey = ConcatenateByteArrays(salt, singleHashedKey);
        var doubleHashedKey = HashPassword(salt, saltSingleHashedKey);

        var saltDoubleHashedKey = ConcatenateByteArrays(salt, doubleHashedKey);

        return saltDoubleHashedKey;
    }

    private static byte[] HashPassword(byte[] salt, byte[] password)
    {
        var argon2id = new Argon2id(password);
        argon2id.Salt = salt;
        argon2id.DegreeOfParallelism = 2;
        argon2id.Iterations = 4;
        argon2id.MemorySize = 40000;

        return argon2id.GetBytes(32);
    }

    public static byte[] ConcatenateByteArrays(byte[] byteArr1, byte[] byteArr2)
    {
        return byteArr1.Concat(byteArr2).ToArray();
    }
}
