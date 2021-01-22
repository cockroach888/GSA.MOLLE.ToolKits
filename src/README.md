[TOC]

# 各个工程的源文件目录

- 解决方案
```
dotnet new sln -n GSA2MOLLE4ToolKits
```

- 控制台示例应用程序
```
dotnet new console -lang "C#" -f net5.0 -n ToolKits.DawnConsole -o samples/ToolKits.DawnConsole/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s samples samples/ToolKits.DawnConsole/src
```

- 窗体示例应用程序
```
dotnet new winforms -lang "C#" -f net5.0 -n ToolKits.DawnApp -o samples/ToolKits.DawnApp/src
dotnet sln GSA2MOLLE4ToolKits.sln add -s samples samples/ToolKits.DawnApp/src
```

- 各类常用工具集
```
dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.DawnUtility -o ToolKits.DawnUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.DawnUtility/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.FileUtility -o ToolKits.FileUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.FileUtility/src

dotnet new classlib -lang "C#" -f net5.0 -n ToolKits.FormUtility -o ToolKits.FormUtility/src
dotnet sln GSA2MOLLE4ToolKits.sln add --in-root ToolKits.FormUtility/src

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
```

- 数据库相关工具集
```
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
```



<br /><br /><br /><br /><br />

### DawnTools

本类库其实是我自己编写的一个EXE应用程序，为了在开发过程中方便使用某些工具处理，如加解密字符串、生成GUID唯一编号、邮件收发测试、数据校验测试等，为了不给您添加麻烦，在您使用本类库时，请建立一个空的项目再添加引用，然后将项目下的“Dist”目录复制到某个位置，打开里面的“晨曦工具集.exe”开始使用。


### DawnUtility

本类库提供了数据类型转换操作辅助类、字符串拼装操作辅助类、字符串操作辅助类、非对称RSA加密类、转换人民币大小金额、C#动态类型对象处理类、DES加解密操作辅助类、晨曦常用操作辅助类、日期操作辅助类、加解密操作辅助类、实体和泛型集合与DataTable数据相互转换帮助类、验证码操作辅助类、超级整型、AES加解密操作辅助类等；实用干脆、简单实用、舒心易用，是您开发中的必备利器。


### FileUtility
本类库提供了文件、目录、图片的操作辅助类，INI文件与XML文件的操作辅助类，同时提供了一个队列化的日志操作辅助类，自由随心让日志记录不留死角，月、日、时等多种存储方式，欢迎您的品尝。


### PHYUtility

本类库提供了软件注册码辅助类、性能计数器操作辅助类、物理硬件相关操作辅助类、性能计数器等实用辅助工具类。


### DBUtility.ODBC

本类库为ODBC数据库操作独家专属，简单实用、舒心易用，是您开发中的必备利器。

### DBUtility.Oracle

本类库为Oracle数据库操作独家专属，简单实用、舒心易用，是您开发中的必备利器。


### DBUtility.Mssql

本类库为SQLServer数据库操作独家专属，简单实用、舒心易用，是您开发中的必备利器。


### DBUtility.SQLite

本类库为SQLite数据库操作独家专属，简单实用、舒心易用，是您开发中的必备利器。


### FormUtility

本类库提供了许可证管理辅助类、线程调用更新界面UI数据、后台执行事件、委托操作类、窗体特效、下载线程队列等辅助工具类，如果您是做WinForm开发，那更合适不过了。


### WebUtilitys

本类库提供了缓存操作辅助类、Cookies操作辅助类、页面运行时间辅助类、请求对象操作辅助类、WebService动态调用操作辅助类、WebService代理操作辅助类等；简单实用、舒心易用，是您开发中的必备利器。


### VerifyUtility

本类库提供了日常基本的数据校验操作辅助类，所有校验一律采用正则表达式完成，同时还有配套的基本描述信息、错误描述信息等；简单实用、舒心易用，是您开发中的必备利器。


### NuclearUtility

本类库暂只提供了电子邮件收发辅助类和FTP操作辅助类，优化并节约您的宝贵开发时间，提升开发效率，本类库我一直在用，您的选择没错！


### PagerUtility

本类库提供了中文和英文版本的分页展示工具，展示风格多样，同时还封装了基于Bootstrap框架的分页展示形式，对于微软MVC更是无下限的友好支持，欢迎您的使用。


### DBUtility.MongoDB

本类库为MongoDB数据库操作独家专属，简单实用、舒心易用，是您开发中的必备利器。


### DBUtility.Sqlce

本类库为SQLServerCE数据库操作独家专属，简单实用、舒心易用，是您开发中的必备利器。


### SafeUtility

本类库暂只包含一个可能已经落后的SQL注入检测。


### DawnRabbitMQ

收集 RabbitMQ.Client 版本库，从.Net 4.0版本开始提供。
