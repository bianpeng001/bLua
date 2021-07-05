
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Matrix4x4
{
public static bool ValidTRS(Box<UnityEngine.Matrix4x4> _this)
{
	return _this.value.ValidTRS();
}

public static void SetTRS(Box<UnityEngine.Matrix4x4> _this, UnityEngine.Vector3 pos, UnityEngine.Quaternion q, UnityEngine.Vector3 s)
{
	_this.value.SetTRS(pos, q, s);
}

public static int GetHashCode(Box<UnityEngine.Matrix4x4> _this)
{
	return _this.value.GetHashCode();
}

public static bool Equals(Box<UnityEngine.Matrix4x4> _this, object other)
{
	return _this.value.Equals(other);
}

public static bool Equals(Box<UnityEngine.Matrix4x4> _this, UnityEngine.Matrix4x4 other)
{
	return _this.value.Equals(other);
}

public static UnityEngine.Vector4 GetColumn(Box<UnityEngine.Matrix4x4> _this, int index)
{
	return _this.value.GetColumn(index);
}

public static UnityEngine.Vector4 GetRow(Box<UnityEngine.Matrix4x4> _this, int index)
{
	return _this.value.GetRow(index);
}

public static void SetColumn(Box<UnityEngine.Matrix4x4> _this, int index, UnityEngine.Vector4 column)
{
	_this.value.SetColumn(index, column);
}

public static void SetRow(Box<UnityEngine.Matrix4x4> _this, int index, UnityEngine.Vector4 row)
{
	_this.value.SetRow(index, row);
}

public static UnityEngine.Vector3 MultiplyPoint(Box<UnityEngine.Matrix4x4> _this, UnityEngine.Vector3 point)
{
	return _this.value.MultiplyPoint(point);
}

public static UnityEngine.Vector3 MultiplyPoint3x4(Box<UnityEngine.Matrix4x4> _this, UnityEngine.Vector3 point)
{
	return _this.value.MultiplyPoint3x4(point);
}

public static UnityEngine.Vector3 MultiplyVector(Box<UnityEngine.Matrix4x4> _this, UnityEngine.Vector3 vector)
{
	return _this.value.MultiplyVector(vector);
}

public static UnityEngine.Plane TransformPlane(Box<UnityEngine.Matrix4x4> _this, UnityEngine.Plane plane)
{
	return _this.value.TransformPlane(plane);
}

public static string ToString(Box<UnityEngine.Matrix4x4> _this)
{
	return _this.value.ToString();
}

public static string ToString(Box<UnityEngine.Matrix4x4> _this, string format)
{
	return _this.value.ToString(format);
}

public static string ToString(Box<UnityEngine.Matrix4x4> _this, string format, System.IFormatProvider formatProvider)
{
	return _this.value.ToString(format, formatProvider);
}

public static UnityEngine.Quaternion get_rotation(Box<UnityEngine.Matrix4x4> _this)
{
	return _this.value.rotation;
}

public static UnityEngine.Vector3 get_lossyScale(Box<UnityEngine.Matrix4x4> _this)
{
	return _this.value.lossyScale;
}

public static bool get_isIdentity(Box<UnityEngine.Matrix4x4> _this)
{
	return _this.value.isIdentity;
}

public static float get_determinant(Box<UnityEngine.Matrix4x4> _this)
{
	return _this.value.determinant;
}

public static UnityEngine.FrustumPlanes get_decomposeProjection(Box<UnityEngine.Matrix4x4> _this)
{
	return _this.value.decomposeProjection;
}

public static UnityEngine.Matrix4x4 get_inverse(Box<UnityEngine.Matrix4x4> _this)
{
	return _this.value.inverse;
}

public static UnityEngine.Matrix4x4 get_transpose(Box<UnityEngine.Matrix4x4> _this)
{
	return _this.value.transpose;
}

public static float get_m00(UnityEngine.Matrix4x4 _this) => _this.m00;
public static void set_m00(UnityEngine.Matrix4x4 _this, float value) => _this.m00 = value;

public static float get_m10(UnityEngine.Matrix4x4 _this) => _this.m10;
public static void set_m10(UnityEngine.Matrix4x4 _this, float value) => _this.m10 = value;

public static float get_m20(UnityEngine.Matrix4x4 _this) => _this.m20;
public static void set_m20(UnityEngine.Matrix4x4 _this, float value) => _this.m20 = value;

public static float get_m30(UnityEngine.Matrix4x4 _this) => _this.m30;
public static void set_m30(UnityEngine.Matrix4x4 _this, float value) => _this.m30 = value;

public static float get_m01(UnityEngine.Matrix4x4 _this) => _this.m01;
public static void set_m01(UnityEngine.Matrix4x4 _this, float value) => _this.m01 = value;

public static float get_m11(UnityEngine.Matrix4x4 _this) => _this.m11;
public static void set_m11(UnityEngine.Matrix4x4 _this, float value) => _this.m11 = value;

public static float get_m21(UnityEngine.Matrix4x4 _this) => _this.m21;
public static void set_m21(UnityEngine.Matrix4x4 _this, float value) => _this.m21 = value;

public static float get_m31(UnityEngine.Matrix4x4 _this) => _this.m31;
public static void set_m31(UnityEngine.Matrix4x4 _this, float value) => _this.m31 = value;

public static float get_m02(UnityEngine.Matrix4x4 _this) => _this.m02;
public static void set_m02(UnityEngine.Matrix4x4 _this, float value) => _this.m02 = value;

public static float get_m12(UnityEngine.Matrix4x4 _this) => _this.m12;
public static void set_m12(UnityEngine.Matrix4x4 _this, float value) => _this.m12 = value;

public static float get_m22(UnityEngine.Matrix4x4 _this) => _this.m22;
public static void set_m22(UnityEngine.Matrix4x4 _this, float value) => _this.m22 = value;

public static float get_m32(UnityEngine.Matrix4x4 _this) => _this.m32;
public static void set_m32(UnityEngine.Matrix4x4 _this, float value) => _this.m32 = value;

public static float get_m03(UnityEngine.Matrix4x4 _this) => _this.m03;
public static void set_m03(UnityEngine.Matrix4x4 _this, float value) => _this.m03 = value;

public static float get_m13(UnityEngine.Matrix4x4 _this) => _this.m13;
public static void set_m13(UnityEngine.Matrix4x4 _this, float value) => _this.m13 = value;

public static float get_m23(UnityEngine.Matrix4x4 _this) => _this.m23;
public static void set_m23(UnityEngine.Matrix4x4 _this, float value) => _this.m23 = value;

public static float get_m33(UnityEngine.Matrix4x4 _this) => _this.m33;
public static void set_m33(UnityEngine.Matrix4x4 _this, float value) => _this.m33 = value;

public static bLua.Box<UnityEngine.Matrix4x4> New(UnityEngine.Vector4 column0, UnityEngine.Vector4 column1, UnityEngine.Vector4 column2, UnityEngine.Vector4 column3)
{
	return new UnityEngine.Matrix4x4(column0, column1, column2, column3);
}
}
}
