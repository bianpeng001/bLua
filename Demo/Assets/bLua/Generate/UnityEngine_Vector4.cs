
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Vector4
{
public static void Set(Box<UnityEngine.Vector4> _this, float newX, float newY, float newZ, float newW)
{
	_this.value.Set(newX, newY, newZ, newW);
}

public static void Scale(Box<UnityEngine.Vector4> _this, UnityEngine.Vector4 scale)
{
	_this.value.Scale(scale);
}

public static int GetHashCode(Box<UnityEngine.Vector4> _this)
{
	return _this.value.GetHashCode();
}

public static bool Equals(Box<UnityEngine.Vector4> _this, object other)
{
	return _this.value.Equals(other);
}

public static bool Equals(Box<UnityEngine.Vector4> _this, UnityEngine.Vector4 other)
{
	return _this.value.Equals(other);
}

public static void Normalize(Box<UnityEngine.Vector4> _this)
{
	_this.value.Normalize();
}

public static string ToString(Box<UnityEngine.Vector4> _this)
{
	return _this.value.ToString();
}

public static string ToString(Box<UnityEngine.Vector4> _this, string format)
{
	return _this.value.ToString(format);
}

public static string ToString(Box<UnityEngine.Vector4> _this, string format, System.IFormatProvider formatProvider)
{
	return _this.value.ToString(format, formatProvider);
}

public static float SqrMagnitude(Box<UnityEngine.Vector4> _this)
{
	return _this.value.SqrMagnitude();
}

public static float get_Item(Box<UnityEngine.Vector4> _this, int index)
{
	return _this.value[index];
}
public static float set_Item(Box<UnityEngine.Vector4> _this, int index, float value)
{
	return _this.value[index] = value;
}
}
}
