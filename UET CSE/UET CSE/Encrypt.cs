using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace UET_CSE
{
    public class Encrypt
    {
        public static string GetHash(string input)
        {
            using (MD5CryptoServiceProvider db = new MD5CryptoServiceProvider())
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes(input);
                b = db.ComputeHash(b);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (byte x in b)
                {
                    sb.Append(x.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}