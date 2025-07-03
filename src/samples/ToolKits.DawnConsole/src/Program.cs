using GSA.ToolKits.DawnConsole;
using GSA.ToolKits.PasswordUtility;
using GSA.ToolKits.PasswordUtility.Entity;
using GSA.ToolKits.MinIOUtility;


Console.WriteLine("Hello World!");
Console.WriteLine();
Console.WriteLine();



// Program4CommonUtility
//Program4CommonUtility.Default.FireInTheHole();
//Program4CommonUtility.Default.HolsterThatWeapon();
//Program4CommonUtility.Default.ImageToBase64String();


// Program4PictureUtility
//Program4PictureUtility.ImageOrBase64StringOperation();


// Program4PagingUtility
//Program4PagingUtility.Default.FireInTheHole();


// Program4EMQXUtility
//await Program4EMQXUtility.Default.GetStatusToTextAsync().ConfigureAwait(false);
//await Program4EMQXUtility.Default.GetStatusToJsonAsync().ConfigureAwait(false);

//await Program4EMQXUtility.Default.GetTelemetryStatusAsync().ConfigureAwait(false);
//await Program4EMQXUtility.Default.GetTelemetryDataAsync().ConfigureAwait(false);

//await Program4EMQXUtility.Default.UpdateTelemetryStatusAsync(true).ConfigureAwait(false);
//await Program4EMQXUtility.Default.GetTelemetryStatusAsync().ConfigureAwait(false);
//await Program4EMQXUtility.Default.GetTelemetryDataAsync().ConfigureAwait(false);
//await Program4EMQXUtility.Default.UpdateTelemetryStatusAsync(false).ConfigureAwait(false);


// Program4ReflectionUtility
//Program4ReflectionUtility.Default.FireInTheHole();


// Program4TDengineUtility
//Program4TDengineUtility.Default.FireInTheHole();



/*SHA512Options opt = new()
{
    SourceString = "admin123",
    Salt = "c841ee1fef56443c9dcc14f553763c12"
};

string? value = await EncryptionHelperProvider.Default.ExecuteAsync(EncryptionType.SHA512, opt).ConfigureAwait(false);

Console.WriteLine($"{value}");
Console.WriteLine();*/


/*
MinIOOptions options = new(
    "127.0.0.1",
    15306,
    "TNdhVD5vh0VJaloveJeo",
    "IpwklW2dhZgOS17jfBvFSU6WvjB5vpgi4g4GHzQa");

string bucketName = $"test-bucket-{Guid.NewGuid().GetHashCode()}";

using IMinIOHelper minIOHelper = MinIOHelperProvider.Default.New(options);

bool createResult = await minIOHelper.BucketOps.BucketExistsAndCreateAsync(bucketName).ConfigureAwait(false);
Console.WriteLine($"$创建存储桶操作：{createResult}");

//bool existsResult = await minIOHelper.BucketOps.BucketExistsAsync(bucketName).ConfigureAwait(false);
//Console.WriteLine($"$查询存储桶操作：{existsResult}");

//bool removeResult = await minIOHelper.BucketOps.BucketExistsAndRemoveAsync(bucketName).ConfigureAwait(false);
//Console.WriteLine($"$移除存储桶操作：{removeResult}");



bool putResult = false;

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
Console.WriteLine($"推送存储对象 {runtimeObjectName} 操作：{putResult}");



bool existsResult = await minIOHelper.ObjectOps.ObjectExistsAsync(bucketName, runtimeObjectName).ConfigureAwait(false);
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
Console.WriteLine($"$获取存储对象 {runtimeObjectName} 预指定URL操作：{runtimeUrlString}");
*/






var breakpoint = 0;


Console.WriteLine();
Console.WriteLine();
Console.WriteLine("按任意键继续...");
Console.ReadKey();