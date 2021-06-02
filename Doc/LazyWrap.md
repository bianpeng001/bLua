[TOC]

# 按需注册

## 解决什么问题
使用过程里, 发现wrap的数量还是比较多的. 总的注册量肯定过万了, 包括了method,enum,property,delegate...

给一个经验数据, 1.5w项. 一次性初始化时间100ms, 内存可能要个10M+.

## 如何解决

### 枚举
可以考虑只注册枚举的类型, 里面成员的初始化, 不用c#来完成. 直接放到lua里面去. 枚举事实上可以当做一种常量.
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
```
Game = {}
Game.UnityType = {
    NPC = 100,
    Monster = 101,
    Player = 102,
    Boss = 103,
}
```

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
lua lazywrap_test.lua
```

控制台输出:
```
get field       SayHello
call method     hello   1234
get field       SayHello
call method     hi      5678
```

可见需要在触发__index的时候, 把实际的方法获取出来返回执行, 就完成了一次按需注册.


#### 第二次访问
如上面的例子, 如果第一次访问, 返回了方法, 但没有记录(注册), 则每次都会去查一遍方法. 并不是我们希望出现的. 
如Test1中所示, 实际上是注册了两次.

需要稍微修改一下, 代码见: Test2

```lua:
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

这时候, 只注册了一次, 第二次访问的时候, 并没有触发__index了. 这是lua的语法特性, 详见lua语法, [Metatables and Metamethods](https://www.lua.org/manual/5.4/manual.html#2.4). 正好可以利用一下, 完成按需注册的目标. 此时离真相, 只有一步之遥.


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
c#, 对overload比较友好, 只要参数不同, 就能自动定位到正确的方法. 这是静态类型语言, 与生俱来的一个优势. 
但是在动态类型语言中, 缺少这个特性. 
如果了解c++的abi信息, 就知道, overload在c++里面多么的艰难, 大约就是加了一长串肉眼无法阅读的信息到函数名上面. 因为编译器的实现里面, 信息都在方法名上面了.

首先, 我们无法牺牲阅读性, 所以方法名必须原样保留. lua里面, 要做下一步区别, 就得需要更多的信息.
这时候要说一下tolua的做法了, 其实做的很优秀, 效率和功能完整性都做到了. 首先如果参数数量足够区分, 则用参数数量. 到此为止我十分喜欢, 因为判断下参数个数, 是不用计较这点苍蝇腿的. 于是, 当参数个数不足以区分的时候, 会判断参数的类型, 并分发到对应处理的方法中去. 这里, 开销明显就上去了. 心情不再那么美丽了.


