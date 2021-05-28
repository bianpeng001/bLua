## 前言

几个更新方案比较下来, 觉得还是lua最方便, 性能也有保证, 用户群体也大. 用久了积累一些经验, 便重新实现了一套. 没有在正式环境里验证过, 生产环境需谨慎, 学习交流放心上.

之前遇到过一些问题, wrap函数的内存占用, 方法数量, 初始化时间, 易用性等, 还有object存储生命周期的问题. 这些也还好, 最难受的还是wrap代码太多, 项目中本来代码就不少, 外加plugin, sdk等, 雪上加霜. 直到, xcode下发现一个跳转超过+-128M的问题, 导致构造失败. 究其原因还是代码太多. 虽然本质il2cpp的机制有不可推卸的责任, 但wrap代码的冗余, 也是实实在在的问题. 改不了il2cpp就只好提升自己了.

所以, 解决或者改善这些问题, 应该是大有需求的. 我把之前的一些尝试和思考, 写在这个小工程里. 不一定都合适, 主要是提供一个解决思路. 抛砖引玉, 欢迎讨论.

放到这里来, 也是为了接受社会的拷打, 提升代码质量, 为Unity3D的lua热更技术, 做一点点小小的贡献.
Unity3D的热更, 有两个流派, 一个是把lua当补丁用, 一个是把lua尽量用. 两者各有优缺点, 线上也都在使用.

## 介绍

主要功能
- 精简wrap代码量
	按照函数声明类型, 复用参数从lua端压栈出栈代码.
- 按需注册
	主要是太多了, 轻轻松松几万个, 按需的好处显而易见, 实际上并不见得所有的功能都会运行到.
- object交换区
	c#的对象, 传递给lua, 无法直接持有, 且两边都是有GC的 不能单独的释放.
- struct
	struct是c#的一个优秀设计, 但是放到这里来, 就比较痛了.
	TODO:
- 多返回值
	可以减少临时内存分配, 所以还是支持一下
- 继承关系
	类似于虚表的一个结构
- overload
	从内心是抗拒的, 需要运行时根据参数的数量, 类型, 进行二次分发. 太浪费, 可以有限支持一下根据参数个数. 另外, 提供了机制来减少overload.
- 支持泛型?
	由于il2cpp的问题, 值类型, 总归是个坑. 但后面, 应该也许可以有限地支持一下下.
- 泛型容器?
	容器还是要的, T[], List<T>, Dictionary<K, V>, HashSet<T>. 参见不支持泛型, 那条.
- delegate
	本来想不支持了, 觉得挺麻烦的, 不过做着做着, 发现意外收获. 原来真相早就在面前, 却骑驴找马, 实际做的时候, 比预想的要简单.
	有了这个, 可以做一些易用的功能了. 比如, 组件里面的临时的属性读写. 不用依赖wrap了, 可以按需方便的加.
	或者写代码的时候, 给lua那边一个回调函数.
- 升级到lua5.4.3
	升级到最新版本, 关爱强迫症患者.


## 类型机制
使用metatable来描述类型, 才能定位到对应的方法.
描述了继承关系, 唯一类型标识.


## 范例

- delegate
c#这边提供一个delegate, 在lua端调用
```CSharp
	public static LuaDelegate GetDelegate()
	{
		var method = new AutoWrap.Func<int, int, int, int>()
		{
			cb = (a, b, c) => a + b + c,
		};
		return new LuaDelegate(method);
	}
```
```lua
    local Example = bLua.Example
    local dele = Example.GetDelegate()
    print(dele)
    local sum = dele(1, 2, 3)
    print('sum', sum)
```

- 动态属性
c#给module注册两个方法, get_XXXX, set_XXXX
这样, behaviour里面的属性, 就可以方便的注册到lua的behaviour里面去, 并不用走wrap, 也不用把obj传来传去, 简单灵活. 等后面有时间, 把这个语法真的改成属性访问就更加美好了.
```CSharp
	AddProperty("path", () => path, value => path = value);
```

```lua
	print('path', module.get_path())
```

-- 初始化过程
```CSharp
{
	state = new LuaState(new LuaFileLoader());
	state.Create();

	state.DoFile("StartUp.lua");

	// init wrap
	var reg = new LuaRegister();
	Binder.Bind(reg);
	AutoWrap.Init(state, reg);
	state.DoFile("Binder.lua");
}
```

## 致谢
感谢tolua这个项目, 提供了不少思路, 学到了很多.

## 联系我
email: bianpeng001@163.com


