
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

}
}
