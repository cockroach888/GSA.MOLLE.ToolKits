using GSA.ToolKits.DawnConsole;
using GSA.ToolKits.PasswordUtility;
using GSA.ToolKits.PasswordUtility.Entity;

Console.WriteLine("Hello World!");
Console.WriteLine();
Console.WriteLine();


//Program4CommonUtility.Default.FireInTheHole();
//Program4CommonUtility.Default.HolsterThatWeapon();

//Program4PagingUtility.Default.FireInTheHole();

//Program4EMQXUtility.Default.FireInTheHole();
//Program4EMQXUtility.Default.WeaponsHotPlus(true);
//Program4EMQXUtility.Default.WeaponsHot();

Program4ReflectionUtility.Default.FireInTheHole();



SHA512Options opt = new()
{
    SourceString = "admin123",
    Salt = "c841ee1fef56443c9dcc14f553763c12"
};

string? value = await EncryptionHelperProvider.Default.ExecuteAsync(EncryptionType.SHA512, opt).ConfigureAwait(false);

Console.WriteLine($"{value}");
Console.WriteLine();


Console.WriteLine();
Console.WriteLine();
Console.WriteLine("按任意键继续...");
Console.ReadKey();