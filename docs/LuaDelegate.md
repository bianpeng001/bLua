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

实现的时候, 发现意外的顺利.


## 注意点

这种delegate, 类似于匿名函数的方式, 传一个闭包给lua, 其实隐含了闭包的上下文环境, 是一个比较隐蔽的持有luaTable, luaFunction的机会, 就有可能导致循环引用, 无法释放.
方便是方便了, 但是隐患也来了. 最好别用.



