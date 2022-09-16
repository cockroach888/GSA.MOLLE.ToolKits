IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .ConfigureHostConfiguration(config =>
    {
        //config.SetBasePath(Directory.GetCurrentDirectory());
        //config.AddJsonFile("hostSettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureAppConfiguration((context, configurationBuilder) =>
    {
        //configureDelegate?.Invoke(new AppHostBuilderContext(context), configurationBuilder);
    })
    .ConfigureServices((context, services) =>
    {
        // 数据库、数据表、初始数据服务 - 后台主机托管服务
        //services.AddHostedService<ResetDBBackgroundService>();

        // 气象自动站 - 主机托管服务
        services.AddHostedService<AutoStationHostedService>();
    })
    .ConfigureServices((services) =>
    {
        //services.AddSingleton<IAppHostLifetime, AppHostLifetime>();

        // 数据库、数据表、初始数据服务
        services.AddTransient<IResetDB, ResetAutoStationDB>();
    })
    .ConfigureLogging((context, logging) =>
    {
        // do something.
        //logging.ClearProviders();
        //logging.AddConsole();
    });

// 数据库服务集成
builder.UseTDengineDB();

// 数据访问助手服务集成
builder.UseAllBusinessDB();

// 阻塞式运行
await builder.Build().RunAsync().ConfigureAwait(false);


// 调皮
Console.ReadKey();