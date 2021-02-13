//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：DelegateEx.cs
// 项目名称：窗体常用操作工具集
// 创建时间：2014年3月7日19时07分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Windows.Forms;

namespace ToolKits.FormUtility
{
    /// <summary>
    /// 委托操作类
    /// </summary>
    public class DelegateEx
    {
        
        #region 委托事件定义

        /// <summary>
        /// 定义一个委托
        /// </summary>
        /// <param name="sender">委托对象</param>
        /// <param name="e">委托事件</param>
        public delegate void UpdateInfoEventHandler(object sender, UpdateInfoEventArgs e);
        /// <summary>
        /// 定义一个委托事件
        /// </summary>
        private event UpdateInfoEventHandler UpdateInfo;

        #endregion

        #region 委托事件

        /// <summary>
        /// 委托事件类
        /// </summary>
        public class UpdateInfoEventArgs : EventArgs
        {
            /// <summary>
            /// 更新信息
            /// </summary>
            public readonly string FStrInfo;
            /// <summary>
            /// 错误消息标记
            /// </summary>
            public readonly bool FExFlag;
            /// <summary>
            /// 构造函数
            /// </summary>            
            /// <param name="strInfo">更新信息</param>
            /// <param name="exFlag">错误消息标记</param>
            public UpdateInfoEventArgs(string strInfo, bool exFlag)
            {
                this.FStrInfo = strInfo;
                this.FExFlag = exFlag;
            }
        }

        #endregion

        #region 注册 & 反注册

        /// <summary>
        /// To register more than one method for an event
        /// </summary>
        /// <param name="method">Method name</param>
        public void Register(UpdateInfoEventHandler method)
        {
            UpdateInfo += method;
        }
        /// <summary>
        /// Registered with the event a unique method
        /// </summary>
        /// <param name="method">Method name</param>
        public void RegisterOnly(UpdateInfoEventHandler method)
        {
            UpdateInfo = method;
        }
        /// <summary>
        /// Registered with the event against method
        /// </summary>
        /// <param name="method">Method name</param>
        public void UnRegister(UpdateInfoEventHandler method)
        {
            UpdateInfo -= method;
        }
        /// <summary>
        /// Registered with the event against method
        /// </summary>
        public void UnRegister()
        {
            UpdateInfo = null;
        }

        #endregion

        #region 成员虚方法

        /// <summary>
        /// Can be overridden execute method
        /// </summary>
        /// <param name="form">System.Windows.Forms</param>
        /// <param name="e">The delegate event</param>
        protected virtual void OnUpdateInfo(Form form, UpdateInfoEventArgs e)
        {
            //if (UpdateInfo != null && form != null) form.Invoke(UpdateInfo, this, e);//会造成阻塞[即假死]
            if (UpdateInfo != null && form != null) form.BeginInvoke(UpdateInfo, this, e);
        }

        #endregion

        #region 成员方法

        /// <summary>
        /// Executes a delegate method
        /// </summary>
        /// <param name="form">System.Windows.Forms</param>
        /// <param name="strInfo">To update the information</param>
        /// <param name="exFlag">Whether for error message</param>
        public void Executes(Form form, string strInfo, bool exFlag)
        {
            UpdateInfoEventArgs e = new UpdateInfoEventArgs(strInfo, exFlag);
            OnUpdateInfo(form, e);
            e = null;
        }

        #endregion

    }
}
