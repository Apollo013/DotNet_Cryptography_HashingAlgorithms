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

            RunSHA512();
            RunMD5CryptoServiceProvider();
            RunHMACRIPEMD160();
            RunMACTripleDES();

            Console.ReadKey();
        }

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

        private static void PrintTitle(string title)
        {
            Console.WriteLine();
            Console.WriteLine(divider);
            Console.WriteLine(title);
            Console.WriteLine(divider);
        }

        /*
         * Other Hashing Algorithms
            SHA1Managed
            SHA256Managed
            SHA384Managed
            HMACMD5
            HMACSHA256
            HMACMD5
            HMACSHA512
        */
    }
}
