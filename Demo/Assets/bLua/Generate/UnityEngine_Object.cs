
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Object
{
public static int GetInstanceID(UnityEngine.Object _this)
{
	return _this.GetInstanceID();
}

public static int GetHashCode(UnityEngine.Object _this)
{
	return _this.GetHashCode();
}

public static bool Equals(UnityEngine.Object _this, object other)
{
	return _this.Equals(other);
}

public static string ToString(UnityEngine.Object _this)
{
	return _this.ToString();
}

public static string get_name(UnityEngine.Object _this)
{
	return _this.name;
}

public static void set_name(UnityEngine.Object _this, string value)
{
	_this.name = value;
}

public static UnityEngine.HideFlags get_hideFlags(UnityEngine.Object _this)
{
	return _this.hideFlags;
}

public static void set_hideFlags(UnityEngine.Object _this, UnityEngine.HideFlags value)
{
	_this.hideFlags = value;
}

}
}
