﻿//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：RSAHelper.cs
// 项目名称：常用方法实用工具集
// 创建时间：2014-03-19 17:34:05
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GSA.ToolKits.DawnUtility
{
    /// <summary>
    /// 非对称RSA加密类 可以参考
    /// <para>http://www.cnblogs.com/hhh/archive/2011/06/03/2070692.html</para>
    /// <para>http://blog.csdn.net/zhilunchen/article/details/2943158</para>
    /// <para>若是私匙加密 则需公钥解密</para>
    /// <para>反之公钥加密 私匙来解密</para>
    /// <para>需要BigInteger类来辅助</para>
    /// <para>使用方法：</para>
    /// <para>RSAHelper.RSAKey keyPair = RSAHelper.GetRASKey();</para>
    /// <para>公钥：keyPair.PublicKey、私钥：keyPair.PrivateKey</para>
    /// <para>加密：string en = RSAHelper.EncryptString(str, keyPair.PrivateKey);</para>
    /// <para>解密：string en = RSAHelper.DecryptString(en, keyPair.PublicKey);</para>
    /// </summary>
    public static class RSAHelper
    {
        /// <summary>
        /// RSA的容器 可以解密的源字符串长度为 DWKEYSIZE/8-11 
        /// </summary>
        public const int DWKEYSIZE = 1024;

        /// <summary>
        /// RSA加密的密匙结构  公钥和私匙
        /// </summary>
        public struct RSAKey
        {
            /// <summary>
            /// 公钥
            /// </summary>
            public string PublicKey { get; set; }
            /// <summary>
            /// 私钥
            /// </summary>
            public string PrivateKey { get; set; }
        }

        #region 得到RSA的解密的密匙对
        /// <summary>
        /// 得到RSA的解密的密匙对
        /// </summary>
        /// <returns></returns>
        public static RSAKey GetRASKey()
        {
            RSACryptoServiceProvider.UseMachineKeyStore = true;
            //声明一个指定大小的RSA容器
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(DWKEYSIZE);
            //取得RSA容易里的各种参数
            RSAParameters p = rsaProvider.ExportParameters(true);

            return new RSAKey()
            {
                PublicKey = ComponentKey(p.Exponent, p.Modulus),
                PrivateKey = ComponentKey(p.D, p.Modulus)
            };
        }
        #endregion

        #region 检查明文的有效性 DWKEYSIZE/8-11 长度之内为有效 中英文都算一个字符
        /// <summary>
        /// 检查明文的有效性 DWKEYSIZE/8-11 长度之内为有效 中英文都算一个字符
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool CheckSourceValidate(string source)
        {
            return (DWKEYSIZE / 8 - 11) >= source.Length;
        }
        #endregion

        #region 组合解析密匙
        /// <summary>
        /// 组合成密匙字符串
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        private static string ComponentKey(byte[] b1, byte[] b2)
        {
            List<byte> list = new List<byte>();
            //在前端加上第一个数组的长度值 这样今后可以根据这个值分别取出来两个数组
            list.Add((byte)b1.Length);
            list.AddRange(b1);
            list.AddRange(b2);
            byte[] b = list.ToArray();
            return Convert.ToBase64String(b);
        }

        /// <summary>
        /// 解析密匙
        /// </summary>
        /// <param name="key">密匙</param>
        /// <param name="b1">RSA的相应参数1</param>
        /// <param name="b2">RSA的相应参数2</param>
        private static void ResolveKey(string key, out byte[] b1, out byte[] b2)
        {
            //从base64字符串 解析成原来的字节数组
            byte[] b = Convert.FromBase64String(key);
            //初始化参数的数组长度
            b1 = new byte[b[0]];
            b2 = new byte[b.Length - b[0] - 1];
            //将相应位置是值放进相应的数组
            for (int n = 1, i = 0, j = 0; n < b.Length; n++)
            {
                if (n <= b[0])
                {
                    b1[i++] = b[n];
                }
                else
                {
                    b2[j++] = b[n];
                }
            }
        }
        #endregion

        #region 字符串加密解密 公开方法
        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="source">源字符串 明文</param>
        /// <param name="key">密匙</param>
        /// <returns>加密遇到错误将会返回原字符串</returns>
        public static string EncryptString(string source, string key)
        {
            string encryptString = string.Empty;
            byte[] d;
            byte[] n;
            try
            {
                if (!CheckSourceValidate(source))
                {
                    throw new Exception("source string too long");
                }
                //解析这个密钥
                ResolveKey(key, out d, out n);
                BigInteger biN = new BigInteger(n);
                BigInteger biD = new BigInteger(d);
                encryptString = EncryptString(source, biD, biN);
            }
            catch
            {
                encryptString = source;
            }
            return encryptString;
        }

        /// <summary>
        /// 字符串解密
        /// </summary>
        /// <param name="encryptString">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>遇到解密失败将会返回原字符串</returns>
        public static string DecryptString(string encryptString, string key)
        {
            string source = string.Empty;
            byte[] e;
            byte[] n;
            try
            {
                //解析这个密钥
                ResolveKey(key, out e, out n);
                BigInteger biE = new BigInteger(e);
                BigInteger biN = new BigInteger(n);
                source = DecryptString(encryptString, biE, biN);
            }
            catch
            {
                source = encryptString;
            }
            return source;
        }
        #endregion

        #region 字符串加密解密 私有  实现加解密的实现方法
        /// <summary>
        /// 用指定的密匙加密 
        /// </summary>
        /// <param name="source">明文</param>
        /// <param name="d">可以是RSACryptoServiceProvider生成的D</param>
        /// <param name="n">可以是RSACryptoServiceProvider生成的Modulus</param>
        /// <returns>返回密文</returns>
        private static string EncryptString(string source, BigInteger d, BigInteger n)
        {
            int len = source.Length;
            int len1 = 0;
            int blockLen = 0;
            if ((len % 128) == 0)
                len1 = len / 128;
            else
                len1 = len / 128 + 1;
            string block = "";
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < len1; i++)
            {
                if (len >= 128)
                    blockLen = 128;
                else
                    blockLen = len;
                block = source.Substring(i * 128, blockLen);
                byte[] oText = System.Text.Encoding.Default.GetBytes(block);
                BigInteger biText = new BigInteger(oText);
                BigInteger biEnText = biText.modPow(d, n);
                string temp = biEnText.ToHexString();
                result.Append(temp).Append("@");
                len -= blockLen;
            }
            return result.ToString().TrimEnd('@');
        }

        /// <summary>
        /// 用指定的密匙加密 
        /// </summary>
        /// <param name="encryptString">密文</param>
        /// <param name="e">可以是RSACryptoServiceProvider生成的Exponent</param>
        /// <param name="n">可以是RSACryptoServiceProvider生成的Modulus</param>
        /// <returns>返回明文</returns>
        private static string DecryptString(string encryptString, BigInteger e, BigInteger n)
        {
            StringBuilder result = new StringBuilder();
            string[] strarr1 = encryptString.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strarr1.Length; i++)
            {
                string block = strarr1[i];
                BigInteger biText = new BigInteger(block, 16);
                BigInteger biEnText = biText.modPow(e, n);
                string temp = System.Text.Encoding.Default.GetString(biEnText.getBytes());
                result.Append(temp);
            }
            return result.ToString();
        }

        #endregion

    }
}
