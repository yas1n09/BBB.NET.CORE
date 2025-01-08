﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Helpers
{
    public class HashHelper
    {
        public static string Sha1Hash(string str, string salt = null)
        {
            if (!string.IsNullOrEmpty(salt)) str = str + salt;

            byte[] data = Encoding.UTF8.GetBytes(str);

            var sha1 = SHA1.Create();
            var result = sha1.ComputeHash(data);
            StringBuilder EnText = new StringBuilder();
            foreach (byte iByte in result)
            {
                EnText.AppendFormat("{0:x2}", iByte);
            }
            return EnText.ToString();
        }



    }
}
