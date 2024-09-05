//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：IDataHelperAbstractions.cs
// 项目名称：WebAPI接口辅助与应用工具集
// 创建时间：2024-09-05 11:02:55
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.WebAPIsUtility;

/// <summary>
/// 数据访问助手基础接口
/// </summary>
/// <typeparam name="TDataModel">数据模型泛型</typeparam>
public interface IDataHelperAbstractions<TDataModel> where TDataModel : class
{
    /// <summary>
    /// 添加数据
    /// </summary>
    /// <param name="info">需要添加的数据</param>
    /// <returns>表示受影响的数据行数量</returns>
    Task<int> InsertAsync(TDataModel info);

    /// <summary>
    /// 更新数据
    /// </summary>
    /// <param name="info">需要更新的数据</param>
    /// <returns>表示受影响的数据行数量</returns>
    Task<int> UpdateAsync(TDataModel? info);

    /// <summary>
    /// 删除数据
    /// </summary>
    /// <param name="info">需要删除的数据</param>
    /// <returns>表示受影响的数据行数量</returns>
    Task<int> DeleteAsync(TDataModel info);

    /// <summary>
    /// 清除所有数据
    /// </summary>
    /// <returns>表示受影响的数据行数量</returns>
    Task<int> ClearAsync();
}