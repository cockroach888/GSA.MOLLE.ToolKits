//=========================================================================
//**   魂哥常用工具集（CRS.CommonUtility）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2021 -- Support 文雀
//=========================================================================
// 文件名称：CasePartTemplateInfo.cs
// 项目名称：魂哥常用工具集
// 创建时间：2021-02-27 00:19:15
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;

namespace GSA.ToolKits.DawnApp.Entities
{
    /// <summary>
	/// 案件部分的模板
	/// </summary>
	[Serializable]
    public sealed class CasePartTemplateInfo
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        //public ObjectId _id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 末次更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }
        /// <summary>
        /// 部分的编号
        /// </summary>
        public string PartId { get; set; }
        /// <summary>
        /// 父级编号
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// AJLX编号
        /// </summary>
        public int AJLX { get; set; }
        /// <summary>
        /// 部分的XML数据
        /// </summary>
        public string PartXML { get; set; }
        /// <summary>
        /// 部分的名称
        /// </summary>
        public string PartName { get; set; }
    }
}
