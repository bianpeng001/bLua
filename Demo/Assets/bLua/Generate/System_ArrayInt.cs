
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class System_ArrayInt
{
public static int Get(int[] _this, int arg0)
{
	return _this[arg0];
}

public static void Set(int[] _this, int arg0, int arg1)
{
	_this[arg0] = arg1;
}

}
}
