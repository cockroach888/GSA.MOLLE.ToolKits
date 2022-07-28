//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineTableManage.cs
// 项目名称：TDengine 数据库管理
// 创建时间：2022-07-25 14:04:43
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
/// TDengine 数据表管理类
/// </summary>
public sealed class TDengineTableManage : ITDengineTableManage
{
    private readonly ITDengineConnector _connector;


    /// <summary>
    /// TDengine 数据表管理
    /// </summary>
    /// <param name="connector">连接器</param>
    public TDengineTableManage(ITDengineConnector connector)
    {
        _connector = connector;
    }


    #region 接口实现[ITDengineTableManage]

    /// <summary>
    /// 创建数据表
    /// </summary>
    /// <param name="option">选项参数</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task CreateAsync(TableCreateOption option)
    {
        StringBuilder sb = new();
        sb.Append($"create table");

        if (option.CheckIsExist)
        {
            sb.Append(" if not exists");
        }
        
        sb.Append($" {option.DBName}.{option.TableName}");

        if (string.IsNullOrWhiteSpace(option.STableName))
        {
            sb.Append($" ({option.Columns})");
        }
        else
        {
            sb.Append($" using {option.DBName}.{option.STableName}");

            if (!string.IsNullOrWhiteSpace(option.TagNames))
            {
                sb.Append($" ({option.TagNames})");
            }

            if (!string.IsNullOrWhiteSpace(option.TagValues))
            {
                sb.Append($" tags ({option.TagValues})");
            }
        }

        sb.Append(';');

        TDengineQueryParam param = new(sb.ToString())
        {
            DBName = option.DBName
        };
        _ = await _connector.ExecutionToResultAsync(param).ConfigureAwait(false);
    }

    /// <summary>
    /// 删除数据表
    /// </summary>
    /// <param name="dbName">数据库名称</param>
    /// <param name="tbName">数据表名称</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task DropAsync(string dbName, string tbName)
    {
        string sqlString = $"drop table if exists {dbName}.{tbName};";
        TDengineQueryParam param = new(sqlString)
        {
            DBName = dbName
        };
        _ = await _connector.ExecutionToResultAsync(param).ConfigureAwait(false);
    }

    #endregion

}