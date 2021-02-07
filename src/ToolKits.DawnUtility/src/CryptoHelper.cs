//==================================================================== 
//*****                    晨曦小竹常用工具集                    *****
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释   **
//====================================================================
// 文件名称：CryptoHelper.cs
// 项目名称：常用方法实用工具集
// 创建时间：2014年2月25日11时52分
// 创建人员：宋杰军
// 负 责 人：宋杰军
// 参与人员：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DawnXZ.DawnUtility
{
    /// <summary>
    /// 加解密操作辅助类
    /// </summary>
    public static class CryptoHelper
    {

        #region ========加密========

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text">待加密字符串</param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, "*DawnXZ..com*");
        }
        /// <summary>
        /// 加密
        /// <remarks>
        /// 101-109
        /// </remarks>
        /// </summary>
        /// <param name="Text">待加密字符串1</param>
        /// <param name="intFlag">待加密字符串2</param>
        /// <returns></returns>
        public static string Encrypt(string Text, byte intFlag)
        {
            string tempEncrypt = string.Empty;
            switch (intFlag)
            {
                case 101:
                    tempEncrypt = Encrypt(Text, "iv9oegcmJ6KT1Wdj2o6");
                    break;
                case 102:
                    tempEncrypt = Encrypt(Text, "zYN80NuP2KtCFHRhN12");
                    break;
                case 103:
                    tempEncrypt = Encrypt(Text, "lSpSNBlfr0XZh6t5K0z");
                    break;
                case 104:
                    tempEncrypt = Encrypt(Text, "hJY3C3NcXvnuD93lame");
                    break;
                case 105:
                    tempEncrypt = Encrypt(Text, "wiwHgeFjU09JyzZUSkq");
                    break;
                case 106:
                    tempEncrypt = Encrypt(Text, "YQnApRjbf4grm9QROY5");
                    break;
                case 107:
                    tempEncrypt = Encrypt(Text, "B6oIdoh0fi7SwKWQGHE");
                    break;
                case 108:
                    tempEncrypt = Encrypt(Text, "FT8IyYTrjpx95hWiaxY");
                    break;
                case 109:
                    tempEncrypt = Encrypt(Text, "ujP341Ae27dsOXNh9wB");
                    break;
                default:
                    tempEncrypt = Encrypt(Text, "*DawnXZ..com*");
                    break;
            }
            return tempEncrypt;
        }
        /// <summary>
        /// 加密 URL 专用
        /// </summary>
        /// <param name="Text">待加密字符串</param>
        /// <returns></returns>
        public static string EncryptUrl(string Text)
        {
            return Encrypt(Text, "*url*");
        }
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text">待加密字符串</param> 
        /// <param name="sKey">加密密钥</param> 
        /// <returns></returns> 
        public static string Encrypt(string Text, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray;
                inputByteArray = Encoding.Default.GetBytes(Text);
                des.Key = ASCIIEncoding.ASCII.GetBytes(MD5(sKey, true).Substring(0, 8));
                des.IV = ASCIIEncoding.ASCII.GetBytes(MD5(sKey, true).Substring(0, 8));
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                return ret.ToString();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region ========解密========

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text">待解密字符串</param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, "*DawnXZ..com*");
        }
        /// <summary>
        /// 解密
        /// <remarks>
        /// 101-109
        /// </remarks>
        /// </summary>
        /// <param name="Text">待解密字符串1</param>
        /// <param name="intFlag">待解密字符串2</param>
        /// <returns></returns>
        public static string Decrypt(string Text, byte intFlag)
        {
            string tempDecrypt = string.Empty;
            switch (intFlag)
            {
                case 101:
                    tempDecrypt = Decrypt(Text, "iv9oegcmJ6KT1Wdj2o6");
                    break;
                case 102:
                    tempDecrypt = Decrypt(Text, "zYN80NuP2KtCFHRhN12");
                    break;
                case 103:
                    tempDecrypt = Decrypt(Text, "lSpSNBlfr0XZh6t5K0z");
                    break;
                case 104:
                    tempDecrypt = Decrypt(Text, "hJY3C3NcXvnuD93lame");
                    break;
                case 105:
                    tempDecrypt = Decrypt(Text, "wiwHgeFjU09JyzZUSkq");
                    break;
                case 106:
                    tempDecrypt = Decrypt(Text, "YQnApRjbf4grm9QROY5");
                    break;
                case 107:
                    tempDecrypt = Decrypt(Text, "B6oIdoh0fi7SwKWQGHE");
                    break;
                case 108:
                    tempDecrypt = Decrypt(Text, "FT8IyYTrjpx95hWiaxY");
                    break;
                case 109:
                    tempDecrypt = Decrypt(Text, "ujP341Ae27dsOXNh9wB");
                    break;
                default:
                    tempDecrypt = Decrypt(Text, "*DawnXZ..com*");
                    break;
            }
            return tempDecrypt;
        }
        /// <summary>
        /// 解密 URL 专用
        /// </summary>
        /// <param name="Text">待解密字符串</param>
        /// <returns></returns>
        public static string DecryptUrl(string Text)
        {
            return Decrypt(Text, "*url*");
        }
        /// <summary>
        /// 解密字符串并将多余显示为 * 号
        /// </summary>
        /// <param name="show">显示位数</param>
        /// <param name="Text">待解密字符串</param>
        /// <returns></returns>
        public static string Decrypt(int show, string Text)
        {
            string strReplace = null;
            string strTemp = Decrypt(Text, "*DawnXZ..com*");
            if (string.IsNullOrEmpty(strTemp)) return null;
            for (int intCount = 0; intCount < strTemp.Length - show; intCount++)
            {
                strReplace += "*";
            }
            if (show < strTemp.Length)
            {
                strTemp = strTemp.Replace(strTemp.Substring(show, strTemp.Length - show), strReplace);
            }
            return strTemp;
        }
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text">待解密字符串</param> 
        /// <param name="sKey">解密密钥</param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                int len;
                len = Text.Length / 2;
                byte[] inputByteArray = new byte[len];
                int x, i;
                for (x = 0; x < len; x++)
                {
                    i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(MD5(sKey, true).Substring(0, 8));
                des.IV = ASCIIEncoding.ASCII.GetBytes(MD5(sKey, true).Substring(0, 8));
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.Default.GetString(ms.ToArray());
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region ========加解密文件========

        /// <summary>
        /// 加密文件
        /// </summary>
        /// <param name="inName">输入文件名</param>
        /// <param name="outName">输出文件名</param>
        /// <param name="desKey">加密Key</param>
        /// <param name="desIV">加密IV</param>
        public static void FileEncryptData(String inName, String outName, byte[] desKey, byte[] desIV)
        {
            //Create the file streams to handle the input and output files.
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            //Create variables to help with read and write.
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
            long rdlen = 0;              //This is the total number of bytes written.
            long totlen = fin.Length;    //This is the total length of the input file.
            int len;                     //This is the number of bytes to be written at a time.
            DES des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);
            //Read from the input file, then encrypt and write to the output file.
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            encStream.Close();
            fout.Close();
            fin.Close();
        }
        /// <summary>
        /// 解密文件
        /// </summary>
        /// <param name="inName">输入文件名</param>
        /// <param name="outName">输出文件名</param>
        /// <param name="desKey">加密Key</param>
        /// <param name="desIV">加密IV</param>
        public static void FileDecryptData(String inName, String outName, byte[] desKey, byte[] desIV)
        {
            //Create the file streams to handle the input and output files.
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            //Create variables to help with read and write.
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
            long rdlen = 0;              //This is the total number of bytes written.
            long totlen = fin.Length;    //This is the total length of the input file.
            int len;                     //This is the number of bytes to be written at a time.
            DES des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateDecryptor(desKey, desIV), CryptoStreamMode.Write);
            //Read from the input file, then encrypt and write to the output file.
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            encStream.Close();
            fout.Close();
            fin.Close();
        }

        #endregion

        #region MD5 & SHA256

        /// <summary>
        /// MD5函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="isUpper">是否大写形式</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str, bool isUpper)
        {
            byte[] b = Encoding.UTF8.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
            {
                ret += b[i].ToString("x").PadLeft(2, '0');
            }
            if (isUpper) ret = ret.ToUpper();
            return ret;
        }
        /// <summary>
        /// SHA256函数
        /// </summary>
        /// /// <param name="str">原始字符串</param>
        /// <returns>SHA256结果</returns>
        public static string SHA256(string str)
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return Convert.ToBase64String(Result);  //返回长度为44字节的字符串
        }

        #endregion

        #region 哈希加密

        /// <summary>
        /// 得到随机哈希加密字符串
        /// </summary>
        /// <returns></returns>
        public static string GetHashSecurity()
        {
            return GetHashEncoding(GetHashRandomValue());
        }
        /// <summary>
        /// 得到一个随机数值
        /// </summary>
        /// <returns></returns>
        public static string GetHashRandomValue()
        {
            Random Seed = new Random();
            string RandomVaule = Seed.Next(1, int.MaxValue).ToString();
            return RandomVaule;
        }
        /// <summary>
        /// 哈希加密一个字符串
        /// SHA512函数
        /// </summary>
        /// <param name="Security"></param>
        /// <returns></returns>
        public static string GetHashEncoding(string Security)
        {
            byte[] Value;
            UnicodeEncoding Code = new UnicodeEncoding();
            byte[] Message = Code.GetBytes(Security);
            SHA512Managed Arithmetic = new SHA512Managed();
            Value = Arithmetic.ComputeHash(Message);
            Security = "";
            foreach (byte o in Value)
            {
                Security += (int)o + "O";
            }
            return Security;
        }

        #endregion

    }
}
