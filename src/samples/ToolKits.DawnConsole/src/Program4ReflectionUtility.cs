//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：Program4ReflectionUtility.cs
// 项目名称：功能调测控制台程序
// 创建时间：2023-05-19 15:20:35
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.CommonUtility;
using System.Text.Json;

namespace GSA.ToolKits.DawnConsole;

/// <summary>
/// ReflectionUtility
/// </summary>
internal sealed class Program4ReflectionUtility
{

    #region 单例模式

    private static readonly Lazy<Program4ReflectionUtility> _lazyInstance = new(() => new Program4ReflectionUtility());

    /// <summary>
    /// ReflectionUtility
    /// </summary>
    internal static Program4ReflectionUtility Default => _lazyInstance.Value;

    #endregion


    /// <summary>
    /// 小心手雷，洞中开火。
    /// </summary>
    /// <remarks>获取IP地址与MAC地址</remarks>
    public void FireInTheHole()
    {
        TestModel model = new();

        ReflectionHelper.SetPropertyValue(model, "Name", "牛的牛的");
        ReflectionHelper.SetPropertyValue(model, "Value", 999999999);
        ReflectionHelper.SetPropertyValue(model, "Description", "尝试修改描述信息");

        ReflectionHelper.SetFieldValue(model, "FieldName", "可以的可以的");
        ReflectionHelper.SetFieldValue(model, "FieldUintValue", 999887766);
        ReflectionHelper.SetFieldValue(model, "FieldStringValue", "This is a test message.");
        bool setResult = ReflectionHelper.SetFieldValue(model, "PrivateFieldValue", "This is a private message.");

        Console.WriteLine($"FieldName: {model.FieldName}");
        Console.WriteLine($"FieldUintValue: {model.FieldUintValue}");
        Console.WriteLine($"FieldStringValue: {model.FieldStringValue}");
        Console.WriteLine($"PrivateFieldValue: {setResult}");

        Console.WriteLine($"Name: {model.Name}");
        Console.WriteLine($"Value: {model.Value}");
        Console.WriteLine($"Description: {model.Description}");

        Console.WriteLine();
        Console.WriteLine();



        ReflectionHelper.TryGetPropertyValue(model, "Name", out string? name);
        ReflectionHelper.TryGetPropertyValue(model, "Value", out int value);
        ReflectionHelper.TryGetPropertyValue(model, "Description", out string? desc);

        ReflectionHelper.TryGetFieldValue(model, "FieldName", out string? fieldName);
        ReflectionHelper.TryGetFieldValue(model, "FieldUintValue", out uint fieldUintValue);
        ReflectionHelper.TryGetFieldValue(model, "FieldStringValue", out string? fieldStringValue);
        bool getResult = ReflectionHelper.TryGetFieldValue(model, "PrivateFieldValue", out string? privateFieldValue);

        Console.WriteLine($"GetFieldValue - FieldName: {fieldName}");
        Console.WriteLine($"GetFieldValue - FieldUintValue: {fieldUintValue}");
        Console.WriteLine($"GetFieldValue - FieldStringValue: {fieldStringValue}");
        Console.WriteLine($"GetFieldValue - PrivateFieldValue: {getResult}");

        Console.WriteLine($"GetPropertyValue - Name: {name}");
        Console.WriteLine($"GetPropertyValue - Value: {value}");
        Console.WriteLine($"GetPropertyValue - Description: {desc}");
    }


    private class TestModel
    {
        public string? FieldName;

        public uint FieldUintValue = 1;

        public readonly string FieldStringValue = "我是只读的字段咧！";

        private string PrivateFieldValue = "这是一个私有字段";


        public string? Name { get; set; }

        public int Value { get; set; }

        public string? Description { get; } = "我是只读的属性咧！";
    }
}