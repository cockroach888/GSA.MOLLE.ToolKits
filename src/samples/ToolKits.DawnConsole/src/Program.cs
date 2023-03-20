using GSA.ToolKits.DawnConsole;


Console.WriteLine("Hello World!");
Console.WriteLine();
Console.WriteLine();


Program4CommonUtility.Default.FireInTheHole();
//Program4CommonUtility.Default.HolsterThatWeapon();

//Program4PagingUtility.Default.FireInTheHole();

Program4EMQXUtility.Default.FireInTheHole();
//Program4EMQXUtility.Default.WeaponsHotPlus(true);
Program4EMQXUtility.Default.WeaponsHot();


Console.WriteLine();
Console.WriteLine();
Console.WriteLine("按任意键继续...");
Console.ReadKey();