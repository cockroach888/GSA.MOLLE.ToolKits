//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：FEffects.cs
// 项目名称：窗体常用操作工具集
// 创建时间：2014年3月7日19时01分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;

namespace GSA.ToolKits.FormUtility
{
    /// <summary>
    /// 窗体特效
    /// </summary>
    public static class FEffects
    {

        #region 成员常量

        /// <summary>
        /// 从左到右打开窗口 
        /// </summary>
        public static readonly int AW_HOR_POSITIVE = 0x0001;
        /// <summary>
        /// 从右到左打开窗口
        /// </summary>
        public static readonly int AW_HOR_NEGATIVE = 0x0002;
        /// <summary>
        /// 从上到下打开窗口
        /// </summary>
        public static readonly int AW_VER_POSITIVE = 0x0004;
        /// <summary>
        /// 从下到上打开窗口
        /// </summary>
        public static readonly int AW_VER_NEGATIVE = 0x0008;
        /// <summary>
        /// 从中央打开 
        /// </summary>
        public static readonly int AW_CENTER = 0x0010;
        /// <summary>
        /// 隐藏窗体
        /// </summary>
        public static readonly int AW_HIDE = 0x10000;
        /// <summary>
        /// Display窗体 
        /// </summary>
        public static readonly int AW_ACTIVATE = 0x20000;
        /// <summary>
        /// 滑入效果
        /// </summary>
        public static readonly int AW_SLIDE = 0x40000;
        /// <summary>
        /// 淡入淡出效果
        /// </summary>
        public static readonly int AW_BLEND = 0x80000;

        #endregion

        #region 成员方法

        /// <summary>
        /// 窗体特效
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="dwTime"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        /// <summary>
        /// 窗体特效
        /// </summary>
        /// <param name="hwnd">窗体句柄号</param>
        /// <param name="dwTime">执行时间，单位：微秒</param>
        /// <param name="dwFlags">动作标识</param>
        /// <returns></returns>
        public static bool ShowEff(IntPtr hwnd, int dwTime, int dwFlags)
        {
            return AnimateWindow(hwnd, dwTime, dwFlags);
        }        

        #endregion

    }
}
