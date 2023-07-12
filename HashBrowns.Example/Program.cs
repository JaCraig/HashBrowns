using BigBook;
using HashBrowns.Hashing.Enums;
using HashBrowns.Symmetric.Enums;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace HashBrowns.Example
{
    /// <summary>
    /// This is just an example of how to use HashBrowns to hash and encrypt strings.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            // Setup the DI
            var Services = new ServiceCollection().AddCanisterModules()?.BuildServiceProvider();

            // Hash the string using SHA256
            Console.WriteLine("Let's hash some strings!".Hash(HashingAlgorithms.SHA256).ToString(Encoding.UTF8));

            // Hash the string using HMACSHA512
            Console.WriteLine("Let's hash some strings!".Hash(HashingAlgorithms.HMACSHA512).ToString(Encoding.UTF8));

            // Encrypt the string using a password and salt
            var EncryptedString = "Let's encrypt some strings!".Encrypt("password".ToByteArray(), "salt".ToByteArray(), HashingAlgorithms.SHA256, 5, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 256, SymmetricAlgorithms.AES);
            Console.WriteLine(EncryptedString.ToString(Encoding.UTF8));

            // Decrypt the string using a password and salt
            var DecryptedString = EncryptedString.Decrypt("password".ToByteArray(), "salt".ToByteArray(), HashingAlgorithms.SHA256, 5, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 256, SymmetricAlgorithms.AES);
            Console.WriteLine(DecryptedString.ToString(Encoding.UTF8));
        }
    }
}