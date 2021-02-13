//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：ActionHelper.cs
// 项目名称：窗体常用操作工具集
// 创建时间：2014-10-20 15:39:03
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
#if (NET20 || NET35)
using System;

namespace ToolKits.FormUtility
{
    /// <summary>
    /// Action
    /// </summary>
    public delegate void Action();
    /// <summary>
    /// Action
    /// <para>T - T1</para>
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <typeparam name="T1">T1</typeparam>
    /// <param name="t">T</param>
    /// <param name="t1">T1</param>
    public delegate void Action<T, T1>(T t, T1 t1);
    /// <summary>
    /// Action
    /// <para>T - T1 - T2</para>
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <typeparam name="T1">T1</typeparam>
    /// <typeparam name="T2">T2</typeparam>
    /// <param name="t">T</param>
    /// <param name="t1">T1</param>
    /// <param name="t2">T2</param>
    public delegate void Action<T, T1, T2>(T t, T1 t1, T2 t2);
    /// <summary>
    /// Action
    /// <para>T - T1 - T2 - T3</para>
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <typeparam name="T1">T1</typeparam>
    /// <typeparam name="T2">T2</typeparam>
    /// <typeparam name="T3">T3</typeparam>
    /// <param name="t">T</param>
    /// <param name="t1">T1</param>
    /// <param name="t2">T2</param>
    /// <param name="t3">T3</param>
    public delegate void Action<T, T1, T2, T3>(T t, T1 t1, T2 t2, T3 t3);
    /// <summary>
    /// Func
    /// <para>T</para>
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <returns>T</returns>
    public delegate T Func<T>();
    /// <summary>
    /// Func
    /// <para>T - T1</para>
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <typeparam name="T1">T1</typeparam>
    /// <returns>T1</returns>
    public delegate T1 Func<T, T1>();
    /// <summary>
    /// Func
    /// <para>T - T1 - T2</para>
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <typeparam name="T1">T1</typeparam>
    /// <typeparam name="T2">T2</typeparam>
    /// <returns>T2</returns>
    public delegate T2 Func<T, T1, T2>();
    /// <summary>
    /// Func
    /// <para>T - T1 - T2 - T3</para>
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <typeparam name="T1">T1</typeparam>
    /// <typeparam name="T2">T2</typeparam>
    /// <typeparam name="T3">T3</typeparam>
    /// <returns>T3</returns>
    public delegate T3 Func<T, T1, T2, T3>();
}
#endif
