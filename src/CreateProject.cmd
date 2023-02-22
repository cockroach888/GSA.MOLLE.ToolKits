@echo off
@title 自动创建解决方案及各隶属项目

set basedir="%~dp0"
set basedir
cd /d %basedir%



@echo.
@echo.
@echo.
@echo\&echo  ---------- 解决方案 ----------

dotnet new sln -n GSA2MOLLE4ToolKits





@echo.
@echo.
@echo.
@echo\&echo  ---------- 示例程序 & samples 2 ----------

dotnet new console -lang "C#" -f net6.0 -n ToolKits.DawnConsole -o samples/ToolKits.DawnConsole/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s samples samples/ToolKits.DawnConsole/src

dotnet new winforms -lang "C#" -f net6.0 -n ToolKits.DawnApp -o samples/ToolKits.DawnApp/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s samples samples/ToolKits.DawnApp/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- TDengineDB 示例程序 & TaosData 4 ----------

dotnet new console -lang "C#" -f net6.0 -n TDengineEx.Bootstrapper -o samples/TaosData/TDengineEx.Bootstrapper/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s samples/TaosData samples/TaosData/TDengineEx.Bootstrapper/src

dotnet new classlib -lang "C#" -f net6.0 -n TDengineEx.DataModel -o samples/TaosData/TDengineEx.DataModel/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s samples/TaosData samples/TaosData/TDengineEx.DataModel/src

dotnet new classlib -lang "C#" -f net6.0 -n TDengineEx.DataHelper -o samples/TaosData/TDengineEx.DataHelper/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s samples/TaosData samples/TaosData/TDengineEx.DataHelper/src

dotnet new classlib -lang "C#" -f net6.0 -n TDengineEx.DataExchange -o samples/TaosData/TDengineEx.DataExchange/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s samples/TaosData samples/TaosData/TDengineEx.DataExchange/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- 各类常用工具集 & 12 ----------

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.CockroachContainer -o ToolKits.CockroachContainer/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.CockroachContainer/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.DawnUtility -o ToolKits.DawnUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.DawnUtility/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.FileUtility -o ToolKits.FileUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.FileUtility/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.FormUtility -o ToolKits.FormUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.FormUtility/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.GoesUtility -o ToolKits.GoesUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.GoesUtility/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.NuclearUtility -o ToolKits.NuclearUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.NuclearUtility/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.PagerUtility -o ToolKits.PagerUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.PagerUtility/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.PHYUtility -o ToolKits.PHYUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.PHYUtility/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.PluginsUtility -o ToolKits.PluginsUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.PluginsUtility/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.SafeUtility -o ToolKits.SafeUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.SafeUtility/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.VerifyUtility -o ToolKits.VerifyUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.VerifyUtility/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.WebUtility -o ToolKits.WebUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.WebUtility/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- 迈向新起点再出发工具集 & Forever 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.CommonUtility -o ToolKits.CommonUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.CommonUtility/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.PagingUtility -o ToolKits.PagingUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.PagingUtility/src

dotnet new classlib -lang "C#" -f net7.0 -n ToolKits.PasswordUtility -o ToolKits.PasswordUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.PasswordUtility/src

dotnet new classlib -lang "C#" -f net7.0 -n ToolKits.EMQXUtility -o ToolKits.EMQXUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.EMQXUtility/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- 数据库访问助手工具集 & DBUtility 8 ----------

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.DBUtility.MongoDB -o ToolKits.DBUtility/ToolKits.DBUtility.MongoDB/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.MongoDB/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.DBUtility.Mssql -o ToolKits.DBUtility/ToolKits.DBUtility.Mssql/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.Mssql/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.DBUtility.ODBC -o ToolKits.DBUtility/ToolKits.DBUtility.ODBC/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.ODBC/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.DBUtility.Oracle -o ToolKits.DBUtility/ToolKits.DBUtility.Oracle/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.Oracle/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.DBUtility.Sqlce -o ToolKits.DBUtility/ToolKits.DBUtility.Sqlce/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.Sqlce/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.DBUtility.SQLite -o ToolKits.DBUtility/ToolKits.DBUtility.SQLite/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.SQLite/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.DBUtility.TDengine -o ToolKits.DBUtility/ToolKits.DBUtility.TDengine/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.TDengine/src

dotnet new classlib -lang "C#" -f net6.0 -n ToolKits.DBUtility.TDengine.Managed -o ToolKits.DBUtility/ToolKits.DBUtility.TDengine.Managed/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.TDengine.Managed/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- 项目类别 ﹫ ProjectCategory 10 ----------

::dotnet new web -lang "C#"" -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
::dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

::dotnet new blazorserver -lang "C#"" -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
::dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

::dotnet new blazorwasm -lang "C#" -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
::dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

::dotnet new mvc -lang "C#" -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
::dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

::dotnet new webapi -lang "C#" -f net6.0 --exclude-launch-settings --no-https -n LibrayName -o LibrayName/src
::dotnet sln SolutionName.sln add --in-root LibrayName/src

::dotnet new winforms -lang "C#" -f net6.0 -n LibrayName -o samples/LibrayName/src
::dotnet sln SolutionName.sln add -s samples samples/LibrayName/src

::dotnet new wpf -lang "C#" -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
::dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

::dotnet new console -lang "C#" -f net6.0 -n LibrayName -o samples/LibrayName/src
::dotnet sln SolutionName.sln add -s samples samples/LibrayName/src

::dotnet new classlib -lang "C#" -f net6.0 -n LibrayName -o LibrayName/src
::dotnet sln SolutionName.sln add --in-root LibrayName/src

::dotnet new classlib -lang "C#" -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
::dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src





::@echo\&echo 所有项目自动创建工作已结束，600 秒后将自动退出本自动创建程序。
::timeout /t 600

@echo.
@echo.
@echo.
@echo.
@echo.
@echo\&echo 所有项目自动创建完毕，请按任意键退出。
pause>nul 
exit
