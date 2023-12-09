using System.Security.Cryptography;
using System.Text;

namespace Itec102
{
    public class Security
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute hash from the password
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        public static bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            // Hash the entered password using the same method used during registration
            string hashedEnteredPassword = HashPassword(enteredPassword);

            // Compare the stored hash with the newly hashed entered password
            return hashedEnteredPassword == storedHashedPassword;
        }
    }
}