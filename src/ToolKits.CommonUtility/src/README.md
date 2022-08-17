[TOC]

# 魂哥常用工具集（GSA.MOLLE.ToolKits）

## 本类库为常见和通用的一些功能集合；诸如JSON序列化转换器、自定义属性方案、数据模型助手、时间戳处理等。

- 专注.Net技术栈，通过对.net6+等系列源码进行研究，展开系列技术的研习之路。内置多个独立的版本（net6.0;）。

- NOTE: 本产品在长期的开发实践工作奋战中，或创作、或摘抄、或优化、或改善、或封装、或集成、或切面等等综合而成，如有雷同，纯属他人抄袭（^_^），不然就是我在抄袭（&gt;_&lt;）；本产品经过了精心的优化改良，同时还进行了适当的完善处理，对所有归集的成品进行了分门别类放置，以供不同场景的便利使用；本产品涵盖之广，运用之丰，可以满足大、中、小等项目的自由支配使用，方便快捷、合理舒心，在使用的过程中还请注重作者劳动成果，保留必要的注释或文字标识，谢谢。


## 开发日志

### 2022-06-16
- 提供JSON序列化转换器、自定义属性方案、数据模型转换助手、时间戳转换助手等系列常见和通用功能。

### 2022-07-01
- 因之前仓促中忘记了重要的命名空间，导致未与之前库形成统一，现在纠正，为此给各位使用者带来不便，表示诚至的歉意，抱歉！！！

### 2022-08-02
- 修复TDataModelHelper中的GetColumnValueString功能实现；
- 调整名称字符串的追加位置，并调整int[]获取和追加值的方式，遇到空对象时追加空字符串。