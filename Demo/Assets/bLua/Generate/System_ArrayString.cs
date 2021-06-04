
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class System_ArrayString
{
public static string Get(string[] _this, int arg0)
{
	return _this[arg0];
}

public static void Set(string[] _this, int arg0, string arg1)
{
	_this[arg0] = arg1;
}

}
}
