[TOC]

## 为Unity3D支持lua编程
为Unity3D提供基于lua的脚本方案, 使得Unity3D具备更新能力, 实现lua代码和C#代码相互调用. 在lua脚本中方便地使用Unity3D引擎的功能, 实现游戏所有逻辑.

## 修改记录
1. 更新到lua5.4.4
2. 支持动态反射注册，作为静态生成代码绑定的一个补充。

## 主要的改进点
1. 函数和属性运行时按需注册使用  [(详情)](docs/LazyWrap.md)
1. 减少wrap代码的生成代码量, 复用相同函数声明类型的wrap代码  [(详情)](docs/LessCode.md)
1. c#对象的存储结构修改  [(详情)](docs/ObjectCache.md)
1. 符合c#使用习惯的c#和lua之间传参接口  [(详情)](docs/LessCode.md#泛型代码)

## 详细特性
1. 自动生成绑定代码, 不通过反射调用
1. 支持[方法](docs/LazyWrap.md#注册方法), [属性](docs/LazyWrap.md#注册属性)在运行时按照实际使用情况, 按需注册
1. 实现luaTable, 对lua中的数据读写
1. 实现luaFunction, 调用lua函数
1. .net对象存储区, 安全高效地分配和释放  [(详情)](docs/ObjectCache.md)
1. 整理出一套基于泛型实现c#和lua之间的传参接口
1. 实现luaDelegate, 支持动态注册c#的delegate到lua中回调  [(详情)](docs/LuaDelegate.md)
1. 支持多返回值, 提高数据传递性能 [(详情)](docs/LessCode.md#多返回值)
1. 减少c#端对lua中数据的引用, 避免循环引用  [(详情)](docs/Cs2Lua.md)
1. 升级到lua-5.4.3, 喜闻乐见的跟进版本
1. 接上条, 原生支持int64, 分代GC等lua特性
...

## 快速入门
```CSharp
var state = LuaClient.State;
state.DoString("print('Hello World!')");
```

## 示例
1. 01_Example, 快速功能展示  [(详情)](http://aa/bb/cc)
1. 02_War, 实现LuaBehaviour的简单游戏逻辑  [(详情)](http://aa/bb/cc)
1. 03_Reload
1. 04_HotFix
1. 05_Tower
1. 06_UI


## 致谢
感谢tolua项目给予的启发, 代码和结构都十分优秀, :-)

## 联系我

本项目代码目前还不稳定, 其中有一些修改还不够成熟, 功能也较少, 不建议放到生产环境.
目前还有不少bug, crash需要解决, 以及出错处理等, 离真实环境使用, 还有一段距离.

总之, 我希望blua是一个令人愉快的经历. 接下来还是看代码吧, have fun!!

我的联系方式, email: [bianpeng001@163.com](mailto:bianpeng001@163.com), 欢迎讨论.



