//=========================================================================
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
    private int _digitalPageCount = 5;

    private string? _extraParameters;


    /// <summary>
    /// 数据分页函数名称，首参数为当前页，次参数为分页大小。
    /// </summary>
    /// <remarks>调用JavsScript脚本的函数名称，默认名称：OnPagingUtility。</remarks>
    public string PagingFunction { get; set; } = "OnPagingUtility";

    /// <summary>
    /// 额外的自定义参数，首参数为当前页，次参数为分页大小。
    /// </summary>
    /// <remarks>
    /// 除首参数和次参数外，额外的自定义参数。
    /// <para>PS：请注意特殊字符转义问题，如果是字符串则必须加上单引号等。</para>
    /// </remarks>
    public string? ExtraParameters
    {
        get
        {
            if (_extraParameters is not null &&
            !string.IsNullOrWhiteSpace(_extraParameters) &&
            !_extraParameters.StartsWith(","))
            {
                return _extraParameters.Insert(0, ",");
            }

            return _extraParameters;
        }
        set { _extraParameters = value; }
    }

    /// <summary>
    /// 数据分页标签Id
    /// </summary>
    /// <remarks>承载数据分页的HTML标签，为其赋予的“id”值，默认：PagingUtility。</remarks>
    public string PagingTagId { get; set; } = "PagingUtility";

    /// <summary>
    /// 数据分页标签Id（HTML）
    /// </summary>
    internal string? PagingTagIdHtml
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(PagingTagId))
            {
                return $" id=\"{PagingTagId}\"";
            }

            return default;
        }
    }

    /// <summary>
    /// 数据分页标签Class
    /// </summary>
    /// <remarks>承载数据分页的HTML标签，为其添加的“class”值，默认：无。</remarks>
    public string? PagingTagClass { get; set; }

    /// <summary>
    /// 数据分页标签Class（HTML）
    /// </summary>
    public string? PagingTagClassHtml
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(PagingTagClass))
            {
                return $" class=\"{PagingTagClass}\"";
            }

            return default;
        }
    }

    /// <summary>
    /// 数据分页标签Style
    /// </summary>
    /// <remarks>承载数据分页的HTML标签，为其添加的“style”值，默认：无。</remarks>
    public string? PagingTagStyle { get; set; }

    /// <summary>
    /// 数据分页标签Style（HTML）
    /// </summary>
    public string? PagingTagStyleHtml
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(PagingTagStyle))
            {
                return $" style=\"{PagingTagStyle}\"";
            }

            return default;
        }
    }

    /// <summary>
    /// 数据分页项Class
    /// </summary>
    /// <remarks>数据分页的各分页项目，为其添加的“class”值，默认：无。</remarks>
    public string? PagingItemClass { get; set; }

    /// <summary>
    /// 数据分页项Class（HTML）
    /// </summary>
    public string? PagingItemClassHtml
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(PagingItemClass))
            {
                return $" {PagingItemClass}";
            }

            return default;
        }
    }

    /// <summary>
    /// 数据分页项Style
    /// </summary>
    /// <remarks>数据分页的各分页项目，为其添加的“style”值，默认：无。</remarks>
    public string? PagingItemStyle { get; set; }

    /// <summary>
    /// 数据分页项Style（HTML）
    /// </summary>
    public string? PagingItemStyleHtml
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(PagingItemStyle))
            {
                return $" style=\"{PagingItemStyle}\"";
            }

            return default;
        }
    }


    /// <summary>
    /// 当前页
    /// </summary>
    /// <remarks>缺省为 1</remarks>
    public int CurrentPage
    {
        get
        {
            if (TotalPages > 1 &&
                _currentPage > TotalPages ||
                TotalPages == 1)
            {
                _currentPage = TotalPages;
            }

            return _currentPage;
        }
        set
        {
            _currentPage = value;

            if (value <= 0)
            {
                _currentPage = 1;
            }

            if (TotalPages > 1 &&
                value > TotalPages)
            {
                _currentPage = TotalPages;
            }
        }
    }

    /// <summary>
    /// 上一页
    /// </summary>
    public int PreviousPage => CurrentPage > 1 && TotalPages > 1 ? CurrentPage - 1 : 1;

    /// <summary>
    /// 下一页
    /// </summary>
    public int NextPage => CurrentPage < TotalPages ? CurrentPage + 1 : TotalPages;

    /// <summary>
    /// 总页数
    /// </summary>
    /// <remarks>缺省为 1</remarks>
    public int TotalPages { get; private set; } = 1;

    /// <summary>
    /// 分页大小
    /// </summary>
    /// <remarks>缺省为 25</remarks>
    public int PaginationSize
    {
        get { return _paginationSize; }
        set
        {
            PaginationSizeRange ??= new int[4] { 25, 50, 75, 100 };

            _paginationSize = value;

            if (!PaginationSizeRange.Any(p => p == _paginationSize))
            {
                _paginationSize = PaginationSizeRange[0];
            }

            // 一顿操作猛如虎，结果值为特么零，那就 Color see see。
            if (_paginationSize <= 0)
            {
                _paginationSize = 25;
                PaginationSizeRange = new int[4] { 25, 50, 75, 100 };
            }

            DataCalculation();
        }
    }

    /// <summary>
    /// 分页大小范围
    /// </summary>
    /// <remarks>缺省为 [25、50、75、100]</remarks>
    public int[] PaginationSizeRange { get; set; } = new int[4] { 25, 50, 75, 100 };

    /// <summary>
    /// 总记录数
    /// </summary>
    /// <remarks>缺省为 0</remarks>
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
    /// 数字分页总个数
    /// </summary>
    /// <remarks>缺省为 5</remarks>
    public int DigitalPageCount
    {
        get { return _digitalPageCount; }
        set
        {
            _digitalPageCount = value;

            if (value <= 0)
            {
                _digitalPageCount = 5;
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
            return result > 2 ? result : 2;
        }
    }

    /// <summary>
    /// 数字分页标记数
    /// </summary>
    internal int DigitalPageFlag => DigitalPageCount / 2;


    /// <summary>
    /// 是否使用分页跳转功能，缺省为 true。
    /// </summary>
    /// <remarks>true 使用，false 不使用。</remarks>
    public bool IsUsePagingJump { get; set; } = true;

    /// <summary>
    /// 是否使用禁用模式，即将无分页项设置为禁用状态，缺省为 false。
    /// </summary>
    /// <remarks>true 使用，false 不使用。</remarks>
    public bool IsUseDisabledMode { get; set; } = false;


    /// <summary>
    /// 数据计算
    /// </summary>
    private void DataCalculation()
    {
        if (PaginationSize < 1 ||
            TotalRecords < 1 ||
            TotalRecords <= PaginationSize)
        {
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