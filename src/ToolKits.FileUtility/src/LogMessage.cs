//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：LogMessage.cs
// 项目名称：文件操作实用工具集
// 创建时间：2014年2月20日15时38分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Globalization;

namespace GSA.ToolKits.FileUtility
{
    /// <summary> 
    /// 日志消息类
    /// </summary> 
    public class LogMessage
    {

        #region 构造函数

        /// <summary> 
        /// 创建日志消息实例
        /// </summary> 
        public LogMessage()
            : this("", MessageType.Unknown)
        { }
        /// <summary> 
        /// 创建日志消息的消息内容和消息类型
        /// </summary> 
        /// <param name="text">消息内容</param> 
        /// <param name="messageType">消息类型</param> 
        public LogMessage(string text, MessageType messageType)
            : this(DateTime.Now, text, messageType)
        { }
        /// <summary> 
        /// 创建日期时间和消息内容和消息类型的日志消息
        /// </summary> 
        /// <param name="dateTime">消息的日期时间</param> 
        /// <param name="text">消息内容</param> 
        /// <param name="messageType">消息类型</param> 
        public LogMessage(DateTime dateTime, string text, MessageType messageType)
        {
            MsgDatetime = dateTime;
            MsgText = text;
            MsgType = messageType;
        }

        #endregion

        #region 成员属性

        /// <summary> 
        /// 获取或设置消息的日期时间
        /// </summary> 
        public DateTime MsgDatetime { get; set; }
        /// <summary> 
        /// 获取或设置消息内容
        /// </summary> 
        public string MsgText { get; set; }
        /// <summary> 
        /// 获取或设置消息类型
        /// </summary> 
        public MessageType MsgType { get; set; }

        #endregion

        #region 成员方法

        /// <summary> 
        /// 得到消息的字符串
        /// </summary> 
        /// <returns>消息字符串</returns> 
        public new string ToString()
        {
            return string.Format("{0}\t{1}\n", MsgDatetime.ToString(CultureInfo.InvariantCulture), MsgText);
        }

        #endregion

    }
}
