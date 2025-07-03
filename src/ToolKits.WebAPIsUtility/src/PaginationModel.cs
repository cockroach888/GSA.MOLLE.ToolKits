//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：PaginationModel.cs
// 项目名称：WebAPI接口辅助与应用工具集
// 创建时间：2024-09-05 09:51:16
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.WebAPIsUtility;

/// <summary>
/// 数据分页信息实体类
/// </summary>
[Serializable]
public class PaginationModel
{
    private int _pageSize = 25;
    private int _currentPage = 1;


    /// <summary>
    /// 总记录数
    /// </summary>
    /// <remarks>表示数据库中总共有多少条记录。</remarks>
    public int TotalRecords { get; set; }

    /// <summary>
    /// 分页大小
    /// </summary>
    /// <remarks>表示每页显示的数据数量。</remarks>
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            // 当分页大小小于或等于零时，设定为默认25条/页记录。
            if (value <= 0)
            {
                value = 25;
            }

            _pageSize = value;
        }
    }

    /// <summary>
    /// 当前页码
    /// </summary>
    /// <remarks>表示用户正在查看的页码。</remarks>
    public int CurrentPage
    {
        get
        {
            return _currentPage;
        }
        set
        {
            // 当页码小于或等于零时，自动跳转至第1页。
            if (value <= 0)
            {
                value = 1;
            }

            _currentPage = value;
        }
    }

    /// <summary>
    /// 总页数
    /// </summary>
    /// <remarks>表示数据可以分成多少页。</remarks>
    public int TotalPages => (int)Math.Ceiling((double)Math.Max(TotalRecords, 0) / PageSize);
}