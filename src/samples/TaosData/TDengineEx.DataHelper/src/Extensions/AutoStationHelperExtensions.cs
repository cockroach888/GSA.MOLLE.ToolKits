//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：AutoStationHelperExtensions.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-09-16 15:27:29
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace TDengineEx.DataHelper;

/// <summary>
/// 气象自动站信息数据访问助手扩展类
/// </summary>
public static class AutoStationHelperExtensions
{
    /// <summary>
    /// 添加气象自动站信息
    /// </summary>
    /// <param name="helper">数据访问助手</param>
    /// <param name="info">气象自动站信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>成功：无任何返回，失败：返回相关信息。</returns>
    public static async Task<string?> InsertAsync(
        this IAutoStationHelper helper,
        AutoStationModel info,
        CancellationToken cancellationToken = default)
    {
        AutoStationHelper innerHelper = (AutoStationHelper)helper;
        var (NameString, ValueString) = TDataModelHelper.GetColumnValueString<AutoStationModel, BuildInsertSqlStringIgnoreAttribute>(info);
        string sqlString = $"insert into {innerHelper.DBName}.{innerHelper.TablePrefix} ({NameString}) values ({ValueString})";
        return await innerHelper.Connector.ExecuteNonQueryAsync(sqlString, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// 获取气象自动站信息
    /// </summary>
    /// <param name="helper">数据访问助手</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>气象自动站信息</returns>
    public static async ValueTask<AutoStationModel?> SelectAsync(
        this IAutoStationHelper helper,
        string stationId,
        CancellationToken cancellationToken = default)
    {
        AutoStationHelper innerHelper = (AutoStationHelper)helper;
        string columnNameString = TDataModelHelper.GetColumnNameString<AutoStationModel, BuildSelectSqlStringIgnoreAttribute>();
        var sqlString = $"select {columnNameString} from {innerHelper.DBName}.{innerHelper.TablePrefix} where station_id='{stationId}'";

        return await helper.QuerySingleModelAsync<AutoStationModel, BuildSelectSqlStringIgnoreAttribute>(sqlString, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// 获取所有气象自动站信息
    /// </summary>
    /// <param name="helper">数据访问助手</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>气象自动站信息枚举列表</returns>
    public static async ValueTask<IEnumerable<AutoStationModel>?> SelectAsync(
        this IAutoStationHelper helper,
        CancellationToken cancellationToken = default)
    {
        AutoStationHelper innerHelper = (AutoStationHelper)helper;
        string columnNameString = TDataModelHelper.GetColumnNameString<AutoStationModel, BuildSelectSqlStringIgnoreAttribute>();
        var sqlString = $"select {columnNameString} from {innerHelper.DBName}.{innerHelper.TablePrefix}";

        return await helper.QueryDataModelAsync<AutoStationModel, BuildSelectSqlStringIgnoreAttribute>(sqlString, cancellationToken).ConfigureAwait(false);
    }
}