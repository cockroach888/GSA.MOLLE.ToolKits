//==================================================================== 
//*****                    晨曦小竹常用工具集                    *****
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释   **
//====================================================================
// 文件名称：SqlInjection.cs
// 项目名称：安全校验实用工具集
// 创建时间：2014年2月21日15时7分
// 创建人员：宋杰军
// 负 责 人：宋杰军
// 参与人员：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
#if NETFRAMEWORK
using System;
using System.Web;

namespace DawnXZ.SafeUtility
{
    /// <summary>
    /// SQL注入安全检测处理类
    /// <remarks>
    /// <para>在 Web.config 文件中的 appSettings 配置节添加如下代码</para>
    /// <para>&lt;!--防注入设置[yes/no][strSqlInjection可不配置]--&gt;</para>
    /// <para>&lt;add key="SafeInjectionString" value="and |exec |insert |select |delete |update |count | * |chr |mid |master |truncate |char |declare " /&gt;</para>
    /// <para>&lt;add key="SafeReturnParam" value="no" /&gt;</para>
    /// <para>&lt;add key="SafeReturnPage" value="Error.aspx" /&gt;</para>
    /// <para>在 Web.config 文件中的 system.web 配置节 中的 HttpModules 中添加如下代码</para>
    /// <para>&lt;!--防注入设置--&gt;</para>
    /// <para>&lt;add name="httpSqlInjection" type="DawnXZ.SafeUtility.SqlInjection,SafeUtility" /&gt;</para>
    /// </remarks>
    /// </summary>
    public class SqlInjection : IHttpModule
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="application"></param>
        public void Init(HttpApplication application)
        {
            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
        }
        /// <summary>
        /// 应用程序请求开始
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void Application_BeginRequest(Object source, EventArgs e)
        {
            ProcessRequest pr = new ProcessRequest();
            pr.StartProcessRequest();
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        { }
    }
}
#endif
