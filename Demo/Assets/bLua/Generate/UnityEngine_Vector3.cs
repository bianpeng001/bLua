
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Vector3
{
public static void Set(Box<UnityEngine.Vector3> _this, float newX, float newY, float newZ)
{
	_this.value.Set(newX, newY, newZ);
}

public static void Scale(Box<UnityEngine.Vector3> _this, UnityEngine.Vector3 scale)
{
	_this.value.Scale(scale);
}

public static int GetHashCode(Box<UnityEngine.Vector3> _this)
{
	return _this.value.GetHashCode();
}

public static bool Equals(Box<UnityEngine.Vector3> _this, object other)
{
	return _this.value.Equals(other);
}

public static bool Equals(Box<UnityEngine.Vector3> _this, UnityEngine.Vector3 other)
{
	return _this.value.Equals(other);
}

public static void Normalize(Box<UnityEngine.Vector3> _this)
{
	_this.value.Normalize();
}

public static string ToString(Box<UnityEngine.Vector3> _this)
{
	return _this.value.ToString();
}

public static string ToString(Box<UnityEngine.Vector3> _this, string format)
{
	return _this.value.ToString(format);
}

public static string ToString(Box<UnityEngine.Vector3> _this, string format, System.IFormatProvider formatProvider)
{
	return _this.value.ToString(format, formatProvider);
}

public static float get_Item(Box<UnityEngine.Vector3> _this, int index)
{
	return _this.value[index];
}
public static float set_Item(Box<UnityEngine.Vector3> _this, int index, float value)
{
	return _this.value[index] = value;
}
public static float get_x(UnityEngine.Vector3 _this) => _this.x;
public static void set_x(UnityEngine.Vector3 _this, float value) => _this.x = value;

public static float get_y(UnityEngine.Vector3 _this) => _this.y;
public static void set_y(UnityEngine.Vector3 _this, float value) => _this.y = value;

public static float get_z(UnityEngine.Vector3 _this) => _this.z;
public static void set_z(UnityEngine.Vector3 _this, float value) => _this.z = value;

public static bLua.Box<UnityEngine.Vector3> New(float x, float y, float z)
{
	return new UnityEngine.Vector3(x, y, z);
}
public static bLua.Box<UnityEngine.Vector3> New(float x, float y)
{
	return new UnityEngine.Vector3(x, y);
}
}
}
