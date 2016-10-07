using System;
using System.Security.Cryptography;
using System.Text;

namespace DotNet_Cryptography_HashingAlgorithms
{
    class Program
    {
        private static string plainTextOne = "Hello Crypto";
        private static string plainTextTwo = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
        private static string divider = new string('-', 140);

        static void Main(string[] args)
        {
            Console.WriteLine($"String 1 Plain Text: {plainTextOne}");
            Console.WriteLine($"String 2 Plain Text: {plainTextTwo}");

            // Algorithms
            RunSHA512();
            RunMD5CryptoServiceProvider();
            RunHMACRIPEMD160();
            RunMACTripleDES();

            // Password
            RunPasswordEncryption();

            // Generic Algorithm Injection
            PrintTitle("Generic Hasher");
            string originalMessage = "Hello world";
            Console.WriteLine($"Original Message: {originalMessage,25}");

            Hash(originalMessage, MD5.Create());
            Hash(originalMessage, SHA1.Create());
            Hash(originalMessage, SHA256.Create());
            Hash(originalMessage, SHA512.Create());

            // Wait and display
            Console.ReadKey();
        }

        #region Algorithms

        private static void RunSHA512()
        {
            PrintTitle("SHA512");

            SHA512Managed sha512 = new SHA512Managed();

            // 'ComputeHash' Returns a 64 byte array (8*64=512)
            byte[] textOneHash = sha512.ComputeHash(Encoding.UTF8.GetBytes(plainTextOne));
            byte[] textTwoHash = sha512.ComputeHash(Encoding.UTF8.GetBytes(plainTextTwo));

            string hexOfValueOne = BitConverter.ToString(textOneHash);
            string hexOfValueTwo = BitConverter.ToString(textTwoHash);

            // Out put is grouped into pairs, each represents a byte value between 0-255
            Console.WriteLine($"String 1 Hash: {hexOfValueOne}");
            Console.WriteLine($"String 2 Hash: {hexOfValueTwo}");

        }

        private static void RunMD5CryptoServiceProvider()
        {
            PrintTitle("MD5CryptoServiceProvider");

            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();

            // 'ComputeHash' Returns a 16 byte array (8*16=128)
            byte[] textOneHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(plainTextOne));
            byte[] textTwoHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(plainTextTwo));

            string hexOfValueOne = BitConverter.ToString(textOneHash);
            string hexOfValueTwo = BitConverter.ToString(textTwoHash);

            // Out put is grouped into pairs, each represents a byte value between 0-255
            Console.WriteLine($"String 1 Hash: {hexOfValueOne}");
            Console.WriteLine($"String 2 Hash: {hexOfValueTwo}");
        }

        private static void RunHMACRIPEMD160()
        {
            PrintTitle("MD5CryptoServiceProvider");

            HMACRIPEMD160 crypto = new HMACRIPEMD160();

            // Compute Hash
            byte[] textOneHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(plainTextOne));
            byte[] textTwoHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(plainTextTwo));

            string hexOfValueOne = BitConverter.ToString(textOneHash);
            string hexOfValueTwo = BitConverter.ToString(textTwoHash);

            // Out put is grouped into pairs, each represents a byte value between 0-255
            Console.WriteLine($"String 1 Hash: {hexOfValueOne}");
            Console.WriteLine($"String 2 Hash: {hexOfValueTwo}");
        }

        private static void RunMACTripleDES()
        {
            PrintTitle("MACTripleDES");

            MACTripleDES crypto = new MACTripleDES();

            // Compute Hash
            byte[] textOneHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(plainTextOne));
            byte[] textTwoHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(plainTextTwo));

            string hexOfValueOne = BitConverter.ToString(textOneHash);
            string hexOfValueTwo = BitConverter.ToString(textTwoHash);

            // Out put is grouped into pairs, each represents a byte value between 0-255
            Console.WriteLine($"String 1 Hash: {hexOfValueOne}");
            Console.WriteLine($"String 2 Hash: {hexOfValueTwo}");
        }


        /*
         * Other Hashing Algorithms
            SHA1Managed
            SHA256Managed
            SHA384Managed
            HMACSHA256
            HMACMD5
            HMACSHA512
        */
        #endregion

        #region Generic Algorithm
        private static void Hash(string plainText, HashAlgorithm hasher)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = hasher.ComputeHash(plainBytes);
            string digest = Convert.ToBase64String(encryptedBytes);
            Console.WriteLine($"{hasher.GetType().Name,-30}: {digest}");
        }
        #endregion

        #region Password

        private static void RunPasswordEncryption()
        {
            PrintTitle("Password Hashing");

            string salt = GenerateSalt(8);
            string password = "secret";
            string constant = "xl1k5ss5NTE=";
            string hashedPassword = ComputeHash(password, salt, constant);

            Console.WriteLine($"Salt: {salt}");
            Console.WriteLine($"Entropy: {constant}");
            Console.WriteLine($"Plain Password: {password}");
            Console.WriteLine($"Hashed Password: {hashedPassword}");
        }
        /// <summary>
        /// Creates a salt using a strong random number generator (RNGCryptoServiceProvider)
        /// </summary>
        /// <param name="byteCount"></param>
        /// <returns></returns>
        private static string GenerateSalt(int byteCount)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[byteCount];
            rng.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// Creates a hash using a salt value
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string ComputeHash(string password, string salt)
        {
            byte[] hashBytes = Encoding.UTF8.GetBytes(password + salt);
            SHA512Managed hashAlg = new SHA512Managed();
            byte[] hash = hashAlg.ComputeHash(hashBytes);
            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Creates a hash using a salt and an entrophy value
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="entropy"></param>
        /// <returns></returns>
        public static string ComputeHash(string password, string salt, string entropy)
        {
            byte[] hashBytes = Encoding.UTF8.GetBytes(password + salt + entropy);
            SHA512Managed hashAlg = new SHA512Managed();
            byte[] hash = hashAlg.ComputeHash(hashBytes);
            return Convert.ToBase64String(hash);
        }
        #endregion

        #region Misc

        private static void PrintTitle(string title)
        {
            Console.WriteLine();
            Console.WriteLine(divider);
            Console.WriteLine(title);
            Console.WriteLine(divider);
        }
        #endregion
    }
}
