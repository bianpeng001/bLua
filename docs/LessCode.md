[TOC]

# 减少wrap代码


## 问题
如题, 遇到了项目代码量太多的问题. 由于Unity3D的一些历史原因, 所有的assembly, 最后会通过il2cpp, 转成c++代码静态编译. 最终以native代码的形式发布出去. 所以罪魁祸首, 还是il2cpp导致的.

这时候, 就遇到了代码量太多的问题. 比较极端的情况, 很无情, 都是在xcode下面:
1. 遇到跳转超过+-128M, 无法构造的情况
1. 由于单个cpp文件代码量特别多, 多到clang直接crash

Android没有爆掉, 并不代表有多安全, 只是忍者而已.

这个问题也是在特定情况下才暴露出来, 原本64位架构下面, 这点代码量能算啥, 开发团队自己手写的代码, 能多到哪里去. 但是, 由于大量第三方插件的存在, 那些插件又是很难修改的. 自然就只能让生成代码来承担了. 何况, 还能减一些内存的占用. 

就像原本是要清洗水塘, 结果还能抓不少鱼, 于是就没啥好犹豫的了.

## 方案

对于这个问题, 就不好说解决了, 但是可以想办法改善一下.

### lua栈操作函数
lua提供了一系列操作栈上数据的函数, 
    lua_pushinteger, lua_pushboolean, lua_pushnumber...
    lua_tointeger, lua_toboolean, lua_tonumber...

c#这边直接使用也是可以的, 就是代码略显繁复, 利用generic和overload, 能大大减少代码量, 简化生成代码的难度, 提高代码复用.

### push/pull

```CSharp
    public delegate void Push<T>(IntPtr L, T value);
    public delegate T Pull<T>(IntPtr L, int pos);
```

归根到底, 就是这两个函数, 往栈里压数据, 从栈里的对应pos位置取数据.

### 泛型代码

根据每个数据的类型, 初始化的时候, 注册对应的入栈出栈函数. 这个写法, 类似c++里面的泛型特化.

```CSharp
public static class TypeTrait<T>
{
    // 返回值的数量
    public static int retCount = 1;
    // 压栈
    public static Push<T> push;
    // 从栈上读取
    public static Pull<T> pull;
    
    // 初始化
    public static void Set(int aretCount, Push<T> apush, Pull<T> apull)
    {
        retCount = aretCount;
        push = apush;
        pull = apull;
    }

    static TypeTrait()
    {
        // 自动初始化
    }
}
```
retCount, 是这里做了一些特殊操作, 用来支持多个返回值那种.

这个结构是其他操作的基础, 灵活性, 扩展性, 都体现在这里了.


```CSharp
    var t1 = TypeTrait<T1>.pull(L, -3);
    var t2 = TypeTrait<T2>.pull(L, -2);
    var t3 = TypeTrait<T3>.pull(L, -1);

    TypeTrait<Result>.push(L, result);
    return 1;

```
然后代码就长一样了, 很整齐, 对于代码生成特别方便.

举例, 有一些基础数据和扩展数据的push/pull的特化

```CSharp
// int
private static void PushInt(IntPtr L, int value)
{
    lua_pushinteger(L, value);
}
private static int PullInt(IntPtr L, int pos)
{
    return (int)lua_tointeger(L, pos);
}
// double
private static double PullDouble(IntPtr L, int pos)
{
    return lua_tonumber(L, pos);
}
private static void PushDouble(IntPtr L, double value)
{
    lua_pushnumber(L, value);
}
// string
private static string PullString(IntPtr L, int pos)
{
    return lua_tostring(L, pos);
}
private static void PushString(IntPtr L, string value)
{
    lua_pushstring(L, value);
}

// 自定义数据类型的扩展
// Vector3, 转换成一个table { x,y,z }
AutoWrap.TypeTrait<Vector3>.Set(
    1,
    (L, value) =>
    {
        LuaLib.lua_createtable(L, 4, 0);
        Float.push(L, value.x);
        LuaLib.lua_rawseti(L, -2, 1);
        Float.push(L, value.y);
        LuaLib.lua_rawseti(L, -2, 2);
        Float.push(L, value.z);
        LuaLib.lua_rawseti(L, -2, 3);
    },
    (L, pos) =>
    {
        LuaLib.lua_rawgeti(L, pos, 1);
        LuaLib.lua_rawgeti(L, pos, 2);
        LuaLib.lua_rawgeti(L, pos, 3);

        Vector3 v;
        v.x = Float.pull(L, -3);
        v.y = Float.pull(L, -2);
        v.z = Float.pull(L, -1);

        LuaLib.lua_pop(L, 3);

        return v;
    });
```

###  多返回值
这个结构里面, 支持多个返回值, 也是容易的. 用在push/pull一些自定义的结构类型, 为了减少GC, 在lua栈上面以展开的形式存储.


### 节省代码
总结一下wrap过程, 主要在于复用了相同函数声明类型的lua出栈入栈代码. 简单的来说, 如果两个函数的参数是一样的, 那他的lua这里操作栈的部分, 也就可以复用. 然后实现部分, 用delegate来对应到目标方法. 然后, 作为有经验的老码农, 负责任的说, 大部分的函数, 信息主要在函数名本身, 他的用到的参数的类型, 尽管没有啥限制, 但程序员并不会用太多.

比如这几个类型
```CSharp
void f();
void f(int);
void f(int, int);
void f(string);
void f(object);
void f(object, int);
void f(object, int, int);
void f(object, string);
```
呆想想, 这几种是最多的, 参数越多的方法越少, 毕竟代码规范里面, 从来都是以少为美, 一个方法上来10个参数, 远超人类承受力. 换言之, 上面说到的上万个wrap方法里面. 有相当一部分会是参数的类型一模一样的. 按照我之前的经验数值, 只有几百种. 相比于1.5w个, 重复的代码就有上万项, 哪怕每项对应的只有10行, 就10w行代码省出来了.

