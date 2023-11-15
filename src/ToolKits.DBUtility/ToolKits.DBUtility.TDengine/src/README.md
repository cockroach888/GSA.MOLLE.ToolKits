[TOC]

# 魂哥常用工具集（GSA.MOLLE.ToolKits）

## 功能介绍

**基于官方提供的RESTful API接口，使用.NET 7等前沿技术封装的TDengine连接器。本封装库提供友好统一的对外接口形态，让使用者更专注于自身业务的开发工作。通过通用主机和服务容器集成使用(也可以使用Provider直接创建)，同时提供了相应的NuGet包供直接引入到项目。本封装库诞生于公司自有业务应用场景，将会同步不断优化和支持。**

- Based on the officially provided RESTful API interface, TDengine connectors encapsulated by cutting-edge technologies such as .NET 7. This package library provides a friendly and unified external interface form, allowing users to focus more on their own business development. It is integrated and used through the common host and service container (it can also be created directly by using Provider), and the corresponding NuGet package is provided for direct introduction into the project. This package library was born in the company's own business application scenarios, and will be continuously optimized and supported synchronously.
- 应用示例(samples)：https://github.com/cockroach888/GSA.MOLLE.ToolKits/tree/main/src/samples/TaosData
- 鄙人专注.NET技术，深入研习.NET 6|7+系列源码。本库通过长期实践工作积累落地成库，库中提供的所有功能均广泛应用于业务生产环境，同时会不间断地进行功能的优化和完善；
- 本库均由鄙人采用最新技术实践编码完成；本库可同时满足大、中、小等各式项目的自由支配使用，以提供快捷、便利的工具方法，提升工作效率和业务能力为宗旨。

<br>

### 配置文件示例

```
"TDengineOptions": {
    "Host": "127.0.0.1",
    "Port": 10101,
    "UserName": "root",
    "Password": "taosdata",
    "TimeZone": "Asia/Shanghai",
    //"VersionSelector": "V2"
    "VersionSelector": "V3",
    "KeyNameRegex": [
        "last_row\\((.+?)\\)",
        "last\\((.+?)\\)",
        "first\\((.+?)\\)",
        "sum\\((.+?)\\)"
    ]
}
```

### 经验分享
**为了更好的使用本库，建议TDEngine数据库作如下配置：**
- 至少3个或以上的数据节点，建议不低于5个，并禁用taosAdapter服务；
- 至少3个或以上的独立taosAdapter服务，建议不低于6个，并仅部署taosAdapter服务；
- 使用 Nginx 或其它反向代理服务，提供统一接口来访问taosAdapter服务；
- Docker 可以使用compose.yml方式进行集群化应用，更高需求可以使用集群+集群等模式；
- 在TDEngine的taos.cfg配置文件中，启用时区和编码格式配置，以避免编码和时间问题；
- 在使用 RESTful API 接口服务时，同时可增加时区设置，可以同样避免时间问题。

## 开发日志

### 2023-11-15
- 升级项目到.NET 8.0版本。

### 2023-08-13
- 优化开发日志时间线排列，调整为倒序排序，以便更为清晰阅读最新开发日志内容；
- 完成时间窗口功能的编码实现，增加滑动时间窗口和翻转时间窗口两种辅助方法；
- 优化数据检索参数类，增加用于查询时使用的原生SQL语句字符串属性定义及其应用。

### 2023-07-30
- 调整开发日志时间为倒序排列，以便更快捷的明确新增功能；
- 增加将时间窗口功能加入到SQL语句中的辅助方法；

### 2023-04-04
- 增加仅用于内部返回最终执行的SQL语句，以便于应用过程中的调测等。

### 2023-03-28
- 去掉TDengine选项参数类中的用户名、密码、时区缺省值，以避免出现不必要的问题；
- 增加对用户名和密码是否为空的判断，如果为空则拋出参数为空的异常信息。

### 2023-03-16
- 更新第三方包引用版本；
- 增加用于从存储键名称中提取出正确名称的正则表达式功能。

### 2023-02-24
- 移除友元程序集配置，外部一律采用Provider调用，提升使用优雅度。

### 2023-02-23 23:47
- 迁移通用主机(GenericHost)扩展支持至DBUtility.TDengine.GenericHost功能库，使本功能库回归天然纯粹；
- 增加TDengine RESTful API 连接器创建工厂提供者，以提供本功能库独立应用支持；
- 优化TDengineOptions在连接器创建过程中的应用实践。

### 2023-02-23
- 将ITDengineConnectorFactory接口实现中的IDisposable接口，变更为接口本身包含IDisposable接口；
- 将ITDengineConnector接口实现中的IDisposable接口，变更为接口本身包含IDisposable接口；
- 调整通用主机扩展，当不存在TDengineOptions配置时，不注册默认ITDengineConnector服务；
- 更新第三方包引用。

### 2022-11-21
- 集成新增加的 RESTful API 时区设置(tz)参数。

### 2022-11-14
- 经常多种尝试，最终发现是多框架支持时编译导致，如果仅独立框架支持则不存在此问题；
- 难道WebAPI支持多框架编译？暂时不作过深研究了，工作继续推进要紧；
- 将原“<TargetFrameworks>net6.0;net7.0;”变更为“<TargetFramework>net7.0”形式。

### 2022-11-14
- 变更通用主机扩展类中方法顺序，将多参数方法后移，避免某种莫名奇妙的问题；
- 目前发现在WepAPI项目中，同时使用了Swagger功能，在执行编译时，貌似会反射到有参的方法，恰好是第一个。
- 今后在编码工作中，将严格遵循多参重载的顺序问题，以避免莫名奇妙的问题存在或出现。

### 2022-11-13
- 全面进入.NET 7时代，将深入研习部分技术体系及源码，增加net7.0独立编译支持；
- 去掉net5.0独立编译支持，转由netstandard标准库提供支持；
- 变更通用主机扩展支持文件名称，优化内部编码实现；
- 更新第三方包引用。

### 2022-11-04
- 增加数据检索与数据分页应用场景功能实现；
- 增加 TDengine 数据检索参数(TDengineSearchParam)类；
- 数据检索参数类涵盖所有数据检索相关的参数信息，如数据分页、排序、条件等；
- TDengineCommons类中增加排序和数据分页拼接方法；
- 拆分 TDengine RESTful API 连接器扩展类，变更为分部类形式；
- 增加 TDengineConnectorDataModelExtensions 并迁移相应功能；
- 增加 TDengineConnectorSingleModelExtensions 并迁移相应功能；
- 增加 TDengineConnectorSearchModelExtensions 并实现数据检索相应功能。

### 2022-11-04
- 调整个别注释格式，增加空格；
- 修正TDengine条件查询参数类中的New方法，参数名称命名错误问题；
- 参数名称本应为数据表名称，结果成了SQL字符串，导致了误导性消费；
- 修正所有字符串判断，增加string.IsNullOrWhiteSpace判断，仅is not null会导致空字符串有效；
- 在WhereStringValidateAndJoinToSqlString中增加开始索引判断应用。

### 2022-10-13
- 修正对于ValueTask的使用误解，变更为Task的直接异步形态；
- 经过查阅相关资料，ValueTask多用于缓存消费，会可能导致返回的对象或结果已释放等；
- 恢复上游引用的自动依赖传递，以避免下游需要单独引用问题，提高用户体验。

### 2022-09-18
- 同步上游功能迭代；
- 增加上游引用的依赖传递控制。

### 2022-09-16
- 同步上游功能迭代；
- 优化并完善了DBUtility.TDengine封装库的应用示例，详见samples目录；
- 同步README.md和项目属性中的功能说明内容。

### 2022-09-12
- 恢复ITDengineConnector接口类的原有形态，变更原泛型T为TRequestResult名称；
- 更改ITDengineConnector接口中方法名称用户，由Execution更改为Execute单词；
- 优化ITDengineConnector接口，增加TDengine选项参数，调整各方法的注释内容；
- 调整部分功能实现类中的逻辑判断方式，采用is null或is not null方式，以相关注释内容；
- 重构TDengine RESTful API 连接器扩展类，优化名称定义、编码实现等，并增加单模型查询扩展方法；
- 删除TDengineFieldDescConverter转换器，改为更先进的自动映射机制；
- 优化TDengineResult实体类，变更ColumnMeta和Data的数据类型为JsonNode类型；
- 优化TDengineResult实体类中自有方法，适配上游封装库功能迭代；
- 优化TDengineConnector实现类，以同步接口的优化工作；
- 发布同时支持TDengine 2.x和3.x的全新版本，原内部序列化由顺序映射进化为自动映射。

### 2022-09-11
- 调整项目属性，增加多版本(netstandard2.0;netstandard2.1;net5.0;net6.0;)支持；
- 优化项目属性中的NuGet打包的说明内容，以及相关信息的优化工作；
- 优化ITDengineConnector接口类，变更原有接口形态，剔除不必要的注释内容；
- 变更TDengineResult实体类的列元数据字段的数据类型，改为原生JSON格式类型；
- 优化Task返回为ValueTask返回。

### 2022-08-25
- 优化列名称及元信息枚举的JSON转换器，增加TDengine 2.X和3.X字段类型的兼容支持；
- 优化数据类型枚举类定义，增加TDengine 2.X和3.X数据类型的兼容支持；
- 优化请求结果实体类，调整属性定义顺序和注释内容，去掉Head定义；
- 优化版本选择器中版本名称定义，调整为V2和V3的名称；
- 完成TDengine3.0的适配工作，待业务实践测试印证功能的完整性。

### 2022-08-22
- 增加TDengine版本选择器定义。

### 2022-08-19
- 修正所有异步使用场景，并更正相应的应用实践，避免异步逻辑问题；
- 因TDengine3.0的RESTful API返回结果改动较大，正在着手支持中，敬请期待。

### 2022-08-18
- 同步更新上游依赖库，解决因臆想而使用异步，导致的异步等待假死问题。

### 2022-08-17
- 修改项目的描述信息，以更贴合和符合封装库的介绍。

### 2022-08-08
- 优化Provider中的最佳单例实践编码。

### 2022-08-02
- 变更解决方案内的项目引用方式，同步依赖库的版本迭代。

### 2022-07-28
- 增加直接执行SQL字符串的扩展方法。

### 2022-07-25
- 调整内部目录中各类文件的命令空间，变更为统一命名空间，以减少层级；
- 因命名空间改变带来的不便，深表歉意！同时，改变也是为了更好的使用，欢迎提出意见和建议，谢谢。

### 2022-07-22
- 迁移原执行参数类(TDengineParameters)至Entity目录，并改名为通用查询参数类(TDengineQueryParam)；
- 增加条件查询参数类(TDengineWhereParam)，仅用于条件查询需求时；
- 调整所有涉及到因参数类变更，带来的的使用同步变更问题；
- 增加通用功能类(TDengineCommons)，用于提供对内和对外的日常相关工具；
- 今天脑子有些浆糊，感觉头有些重，疑似有些感冒，所以今天改的功能等会没有完全想好，先满足公司需求进行优化先。

### 2022-07-22
- 调整连接器接口参数形态，由单个参数调整为结构体形态，以满足更多扩展需求；
- 优化连接器实现中对数据库名称的使用方式；
- 调整包仓库地址指向，由指向仓库地址，变更为更具体目录地址；
- 因为调整了连接器的接口形态，将导致已使用的代码发生改变，因此给您带来的不便，深表歉意；
- 因个人工作较忙，于近期考虑增加的管理扩展，以及进一步的应用扩展示例等，需要稍晚才能编码，抱歉；
- 友情提示：请务必调整taosAdapter的默认日志级别，以避免高速入库时，因控制台日志过频导致影响效率。

### 2022-07-01
- 因之前仓促中忘记了重要的命名空间，导致未与之前库形成统一，现在纠正，为此给各位使用者带来不便，表示诚至的歉意，抱歉！！！

### 2022-06-28
- 删除不必要的 NuGet 包引用。

### 2022-06-16
- 面向接口编程，结合ITDengineConnector和ITDengineConnectorFactory对外提供API使用形态；可通过TDengineConnectorProvider独立使用，亦可与微软通用主机深度集成
