using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Password.Classes
{
    public static class ObjectHelper
    {
        public static Guid ToGuid(this string obj)
        {
            return new Guid(obj);
        }

        public static bool ToBool(this string obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static byte[] ToBytes(this string obj)
        {
            return obj.Select(Convert.ToByte).ToArray();
        }

        private static SymmetricAlgorithm MakeCoder(string password)
        {
            var key = password.ToBytes();
            if (key.Length > 16)
                key = key.Take(16).ToArray();
            else if (key.Length < 16)
                key = key.Concat(Enumerable.Range(1, 16 - key.Length).Select(x => (byte)x)).ToArray();

            var result = SymmetricAlgorithm.Create("RC2");
            result.IV = new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 };
            result.Key = key;

            return result;
        }

        public static string Encrypt(string value, string password)
        {
            var coder = MakeCoder(password);
            ICryptoTransform transform = coder.CreateEncryptor();

            var bytes = value.ToBytes();
            var result = transform.TransformFinalBlock(bytes, 0, bytes.Length);
            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string value, string password)
        {
            var coder = MakeCoder(password);
            ICryptoTransform transform = coder.CreateDecryptor();

            var bytes = Convert.FromBase64String(value);
            var result = transform.TransformFinalBlock(bytes, 0, bytes.Length);
            return new string(result.Select(Convert.ToChar).ToArray());
        }

        public static string Md5(string value)
        {
            var md5 = MD5.Create();
            var bytes = Encoding.Unicode.GetBytes(value);
            var data = md5.ComputeHash(bytes);

            return string.Join("", data.Select(x => x.ToString("x2"))).ToUpper();
        }

        public static string DecodePassword(this string value, string password)
        {
            return Decrypt(value, password);
        }

        public static string EncodePassword(this string value, string password)
        {
            return Encrypt(value, password);
        }

        public static string EncodeDocumentPassword(this string value)
        {
            return Md5(value);
        }

        public static bool CompareDocumentPassword(this string value, string password)
        {
            return value == password.EncodeDocumentPassword();
        }
    }
}