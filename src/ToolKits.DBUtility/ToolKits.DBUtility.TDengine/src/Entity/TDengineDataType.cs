//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineDataType.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-06-22 22:15:06
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// 数据类型枚举类
/// </summary>
public enum TDengineDataType
{
    /// <summary>
    /// 布尔型
    /// </summary>
    BOOL = 1,

    /// <summary>
    /// 单字节整型
    /// </summary>
    TINYINT = 2,

    /// <summary>
    /// 短整型
    /// </summary>
    SMALLINT = 3,

    /// <summary>
    /// 整型
    /// </summary>
    INT = 4,

    /// <summary>
    /// 长整型
    /// </summary>
    BIGINT = 5,

    /// <summary>
    /// 浮点型
    /// </summary>
    FLOAT = 6,

    /// <summary>
    /// 双精度浮点型
    /// </summary>
    DOUBLE = 7,

    /// <summary>
    /// 记录单字节字符串
    /// </summary>
    /// <remarks>只用于处理 ASCII 可见字符</remarks>
    BINARY = 8,

    /// <summary>
    /// 时间戳
    /// </summary>
    TIMESTAMP = 9,

    /// <summary>
    /// 记录包含多字节字符在内的字符串
    /// </summary>
    /// <remarks>如中文字符</remarks>
    NCHAR = 10,

    /// <summary>
    /// 未知
    /// </summary>
    NONE
}