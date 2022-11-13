[TOC]

# 魂哥常用工具集（GSA.MOLLE.ToolKits）

## 功能介绍

**基于官方提供的RESTful API接口，使用.NET 7等前沿技术封装的TDengine连接器。本封装库提供友好统一的对外接口形态，让使用者更专注于自身业务的开发工作。通过通用主机和服务容器集成使用(也可以使用Provider直接创建)，同时提供了相应的NuGet包供直接引入到项目。本封装库诞生于公司自有业务应用场景，将会同步不断优化和支持。**

- Based on the officially provided RESTful API interface, TDengine connectors encapsulated by cutting-edge technologies such as .NET 7. This package library provides a friendly and unified external interface form, allowing users to focus more on their own business development. It is integrated and used through the common host and service container (it can also be created directly by using Provider), and the corresponding NuGet package is provided for direct introduction into the project. This package library was born in the company's own business application scenarios, and will be continuously optimized and supported synchronously.
- 应用示例(samples)：https://github.com/cockroach888/GSA.MOLLE.ToolKits/tree/main/src/samples/TaosData
- 鄙人专注.NET技术，深入研习.NET 6|7+系列源码。本库通过长期实践工作积累落地成库，库中提供的所有功能均广泛应用于业务生产环境，同时会不间断地进行功能的优化和完善；
- 本库均由鄙人采用最新技术实践编码完成；本库可同时满足大、中、小等各式项目的自由支配使用，以提供快捷、便利的工具方法，提升工作效率和业务能力为宗旨。

<br>

## 开发日志

### 2022-06-16
- 面向接口编程，结合ITDengineConnector和ITDengineConnectorFactory对外提供API使用形态；可通过TDengineConnectorProvider独立使用，亦可与微软通用主机深度集成。

### 2022-06-28
- 删除不必要的 NuGet 包引用。

### 2022-07-01
- 因之前仓促中忘记了重要的命名空间，导致未与之前库形成统一，现在纠正，为此给各位使用者带来不便，表示诚至的歉意，抱歉！！！

### 2022-07-22
- 调整连接器接口参数形态，由单个参数调整为结构体形态，以满足更多扩展需求；
- 优化连接器实现中对数据库名称的使用方式；
- 调整包仓库地址指向，由指向仓库地址，变更为更具体目录地址；
- 因为调整了连接器的接口形态，将导致已使用的代码发生改变，因此给您带来的不便，深表歉意；
- 因个人工作较忙，于近期考虑增加的管理扩展，以及进一步的应用扩展示例等，需要稍晚才能编码，抱歉；
- 友情提示：请务必调整taosAdapter的默认日志级别，以避免高速入库时，因控制台日志过频导致影响效率。

### 2022-07-22
- 迁移原执行参数类(TDengineParameters)至Entity目录，并改名为通用查询参数类(TDengineQueryParam)；
- 增加条件查询参数类(TDengineWhereParam)，仅用于条件查询需求时；
- 调整所有涉及到因参数类变更，带来的的使用同步变更问题；
- 增加通用功能类(TDengineCommons)，用于提供对内和对外的日常相关工具；
- 今天脑子有些浆糊，感觉头有些重，疑似有些感冒，所以今天改的功能等会没有完全想好，先满足公司需求进行优化先。

### 2022-07-25
- 调整内部目录中各类文件的命令空间，变更为统一命名空间，以减少层级；
- 因命名空间改变带来的不便，深表歉意！同时，改变也是为了更好的使用，欢迎提出意见和建议，谢谢。

### 2022-07-28
- 增加直接执行SQL字符串的扩展方法。

### 2022-08-02
- 变更解决方案内的项目引用方式，同步依赖库的版本迭代。

### 2022-08-08
- 优化Provider中的最佳单例实践编码。

### 2022-08-17
- 修改项目的描述信息，以更贴合和符合封装库的介绍。

### 2022-08-18
- 同步更新上游依赖库，解决因臆想而使用异步，导致的异步等待假死问题。

### 2022-08-19
- 修正所有异步使用场景，并更正相应的应用实践，避免异步逻辑问题；
- 因TDengine3.0的RESTful API返回结果改动较大，正在着手支持中，敬请期待。

### 2022-08-22
- 增加TDengine版本选择器定义。

### 2022-08-25
- 优化列名称及元信息枚举的JSON转换器，增加TDengine 2.X和3.X字段类型的兼容支持；
- 优化数据类型枚举类定义，增加TDengine 2.X和3.X数据类型的兼容支持；
- 优化请求结果实体类，调整属性定义顺序和注释内容，去掉Head定义；
- 优化版本选择器中版本名称定义，调整为V2和V3的名称；
- 完成TDengine3.0的适配工作，待业务实践测试印证功能的完整性。

### 2022-09-11
- 调整项目属性，增加多版本(netstandard2.0;netstandard2.1;net5.0;net6.0;)支持；
- 优化项目属性中的NuGet打包的说明内容，以及相关信息的优化工作；
- 优化ITDengineConnector接口类，变更原有接口形态，剔除不必要的注释内容；
- 变更TDengineResult实体类的列元数据字段的数据类型，改为原生JSON格式类型；
- 优化Task返回为ValueTask返回。

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

### 2022-09-16
- 同步上游功能迭代；
- 优化并完善了DBUtility.TDengine封装库的应用示例，详见samples目录；
- 同步README.md和项目属性中的功能说明内容。

### 2022-09-18
- 同步上游功能迭代；
- 增加上游引用的依赖传递控制。

### 2022-10-13
- 修正对于ValueTask的使用误解，变更为Task的直接异步形态；
- 经过查阅相关资料，ValueTask多用于缓存消费，会可能导致返回的对象或结果已释放等；
- 恢复上游引用的自动依赖传递，以避免下游需要单独引用问题，提高用户体验。

### 2022-11-04
- 调整个别注释格式，增加空格；
- 修正TDengine条件查询参数类中的New方法，参数名称命名错误问题；
- 参数名称本应为数据表名称，结果成了SQL字符串，导致了误导性消费；
- 修正所有字符串判断，增加string.IsNullOrWhiteSpace判断，仅is not null会导致空字符串有效；
- 在WhereStringValidateAndJoinToSqlString中增加开始索引判断应用。

### 2022-11-04
- 增加数据检索与数据分页应用场景功能实现；
- 增加 TDengine 数据检索参数(TDengineSearchParam)类；
- 数据检索参数类涵盖所有数据检索相关的参数信息，如数据分页、排序、条件等；
- TDengineCommons类中增加排序和数据分页拼接方法；
- 拆分 TDengine RESTful API 连接器扩展类，变更为分部类形式；
- 增加 TDengineConnectorDataModelExtensions 并迁移相应功能；
- 增加 TDengineConnectorSingleModelExtensions 并迁移相应功能；
- 增加 TDengineConnectorSearchModelExtensions 并实现数据检索相应功能。

### 2022-11-13
- 全面进入.NET 7时代，将深入研习部分技术体系及源码，增加net7.0独立编译支持；
- 去掉net5.0独立编译支持，转由netstandard标准库提供支持；
- 变更通用主机扩展支持文件名称，优化内部编码实现；
- 更新第三方包引用。
