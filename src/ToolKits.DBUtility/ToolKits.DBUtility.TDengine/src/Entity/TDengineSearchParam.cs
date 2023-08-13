//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineSearchParam.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-11-04 10:20:42
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
/// TDengine 数据检索参数类
/// </summary>
[Serializable]
public sealed class TDengineSearchParam
{
    /// <summary>
    /// TDengine 数据检索参数
    /// </summary>
    /// <param name="tableName">数据表名称</param>
    public TDengineSearchParam(string tableName)
    {
        TableName = tableName;
    }

    /// <summary>
    /// 取消令牌 (缺省 default)
    /// </summary>
    /// <remarks>通常不需要的。年轻人不要怂，就是干！赢了____，输了下海干活。</remarks>
    public CancellationToken Token { get; set; } = default;

    /// <summary>
    /// 数据库名称 (缺省 null)
    /// </summary>
    /// <remarks>如果需要指定数据库执行时</remarks>
    public string? DBName { get; set; } = null;

    /// <summary>
    /// 数据表名称
    /// </summary>
    /// <remarks>必须指定！如果不带数据库名称，将自动补全DBName值。</remarks>
    public string TableName { get; set; }

    /// <summary>
    /// 需要检索的字段名称 (默认 * 即所有表字段)
    /// </summary>
    /// <remarks>
    /// 字段名之间请使用半角逗号分隔
    /// <example>
    /// <code>
    ///   示例：id,name,address,phone,mobile
    /// </code>
    /// </example>
    /// </remarks>
    public string FieldNames { get; set; } = "*";

    /// <summary>
    /// 仅用于内部返回最终执行的SQL语句
    /// </summary>
    public string? SqlString { get; internal set; }

    /// <summary>
    /// 用于查询时使用的原生SQL语句字符串
    /// </summary>
    /// <remarks>
    /// 注意：
    /// <para>1.当使用原生SQL字符串时，将不会组织查询字段和数据表名称。</para>
    /// <para>2.使用原生SQL字符串时，仅需要到 from 数据表名称即可。</para>
    /// <para>3.无论何种SQL语句来源的方式，均会自动组织查询条件、排序方式、分页检索。</para>
    /// </remarks>
    public string? BasedSqlString { get; set; }

    /// <summary>
    /// 查询条件字符串 (缺省 null)
    /// </summary>
    /// <remarks>
    /// 查询条件会自动补全where名称，但条件逻辑必须清晰。
    /// <example>
    /// <code>
    ///   示例：log_time between '2021-10-1 00:00:00.0000' and '2022-10-31 23:59:59.9999' and phone=3389
    /// </code>
    /// </example>
    /// </remarks>
    public string? WhereString { get; set; } = null;

    /// <summary>
    /// 排序字符串 (缺省 _c0 desc)
    /// </summary>
    /// <remarks>
    /// 将数据检索结果进行排序
    /// <para>TDEngine 2.x 仅支持首列时间戳排序；</para>
    /// <para>TDEngine 3.x 无此限制，与寻常SQL排序方式一致。</para>
    /// <para>“_c0”代表时间戳列，即任你瞎命名，我三个字符皆代表。</para>
    /// <example>
    /// <code>
    ///   2.x 示例：_c0 desc
    ///   3.x 示例：id desc,name asc,address desc,phone asc,mobile desc
    /// </code>
    /// </example>
    /// </remarks>
    public string? OrderByString { get; set; } = "_c0 desc";

    /// <summary>
    /// 检索页码 (缺省 -1)
    /// </summary>
    /// <remarks>如果需要分页检索，请设置需要检索的页码；当值少于等于零时，表示不使用分页检索。</remarks>
    public int PageNumber { get; set; } = -1;

    /// <summary>
    /// 分页大小 (缺省 25)
    /// </summary>
    /// <remarks>数据分页检索时，每页显示的数据记录数。</remarks>
    public int PaginationSize { get; set; } = 25;
}