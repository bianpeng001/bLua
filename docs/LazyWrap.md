[TOC]

# 按需注册

## 问题
使用过程里, 发现wrap的数量还是比较多的. 总的注册量肯定过万了, 包括了method,enum,property,delegate...

给一个经验数据, 1.5w项. 一次性初始化时间100ms, 手机上还要慢几倍, 内存开销10M+.

## 方案

### 枚举

建议枚举类型数据不用生成c#代码来完成注册初始化, 比如UnityEngine.KeyCode的wrap文件, 大约有2600行.
直接放到lua里面去, 枚举事实上可以当做一种常量. 全转成lua, 岂不美哉.
就是类型系统那边要做一些修改, 自动处理枚举和int, 有些额外的处理.

例如: 单位类型
```CSharp
namespace Game 
{
    public enum UnitType
    {
        NPC = 100,
        Monster,
        Player,
        Boss,
    }
}
```

转换成lua代码
```lua
Game = {}
Game.UnityType =
{
    NPC = 100,
    Monster = 101,
    Player = 102,
    Boss = 103,
}
```

### 方法和属性

属性本质上是对应到get_XXX, set_XXX两个方法, 所以归根到底是要解决方法.
方法是必须存在的, 限制逻辑代码去控制注册量是得不偿失的.

所以, 想来想去, 能有效解决这个问题, 最可行的方向就只有按需注册.

#### 实现原理

代码: lazywrap_test.lua

```lua
-- 按需注册的功能演示
local function Test1()
	local GameObject = {}
	setmetatable(GameObject, GameObject)

	function GameObject.__index(tbl, key)
		print('register method', key)
		return function(...)
			print('call method', ...)
		end
	end

	GameObject.SayHello('hello', 1234)
	GameObject.SayHello('hi', 5678)
end

```

控制台运行:
```
$ lua lazywrap_test.lua
```

控制台输出:
```
register method SayHello
call method     hello   1234
register method SayHello
call method     hi      5678
```

在触发__index的时候, 把实际的方法获取出来返回执行, 完成按需注册.


#### 第二次访问
如上面的例子, 如果第一次访问, 返回了方法但没有记录(注册), 则每次都会去查一遍方法. 并不是我们希望出现的. 
如Test1中所示, 实际上是注册了两次.

需要稍微修改一下, 代码见: Test2

```lua
local function Test2()
	local GameObject = {}
	setmetatable(GameObject, GameObject)

	function GameObject.__index(tbl, key)
		print('register method', key)
		local method = function(...)
			print('call method', ...)
		end
		rawset(tbl, key, method)
		return method
	end

	GameObject.SayHello('hello', 1234)
	GameObject.SayHello('hi', 5678)
end
```
控制台输出:
```
register method SayHello
call method     hello   1234
call method     hi      5678
```

这时候, 只注册了一次, 第二次访问的时候, 并没有触发__index了. 利用lua这个语法, 完成按需注册.

详见lua文档 [Metatables and Metamethods](https://www.lua.org/manual/5.4/manual.html#2.4)


#### 注册方法

这时候, 在赋值method的位置, 换成实际的方法. 核心功能就完成了. 不过, 细心地朋友可能已经发现, 此时能用来定位方法的信息比较少, 只有一个函数名, 以及本来就隐含的类名. 所以很自然, 我们现在有一个overload问题需要处理. 先处理注册部分, overload欠着.

```lua
local function Test3()
	local function RegisterMethod(className, methodName)
		print('register method', className, methodName)
		return function(...)
			print('call method', className, methodName, ...)
		end
	end

	local GameObject = { className="UnityEngine.GameObject" }
	setmetatable(GameObject, GameObject)
	
	function GameObject.__index(tbl, key)
		local method = RegisterMethod(GameObject.className, key)
		rawset(tbl, key, method)
		return method
	end

	GameObject.SayHello('hello', 1234)
	GameObject.SayHello('hi', 5678)
end
```

控制台输出:
```
register method UnityEngine.GameObject  SayHello
call method     UnityEngine.GameObject  SayHello        hello   1234
call method     UnityEngine.GameObject  SayHello        hi      5678
```

接下来, 把RegisterMethod换成可以注册c#方法的基础方法, 按需注册顺利完成.

#### 注册属性
c#的属性的实现, 实际上是get_XXX, set_XXX两个方法, 算是一个语法糖. 包括index这种语法, 也是一样的. c#编译器提供了一个语法糖, 把属性访问, 翻译成对这两个方法的调用.
lua这边, 只能自己做了. 需要拦截read/write两个的入口.

```lua
-- prop test
local function Test1()
    local mt = {}
    mt.__index = function(obj, k)
        print('get', obj, k)
        return 1
    end
    mt.__newindex = function(obj, k, v)
        print('set', obj, k, v)
    end

    local a = {}
    setmetatable(a, mt)

	-- read
    a.x = 1
    a.x = 2
	-- write
    print(a.x)
    print(a.y)
end
```

控制台输出:
```
set     table: 0000023399EA7A10 x       1
set     table: 0000023399EA7A10 x       2
get     table: 0000023399EA7A10 x
1
get     table: 0000023399EA7A10 y
1
```

这两个地方, 换成read/write的方法调用即可, 其他逻辑跟前面的方法注册一样.

结论, 只是为了语法完整性而支持了一下属性, 其实比直接的方法调用, 多了一个查找过程, 所以并不是特别的划算. 如果不嫌丑的话, 还是建议方法调用, 直接a:get_XXX().

#### overload
c#对overload比较友好, 只要参数不同, 就能自动定位到正确的方法. 这是静态类型语言与生俱来的一个优势.
但是动态类型语言lua里面, 要达到overload, 还要更多的信息.

先说一下tolua的做法, 做的很优秀, 效率和功能都做到了. 首先如果参数个数足够区分, 则用参数个数先判断, 这个开销很小. 当参数个数不足以区分的时候, 再判断每个参数的类型. 这个还是有一点开销的, 需要在运行时每次调用的时候判断.

所以, 建议尽量避免依赖参数类型的校验的overload.

TODO:

#### 动态wrap

动态注册相比于静态注册, 有另外一个问题要处理, 既动态的把对应的delegate实例化出来, 每次返回一个函数. 
原始的想法是这样, 可以用一个if语句, 分配每一个方法, 看起来就像这样:

```CSharp
switch(name)
{
	case "XXX":
		return XXX;
	case "YYY":
		return YYY;
}
```

功能没有问题, 思路清晰, 代码简单, 直接明了, 其实也不错. 
但就是不够优雅, 而且还需要花点时间去生成这个swith语句. 所以实际上, 我目前用的并不是这个. 性能和内存上的开销可能大一些, 后面可以把两个方案现对比一下. 不过不是重点, 暂时先用着.

动态wrap的语言基础, 从概念上来说, 有点像c++里面的成员方法指针.
```CSharp
public static Delegate CreateDelegate(Type type, object firstArgument, MethodInfo method);
```

这个就很香了, 尤其是静态方法, firstArgument是null. 简直完美. 这个delegate, 可以适用于同样参数的其他所有方法.

最终产出结果应该是一个IUnityMethod的类, 需要做必要的lua栈push/pull操作. 结合上面的TypeTrait工具类, 这里的代码就很美丽了.

```CSharp
public class Func<T1, T2, Result> : IUnityMethod
{
	public System.Func<T1, T2, Result> cb;

	public int Call(IntPtr L)
	{
		var t1 = TypeTrait<T1>.pull(L, -2);
		var t2 = TypeTrait<T2>.pull(L, -1);

		var result = cb(t1, t2);
		TypeTrait<Result>.push(L, result);

		return TypeTrait<Result>.retCount;
	}
}
```
这样的代码, 只跟参数个数有关, 于是我复制粘贴了10份, 每一个都是比上一个多一个参数, T1 ... T10, 十分的壮观
```CSharp
public int Call(IntPtr L)
{
	var t1 = TypeTrait<T1>.pull(L, -10);
	var t2 = TypeTrait<T2>.pull(L, -9);
	var t3 = TypeTrait<T3>.pull(L, -8);
	var t4 = TypeTrait<T4>.pull(L, -7);
	var t5 = TypeTrait<T5>.pull(L, -6);
	var t6 = TypeTrait<T6>.pull(L, -5);
	var t7 = TypeTrait<T7>.pull(L, -4);
	var t8 = TypeTrait<T8>.pull(L, -3);
	var t9 = TypeTrait<T9>.pull(L, -2);
	var t10 = TypeTrait<T10>.pull(L, -1);

	var result = cb(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
	TypeTrait<Result>.push(L, result);

	return TypeTrait<Result>.retCount;
}
```
10个参数够了, 真的不少了, 超出人类记忆的极限了. 想想十个正交的条件, 得有多少个结果. 提高代码阅读性来避免出现更多的参数吧.

现实比较残酷, 除了静态方法, 还有更多的是实例方法.此时firstArgument, 对应c#的this. 因为实例方法的this, 是直接带到delegate里面去的. 导致, 每一个方法, 都要创建一个单独实例上的的delegate才能调用到实例方法上去, 并且delegate的实例需要动态创建销毁, 那就比较麻烦了, 两个选择, 要么处理, 要么不处理. 我选择了后者, 但是需要做一些牺牲.

所以, 从节约的角度, 强力推荐使用静态方法. 但对于那些无法避免的实例方法咋办, 请看下节, 还是要引入一种wrap. 把 instance method 转换成 static method.

#### 另一种wrap
对于实例方法, 实例属性, 需要做一些wrap操作. 把实例方法, 变成成静态方法.
这种wrap, 其实也是要生成代码的, 但是没有跨语言调用, 且过程特别简单, 仅仅是把参数复制了一遍. 相当于操作lua栈, 并复制参数, 肯定是省多了.
```CSharp
public static void SetParent(UnityEngine.Transform _this, UnityEngine.Transform p)
{
	_this.SetParent(p);
}
public static void Translate(UnityEngine.Transform _this, float x, float y, float z)
{
	_this.Translate(x, y, z);
}
public static void LookAt(UnityEngine.Transform _this, UnityEngine.Vector3 worldPosition)
{
	_this.LookAt(worldPosition);
}
// ...
```

这是一个简单的把this指针放到第一个参数, 生成过程很简单. 目前是静态生成代码的. 后面可以考虑改成用mono.cecil把这个生成的代码隐藏一下.

#### 静态属性
这又是一个很烦人的概念, c#允许类上面有静态的属性, 而且还挺常用的.
TODO

#### 然则, 到底省在哪里?
既然还是要wrap, 一些人可能已经发现了, 相对于传统的wrap, 到底省在哪里了?
此时应该音乐响起, 真相只有一个, 下面就是见证奇迹的时刻!

[节省wrap代码](LessCode.md#节省代码)

#### 缺点
这个方案我很喜欢, 但是也有缺点, 对于il2cpp的AOT还是要额外支持一下.
TODO:
