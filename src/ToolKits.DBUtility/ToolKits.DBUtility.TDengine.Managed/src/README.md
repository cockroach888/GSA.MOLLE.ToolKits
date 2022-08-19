[TOC]

# 魂哥常用工具集（GSA.MOLLE.ToolKits）

## 基于RESTful API的TDengine C# 连接器的管理扩展

- 对DBUtility.TDengine封装库提供的扩展支持，提供数据库日常的管理应用等需求，诸如数据库、超级表、数据表等的管理，友好的日常管理接口使用形态，可以满足不同的应用需求。（[NuGet包](https://www.nuget.org/packages/DBUtility.TDengine.Managed)）

- The DBUtility.TDengine package library provides extended support for the daily management application requirements of the database, such as the management of databases, super tables, and data tables. The friendly daily management interface usage form in TDengine can meet different application requirements.（[NuGet package](https://www.nuget.org/packages/DBUtility.TDengine.Managed)）

- 应用示例(samples)：https://github.com/cockroach888/GSA.MOLLE.ToolKits/tree/main/src/samples/TaosData

- NOTE: 本产品在长期的开发实践工作奋战中，或创作、或摘抄、或优化、或改善、或封装、或集成、或切面等等综合而成，如有雷同，纯属他人抄袭（^_^），不然就是我在抄袭（&gt;_&lt;）；本产品经过了精心的优化改良，同时还进行了适当的完善处理，对所有归集的成品进行了分门别类放置，以供不同场景的便利使用；本产品涵盖之广，运用之丰，可以满足大、中、小等项目的自由支配使用，方便快捷、合理舒心，在使用的过程中还请注重作者劳动成果，保留必要的注释或文字标识，谢谢。


## 开发日志

### 2022-06-28
- 完成项目创建，以及打包配置、项目说明等基础内容与信息的处置工作。

### 2022-07-25
- 对DBUtility.TDengine库进行数据库管理层面的扩展封装。提供数据库日常管理的操作，以满足日常使用需求；
- 暂时实现数据库、超级数据表、数据表的创建和删除操作，其它功能后续推出。

### 2022-07-28
- 完成对数据库创建的选项参数包装，采用实体参数形式，以满足数据库创建时不同需求；
- 完成对数据库的创建、删除功能实现；
- 完成对超级数据表的创建、删除功能实现；
- 完成对数据表的创建、删除功能实现。

### 2022-08-02
- 变更解决方案内的项目引用方式，同步依赖库的版本迭代。

### 2022-08-08
- 优化Provider中的最佳单例实践编码。

### 2022-08-17
- 修改项目的描述信息，以更贴合和符合封装库的介绍。

### 2022-08-18
- 同步更新上游库依赖，以避免重大问题。

### 2022-08-19
- 因TDengine3.0的RESTful API返回结果改动较大，正在着手支持中，敬请期待。
