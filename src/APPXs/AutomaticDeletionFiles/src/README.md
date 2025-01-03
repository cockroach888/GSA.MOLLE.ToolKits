[TOC]

# 魂哥常用工具集（GSA.MOLLE.ToolKits）

## 功能介绍

**自动删除文件工具，采用WPF、WebView2、CeriumX.WebEngine.WebView2、HTML、CSS、JS及前端相关功能库等实现。**

- 鄙人专注.NET技术，深入研习.NET 9系列源码。本工具以提供快捷、便利、提升工作效率和业务能力为宗旨；
- 本工具均由鄙人采用最新技术实践编码完成，主要实现自动删除文件的相关功能，以解决相应场景的需求；
- 采用周期轮询的方式，既间隔一定时间后，进行前置时间外的文件删除处理，以及相关功能的实现；
- 包括但不限于：日、时、分、秒的前置时间，轮询周期、是否涵盖子目录，及排除目录、文件、文件类型等功能。

<br>

## 开发日志

### 2024-12-04
- 升级项目到.NET 9版本。

### 2023-11-19
- 更新第三方包引用；
- 优化部分代码实现。

### 2023-11-15
- 升级项目到.NET 8版本，修复包含内容和排除内容的添加与移除问题，优化相关功能的编码实现；
- 优化appsettings.json配置文件和部分功能代码。

### 2023-11-14
- 夜深了，优化目录、文件、类型的匹配规则；
- 夜很深了，改进要包含的内容和要排除的内容的匹配规则，匹配层级为目录至文件至类型。

### 2023-11-14
- 清理不需要的资源集成；
- 变更控制器注入方式，由服务集成变更为实例化使用的方式；
- 增加main.css文件，用于编写需要的样式内容，增加弹出对话框格式化；
- 优化主窗体控制器所需服务的注入方式和相关使用方式，由方法传入变更为构造函数指定；
- 去掉前置时间单位属性及其枚举定义，变更前置时间为TimeSpan形式，以直接满足日时分秒需求；
- 优化主窗体控服务的功能编码实现，调整开始和停止方法为异步形式；
- 调整数值输入为number标签，前置时间变更为time标签，图标直接使用svg元素，优化相关js使用方式；
- 清理main.js中多余的代码，调整轮询周期为time标签，参数字段为TimeSpan类型；
- 调整开始事件返回为数组，同时返回文本内容和提示类型两者；
- 优化主窗体服务的功能编码实现，增加CTS和任务的轮询执行等；
- 增加是否清理所有层级的空目录功能，增加开始和停止的按钮控制，优化部分功能的编码实现。

### 2023-11-13
- 夜深了，完成粗略的主体功能的编码实现，真的就是粗略得很。

### 2023-11-12
- 夜深了，继续着手主体功能的编码实现工作。

### 2023-11-12
- 增加排除临时文件和文件夹的选项与应用；
- 着手主体功能的编码实现工作。

### 2023-11-10
- 完成功能页面的所有人机交互功能和逻辑处理等工作；
- 完善部分功能处置，着手主要功能逻辑的代码编写。

### 2023-11-09
- 集成bootstrap-icons前端图标库；
- 完成主界面的功能设计和排版还原等工作。

### 2023-11-08
- 集成Shoelace前端UI组件库(web components)、jQuery前端JS功能库、Knockout前端双向绑定功能库；
- 去除Shoelace集成与应用，集成Bootstrap前端UI库、Flatpickr日期组件库、SweetAlert消息组件库、WenQue自研工具库等；
- 完成通用主机和CeriumX.WebEngine.WebView2的集成，以及前端技术的应用与处理工作；
- 增加F12显示开发者工具栏功能，增加MainWindowController控制器注入前端对象功能；
- 完成后端与前端的相关直接交互验证，着手界面的原型设计和还原实现，及其功能研发。

### 2023-11-07
- 增加appsettings全局配置配套文件；
- 集成通用主机和CeriumX.WebEngine.WebView2组件等功能，及其相关的基础配置等工作。

### 2023-11-03
- 初始化项目及其基础配置等工作。
