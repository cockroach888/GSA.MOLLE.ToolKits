[TOC]

# 魂哥常用工具集（GSA.MOLLE.ToolKits）

## 基于RESTful API的TDengine C# 连接器

- 基于官方提供的RESTful API接口，使用.net6(即将提供.net7支持)等前沿技术封装的TDengine连接器。本封装库提供友好统一的对外接口形态，让使用者更专注于自身业务的开发工作。通过通用主机和服务容器集成使用(也可以使用Provider直接创建)，同时提供了相应的[NuGet包](https://www.nuget.org/packages/DBUtility.TDengine)供直接引入到项目。本封装库诞生于公司自有业务应用场景，将会同步不断优化和支持。

- Based on the officially provided RESTful API interface, TDengine connectors encapsulated by cutting-edge technologies such as .net6 (.net7 support will be provided soon). This package library provides a friendly and unified external interface form, allowing users to focus more on their own business development. It is integrated and used through the common host and service container (it can also be created directly by using Provider), and the corresponding [NuGet package](https://www.nuget.org/packages/DBUtility.TDengine) is provided for direct introduction into the project. This package library was born in the company's own business application scenarios, and will be continuously optimized and supported synchronously.

- 应用示例(samples)：https://github.com/cockroach888/GSA.MOLLE.ToolKits/tree/main/src/samples/TaosData

- NOTE: 本产品在长期的开发实践工作奋战中，或创作、或摘抄、或优化、或改善、或封装、或集成、或切面等等综合而成，如有雷同，纯属他人抄袭（^_^），不然就是我在抄袭（&gt;_&lt;）；本产品经过了精心的优化改良，同时还进行了适当的完善处理，对所有归集的成品进行了分门别类放置，以供不同场景的便利使用；本产品涵盖之广，运用之丰，可以满足大、中、小等项目的自由支配使用，方便快捷、合理舒心，在使用的过程中还请注重作者劳动成果，保留必要的注释或文字标识，谢谢。


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
