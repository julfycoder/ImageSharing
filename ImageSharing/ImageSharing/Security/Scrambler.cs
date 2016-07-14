using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace ImageSharing.Security
{
    public static class Scrambler
    {
        public static string GetMD5Hash(string input)
        {
            MD5 md = new MD5CryptoServiceProvider();
            byte[] data = md.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++) sBuilder.Append(data[i]);
            return sBuilder.ToString();
        }
        public static string GeneratePassword()
        {
            int length = new Random().Next(14, 19);
            string password = "";
            Random randomGenerator = new Random();
            for (int i = 0; i < length; i++)
            {
                char symbol = (char)randomGenerator.Next(97, 122);
                password += symbol.ToString();
            }
            return password;
        }
    }
}