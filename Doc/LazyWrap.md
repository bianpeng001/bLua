[TOC]

# 按需注册

## 问题
使用过程里, 发现wrap的数量还是比较多的. 总的注册量肯定过万了, 包括了method,enum,property,delegate...

给一个经验数据, 1.5w项. 一次性初始化时间100ms, 手机上还要慢几倍, 内存开销10M+.

## 方案

### 枚举

建议枚举类型数据不用c#来完成. 直接放到lua里面去. 枚举事实上可以当做一种常量.
这样的话, 就是类型系统那边要做一些额外的处理.

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
Game.UnityType = {
    NPC = 100,
    Monster = 101,
    Player = 102,
    Boss = 103,
}
```
直接放到lua里面去初始化枚举数据, 也减掉不少wrap代码量.

比如UnityEngine.KeyCode的wrap文件, 原本有2600行, 全转成lua, 岂不美哉.

### 方法和属性

属性本质上是对应到get_XXX, set_XXX两个方法, 所以归根到底是要解决方法.
方法是必须存在的, 限制逻辑代码去控制注册量是得不偿失的.

所以, 想来想去, 能有效解决这个问题, 最简单可行的方法, 就只有按需注册了.

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
$lua lazywrap_test.lua
```

控制台输出:
```
get field       SayHello
call method     hello   1234
get field       SayHello
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


#### 方法注册

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

#### overload
c#对overload比较友好, 只要参数不同, 就能自动定位到正确的方法. 这是静态类型语言与生俱来的一个优势.
但是动态类型语言lua里面, 要达到overload, 还要更多的信息.

先说一下tolua的做法, 做的很优秀, 效率和功能都做到了. 首先如果参数个数足够区分, 则用参数个数先判断, 这个开销很小. 当参数个数不足以区分的时候, 再判断每个参数的类型. 这个还是有一点开销的, 需要在运行时每次调用的时候判断.

所以, 建议尽量避免依赖参数类型的校验的overload.


### 动态wrap

动态注册相比于静态注册, 有另外一个问题要处理, 既动态的把对应的delegate实例化出来, 每次返回一个函数. 我们可以用一个if语句, 来分配每一个方法, 看起来就像这样

```
switch(name)
{
	case 'XXX':
		return XXX;
	case 'YYY':
		return YYY;
}
```

功能没有问题, 思路清晰, 代码简单, 直接明了, 是一个不错的方式. 其实我还是找到了另一个方案2, 不一定比这个好, 也算是目前.net框架下面可以利用的一个feature.

### 需要另一种wrap
这种wrap, 其实也是要生成代码的, 但是看上去没有跨语言调用, 且逻辑特别简单, 有理由相信, .net内部复制一次参数的值, 是一个无足轻重的操作.

### 然则, 到底省在哪里?
既然还是要wrap, 一些刻薄的人立马就产生一个疑问, 相对于传统的wrap, 到底哪里省了?
此时应该音乐响起, 真相只有一个, 下面就是见证奇迹的时刻!


### 缺点
这个方案我很喜欢, 但是也有缺点, 对于il2cpp的AOT还是要额外支持一下.

