//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MainWindowService.cs
// 项目名称：自动删除文件工具
// 创建时间：2023-11-10 15:16:24
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Windows.Threading;
using System.Collections.Concurrent;
using System.Text.Json;
using System.IO;

namespace GSA.ToolKits.AutomaticDeletionFiles.Services;

/// <summary>
/// 主窗体控服务
/// </summary>
internal sealed class MainWindowService
{
    private Dispatcher? _dispatcher;
    private ConcurrentDictionary<DeleteContentType, List<string>> _dictIncludeList = new();
    private ConcurrentDictionary<DeleteContentType, List<string>> _dictExcludeList = new();


    /// <summary>
    /// 主窗体控服务
    /// </summary>
    /// <param name="dispatcher">调度器</param>
    public MainWindowService(Dispatcher dispatcher)
    {
        _dispatcher = dispatcher;

        _dictIncludeList[DeleteContentType.Folder] = new List<string>();
        _dictIncludeList[DeleteContentType.FileName] = new List<string>();
        _dictIncludeList[DeleteContentType.FileType] = new List<string>();

        _dictExcludeList[DeleteContentType.Folder] = new List<string>();
        _dictExcludeList[DeleteContentType.FileName] = new List<string>();
        _dictExcludeList[DeleteContentType.FileType] = new List<string>();
    }


    /// <summary>
    /// 添加要包含的内容
    /// </summary>
    /// <param name="keyword">关键字</param>
    /// <param name="value">值</param>
    public void IncludeAddin(string keyword, string value)
    {
        if (Enum.TryParse(keyword, out DeleteContentType type))
        {
            _dictIncludeList[type].Add(value);
        }
    }

    /// <summary>
    /// 添加要排除的内容
    /// </summary>
    /// <param name="keyword">关键字</param>
    /// <param name="value">值</param>
    public void ExcludeAddin(string keyword, string value)
    {
        if (Enum.TryParse(keyword, out DeleteContentType type))
        {
            _dictExcludeList[type].Add(value);
        }
    }

    /// <summary>
    /// 移除要包含的内容
    /// </summary>
    /// <param name="keyword">关键字</param>
    /// <param name="value">值</param>
    public void IncludeRemove(string keyword, string value)
    {
        if (Enum.TryParse(keyword, out DeleteContentType type))
        {
            _dictIncludeList[type].Remove(value);
        }
    }

    /// <summary>
    /// 移除要排除的内容
    /// </summary>
    /// <param name="keyword">关键字</param>
    /// <param name="value">值</param>
    public void ExcludeRemove(string keyword, string value)
    {
        if (Enum.TryParse(keyword, out DeleteContentType type))
        {
            _dictExcludeList[type].Remove(value);
        }
    }


    /// <summary>
    /// 启动
    /// </summary>
    /// <param name="paramString">参数字符串</param>
    public void Start(string paramString)
    {
        DeletionFilesParam? param = JsonSerializer.Deserialize<DeletionFilesParam>(paramString);

        _dispatcher?.BeginInvoke((DeletionFilesParam info) =>
        {
            if (!Directory.Exists(info.MonitorDirectories))
            {
                MessageBox.Show("哥们儿！您逗我呢！！需要监视的目录都没有配置咧！！！", "系统提示", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            FileAttributes fileAttr = new();

            if (info.ExcludeHiddenFiles) // 是否排除隐藏文件和文件夹
            {
                fileAttr |= FileAttributes.Hidden;
            }

            if (info.ExcludeSystemFiles) // 排除系统文件和文件夹
            {
                fileAttr |= FileAttributes.System;
            }

            if (info.ExcludeTemporaryFiles) // 排除临时文件和文件夹
            {
                fileAttr |= FileAttributes.Temporary;
            }


            EnumerationOptions option = new()
            {
                // 要跳过的属性
                AttributesToSkip = fileAttr,

                // 建议的缓冲区大小（以字节为单位），默认值为 0（无建议）。
                //BufferSize = 0,

                // 是否在拒绝访问时跳过文件或目录，默认值为 true。
                //IgnoreInaccessible = true,

                // 大小写匹配行为。默认值是匹配平台默认值，这些默认值是从临时文件夹的区分大小写中收集的。
                //MatchCasing = MatchCasing.PlatformDefault,

                // 匹配类型，默认值为简单匹配，其中“*”始终为 0 个或多个字符，而“？”是单个字符。
                // MatchType = MatchType.Simple,

                // 要递归的最大目录深度，默认值为 Int32.MaxValue。
                // 如果 MaxRecursionDepth 设置为负数，则使用默认值 MaxValue 。
                // 如果 MaxRecursionDepth 设置为零，枚举将返回初始目录的内容。
                //MaxRecursionDepth = int.MaxValue,

                // 是否递归到子目录中
                RecurseSubdirectories = info.IncludeSubdirectories,

                // 是否返回特殊目录项“.”和“..”
                ReturnSpecialDirectories = false
            };

            IEnumerable<string> files = Directory.EnumerateFiles(info.MonitorDirectories, "*.*", option);



        }, param);
    }

    /// <summary>
    /// 停止
    /// </summary>
    public void Stop()
    {
        _dispatcher?.BeginInvoke(() =>
        {
            //MessageBox.Show("停止", "系统提示", MessageBoxButton.OK, MessageBoxImage.Information);
        });
    }
}