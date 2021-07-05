
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Vector2
{
public static void Set(Box<UnityEngine.Vector2> _this, float newX, float newY)
{
	_this.value.Set(newX, newY);
}

public static void Scale(Box<UnityEngine.Vector2> _this, UnityEngine.Vector2 scale)
{
	_this.value.Scale(scale);
}

public static void Normalize(Box<UnityEngine.Vector2> _this)
{
	_this.value.Normalize();
}

public static string ToString(Box<UnityEngine.Vector2> _this)
{
	return _this.value.ToString();
}

public static string ToString(Box<UnityEngine.Vector2> _this, string format)
{
	return _this.value.ToString(format);
}

public static string ToString(Box<UnityEngine.Vector2> _this, string format, System.IFormatProvider formatProvider)
{
	return _this.value.ToString(format, formatProvider);
}

public static int GetHashCode(Box<UnityEngine.Vector2> _this)
{
	return _this.value.GetHashCode();
}

public static bool Equals(Box<UnityEngine.Vector2> _this, object other)
{
	return _this.value.Equals(other);
}

public static bool Equals(Box<UnityEngine.Vector2> _this, UnityEngine.Vector2 other)
{
	return _this.value.Equals(other);
}

public static float SqrMagnitude(Box<UnityEngine.Vector2> _this)
{
	return _this.value.SqrMagnitude();
}

public static float get_Item(Box<UnityEngine.Vector2> _this, int index)
{
	return _this.value[index];
}
public static float set_Item(Box<UnityEngine.Vector2> _this, int index, float value)
{
	return _this.value[index] = value;
}
public static float get_x(UnityEngine.Vector2 _this) => _this.x;
public static void set_x(UnityEngine.Vector2 _this, float value) => _this.x = value;

public static float get_y(UnityEngine.Vector2 _this) => _this.y;
public static void set_y(UnityEngine.Vector2 _this, float value) => _this.y = value;

public static bLua.Box<UnityEngine.Vector2> New(float x, float y)
{
	return new UnityEngine.Vector2(x, y);
}
}
}
