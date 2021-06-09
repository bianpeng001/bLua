[TOC]

# 实现LuaDelegate
c#的delegate同lua的function, 实现互通.

## 目标
把c#端的函数, 以delegate的形式, 函数对象, 传送到lua端, 并当做函数来使用.
看到这个目标, 第一感觉, 这不就是wrap函数要做的事情么. 对, 就是这个. 前面非这么大劲, 注册了几万个函数给lua, 全部的目的, 就是为了这个. 核心的功能到这里汇合到一起, 迷雾渐渐拨开.

整理一下需求, 我们想要的东西, 大概长这个样子:
```CSharp
static void SayHello(string msg, int id)
{
    // ...
}
```

```CSharp
RegisterDelegate(SayHello);
RegisterDelegate((string a, int b) => 
{
    // ...
});
```

```lua
local f = GetDelegate()
f('hello', 1234)
local g = GetDelegate()
g('你好', 5678)
```

到这里为止, 大有统一之势, 静态方法, 非静态的, 匿名函数, 本地函数...
如果实现了, 是不是就可以替代掉前面的那堆wrap了.


## 实现

实现的时候, 发现意外的顺利. 但总的来说, 这是一个危险的东西


## 思考

