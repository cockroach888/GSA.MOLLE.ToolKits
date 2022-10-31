﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：PagingOptions.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-10-31 09:34:18
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.PagingUtility;

/// <summary>
/// 数据分页选项(参数)类
/// </summary>
[Serializable]
public sealed class PagingOptions
{
    private int _currentPage = 1;
    private int _paginationSize = 25;
    private int _totalRecords = 0;
    private int _digitalPageCount = 7;


    /// <summary>
    /// 数据分页函数名称，首参数为当前页数值。
    /// </summary>
    /// <remarks>调用JavsScript脚本的函数名称，默认名称：OnPagingUtility。</remarks>
    public string PagingFunction { get; set; } = "OnPagingUtility";

    /// <summary>
    /// 额外的自定义参数，首参数为当前页数值。
    /// </summary>
    /// <remarks>除首参数外，额外的自定义参数。</remarks>
    public string? ExtraParameters { get; set; }

    /// <summary>
    /// 数据分页标签Id
    /// </summary>
    /// <remarks>承载数据分页的HTML标签，为其赋予的“id”值，默认：PagingUtility。</remarks>
    public string PagingTagId { get; set; } = "PagingUtility";

    /// <summary>
    /// 数据分页标签Class
    /// </summary>
    /// <remarks>承载数据分页的HTML标签，为其添加的“class”值，默认：无。</remarks>
    public string? PagingTagClass { get; set; }

    /// <summary>
    /// 数据分页标签Style
    /// </summary>
    /// <remarks>承载数据分页的HTML标签，为其添加的“style”值，默认：无。</remarks>
    public string? PagingTagStyle { get; set; }

    /// <summary>
    /// 数据分页项Class
    /// </summary>
    /// <remarks>数据分页的各分页项目，为其添加的“class”值，默认：无。</remarks>
    public string? PagingItemClass { get; set; }

    /// <summary>
    /// 数据分页项Style
    /// </summary>
    /// <remarks>数据分页的各分页项目，为其添加的“style”值，默认：无。</remarks>
    public string? PagingItemStyle { get; set; }


    /// <summary>
    /// 当前页
    /// </summary>
    public int CurrentPage
    {
        get { return _currentPage; }
        set
        {
            _currentPage = value;

            if (value <= 0)
            {
                _currentPage = 1;
            }

            if (value > TotalPages)
            {
                _currentPage = TotalPages;
            }
        }
    }

    /// <summary>
    /// 总页数
    /// </summary>
    public int TotalPages { get; private set; }

    /// <summary>
    /// 分页大小
    /// </summary>
    public int PaginationSize
    {
        get { return _paginationSize; }
        set
        {
            _paginationSize = value;

            if (_paginationSize <= 0)
            {
                _paginationSize = 1;
            }

            DataCalculation();
        }
    }

    /// <summary>
    /// 总记录数
    /// </summary>
    public int TotalRecords
    {
        get { return _totalRecords; }
        set
        {
            _totalRecords = value;

            if (_totalRecords < 0)
            {
                _totalRecords = 0;
            }

            DataCalculation();
        }
    }

    /// <summary>
    /// 当前页记录数
    /// </summary>
    public int CurrentPageRecords { get; set; }


    /// <summary>
    /// 数字分页总个数
    /// </summary>
    public int DigitalPageCount
    {
        get { return _digitalPageCount; }
        set
        {
            _digitalPageCount = value;

            if (value <= 0)
            {
                _digitalPageCount = 7;
            }
        }
    }

    /// <summary>
    /// 数字分页起始数
    /// </summary>
    internal int DigitalPageStart
    {
        get
        {
            int result = CurrentPage - DigitalPageFlag;
            return result >= 1 ? result : 1;
        }
    }

    /// <summary>
    /// 数字分页标记数
    /// </summary>
    internal int DigitalPageFlag => DigitalPageCount / 2;


    /// <summary>
    /// 是否输出当前页记录数
    /// </summary>
    /// <remarks>true 输出，false 不输出。</remarks>
    public bool IsOutputCurrentPageRecords { get; set; }

    /// <summary>
    /// 是否使用分页跳转
    /// </summary>
    /// <remarks>true 使用，false 不使用。</remarks>
    public bool IsUsePagingJump { get; set; }


    /// <summary>
    /// 数据计算
    /// </summary>
    private void DataCalculation()
    {
        if (PaginationSize < 1 ||
            TotalRecords < 1 ||
            TotalRecords <= PaginationSize)
        {
            _currentPage = 1;
            TotalPages = 1;

            return;
        }

        TotalPages = TotalRecords / PaginationSize;

        if (TotalRecords % PaginationSize != 0)
        {
            TotalPages++;
        }
    }
}