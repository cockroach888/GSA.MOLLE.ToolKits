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
using System.Collections.Concurrent;
using System.IO;
using System.Text.Json;
using System.Windows.Threading;

namespace GSA.ToolKits.AutomaticDeletionFiles.Services;

/// <summary>
/// 主窗体服务
/// </summary>
public sealed class MainWindowService
{
    private readonly Dispatcher _dispatcher;
    private readonly ConcurrentDictionary<DeleteContentType, List<string>> _dictIncludeList = new();
    private readonly ConcurrentDictionary<DeleteContentType, List<string>> _dictExcludeList = new();
    private CancellationTokenSource? _cts;
    private bool _isStarted = false;


    /// <summary>
    /// 主窗体服务
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
            FormatInputValue(keyword, ref value);

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
            FormatInputValue(keyword, ref value);

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
            FormatInputValue(keyword, ref value);

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
            FormatInputValue(keyword, ref value);

            _dictExcludeList[type].Remove(value);
        }
    }

    /// <summary>
    /// 格式化输入值
    /// </summary>
    /// <param name="keyword">关键字</param>
    /// <param name="value">输入值</param>
    private void FormatInputValue(string keyword, ref string value)
    {
        if (Enum.TryParse(keyword, out DeleteContentType type) &&
            type is DeleteContentType.FileType)
        {
            value = value.Replace("*", "");
        }
    }


    /// <summary>
    /// 启动
    /// </summary>
    /// <param name="paramString">参数字符串</param>
    public async Task<IEnumerable<string>> StartAsync(string paramString)
    {
        if (_isStarted)
        {
            return new string[] { "对不起！当前已经开始执行自动删除文件操作，你可以停止，但请勿重复执行。", "warning" };
        }

        DeletionFilesParam? param = JsonSerializer.Deserialize<DeletionFilesParam>(paramString);

        if (param is null)
        {
            return new string[] { "哥们儿，请问：你是猴子请来的救兵吗？什么参数都没有配置，自己心里没点逼数！", "error" };
        }

        return await _dispatcher.InvokeAsync(() =>
        {
            if (!Directory.Exists(param.MonitorDirectories))
            {
                return new string[] { "哥们儿！您逗我呢！！需要监视的目录都没有配置！！！", "warning" };
            }


            FileAttributes fileAttr = new();

            if (param.ExcludeHiddenFiles) // 是否排除隐藏文件和文件夹
            {
                fileAttr |= FileAttributes.Hidden;
            }

            if (param.ExcludeSystemFiles) // 排除系统文件和文件夹
            {
                fileAttr |= FileAttributes.System;
            }

            if (param.ExcludeTemporaryFiles) // 排除临时文件和文件夹
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
                RecurseSubdirectories = param.IsIncludeSubdirectories,

                // 是否返回特殊目录项“.”和“..”
                ReturnSpecialDirectories = false
            };

            _cts = new();
            ExcuteDeleteFiles(param, option, _cts.Token);

            return new string[] { "开始执行自动删除文件操作，将进入轮询处置阶段。（你可以停止，但不一定管用，呵。 ^_^）", "success" };
        });
    }

    /// <summary>
    /// 停止
    /// </summary>
    public async Task StopAsync()
    {
        await _dispatcher.InvokeAsync(() =>
        {
            _cts?.Cancel();
            _isStarted = false;

            MessageBox.Show("停止", "系统提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }).Task.ConfigureAwait(false);
    }


    private void ExcuteDeleteFiles(DeletionFilesParam param, EnumerationOptions option, CancellationToken cancellation)
    {
        _isStarted = true;

        _ = Task.Run(async () =>
        {
            while (cancellation.IsCancellationRequested is false)
            {
                IEnumerable<string> sourceFiles = from file in Directory.EnumerateFiles(param.MonitorDirectories, "*", option)
                                                  where (DateTime.Now - File.GetCreationTime(file)) > param.LeadTime
                                                  select file;

                if (sourceFiles.Any())
                {
                    IEnumerable<string> includeFiles = Enumerable.Empty<string>();

                    // 要包含的内容
                    if (_dictIncludeList.Values.Any())
                    {
                        if (_dictIncludeList[DeleteContentType.Folder].Any())
                        {
                            foreach (string item in _dictIncludeList[DeleteContentType.Folder])
                            {
                                includeFiles = includeFiles.Concat(sourceFiles.Where(p => Path.GetDirectoryName(p)!.Contains(item)));
                            }
                        }

                        if (_dictIncludeList[DeleteContentType.FileName].Any())
                        {
                            foreach (string item in _dictIncludeList[DeleteContentType.FileName])
                            {
                                includeFiles = includeFiles.Concat(sourceFiles.Where(p => Path.GetFileNameWithoutExtension(p).Contains(item)));
                            }
                        }

                        if (_dictIncludeList[DeleteContentType.FileType].Any())
                        {
                            foreach (string item in _dictIncludeList[DeleteContentType.FileType])
                            {
                                includeFiles = includeFiles.Concat(sourceFiles.Where(p => Path.GetExtension(p) == item));
                            }
                        }
                    }

                    IEnumerable<string> excludeFiles = Enumerable.Empty<string>();

                    // 要排除的内容
                    if (_dictExcludeList.Values.Any())
                    {
                        if (_dictExcludeList[DeleteContentType.Folder].Any())
                        {
                            foreach (string item in _dictExcludeList[DeleteContentType.Folder])
                            {
                                excludeFiles = excludeFiles.Concat(includeFiles.Where(p => Path.GetDirectoryName(p)!.Contains(item) is false));
                            }
                        }

                        if (_dictExcludeList[DeleteContentType.FileName].Any())
                        {
                            foreach (string item in _dictExcludeList[DeleteContentType.FileName])
                            {
                                excludeFiles = excludeFiles.Concat(includeFiles.Where(p => Path.GetFileNameWithoutExtension(p).Contains(item) is false));
                            }
                        }

                        if (_dictExcludeList[DeleteContentType.FileType].Any())
                        {
                            foreach (string item in _dictExcludeList[DeleteContentType.FileType])
                            {
                                excludeFiles = excludeFiles.Concat(includeFiles.Where(p => Path.GetExtension(p) != item));
                            }
                        }
                    }

                    IEnumerable<string> files = excludeFiles.Any() ? excludeFiles : includeFiles.Any() ? includeFiles : sourceFiles;

                    foreach (string file in files)
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            // do something.
                        }
                    }
                }

                // 清理空目录
                if (param.IsCleanEmptyFolder)
                {
                    IEnumerable<string> folders = Directory.EnumerateDirectories(param.MonitorDirectories, "*", option);

                    foreach (string folder in folders)
                    {
                        try
                        {
                            Directory.Delete(folder);
                        }
                        catch (Exception ex)
                        {
                            // do something.
                        }
                    }
                }

                await Task.Delay(param.CycleTimeDelay);
            }
        }, cancellation);
    }
}