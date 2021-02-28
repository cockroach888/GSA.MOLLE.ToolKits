@echo off
@title �Զ����������������������Ŀ

set basedir="%~dp0"
set basedir
cd /d %basedir%



@echo.
@echo.
@echo.
@echo\&echo  ---------- ������� ----------
dotnet new sln -n GSA2MOLLE4ToolKits

@echo\&echo  ---------- ����̨ʾ��Ӧ�ó��� ----------
dotnet new console -lang "C#" -f net5.0 -n ToolKits.DawnConsole -o samples/ToolKits.DawnConsole/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s samples samples/ToolKits.DawnConsole/src

@echo\&echo  ---------- ����ʾ��Ӧ�ó��� ----------
dotnet new winforms -lang "C#" -f net5.0 -n ToolKits.DawnApp -o samples/ToolKits.DawnApp/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s samples samples/ToolKits.DawnApp/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- ���ೣ�ù��߼� ----------
dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.DawnUtility -o ToolKits.DawnUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.DawnUtility/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.FileUtility -o ToolKits.FileUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.FileUtility/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.FormUtility -o ToolKits.FormUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.FormUtility/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.GoesUtility -o ToolKits.GoesUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.GoesUtility/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.NuclearUtility -o ToolKits.NuclearUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.NuclearUtility/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.PagerUtility -o ToolKits.PagerUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.PagerUtility/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.PHYUtility -o ToolKits.PHYUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.PHYUtility/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.PluginsUtility -o ToolKits.PluginsUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.PluginsUtility/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.SafeUtility -o ToolKits.SafeUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.SafeUtility/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.VerifyUtility -o ToolKits.VerifyUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.VerifyUtility/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.WebUtility -o ToolKits.WebUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.WebUtility/src



@echo.
@echo.
@echo.
@echo\&echo  ---------- ���ݿ���ع��߼� ----------
dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.DBUtility.MongoDB -o ToolKits.DBUtility/ToolKits.DBUtility.MongoDB/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.MongoDB/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.DBUtility.Mssql -o ToolKits.DBUtility/ToolKits.DBUtility.Mssql/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.Mssql/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.DBUtility.ODBC -o ToolKits.DBUtility/ToolKits.DBUtility.ODBC/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.ODBC/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.DBUtility.Oracle -o ToolKits.DBUtility/ToolKits.DBUtility.Oracle/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.Oracle/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.DBUtility.Sqlce -o ToolKits.DBUtility/ToolKits.DBUtility.Sqlce/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.Sqlce/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.DBUtility.SQLite -o ToolKits.DBUtility/ToolKits.DBUtility.SQLite/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s ToolKits.DBUtility ToolKits.DBUtility/ToolKits.DBUtility.SQLite/src





::@echo\&echo ������Ŀ�Զ����������ѽ�����600 ����Զ��˳����Զ���������
::timeout /t 600

@echo.
@echo.
@echo.
@echo.
@echo.
@echo\&echo �Զ�����������Ŀ��ϣ��밴������˳���
pause>nul 
exit