//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ExpressionVisitorToSQL.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-06-22 17:34:35
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Linq.Expressions;

namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// 将条件表达式转换为字符串SQL语句
/// </summary>
/// <example>
/// <code>
/// var exception = Lambda 表达式;
/// ExpressionVisitorToSQL visitorToSQL = new();
/// visitorToSQL.Visit(exception);
/// string sqlCondition = visitorToSQL.GetSqlCondtion();
/// </code>
/// </example>
public sealed class ExpressionVisitorToSQL : ExpressionVisitor
{
    private readonly Stack<string> _sqlCondition = new Stack<string>();


    /// <summary>
    /// 将指定表达式类型转换为逻辑标识符
    /// </summary>
    /// <param name="expressionType">表达式类型</param>
    /// <returns>逻辑标识符</returns>
    private string GetSqlOpereatorByNodeType(ExpressionType expressionType)
    {
        return expressionType switch
        {
            ExpressionType.AndAlso => "and",
            ExpressionType.OrElse => "or",
            ExpressionType.GreaterThan => ">",
            ExpressionType.Equal => "=",
            _ => "**",
        };
    }

    /// <summary>
    /// 二元遍历
    /// </summary>
    /// <param name="node">二进制运算符表达式</param>
    /// <returns>表达式</returns>
    protected override Expression VisitBinary(BinaryExpression node)
    {
        _sqlCondition.Push(")");
        Visit(node.Right);
        _sqlCondition.Push(GetSqlOpereatorByNodeType(node.NodeType));
        Visit(node.Left);
        _sqlCondition.Push("(");

        return node;
    }

    /// <summary>
    /// 成员遍历
    /// </summary>
    /// <param name="node">字段或属性表达式</param>
    /// <returns>表达式</returns>
    protected override Expression VisitMember(MemberExpression node)
    {
        if (node.Expression?.NodeType == ExpressionType.Parameter)
        {
            _sqlCondition.Push($"`{node.Member.Name}`");

            return node;
        }

        if (node.Expression?.NodeType == ExpressionType.MemberAccess)
        {
            var objectMember = Expression.Convert(node, typeof(object));
            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
            var getterValue = getterLambda.Compile()();
            _sqlCondition.Push($"`{getterValue}`");

            return node;
        }

        return base.VisitMember(node);
    }

    /// <summary>
    /// 常量遍历
    /// </summary>
    /// <param name="node">常量值表达式</param>
    /// <returns>表达式</returns>
    protected override Expression VisitConstant(ConstantExpression node)
    {
        if (node.Value != null)
        {
            if (node.Value.GetType().IsValueType ||
                node.Value.GetType().Name == "String")
            {
                _sqlCondition.Push(node.Value.ToString()!);

                return node;
            }
        }

        return base.VisitConstant(node);
    }

    /// <summary>
    /// 获取SQL条件拼接字符串
    /// </summary>
    /// <returns>SQL条件拼接字符串</returns>
    public string GetSQLString()
    {
        return string.Join(" ", _sqlCondition.ToArray());
    }
}