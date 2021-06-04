
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class System_Object
{
public static int GetHashCode(object _this)
{
	return _this.GetHashCode();
}

public static System.Type GetType(object _this)
{
	return _this.GetType();
}

public static string ToString(object _this)
{
	return _this.ToString();
}

}
}
