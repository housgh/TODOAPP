using System;
using TODOAPP.Core.Interfaces;

namespace TODOAPP.Core.Implementations
{
    public class HashService : IHashService
    {
        public string HashString(string text, string salt = "")
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            using var sha = new System.Security.Cryptography.SHA256Managed();
            var textBytes = System.Text.Encoding.UTF8.GetBytes(text + salt);
            var hashBytes = sha.ComputeHash(textBytes);
                
            var hash = BitConverter
                .ToString(hashBytes)
                .Replace("-", String.Empty);

            return hash;
        }
    }
}