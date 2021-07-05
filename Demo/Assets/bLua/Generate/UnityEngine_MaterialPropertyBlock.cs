
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_MaterialPropertyBlock
{
public static void Clear(UnityEngine.MaterialPropertyBlock _this)
{
	_this.Clear();
}

public static void SetFloat(UnityEngine.MaterialPropertyBlock _this, string name, float value)
{
	_this.SetFloat(name, value);
}

public static void SetFloat(UnityEngine.MaterialPropertyBlock _this, int nameID, float value)
{
	_this.SetFloat(nameID, value);
}

public static void SetInt(UnityEngine.MaterialPropertyBlock _this, string name, int value)
{
	_this.SetInt(name, value);
}

public static void SetInt(UnityEngine.MaterialPropertyBlock _this, int nameID, int value)
{
	_this.SetInt(nameID, value);
}

public static void SetVector(UnityEngine.MaterialPropertyBlock _this, string name, UnityEngine.Vector4 value)
{
	_this.SetVector(name, value);
}

public static void SetVector(UnityEngine.MaterialPropertyBlock _this, int nameID, UnityEngine.Vector4 value)
{
	_this.SetVector(nameID, value);
}

public static void SetColor(UnityEngine.MaterialPropertyBlock _this, string name, UnityEngine.Color value)
{
	_this.SetColor(name, value);
}

public static void SetColor(UnityEngine.MaterialPropertyBlock _this, int nameID, UnityEngine.Color value)
{
	_this.SetColor(nameID, value);
}

public static void SetMatrix(UnityEngine.MaterialPropertyBlock _this, string name, UnityEngine.Matrix4x4 value)
{
	_this.SetMatrix(name, value);
}

public static void SetMatrix(UnityEngine.MaterialPropertyBlock _this, int nameID, UnityEngine.Matrix4x4 value)
{
	_this.SetMatrix(nameID, value);
}

public static void SetBuffer(UnityEngine.MaterialPropertyBlock _this, string name, UnityEngine.ComputeBuffer value)
{
	_this.SetBuffer(name, value);
}

public static void SetBuffer(UnityEngine.MaterialPropertyBlock _this, int nameID, UnityEngine.ComputeBuffer value)
{
	_this.SetBuffer(nameID, value);
}

public static void SetBuffer(UnityEngine.MaterialPropertyBlock _this, string name, UnityEngine.GraphicsBuffer value)
{
	_this.SetBuffer(name, value);
}

public static void SetBuffer(UnityEngine.MaterialPropertyBlock _this, int nameID, UnityEngine.GraphicsBuffer value)
{
	_this.SetBuffer(nameID, value);
}

public static void SetTexture(UnityEngine.MaterialPropertyBlock _this, string name, UnityEngine.Texture value)
{
	_this.SetTexture(name, value);
}

public static void SetTexture(UnityEngine.MaterialPropertyBlock _this, int nameID, UnityEngine.Texture value)
{
	_this.SetTexture(nameID, value);
}

public static void SetTexture(UnityEngine.MaterialPropertyBlock _this, string name, UnityEngine.RenderTexture value, int element)
{
	_this.SetTexture(name, value, (UnityEngine.Rendering.RenderTextureSubElement)element);
}

public static void SetTexture(UnityEngine.MaterialPropertyBlock _this, int nameID, UnityEngine.RenderTexture value, int element)
{
	_this.SetTexture(nameID, value, (UnityEngine.Rendering.RenderTextureSubElement)element);
}

public static void SetConstantBuffer(UnityEngine.MaterialPropertyBlock _this, string name, UnityEngine.ComputeBuffer value, int offset, int size)
{
	_this.SetConstantBuffer(name, value, offset, size);
}

public static void SetConstantBuffer(UnityEngine.MaterialPropertyBlock _this, int nameID, UnityEngine.ComputeBuffer value, int offset, int size)
{
	_this.SetConstantBuffer(nameID, value, offset, size);
}

public static void SetConstantBuffer(UnityEngine.MaterialPropertyBlock _this, string name, UnityEngine.GraphicsBuffer value, int offset, int size)
{
	_this.SetConstantBuffer(name, value, offset, size);
}

public static void SetConstantBuffer(UnityEngine.MaterialPropertyBlock _this, int nameID, UnityEngine.GraphicsBuffer value, int offset, int size)
{
	_this.SetConstantBuffer(nameID, value, offset, size);
}

public static void SetFloatArray(UnityEngine.MaterialPropertyBlock _this, string name, float[] values)
{
	_this.SetFloatArray(name, values);
}

public static void SetFloatArray(UnityEngine.MaterialPropertyBlock _this, int nameID, float[] values)
{
	_this.SetFloatArray(nameID, values);
}

public static void SetVectorArray(UnityEngine.MaterialPropertyBlock _this, string name, UnityEngine.Vector4[] values)
{
	_this.SetVectorArray(name, values);
}

public static void SetVectorArray(UnityEngine.MaterialPropertyBlock _this, int nameID, UnityEngine.Vector4[] values)
{
	_this.SetVectorArray(nameID, values);
}

public static void SetMatrixArray(UnityEngine.MaterialPropertyBlock _this, string name, UnityEngine.Matrix4x4[] values)
{
	_this.SetMatrixArray(name, values);
}

public static void SetMatrixArray(UnityEngine.MaterialPropertyBlock _this, int nameID, UnityEngine.Matrix4x4[] values)
{
	_this.SetMatrixArray(nameID, values);
}

public static float GetFloat(UnityEngine.MaterialPropertyBlock _this, string name)
{
	return _this.GetFloat(name);
}

public static float GetFloat(UnityEngine.MaterialPropertyBlock _this, int nameID)
{
	return _this.GetFloat(nameID);
}

public static int GetInt(UnityEngine.MaterialPropertyBlock _this, string name)
{
	return _this.GetInt(name);
}

public static int GetInt(UnityEngine.MaterialPropertyBlock _this, int nameID)
{
	return _this.GetInt(nameID);
}

public static UnityEngine.Vector4 GetVector(UnityEngine.MaterialPropertyBlock _this, string name)
{
	return _this.GetVector(name);
}

public static UnityEngine.Vector4 GetVector(UnityEngine.MaterialPropertyBlock _this, int nameID)
{
	return _this.GetVector(nameID);
}

public static UnityEngine.Color GetColor(UnityEngine.MaterialPropertyBlock _this, string name)
{
	return _this.GetColor(name);
}

public static UnityEngine.Color GetColor(UnityEngine.MaterialPropertyBlock _this, int nameID)
{
	return _this.GetColor(nameID);
}

public static UnityEngine.Matrix4x4 GetMatrix(UnityEngine.MaterialPropertyBlock _this, string name)
{
	return _this.GetMatrix(name);
}

public static UnityEngine.Matrix4x4 GetMatrix(UnityEngine.MaterialPropertyBlock _this, int nameID)
{
	return _this.GetMatrix(nameID);
}

public static UnityEngine.Texture GetTexture(UnityEngine.MaterialPropertyBlock _this, string name)
{
	return _this.GetTexture(name);
}

public static UnityEngine.Texture GetTexture(UnityEngine.MaterialPropertyBlock _this, int nameID)
{
	return _this.GetTexture(nameID);
}

public static float[] GetFloatArray(UnityEngine.MaterialPropertyBlock _this, string name)
{
	return _this.GetFloatArray(name);
}

public static float[] GetFloatArray(UnityEngine.MaterialPropertyBlock _this, int nameID)
{
	return _this.GetFloatArray(nameID);
}

public static UnityEngine.Vector4[] GetVectorArray(UnityEngine.MaterialPropertyBlock _this, string name)
{
	return _this.GetVectorArray(name);
}

public static UnityEngine.Vector4[] GetVectorArray(UnityEngine.MaterialPropertyBlock _this, int nameID)
{
	return _this.GetVectorArray(nameID);
}

public static UnityEngine.Matrix4x4[] GetMatrixArray(UnityEngine.MaterialPropertyBlock _this, string name)
{
	return _this.GetMatrixArray(name);
}

public static UnityEngine.Matrix4x4[] GetMatrixArray(UnityEngine.MaterialPropertyBlock _this, int nameID)
{
	return _this.GetMatrixArray(nameID);
}

public static void CopySHCoefficientArraysFrom(UnityEngine.MaterialPropertyBlock _this, UnityEngine.Rendering.SphericalHarmonicsL2[] lightProbes)
{
	_this.CopySHCoefficientArraysFrom(lightProbes);
}

public static void CopySHCoefficientArraysFrom(UnityEngine.MaterialPropertyBlock _this, UnityEngine.Rendering.SphericalHarmonicsL2[] lightProbes, int sourceStart, int destStart, int count)
{
	_this.CopySHCoefficientArraysFrom(lightProbes, sourceStart, destStart, count);
}

public static void CopyProbeOcclusionArrayFrom(UnityEngine.MaterialPropertyBlock _this, UnityEngine.Vector4[] occlusionProbes)
{
	_this.CopyProbeOcclusionArrayFrom(occlusionProbes);
}

public static void CopyProbeOcclusionArrayFrom(UnityEngine.MaterialPropertyBlock _this, UnityEngine.Vector4[] occlusionProbes, int sourceStart, int destStart, int count)
{
	_this.CopyProbeOcclusionArrayFrom(occlusionProbes, sourceStart, destStart, count);
}

public static bool get_isEmpty(UnityEngine.MaterialPropertyBlock _this)
{
	return _this.isEmpty;
}

public static UnityEngine.MaterialPropertyBlock New()
{
	return new UnityEngine.MaterialPropertyBlock();
}
}
}
