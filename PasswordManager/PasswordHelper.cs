using System;
using PasswordManager.Classes;

namespace PasswordManager
{
    internal static class PasswordHelper
    {
        private static readonly Random _random;

        static PasswordHelper()
        {
            _random = new Random();
        }

        public static string CreatePassword(Configuration config)
        {
            string result = string.Empty;

            for (int i = 0; i < config.PasswordLength; i++)
                result += config.AllowChars[_random.Next(config.AllowChars.Length)];

            return result;
        }
    }
}