using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MX2.Manager.Sys
{
    public class SysConstant
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        public static string GenerateCode(int count)
        {
            string[] codes = {
                                 "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "j",
                                 "k", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y"
                             };

            Random random = new Random();
            StringBuilder code = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                code.Append(codes[random.Next(0, codes.Length)]);
            }

            return code.ToString();
        }
        /// <summary>
        /// 生产md5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMD5(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}