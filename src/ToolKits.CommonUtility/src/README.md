[TOC]

# 魂哥常用工具集（GSA.MOLLE.ToolKits）

## 功能介绍

**本库提供常见和通用的各种助手类合集，支持多种版本（netstandard2.0;netstandard2.1;net6.0;net7.0;）。**

包括但不限于如下功能类：
1. CommonHelper (常见和通用的功能应用助手类)
1. CustomAttributeHelper (自定义属性助手类)
1. DateTimeHelper (日期与时间帮助类)
1. ExpressionVisitorToSQL (将条件表达式转换为字符串SQL语句)
1. JsonSerializerMappingHelper (JSON序列化数据映射助手类，键值分离JSON序列化)
1. MockDataHelper (数据模拟助手类)
1. NetworkHelper (网络与通信助手类)
1. TDataModelHelper (数据模型属性字段名称与值字符串拼接助手类)
1. UrlHackerHelper (Url相关操作与处理助手类)

- 鄙人专注.NET技术，深入研习.NET 6|7+系列源码。本库通过长期实践工作积累落地成库，库中提供的所有功能均广泛应用于业务生产环境，同时会不间断地进行功能的优化和完善；
- 本库均由鄙人采用最新技术实践编码完成，部分功能借鉴于互联网，如有不适请告之，谢谢；
- 本库可同时满足大、中、小等各式项目的自由支配使用，以提供快捷、便利的工具方法，提升工作效率和业务能力为宗旨。

<br>

## 开发日志

### 2022-06-16
- 提供JSON序列化转换器、自定义属性方案、数据模型转换助手、时间戳转换助手等系列常见和通用功能。

### 2022-07-01
- 因之前仓促中忘记了重要的命名空间，导致未与之前库形成统一，现在纠正，为此给各位使用者带来不便，表示诚至的歉意，抱歉！！！

### 2022-08-02
- 修复TDataModelHelper中的GetColumnValueString功能实现；
- 调整名称字符串的追加位置，并调整int[]获取和追加值的方式，遇到空对象时追加空字符串。

### 2022-08-16
- 去掉DateTimeHelper类中的多余且然并卵的异步形态；
- 在考虑异步编程时，即不能为了异步而异步，更不能觉得可以写就写；
- 异步编程具有传染性质，而且用不好容易导致异步死锁，所以需求讲究一二。

### 2022-08-18
- 调整DateTimeHelper中的方法名称，使其更贴合功能所具备的涵义；
- 同步修改DateTimeHelper中各方法相应的注释内容。

### 2022-08-30
- 更正全局命名空间定义，并优化部分类的注释内容；
- 增加用于JSON序列化字段与数据映射的实体类。

### 2022-08-31
- 完成JSON序列化数据映射助手类的功能实现。

### 2022-09-01
- 优化JSON序列化数据映射助手类的功能实现；
- 调整JSON序列化数据映射返回值为枚举列表；
- 更正keyIndex为零时的有效性判断；
- 增加自定义属性助手类，用于判断是否使用某自定义属性，及获取自定义属性成员元数据；
- 增加自定义属性扩展类，为MemberInfo和Type提供助手类中的功能扩展支持。

### 2022-09-02
- 优化自定义属性助手类，完善相关方法的注释内容；
- 给自定义属性助手类增加example与code的使用示例代码；
- 优化将条件表达式转换为字符串SQL语句的示例代码内容；
- 将所有存在示例代码的内容迁移至remarks配置节中；
- 增加是否存指定泛型对象的自定义属性原生的扩展支持；
- 增加特别的可为空的类型属性，用于内部另类应用处理；
- 优化JSON序列化数据映射助手类的功能实现；
- 优化TDataModelHelper类的整体功能实现，去掉多余方法，以及相关注释内容等。

### 2022-09-05
- 调整TaosInsertIgnoreAttribute为BuildInsertSqlStringIgnoreAttribute名称；
- 调整TaosSelectIgnoreAttribute为BuildSelectSqlStringIgnoreAttribute名称；
- 还原TDataModelHelper中的原枚举独立case应用；
- 增加JsonSerializerMappingIgnoreAttribute类，用于处理映射时的忽略需求；
- 优化部分类中的注释内容，以期更能匹配其所表示的含义。

### 2022-09-06
- 优化JsonSerializerMappingIgnoreAttribute类的功能实现，补全注释内容；
- 变更CommonHelper中NewGUID方法转换大写的使用方式；
- 为CustomAttributeExtensions类增加namespace System定义，以明确其扩展；
- 优化DateTimeHelper类中GetTimestamp方法实现，将普通switch变更为模式匹配；
- 优化JsonSerializerMappingHelper类的功能实现，补全相应的注释内容；
- 优化TDataModelHelper类中的功能实现，着手为枚举增加字符串取值方式。

### 2022-09-07
- 增加JsonSerializerEnumToStringAttribute功能属性类，用于枚举序列化为字符串；
- 优化JSON序列化数据映射助手类，增加反序列化键与值分离形态的JSON字符串数据功能；
- 优化TDataModelHelper类，迁移原ConverterAsync功能方法为独立助手类；
- 增加多版本(netstandard2.0;netstandard2.1;net5.0;net6.0;)支持，并对部分编码增加条件编译；
- 优化部分功能类的注释内容，以及本库的功能介绍和打包信息等内容；
- 发布最新版本。

### 2022-09-16
- 为TDataModelHelper类中各方法，增加特别注释内容，以明确其含义；
- 优化JsonSerializerMappingHelper类中各方法，增加特别注释内容，以明确其含义；
- 优化JsonSerializerMappingHelper类中主方法实现，增加ColumnAttribute的字段比对应用。

### 2022-09-18
- 增加元组的JSON序列化自定义转换器，暂时支持1-6个元素的定义。

### 2022-10-09
- 增加网络与通信助手类(NetworkHelper)；
- 增加物理IP地址和MAC地址获取方法。

### 2022-10-13
- Url相关操作与处理助手类(UrlHackerHelper)。

### 2022-10-13
- 修正对于ValueTask的使用误解，变更为Task的直接异步形态；
- 经过查阅相关资料，ValueTask多用于缓存消费，会可能导致返回的对象或结果已释放等。

### 2022-10-20
- 修正JSON时间戳自定义转换器的数据转换时逻辑处理及转换方式；
- 增加增强版JSON时间戳自定义转换器，入参时为时间戳格式，出参时则为字符串格式。

### 2022-11-08
- 修正时间戳JSON自定义转换器中的严重BUG；
- 增加TryConvertToDateTime方法，自动根据毫秒->秒的解析，如果均失败则返回最小时间；
- 增加读取Utf8JsonReader时的Number或String判断，并相应获取数值；
- 调整时间戳JSON自定义转换器，在转换后的时间默认为本地时间。

### 2022-11-12
- 全面进入.NET 7时代，将深入研习部分技术体系及源码，增加net7.0独立编译支持；
- 去掉net5.0独立编译支持，转由netstandard标准库提供支持；
- 增加数据模拟助手类，暂提供随机生成中文功能。

### 2022-11-13
- 优化数据模拟助手随机生成中文编码；
- 增加获取指定偏移量与格式的日期时间字符串；
- 更新第三方包引用。

### 2023-02-20
- 增加GUID格式化类型枚举定义，以满足不同层面的GUID生成需求；
- 调整常见和通用的功能应用助手中的获取GUID方法，增加格式化和大小写参数，默认为“N”和小写；
- 优化README.md中的功能库涵盖注解，以及增加部分注释内容等。
