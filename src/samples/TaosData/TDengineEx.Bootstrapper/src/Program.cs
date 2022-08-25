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
        services.AddHostedService<ResetDBBackgroundService>();
    })
    .ConfigureServices((services) =>
    {
        //services.AddSingleton<IAppHostLifetime, AppHostLifetime>();
        services.AddTransient<IResetDB, ResetAutoStationDB>();
    })
    .ConfigureLogging((context, logging) =>
    {
        // do something.
        //logging.ClearProviders();
        //logging.AddConsole();
    });

// 数据访问服务集成
builder.UseTDengineDB();

// 阻塞式运行
await builder.Build().RunAsync().ConfigureAwait(false);


// 调皮
Console.ReadKey();