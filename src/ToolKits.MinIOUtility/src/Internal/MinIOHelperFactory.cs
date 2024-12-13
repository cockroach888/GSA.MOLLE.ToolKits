//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MinIOHelperFactory.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2024-12-11 10:34:45
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Collections.Concurrent;

namespace GSA.ToolKits.MinIOUtility.Internal;

/// <summary>
/// MinIO 对象存储访问助手工厂
/// </summary>
/// <param name="options">选项参数</param>
internal sealed class MinIOHelperFactory(MinIOOptions options) : IMinIOHelperFactory
{
    private readonly ConcurrentDictionary<int, MinIOHelper> _helpers = new();


    /// <summary>
    /// 创建一个新的MinIO对象存储访问助手
    /// </summary>
    /// <remarks>使用工厂创建时的选项参数</remarks>
    /// <param name="oldHelper">旧的MinIO对象存储访问助手</param>
    /// <returns>MinIO对象存储访问助手</returns>
    public IMinIOHelper New(IMinIOHelper? oldHelper = null)
    {
        TryRemove(oldHelper);

        MinIOHelper helper = new(options);
        _helpers[helper.Id] = helper;

        return helper;
    }

    /// <summary>
    /// 创建一个新的MinIO对象存储访问助手
    /// </summary>
    /// <remarks>使用传入的选项参数</remarks>
    /// <param name="option">选项参数</param>
    /// <param name="oldHelper">旧的MinIO对象存储访问助手</param>
    /// <returns>MinIO对象存储访问助手</returns>
    public IMinIOHelper New(MinIOOptions option, IMinIOHelper? oldHelper = null)
    {
        TryRemove(oldHelper);

        MinIOHelper helper = new(option);
        _helpers[helper.Id] = helper;

        return helper;
    }


    /// <summary>
    /// 尝试移除所匹配的MinIO对象存储访问助手实例
    /// </summary>
    /// <param name="outerHelper">MinIO对象存储访问助手</param>
    private void TryRemove(IMinIOHelper? outerHelper)
    {
        if (outerHelper is MinIOHelper innerHelper)
        {
            if (_helpers.TryRemove(innerHelper.Id, out _))
            {
                using (innerHelper) { }
            }
        }
    }

    /// <summary>
    /// 资源释放
    /// </summary>
    public void Dispose()
    {
        foreach (MinIOHelper helper in _helpers.Values)
        {
            using (helper) { }
        }

        _helpers.Clear();
        GC.SuppressFinalize(this);
    }
}