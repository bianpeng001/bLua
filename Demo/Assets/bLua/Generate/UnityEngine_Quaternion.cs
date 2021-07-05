
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Quaternion
{
public static void Set(Box<UnityEngine.Quaternion> _this, float newX, float newY, float newZ, float newW)
{
	_this.value.Set(newX, newY, newZ, newW);
}

public static void SetLookRotation(Box<UnityEngine.Quaternion> _this, UnityEngine.Vector3 view)
{
	_this.value.SetLookRotation(view);
}

public static void SetLookRotation(Box<UnityEngine.Quaternion> _this, UnityEngine.Vector3 view, UnityEngine.Vector3 up)
{
	_this.value.SetLookRotation(view, up);
}

public static void SetFromToRotation(Box<UnityEngine.Quaternion> _this, UnityEngine.Vector3 fromDirection, UnityEngine.Vector3 toDirection)
{
	_this.value.SetFromToRotation(fromDirection, toDirection);
}

public static void Normalize(Box<UnityEngine.Quaternion> _this)
{
	_this.value.Normalize();
}

public static int GetHashCode(Box<UnityEngine.Quaternion> _this)
{
	return _this.value.GetHashCode();
}

public static bool Equals(Box<UnityEngine.Quaternion> _this, object other)
{
	return _this.value.Equals(other);
}

public static bool Equals(Box<UnityEngine.Quaternion> _this, UnityEngine.Quaternion other)
{
	return _this.value.Equals(other);
}

public static string ToString(Box<UnityEngine.Quaternion> _this)
{
	return _this.value.ToString();
}

public static string ToString(Box<UnityEngine.Quaternion> _this, string format)
{
	return _this.value.ToString(format);
}

public static string ToString(Box<UnityEngine.Quaternion> _this, string format, System.IFormatProvider formatProvider)
{
	return _this.value.ToString(format, formatProvider);
}

public static float get_Item(Box<UnityEngine.Quaternion> _this, int index)
{
	return _this.value[index];
}
public static float set_Item(Box<UnityEngine.Quaternion> _this, int index, float value)
{
	return _this.value[index] = value;
}
public static float get_x(UnityEngine.Quaternion _this) => _this.x;
public static void set_x(UnityEngine.Quaternion _this, float value) => _this.x = value;

public static float get_y(UnityEngine.Quaternion _this) => _this.y;
public static void set_y(UnityEngine.Quaternion _this, float value) => _this.y = value;

public static float get_z(UnityEngine.Quaternion _this) => _this.z;
public static void set_z(UnityEngine.Quaternion _this, float value) => _this.z = value;

public static float get_w(UnityEngine.Quaternion _this) => _this.w;
public static void set_w(UnityEngine.Quaternion _this, float value) => _this.w = value;

public static bLua.Box<UnityEngine.Quaternion> New(float x, float y, float z, float w)
{
	return new UnityEngine.Quaternion(x, y, z, w);
}
}
}
