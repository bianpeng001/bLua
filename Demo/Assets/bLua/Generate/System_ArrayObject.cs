
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class System_ArrayObject
{
public static object Get(object[] _this, int arg0)
{
	return _this[arg0];
}

public static void Set(object[] _this, int arg0, object arg1)
{
	_this[arg0] = arg1;
}

public static object[] New(int arg0)
{
	return new object[arg0];
}
}
}
