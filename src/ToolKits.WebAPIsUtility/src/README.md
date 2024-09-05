[TOC]

# 魂哥常用工具集（GSA.MOLLE.ToolKits）

## 功能介绍

**本库主要致力于提供在WebAPI项目中规范的抽象定义和数据实体定义等功能类合集，支持多种版本（netstandard2.0;netstandard2.1;net6.0;net7.0;net8.0;）。**

包括但不限于如下功能类：
1. IDataHelperAbstractions (数据访问助手基础接口)
1. PaginationModel (数据分页信息实体类)
1. DataListResult (数据列表请求结果实体类)
1. SingleDataResult (单一数据请求结果实体类)
1. PaginationQuery (数据分页查询参数实体类)

- 鄙人专注.NET技术，深入研习.NET 8系列源码。本库通过长期实践工作积累落地成库，库中提供的所有功能均广泛应用于业务生产环境，同时会不间断地进行功能的优化和完善；
- 本库均由鄙人采用最新技术实践编码完成，根据工作中的业务实践需求封装成库，如有不明之处请告之，谢谢；
- 本库可同时满足大、中、小等各式项目的自由支配使用，以提供快捷、便利的工具方法，提升工作效率和业务能力为宗旨。

<br>

## 开发日志

### 2024-09-05
- 增加数据分页查询参数实体类(PaginationQuery)编码实现。

### 2024-09-05
- 添加数据访问助手基础接口(IDataHelperAbstractions)编码实现；
- 添加数据分页信息实体类(PaginationModel)编码实现；
- 添加数据列表请求结果实体类(DataListResult)编码实现；
- 添加单一数据请求结果实体类(SingleDataResult)编码实现。

### 2024-09-04
- 构建WebAPI接口辅助与应用工具集(WebAPIsUtility)，主要提供在WebAPI项目中规范的抽象定义和数据实体定义等功能类；
- 完成项目初始化和基础属性配置与定义。
