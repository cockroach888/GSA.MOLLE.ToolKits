//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：ConnectionString.cs
// 项目名称：数据库操作实用工具集
// 创建时间：2014年2月26日14时33分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Text;

namespace GSA.ToolKits.DBUtility
{
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    public sealed class SQliteConnectionString
    {
        /// <summary>
        /// SQLite数据库连接字符串
		/// <para>调用时请对此方法特别调用</para>
        /// </summary>
        /// <param name="dataPath">SQLite数据库文件路径</param>
        /// <param name="pwd">数据库密码</param>
        /// <param name="isShared">是否共享缓存</param>
        /// <param name="isReadOnly">是否只读打开</param>
        /// <returns>SQLite数据库连接字符串</returns>
		public static string ConnectionString(string dataPath, string pwd, bool isShared = true, bool isReadOnly = false)
        {
            var sb = new StringBuilder();

            sb.Append($@"Data Source={dataPath};");
            sb.Append($@"Pooling=true;");
            sb.Append($@"FailIfMissing=false;");

            // 共享缓存提高并发
            if (isShared)
            {
                sb.Append($@"Cache=Shared;");
            }

            // 加密
            if (!string.IsNullOrEmpty(pwd))
            {
                sb.Append($@"Password={pwd};");
            }

            // 只读
            if (isReadOnly)
            {
                sb.Append($@"Mode=ReadOnly;");
            }

            return sb.ToString();
        }
    }
}
