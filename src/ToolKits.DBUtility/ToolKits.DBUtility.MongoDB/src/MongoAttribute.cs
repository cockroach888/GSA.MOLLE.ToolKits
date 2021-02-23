//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：MongoAttribute.cs
// 项目名称：数据库操作实用工具集
// 创建时间：2014-12-21 23:42:48
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;

namespace GSA.ToolKits.DBUtility
{
    /// <summary>
    /// Mongodb数据库的字段特性  主要是设置索引之用
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MongoAttribute : Attribute
    {
        /// <summary>
        /// 是否是索引
        /// </summary>
        public bool IsIndex { get; set; }
        /// <summary>
        /// 是否是唯一的
		/// <para>默认flase</para>
        /// </summary>
        public bool Unique { get; set; }
        /// <summary>
        /// 是否是升序
		/// <para>默认true</para>
        /// </summary>
        public bool Ascending { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_isIndex">是否为索引</param>
        public MongoAttribute(bool _isIndex)
        {
            this.IsIndex = _isIndex;
            this.Unique = false;
            this.Ascending = true;
        }
    }
}
