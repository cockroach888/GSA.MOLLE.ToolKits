//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ITDengineDBManage.cs
// 项目名称：TDengine 数据库管理
// 创建时间：2022-07-25 13:52:59
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.DBUtility.TDengine.Managed;

/// <summary>
/// TDengine 数据库管理接口
/// </summary>
public interface ITDengineDBManage
{
    /// <summary>
    /// 创建数据库
    /// </summary>
    /// <param name="option">选项参数</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    Task CreateAsync(DatabaseCreateOption option);

    /// <summary>
    /// 删除数据库
    /// </summary>
    /// <param name="dbName">数据库名称</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    Task DropAsync(string dbName);
}