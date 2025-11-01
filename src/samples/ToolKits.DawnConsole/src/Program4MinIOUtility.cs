//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2025 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：Program4MinIOUtility.cs
// 项目名称：功能调测控制台程序
// 创建时间：2025-11-01 14:27:12
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.MinIOUtility;
using GSA.ToolKits.MinIOUtility.Entity;

namespace GSA.ToolKits.DawnConsole;

/// <summary>
/// MinIOUtility
/// </summary>
internal sealed class Program4MinIOUtility
{

    #region 单例模式

    private static readonly Lazy<Program4MinIOUtility> _lazyInstance = new(() => new Program4MinIOUtility());

    /// <summary>
    /// MinIOUtility
    /// </summary>
    internal static Program4MinIOUtility Default => _lazyInstance.Value;

    #endregion


    /// <summary>
    /// 小心手雷，洞中开火。
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task FireInTheHoleAsync()
    {

        MinIOOptions options = new(
            "127.0.0.1",
            15306,
            "uoJvNyUXnARWYmIJHQ4K",
            "hoQ3R3zAeR9Xe9xyqH1iTdBTu5aGhfxnFdprddFx");

        //string bucketName = $"test-bucket-{Guid.NewGuid().GetHashCode()}";

        using IMinIOHelper minIOHelper = MinIOHelperProvider.Default.New(options);

        //bool createResult = await minIOHelper.BucketOps.BucketExistsAndCreateAsync(bucketName).ConfigureAwait(false);
        //Console.WriteLine($"$创建存储桶操作：{createResult}");

        //bool existsResult = await minIOHelper.BucketOps.BucketExistsAsync(bucketName).ConfigureAwait(false);
        //Console.WriteLine($"$查询存储桶操作：{existsResult}");

        //bool removeResult = await minIOHelper.BucketOps.BucketExistsAndRemoveAsync(bucketName).ConfigureAwait(false);
        //Console.WriteLine($"$移除存储桶操作：{removeResult}");



        /*bool putResult = false;

        string dllFilePath = Path.Combine(AppContext.BaseDirectory, "ToolKits.DawnConsole.dll");
        string dllFileType = "application/x-msdownload";
        string dllObjectName = $"{Path.GetFileName(dllFilePath)}";
        using FileStream dllStream = new(dllFilePath, FileMode.Open, FileAccess.Read);
        putResult = await minIOHelper.ObjectOps.ObjectPutAsync(bucketName, dllObjectName, dllStream, dllFileType);
        //putResult = await minIOHelper.ObjectOps.ObjectExistsAndPutAsync(bucketName, dllObjectName, dllStream, dllFileType);
        Console.WriteLine($"推送存储对象 {dllObjectName} 操作：{putResult}");


        string exeFilePath = Path.Combine(AppContext.BaseDirectory, "ToolKits.DawnConsole.exe");
        string exeFileType = "application/octet-stream";
        string exeObjectName = $"{Path.GetFileName(exeFilePath)}";
        using FileStream exeStream = new(exeFilePath, FileMode.Open, FileAccess.Read);
        putResult = await minIOHelper.ObjectOps.ObjectPutAsync(bucketName, exeObjectName, exeStream, exeFileType);
        //putResult = await minIOHelper.ObjectOps.ObjectExistsAndPutAsync(bucketName, exeObjectName, exeStream, exeFileType);
        Console.WriteLine($"推送存储对象 {exeObjectName} 操作：{putResult}");


        string depsFilePath = Path.Combine(AppContext.BaseDirectory, "ToolKits.DawnConsole.deps.json");
        string depsFileType = "application/json";
        string depsObjectName = $"{Path.GetFileName(depsFilePath)}";
        using FileStream depsStream = new(depsFilePath, FileMode.Open, FileAccess.Read);
        putResult = await minIOHelper.ObjectOps.ObjectPutAsync(bucketName, depsObjectName, depsStream, depsFileType);
        //putResult = await minIOHelper.ObjectOps.ObjectExistsAndPutAsync(bucketName, depsObjectName, depsStream, depsFileType);
        Console.WriteLine($"推送存储对象 {depsObjectName} 操作：{putResult}");


        string runtimeFilePath = Path.Combine(AppContext.BaseDirectory, "ToolKits.DawnConsole.runtimeconfig.json");
        string runtimeFileType = "application/json";
        string runtimeObjectName = $"{Path.GetFileName(runtimeFilePath)}";
        using FileStream runtimeStream = new(runtimeFilePath, FileMode.Open, FileAccess.Read);
        putResult = await minIOHelper.ObjectOps.ObjectPutAsync(bucketName, runtimeObjectName, runtimeStream, runtimeFileType);
        //putResult = await minIOHelper.ObjectOps.ObjectExistsAndPutAsync(bucketName, runtimeObjectName, runtimeStream, runtimeFileType);
        Console.WriteLine($"推送存储对象 {runtimeObjectName} 操作：{putResult}");*/



        /*bool existsResult = await minIOHelper.ObjectOps.ObjectExistsAsync(bucketName, runtimeObjectName).ConfigureAwait(false);
        Console.WriteLine($"$查询存储对象 {runtimeObjectName} 操作：{existsResult}");


        string saveRuntimeFilePath = $"d://{Path.GetFileName(runtimeFilePath)}";
        using Stream? getRuntimeStream = await minIOHelper.ObjectOps.ObjectExistsAndGetWithStreamAsync(bucketName, runtimeObjectName).ConfigureAwait(false);
        //getRuntimeStream!.Position = 0;
        Console.WriteLine($"$获取存储对象 {runtimeObjectName} 操作：{getRuntimeStream?.Length}");
        using FileStream saveRuntimeStream = new(saveRuntimeFilePath, FileMode.OpenOrCreate, FileAccess.Write);
        await getRuntimeStream!.CopyToAsync(saveRuntimeStream).ConfigureAwait(false);
        await saveRuntimeStream.FlushAsync().ConfigureAwait(false);


        string saveDepsFilePath = $"d://{Path.GetFileName(depsFilePath)}";
        bool getFileReulst = await minIOHelper.ObjectOps.ObjectExistsAndGetWithFileAsync(bucketName, depsObjectName, saveDepsFilePath).ConfigureAwait(false);
        Console.WriteLine($"$获取存储对象 {depsObjectName} 操作：{getFileReulst}");


        bool removeResult = await minIOHelper.ObjectOps.ObjectExistsAndRemoveAsync(bucketName, depsObjectName).ConfigureAwait(false);
        Console.WriteLine($"$移除存储对象 {depsObjectName} 操作：{removeResult}");



        string runtimeUrlString = await minIOHelper.PresignedOps.PresignedObjectGetAsync(bucketName, runtimeObjectName, "image/jpeg").ConfigureAwait(false);
        Console.WriteLine($"$获取存储对象 {runtimeObjectName} 预指定URL操作：{runtimeUrlString}");*/



        LifecycleRuleModel lif = new("Automatically clear old storage objects", 1);

        string bucketName1 = "xj250100695-1282265133-2025";
        await minIOHelper.LifecycleOps.LifecycleSetAsync(bucketName1, lif).ConfigureAwait(false);

        string bucketName2 = "xj250100695-1394570470-2025";
        await minIOHelper.LifecycleOps.LifecycleSetAsync(bucketName2, lif).ConfigureAwait(false);

        string bucketName3 = "xj250100695-3425998202-2025";
        await minIOHelper.LifecycleOps.LifecycleSetAsync(bucketName3, lif).ConfigureAwait(false);


        var result1 = await minIOHelper.LifecycleOps.LifecycleGetAsync(bucketName1).ConfigureAwait(false);
        if (result1 is not null && result1.Rules?.Count > 0)
        {
            Console.WriteLine($"Got Bucket Lifecycle set for bucket {bucketName1}.");
            Console.WriteLine(result1.MarshalXML());
            Console.WriteLine();
        }

        var result2 = await minIOHelper.LifecycleOps.LifecycleGetAsync(bucketName2).ConfigureAwait(false);
        if (result2 is not null && result2.Rules?.Count > 0)
        {
            Console.WriteLine($"Got Bucket Lifecycle set for bucket {bucketName2}.");
            Console.WriteLine(result2.MarshalXML());
            Console.WriteLine();
        }

        var result3 = await minIOHelper.LifecycleOps.LifecycleGetAsync(bucketName3).ConfigureAwait(false);
        if (result3 is not null && result3.Rules?.Count > 0)
        {
            Console.WriteLine($"Got Bucket Lifecycle set for bucket {bucketName3}.");
            Console.WriteLine(result3.MarshalXML());
            Console.WriteLine();
        }


        await minIOHelper.LifecycleOps.LifecycleRemoveAsync(bucketName1).ConfigureAwait(false);
        await minIOHelper.LifecycleOps.LifecycleRemoveAsync(bucketName2).ConfigureAwait(false);
        await minIOHelper.LifecycleOps.LifecycleRemoveAsync(bucketName3).ConfigureAwait(false);
    }
}