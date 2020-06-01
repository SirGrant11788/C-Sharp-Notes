using System;
using System.IO;
using System.Security.Cryptography;
namespace Adv_One
{
    //xml documentation
    ///<summary>
    /// Class Program does stuff with x and y to do z
    /// </summary>
    class Program
    {
        
        static void Main(string[] args)
        {
            //debug writeline. shown in Output tab
            int a = 5, b = 10;
            System.Diagnostics.Debug.WriteLine("Hello from the debug line");
            System.Diagnostics.Debug.WriteLine("a = "+a);
            System.Diagnostics.Debug.WriteLine("b = "+b);
            System.Diagnostics.Debug.WriteLineIf(b==10,"if. b = " + b);
            System.Diagnostics.Debug.WriteLineIf(b == 11, "if. b = " + b);

            //files - write
            string file = @"F:\Google Drive\Visual Studio Projects\CSharpLearn\Adv_One\files\Names.txt";
            Directory.CreateDirectory(@"F:\Google Drive\Visual Studio Projects\CSharpLearn\Adv_One\mail");//creates a directory
            string fileMail = @"F:\Google Drive\Visual Studio Projects\CSharpLearn\Adv_One\mail\Email.txt";
            StreamWriter sw = new StreamWriter(file,true);//true amends the file
            sw.WriteLine("Howzit Home!");
            sw.WriteLine("Howzit Grant!");
            sw.WriteLine("Howzit from VS Studio!");
            sw.Close();
            //files - read
            string fileRead = @"F:\Google Drive\Visual Studio Projects\CSharpLearn\Adv_One\files\Names.txt";
            StreamReader sr = new StreamReader(fileRead);
            Console.WriteLine(sr.ReadToEnd());
            Console.WriteLine("File Ended!");
            sr.Close();
            //cryptography
            //Symmetrical Encryption uses the same key
            //Asymmetrical uses differnt keys, public and private keys
            //Caesar Cipher - each letter is shifted places down the aplhabet
            // DES, Triple DES, RSA, BlowFish, Salting, Hashing
            DESCryptoServiceProvider key =new  DESCryptoServiceProvider();
            Console.WriteLine("Enter you message: ");
            string plainText = Console.ReadLine();
            string cypherText = Encrypt(plainText,key);
            Console.WriteLine("\nCipher Text: "+Encrypt(plainText,key));
            Console.WriteLine("\nPlain Text: " + Decrypt(cypherText, key));
            //Digit Seperator
            var distanceToSunFromEarth = 149_600_000;
            Console.WriteLine(distanceToSunFromEarth);

            //default keyword - need 7.1 or latest c# build
            long longvar = default;
            string stringVar = default;
            DateTime dateVaar = default;
            int intVar = default;

            //Console Colours
            string greenMsg = "This is a green message";
            string redMsg = "This is a red message";
            string blueMsg = "This is a blue message";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(greenMsg);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(redMsg);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(blueMsg);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
        }

        #region Cryptography
        //Encrypt
        public static string Encrypt(string plainText, SymmetricAlgorithm key)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, key.CreateEncryptor(),CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(plainText);
            sw.Flush();//clear buffer
            cs.FlushFinalBlock();
            return (Convert.ToBase64String(ms.GetBuffer(),0,(int)ms.Length));
        }
        
        //Decrypt
        public static string Decrypt(string cipherText, SymmetricAlgorithm key)
        {
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText));
            CryptoStream cs = new CryptoStream(ms, key.CreateDecryptor(), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
        #endregion
    }
}
