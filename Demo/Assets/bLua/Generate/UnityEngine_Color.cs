
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Color
{
public static string ToString(Box<UnityEngine.Color> _this)
{
	return _this.value.ToString();
}

public static string ToString(Box<UnityEngine.Color> _this, string format)
{
	return _this.value.ToString(format);
}

public static string ToString(Box<UnityEngine.Color> _this, string format, System.IFormatProvider formatProvider)
{
	return _this.value.ToString(format, formatProvider);
}

public static int GetHashCode(Box<UnityEngine.Color> _this)
{
	return _this.value.GetHashCode();
}

public static bool Equals(Box<UnityEngine.Color> _this, object other)
{
	return _this.value.Equals(other);
}

public static bool Equals(Box<UnityEngine.Color> _this, UnityEngine.Color other)
{
	return _this.value.Equals(other);
}

public static float get_grayscale(Box<UnityEngine.Color> _this)
{
	return _this.value.grayscale;
}

public static UnityEngine.Color get_linear(Box<UnityEngine.Color> _this)
{
	return _this.value.linear;
}

public static UnityEngine.Color get_gamma(Box<UnityEngine.Color> _this)
{
	return _this.value.gamma;
}

public static float get_maxColorComponent(Box<UnityEngine.Color> _this)
{
	return _this.value.maxColorComponent;
}

public static float get_Item(Box<UnityEngine.Color> _this, int index)
{
	return _this.value[index];
}
public static float set_Item(Box<UnityEngine.Color> _this, int index, float value)
{
	return _this.value[index] = value;
}
public static float get_r(UnityEngine.Color _this) => _this.r;
public static void set_r(UnityEngine.Color _this, float value) => _this.r = value;

public static float get_g(UnityEngine.Color _this) => _this.g;
public static void set_g(UnityEngine.Color _this, float value) => _this.g = value;

public static float get_b(UnityEngine.Color _this) => _this.b;
public static void set_b(UnityEngine.Color _this, float value) => _this.b = value;

public static float get_a(UnityEngine.Color _this) => _this.a;
public static void set_a(UnityEngine.Color _this, float value) => _this.a = value;

public static bLua.Box<UnityEngine.Color> New(float r, float g, float b, float a)
{
	return new UnityEngine.Color(r, g, b, a);
}
public static bLua.Box<UnityEngine.Color> New(float r, float g, float b)
{
	return new UnityEngine.Color(r, g, b);
}
}
}
