using GSA.ToolKits.DawnConsole;
using GSA.ToolKits.PasswordUtility;
using GSA.ToolKits.PasswordUtility.Entity;

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



Console.WriteLine();
Console.WriteLine();
Console.WriteLine("按任意键继续...");
Console.ReadKey();