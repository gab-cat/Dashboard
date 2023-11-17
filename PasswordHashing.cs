using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public class PasswordHashing
    {
        private const int SaltSize = 32; // Size of the salt in bytes

        public static (string hashedPassword, string salt) HashPassword(string password)
        {
            // Generate a random salt
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            // Combine the password and salt and hash it
            string hashedPassword = HashString(password, salt);

            return (hashedPassword, salt);
        }

        public static string HashString(string password, string salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            byte[] combinedBytes = new byte[passwordBytes.Length + saltBytes.Length];
            Array.Copy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
            Array.Copy(saltBytes, 0, combinedBytes, passwordBytes.Length, saltBytes.Length);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword, string salt)
        {
            string hashedInputPassword = HashString(password, salt);
            return hashedInputPassword.Equals(hashedPassword);
        }

        public static string GenerateSalt()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var salt = new string(Enumerable.Repeat(validChars, 16)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return salt;
        }
    }
}
