//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineSTableManage.cs
// 项目名称：TDengine 数据库管理
// 创建时间：2022-07-25 14:04:24
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Text;

namespace GSA.ToolKits.DBUtility.TDengine.Managed;

/// <summary>
/// TDengine 超级数据表管理类
/// </summary>
public sealed class TDengineSTableManage : ITDengineSTableManage
{
    private readonly ITDengineConnector _connector;


    /// <summary>
    /// TDengine 超级数据表管理
    /// </summary>
    /// <param name="connector">连接器</param>
    public TDengineSTableManage(ITDengineConnector connector)
    {
        _connector = connector;
    }


    #region 接口实现[ITDengineSTableManage]

    /// <summary>
    /// 创建超级数据表
    /// </summary>
    /// <param name="option">选项参数</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task CreateAsync(STableCreateOption option)
    {
        StringBuilder sb = new();
        sb.Append($"create stable");

        if (option.CheckIsExist)
        {
            sb.Append(" if not exists");
        }

        sb.Append($" {option.DBName}.{option.STableName}");
        sb.Append($" ({option.Columns})");
        sb.Append($" tags ({option.Tags})");

        sb.Append(';');

        TDengineQueryParam param = new(sb.ToString())
        {
            DBName = option.DBName
        };
        _ = await _connector.ExecuteRequestResultAsync(param).ConfigureAwait(false);
    }

    /// <summary>
    /// 删除超级数据表
    /// </summary>
    /// <param name="dbName">数据库名称</param>
    /// <param name="stbName">超级数据表名称</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task DropAsync(string dbName, string stbName)
    {
        string sqlString = $"drop stable if exists {dbName}.{stbName};";
        TDengineQueryParam param = new(sqlString)
        {
            DBName = dbName
        };
        _ = await _connector.ExecuteRequestResultAsync(param).ConfigureAwait(false);
    }

    #endregion

}