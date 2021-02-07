//==================================================================== 
//*****                     晨曦小竹常用工具集                   *****
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释   **
//====================================================================
// 文件名称：StringJoiner.cs
// 项目名称：常用方法实用工具集
// 创建时间：2014-03-21 16:57:57
// 创建人员：宋杰军
// 负 责 人：宋杰军
// 参与人员：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Text;

namespace DawnXZ.DawnUtility
{
    /// <summary>
    /// 字符串拼装操作辅助类
    /// </summary>
    public class StringJoiner
    {
        /// <summary>
        /// 字符串操作类
        /// </summary>
        protected StringBuilder FBuilder;
        /// <summary>
        /// 字符串拼装操作辅助类
        /// </summary>
        public StringJoiner()
        {
            FBuilder = new StringBuilder();
        }
        /// <summary>
        /// 字符串拼装操作
        /// </summary>
        /// <param name="value">需要拼装的值</param>
        /// <returns>拼装后的值</returns>
        public static implicit operator StringJoiner(string value)
        {
            StringJoiner sj = new StringJoiner();
            sj.FBuilder.Append(value);
            return sj;
        }
        /// <summary>
        /// 字符串拼装操作
        /// <para>重载加号运算符</para>
        /// </summary>
        /// <param name="self">拼装操作本身</param>
        /// <param name="value">需要拼装的值</param>
        /// <returns>拼装后的值</returns>
        public static StringJoiner operator +(StringJoiner self, string value)
        {
            self.FBuilder.Append(value);
            return self;
        }
        /// <summary>
        /// 字符串拼装操作
        /// <para>重载加号运算符</para>
        /// </summary>
        /// <param name="self">拼装操作本身</param>
        /// <param name="value">需要拼装的对象</param>
        /// <returns>拼装后的值</returns>
        public static StringJoiner operator +(StringJoiner self, object value)
        {
            self.FBuilder.Append(value);
            return self;
        }
        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="value">需要转换的拼装对象</param>
        /// <returns>转换后的字符串</returns>
        public static implicit operator string(StringJoiner value)
        {
            return value.ToString();
        }
        /// <summary>
        /// 重载字符串转换
        /// </summary>
        /// <returns>转换后的字符串</returns>
        public override string ToString()
        {
            return this.FBuilder.ToString();
        }
    }
}
