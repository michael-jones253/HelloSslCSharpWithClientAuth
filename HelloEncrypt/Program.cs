using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEncrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringToEncrypt = "hello world!";

            byte[] stuffToEncrypt = System.Text.Encoding.UTF8.GetBytes(stringToEncrypt);

            Console.Write("Enter password: ");
            var pwd = Console.ReadLine();
            var encryptedStuff = EncryptIt.Encrypt(pwd, stuffToEncrypt);

            var junk = System.Text.Encoding.UTF8.GetString(encryptedStuff);

            Console.WriteLine("Encrypted Junk: {0}", junk);

            var decryptedStuff = EncryptIt.Decrypt(pwd, encryptedStuff);

            var goodStuff = Encoding.UTF8.GetString(decryptedStuff);

            Console.WriteLine("Good stuff: {0}", goodStuff);
            var keyboardIn = Console.ReadKey();
        }
    }
}
