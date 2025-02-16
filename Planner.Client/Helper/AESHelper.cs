using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Client.Helper
{
    internal class AESHelper
    {
        internal static byte[] Encrypt(string plainText, byte[] key, byte[] iv)
        {
            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using MemoryStream memoryStream = new();
            using CryptoStream cryptoStream = new(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            using StreamWriter writer = new(cryptoStream);
            writer.Write(plainText);

            return memoryStream.ToArray();
        }

        internal static string Decrypt(byte[] cipherText, byte[] key, byte[] iv)
        {
            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using MemoryStream memoryStream = new(cipherText);
            using CryptoStream cryptoStream = new(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader reader = new(cryptoStream);

            return reader.ReadToEnd();
        }
    }
}
