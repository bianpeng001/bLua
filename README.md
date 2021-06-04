[TOC]

## 为Unity3D支持lua编程
为Unity3D提供基于lua的脚本方案, 使得Unity3D具备更新能力, 实现lua代码和C#代码相互调用. 在lua脚本中方便地使用Unity3D引擎的功能, 实现游戏所有逻辑.

## 主要的改进点
1. 函数和属性运行时按需注册使用  [(详情)](Doc/LazyWrap.md)
1. 减少wrap代码的生成代码量, 复用相同函数声明类型的wrap代码  [(详情)](Doc/LessCode.md)
1. c#对象的存储结构修改  [(详情)](Doc/ObjectCache.md)
1. 符合c#使用习惯的c#和lua之间传参接口  [(详情)](Doc/LessCode.md#泛型代码)

## 详细特性
1. 自动生成绑定代码, 不通过反射调用
1. 支持方法, 属性在运行时按照实际使用情况, 按需注册
1. 实现luaTable, 对lua中的数据读写
1. 实现luaFunction, 调用lua函数
1. .net对象存储区, 用FreeList实现, 安全高效地分配和释放  [(详情)](Doc/ObjectCache.md)
1. 整理出一套基于泛型实现c#和lua之间的传参接口
1. 实现luaDelegate, 支持动态注册c#的delegate到lua中回调  [(详情)](Doc/LuaDelegate.md)
1. 支持多返回值, 提高数据传递性能
1. 减少c#端对lua中数据的引用, 并避免循环引用  [(详情)](Doc/Cs2Lua.md)
1. 升级到lua-5.4.3, 喜闻乐见的跟进版本
1. 接上条, 原生支持int64, 分代GC
...


## 示例
1. 01_Example, 快速功能展示  [(详情)](http://aa/bb/cc)
1. 02_War, 实现MonoBehaviour的简单游戏逻辑  [(详情)](http://aa/bb/cc)

## 致谢
感谢tolua项目给予的启发, 代码和结构都十分优秀, :-)


## 联系我

本项目代码目前还不稳定, 其中有一些修改还不够成熟, 功能也较少, 不建议放到生产环境, 欢迎讨论.

email: [bianpeng001@163.com](mailto:bianpeng001@163.com)



