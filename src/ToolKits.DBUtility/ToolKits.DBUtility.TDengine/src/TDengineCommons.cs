//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineCommons.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-07-22 16:17:27
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
/// TDengine 常见和通用功能类
/// </summary>
public static class TDengineCommons
{
    /// <summary>
    /// 仅用于验证并自动更正查询条件前缀是否为正确的where关键字标识
    /// </summary>
    /// <param name="whereString">待验证的查询条件字符串</param>
    /// <returns>验证后的查询条件字符串</returns>
    public static string? WhereStringValidate(string? whereString)
    {
        if (string.IsNullOrWhiteSpace(whereString) ||
            whereString is null)
        {
            return default;
        }

        // 移除首尾所有空白字符
        whereString = whereString.Trim();

        // 验证 where 关键字
        if (whereString.StartsWith("where"))
        {
            whereString = whereString.Insert(0, " ");
        }
        else
        {
            whereString = whereString.Insert(0, " where ");
        }

        return whereString;
    }

    /// <summary>
    /// 验证查询条件的where关键字标识，并加入到SQL语句中。
    /// </summary>
    /// <param name="sqlString">SQL字符串</param>
    /// <param name="whereString">待验证的查询条件字符串</param>
    /// <returns>SQL字符串</returns>
    public static string WhereStringValidateAndJoinToSqlString(string sqlString, string? whereString)
    {
        whereString = WhereStringValidate(whereString);

        if (string.IsNullOrWhiteSpace(whereString) ||
            whereString is null)
        {
            return sqlString;
        }

        int startIndex = sqlString.EndsWith(";") ? sqlString.Length - 1 : sqlString.Length;

        return sqlString.Insert(startIndex, whereString);
    }

    /// <summary>
    /// 将排序字符串加入到SQL语句中
    /// </summary>
    /// <param name="sqlString">SQL字符串</param>
    /// <param name="orderbyString">排序字符串</param>
    /// <returns>SQL字符串</returns>
    public static string OrderByJoinToSqlString(string sqlString, string? orderbyString)
    {
        if (string.IsNullOrWhiteSpace(orderbyString) ||
            orderbyString is null)
        {
            return sqlString;
        }

        return $"{sqlString} order by {orderbyString}";
    }

    /// <summary>
    /// 将数据分页功能加入到SQL语句中
    /// </summary>
    /// <param name="sqlString">SQL字符串</param>
    /// <param name="pageNumber">检索页码</param>
    /// <param name="paginationSize">分页大小</param>
    /// <returns>SQL字符串</returns>
    public static string PaginationJoinToSqlString(string sqlString, int pageNumber, int paginationSize)
    {
        if (pageNumber <= 0 || paginationSize <= 0)
        {
            return sqlString;
        }

        //数据分页偏移量
        int paginationOffset = (pageNumber - 1) * paginationSize;

        return $"{sqlString} limit {paginationSize} offset {paginationOffset}";
    }
}