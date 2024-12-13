//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：IMinIOHelperFactory.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2024-12-11 10:34:11
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.MinIOUtility;

/// <summary>
/// MinIO 对象存储访问助手工厂接口
/// </summary>
public interface IMinIOHelperFactory : IDisposable
{
    /// <summary>
    /// 创建一个新的MinIO对象存储访问助手
    /// </summary>
    /// <remarks>使用工厂创建时的选项参数</remarks>
    /// <param name="oldHelper">旧的MinIO对象存储访问助手</param>
    /// <returns>MinIO对象存储访问助手</returns>
    IMinIOHelper New(IMinIOHelper? oldHelper = null);

    /// <summary>
    /// 创建一个新的MinIO对象存储访问助手
    /// </summary>
    /// <remarks>使用传入的选项参数</remarks>
    /// <param name="option">选项参数</param>
    /// <param name="oldHelper">旧的MinIO对象存储访问助手</param>
    /// <returns>MinIO对象存储访问助手</returns>
    IMinIOHelper New(MinIOOptions option, IMinIOHelper? oldHelper = null);
}