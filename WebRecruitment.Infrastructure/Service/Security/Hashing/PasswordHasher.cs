using System.Security.Cryptography;
using System.Text;
using WebRecruitment.Application.Common.Security.Hashing;
using BCryptNet = BCrypt.Net.BCrypt;

namespace WebRecruitment.Infrastructure.Service.Security.Hashing
{
    public class PasswordHasher : IPasswordHasher
    {
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }


        public bool VerifyPassword(string password, string storedHash)
        {
            byte[] salt = GetSaltFromHash(storedHash);
            string hashedPassword = HashPassword(password, salt);
            return storedHash.Equals(hashedPassword);
        }

        private string HashPassword(string password, byte[] salt)
        {
            int iterations = 350000;
            int keySize = 64;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm))
            {
                byte[] hash = rfc2898DeriveBytes.GetBytes(keySize);
                return Convert.ToHexString(hash);
            }
        }

        private byte[] GetSaltFromHash(string hash)
        {
            int saltSize = 16; // Assuming the salt size is 16 bytes in the stored hash
            byte[] salt = new byte[saltSize];
            for (int i = 0; i < salt.Length; i++)
            {
                salt[i] = Convert.ToByte(hash.Substring(i * 2, 2), 16);
            }
            return salt;
        }

        private const int WorkFactor = 12;

        public string HashPassword(string password)
        {
            string salt = BCryptNet.GenerateSalt(WorkFactor);
            string hashedPassword = BCryptNet.HashPassword(password, salt);
            return hashedPassword;
        }

        public bool VerifyPasswordB(string password, string hashedPassword)
        {
            return BCryptNet.Verify(password, hashedPassword);
        }
    }
}