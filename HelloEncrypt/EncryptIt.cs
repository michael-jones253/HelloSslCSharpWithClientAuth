using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HelloEncrypt
{
    class EncryptIt
    {
        public static byte[] Encrypt(String pwd, byte[] input)
        {
            Rfc2898DeriveBytes pdb = GetPDBytes(pwd);
            MemoryStream ms = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = pdb.GetBytes(aes.KeySize / 8);
            aes.IV = pdb.GetBytes(aes.BlockSize / 8);
            CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.Close();
            return ms.ToArray();
        }

        private static Rfc2898DeriveBytes GetPDBytes(string pwd)
        {
            // Never hard-code a password within your source code. Hard coded passwords can be retrieved from an assembly using the Ildasm.exe (IL Disassembler) tool, a hex editor, or by simply opening up the assembly in a text editor like notepad.exe.
            Rfc2898DeriveBytes pdb =
              new Rfc2898DeriveBytes(pwd, new byte[] { 0x0d, 0x43, 0x0e, 0x87, 0x0a, 0x23, 0x0b, 0x71 });
            return pdb;
        }

        public static byte[] Decrypt(string pwd, byte[] input)
        {
            Rfc2898DeriveBytes pdb = GetPDBytes(pwd);
            MemoryStream ms = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = pdb.GetBytes(aes.KeySize / 8);
            aes.IV = pdb.GetBytes(aes.BlockSize / 8);
            CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.Close();
            return ms.ToArray();
        }
    }
}
