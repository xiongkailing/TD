using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace TeamDay.Helpers
{
    public class CommonHelper
    {
        private static SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();

        private static Random rnd = new Random();
        /// <summary>
        /// 生成唯一字符串
        /// </summary>
        /// <returns></returns>
        public static string GenerateUniqueStr()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:X}", i - DateTime.Now.Ticks);
        }

        /// <summary>
        /// 数字验证码生成
        /// </summary>
        /// <param name="len">长度</param>
        /// <returns>数字验证码</returns>
        public static string NumCode(int len)
        {
            string res = string.Empty;
            for (int i = 0; i < len; i++)
            {
                res += rnd.Next(1, 10).ToString();
            }
            return res;
        }

        /// <summary>
        /// 可逆加密
        /// </summary>
        /// <param name="raw">原始字符串</param>
        /// <returns>加密字符串</returns>
        public static string ReverseEncrypt(string raw, string privateKey, string sIV)
        {
            if (mCSP == null)
                mCSP = new TripleDESCryptoServiceProvider();
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            mCSP.Key = Convert.FromBase64String(privateKey);
            mCSP.IV = Convert.FromBase64String(sIV);
            mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
            mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);
            byt = Encoding.UTF8.GetBytes(raw);
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());

        }

        /// <summary>
        /// 可逆解密
        /// </summary>
        /// <param name="ciphertext">密文</param>
        /// <returns>解密字符串</returns>
        public static string ReverseDecrypt(string ciphertext, string privateKey, string sIV)
        {
            if (mCSP == null)
                mCSP = new TripleDESCryptoServiceProvider();
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            mCSP.Key = Convert.FromBase64String(privateKey);
            mCSP.IV = Convert.FromBase64String(sIV);
            mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
            mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
            byt = Convert.FromBase64String(ciphertext);
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="raw">原始字符串</param>
        /// <returns>密文</returns>
        public static string MD5Encrypt(string raw)
        {
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(raw);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
