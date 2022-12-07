//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：AutoStationDataHelperExtensions.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-09-16 15:27:38
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
/// 气象自动站数据数据访问助手扩展类
/// </summary>
public static class AutoStationDataHelperExtensions
{
    /// <summary>
    /// 获取气象自动站数据
    /// </summary>
    /// <param name="helper">数据访问助手</param>
    /// <param name="stationId">自动站编号</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>气象自动站数据枚举列表</returns>
    public static async Task<IEnumerable<AutoStationDataModel>?> SearchAsync(
        this IAutoStationDataHelper helper,
        string stationId,
        CancellationToken cancellationToken = default)
    {
        AutoStationDataHelper innerHelper = (AutoStationDataHelper)helper;

        string tableName = $"{innerHelper.DBName}.{innerHelper.TablePrefix}_{stationId}";
        string columnNameString = TDataModelHelper.GetColumnNameString<AutoStationDataModel>();

        TDengineSearchParam param = new(tableName)
        {
            Token = cancellationToken,
            DBName = innerHelper.DBName,
            FieldNames = columnNameString,
            WhereString = "temperature between -20 and 20",
            OrderByString = "tss desc",
            PageNumber = 10,
            PaginationSize = 50
        };

        IEnumerable<AutoStationDataModel>? result = await innerHelper.Connector.ExecuteSearchModelAsync<AutoStationDataModel>(param).ConfigureAwait(false);
        return result;
    }
}