
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Material
{
public static bool HasProperty(UnityEngine.Material _this, int nameID)
{
	return _this.HasProperty(nameID);
}

public static bool HasProperty(UnityEngine.Material _this, string name)
{
	return _this.HasProperty(name);
}

public static void EnableKeyword(UnityEngine.Material _this, string keyword)
{
	_this.EnableKeyword(keyword);
}

public static void DisableKeyword(UnityEngine.Material _this, string keyword)
{
	_this.DisableKeyword(keyword);
}

public static bool IsKeywordEnabled(UnityEngine.Material _this, string keyword)
{
	return _this.IsKeywordEnabled(keyword);
}

public static void SetShaderPassEnabled(UnityEngine.Material _this, string passName, bool enabled)
{
	_this.SetShaderPassEnabled(passName, enabled);
}

public static bool GetShaderPassEnabled(UnityEngine.Material _this, string passName)
{
	return _this.GetShaderPassEnabled(passName);
}

public static string GetPassName(UnityEngine.Material _this, int pass)
{
	return _this.GetPassName(pass);
}

public static int FindPass(UnityEngine.Material _this, string passName)
{
	return _this.FindPass(passName);
}

public static void SetOverrideTag(UnityEngine.Material _this, string tag, string val)
{
	_this.SetOverrideTag(tag, val);
}

public static string GetTag(UnityEngine.Material _this, string tag, bool searchFallbacks, string defaultValue)
{
	return _this.GetTag(tag, searchFallbacks, defaultValue);
}

public static string GetTag(UnityEngine.Material _this, string tag, bool searchFallbacks)
{
	return _this.GetTag(tag, searchFallbacks);
}

public static void Lerp(UnityEngine.Material _this, UnityEngine.Material start, UnityEngine.Material end, float t)
{
	_this.Lerp(start, end, t);
}

public static bool SetPass(UnityEngine.Material _this, int pass)
{
	return _this.SetPass(pass);
}

public static void CopyPropertiesFromMaterial(UnityEngine.Material _this, UnityEngine.Material mat)
{
	_this.CopyPropertiesFromMaterial(mat);
}

public static int ComputeCRC(UnityEngine.Material _this)
{
	return _this.ComputeCRC();
}

public static string[] GetTexturePropertyNames(UnityEngine.Material _this)
{
	return _this.GetTexturePropertyNames();
}

public static int[] GetTexturePropertyNameIDs(UnityEngine.Material _this)
{
	return _this.GetTexturePropertyNameIDs();
}

public static void SetFloat(UnityEngine.Material _this, string name, float value)
{
	_this.SetFloat(name, value);
}

public static void SetFloat(UnityEngine.Material _this, int nameID, float value)
{
	_this.SetFloat(nameID, value);
}

public static void SetInt(UnityEngine.Material _this, string name, int value)
{
	_this.SetInt(name, value);
}

public static void SetInt(UnityEngine.Material _this, int nameID, int value)
{
	_this.SetInt(nameID, value);
}

public static void SetColor(UnityEngine.Material _this, string name, UnityEngine.Color value)
{
	_this.SetColor(name, value);
}

public static void SetColor(UnityEngine.Material _this, int nameID, UnityEngine.Color value)
{
	_this.SetColor(nameID, value);
}

public static void SetVector(UnityEngine.Material _this, string name, UnityEngine.Vector4 value)
{
	_this.SetVector(name, value);
}

public static void SetVector(UnityEngine.Material _this, int nameID, UnityEngine.Vector4 value)
{
	_this.SetVector(nameID, value);
}

public static void SetMatrix(UnityEngine.Material _this, string name, UnityEngine.Matrix4x4 value)
{
	_this.SetMatrix(name, value);
}

public static void SetMatrix(UnityEngine.Material _this, int nameID, UnityEngine.Matrix4x4 value)
{
	_this.SetMatrix(nameID, value);
}

public static void SetTexture(UnityEngine.Material _this, string name, UnityEngine.Texture value)
{
	_this.SetTexture(name, value);
}

public static void SetTexture(UnityEngine.Material _this, int nameID, UnityEngine.Texture value)
{
	_this.SetTexture(nameID, value);
}

public static void SetTexture(UnityEngine.Material _this, string name, UnityEngine.RenderTexture value, int element)
{
	_this.SetTexture(name, value, (UnityEngine.Rendering.RenderTextureSubElement)element);
}

public static void SetTexture(UnityEngine.Material _this, int nameID, UnityEngine.RenderTexture value, int element)
{
	_this.SetTexture(nameID, value, (UnityEngine.Rendering.RenderTextureSubElement)element);
}

public static void SetBuffer(UnityEngine.Material _this, string name, UnityEngine.ComputeBuffer value)
{
	_this.SetBuffer(name, value);
}

public static void SetBuffer(UnityEngine.Material _this, int nameID, UnityEngine.ComputeBuffer value)
{
	_this.SetBuffer(nameID, value);
}

public static void SetBuffer(UnityEngine.Material _this, string name, UnityEngine.GraphicsBuffer value)
{
	_this.SetBuffer(name, value);
}

public static void SetBuffer(UnityEngine.Material _this, int nameID, UnityEngine.GraphicsBuffer value)
{
	_this.SetBuffer(nameID, value);
}

public static void SetConstantBuffer(UnityEngine.Material _this, string name, UnityEngine.ComputeBuffer value, int offset, int size)
{
	_this.SetConstantBuffer(name, value, offset, size);
}

public static void SetConstantBuffer(UnityEngine.Material _this, int nameID, UnityEngine.ComputeBuffer value, int offset, int size)
{
	_this.SetConstantBuffer(nameID, value, offset, size);
}

public static void SetConstantBuffer(UnityEngine.Material _this, string name, UnityEngine.GraphicsBuffer value, int offset, int size)
{
	_this.SetConstantBuffer(name, value, offset, size);
}

public static void SetConstantBuffer(UnityEngine.Material _this, int nameID, UnityEngine.GraphicsBuffer value, int offset, int size)
{
	_this.SetConstantBuffer(nameID, value, offset, size);
}

public static void SetFloatArray(UnityEngine.Material _this, string name, float[] values)
{
	_this.SetFloatArray(name, values);
}

public static void SetFloatArray(UnityEngine.Material _this, int nameID, float[] values)
{
	_this.SetFloatArray(nameID, values);
}

public static void SetColorArray(UnityEngine.Material _this, string name, UnityEngine.Color[] values)
{
	_this.SetColorArray(name, values);
}

public static void SetColorArray(UnityEngine.Material _this, int nameID, UnityEngine.Color[] values)
{
	_this.SetColorArray(nameID, values);
}

public static void SetVectorArray(UnityEngine.Material _this, string name, UnityEngine.Vector4[] values)
{
	_this.SetVectorArray(name, values);
}

public static void SetVectorArray(UnityEngine.Material _this, int nameID, UnityEngine.Vector4[] values)
{
	_this.SetVectorArray(nameID, values);
}

public static void SetMatrixArray(UnityEngine.Material _this, string name, UnityEngine.Matrix4x4[] values)
{
	_this.SetMatrixArray(name, values);
}

public static void SetMatrixArray(UnityEngine.Material _this, int nameID, UnityEngine.Matrix4x4[] values)
{
	_this.SetMatrixArray(nameID, values);
}

public static float GetFloat(UnityEngine.Material _this, string name)
{
	return _this.GetFloat(name);
}

public static float GetFloat(UnityEngine.Material _this, int nameID)
{
	return _this.GetFloat(nameID);
}

public static int GetInt(UnityEngine.Material _this, string name)
{
	return _this.GetInt(name);
}

public static int GetInt(UnityEngine.Material _this, int nameID)
{
	return _this.GetInt(nameID);
}

public static UnityEngine.Color GetColor(UnityEngine.Material _this, string name)
{
	return _this.GetColor(name);
}

public static UnityEngine.Color GetColor(UnityEngine.Material _this, int nameID)
{
	return _this.GetColor(nameID);
}

public static UnityEngine.Vector4 GetVector(UnityEngine.Material _this, string name)
{
	return _this.GetVector(name);
}

public static UnityEngine.Vector4 GetVector(UnityEngine.Material _this, int nameID)
{
	return _this.GetVector(nameID);
}

public static UnityEngine.Matrix4x4 GetMatrix(UnityEngine.Material _this, string name)
{
	return _this.GetMatrix(name);
}

public static UnityEngine.Matrix4x4 GetMatrix(UnityEngine.Material _this, int nameID)
{
	return _this.GetMatrix(nameID);
}

public static UnityEngine.Texture GetTexture(UnityEngine.Material _this, string name)
{
	return _this.GetTexture(name);
}

public static UnityEngine.Texture GetTexture(UnityEngine.Material _this, int nameID)
{
	return _this.GetTexture(nameID);
}

public static float[] GetFloatArray(UnityEngine.Material _this, string name)
{
	return _this.GetFloatArray(name);
}

public static float[] GetFloatArray(UnityEngine.Material _this, int nameID)
{
	return _this.GetFloatArray(nameID);
}

public static UnityEngine.Color[] GetColorArray(UnityEngine.Material _this, string name)
{
	return _this.GetColorArray(name);
}

public static UnityEngine.Color[] GetColorArray(UnityEngine.Material _this, int nameID)
{
	return _this.GetColorArray(nameID);
}

public static UnityEngine.Vector4[] GetVectorArray(UnityEngine.Material _this, string name)
{
	return _this.GetVectorArray(name);
}

public static UnityEngine.Vector4[] GetVectorArray(UnityEngine.Material _this, int nameID)
{
	return _this.GetVectorArray(nameID);
}

public static UnityEngine.Matrix4x4[] GetMatrixArray(UnityEngine.Material _this, string name)
{
	return _this.GetMatrixArray(name);
}

public static UnityEngine.Matrix4x4[] GetMatrixArray(UnityEngine.Material _this, int nameID)
{
	return _this.GetMatrixArray(nameID);
}

public static void SetTextureOffset(UnityEngine.Material _this, string name, UnityEngine.Vector2 value)
{
	_this.SetTextureOffset(name, value);
}

public static void SetTextureOffset(UnityEngine.Material _this, int nameID, UnityEngine.Vector2 value)
{
	_this.SetTextureOffset(nameID, value);
}

public static void SetTextureScale(UnityEngine.Material _this, string name, UnityEngine.Vector2 value)
{
	_this.SetTextureScale(name, value);
}

public static void SetTextureScale(UnityEngine.Material _this, int nameID, UnityEngine.Vector2 value)
{
	_this.SetTextureScale(nameID, value);
}

public static UnityEngine.Vector2 GetTextureOffset(UnityEngine.Material _this, string name)
{
	return _this.GetTextureOffset(name);
}

public static UnityEngine.Vector2 GetTextureOffset(UnityEngine.Material _this, int nameID)
{
	return _this.GetTextureOffset(nameID);
}

public static UnityEngine.Vector2 GetTextureScale(UnityEngine.Material _this, string name)
{
	return _this.GetTextureScale(name);
}

public static UnityEngine.Vector2 GetTextureScale(UnityEngine.Material _this, int nameID)
{
	return _this.GetTextureScale(nameID);
}

public static UnityEngine.Shader get_shader(UnityEngine.Material _this)
{
	return _this.shader;
}

public static void set_shader(UnityEngine.Material _this, UnityEngine.Shader value)
{
	_this.shader = value;
}

public static UnityEngine.Color get_color(UnityEngine.Material _this)
{
	return _this.color;
}

public static void set_color(UnityEngine.Material _this, UnityEngine.Color value)
{
	_this.color = value;
}

public static UnityEngine.Texture get_mainTexture(UnityEngine.Material _this)
{
	return _this.mainTexture;
}

public static void set_mainTexture(UnityEngine.Material _this, UnityEngine.Texture value)
{
	_this.mainTexture = value;
}

public static UnityEngine.Vector2 get_mainTextureOffset(UnityEngine.Material _this)
{
	return _this.mainTextureOffset;
}

public static void set_mainTextureOffset(UnityEngine.Material _this, UnityEngine.Vector2 value)
{
	_this.mainTextureOffset = value;
}

public static UnityEngine.Vector2 get_mainTextureScale(UnityEngine.Material _this)
{
	return _this.mainTextureScale;
}

public static void set_mainTextureScale(UnityEngine.Material _this, UnityEngine.Vector2 value)
{
	_this.mainTextureScale = value;
}

public static int get_renderQueue(UnityEngine.Material _this)
{
	return _this.renderQueue;
}

public static void set_renderQueue(UnityEngine.Material _this, int value)
{
	_this.renderQueue = value;
}

public static UnityEngine.MaterialGlobalIlluminationFlags get_globalIlluminationFlags(UnityEngine.Material _this)
{
	return _this.globalIlluminationFlags;
}

public static void set_globalIlluminationFlags(UnityEngine.Material _this, UnityEngine.MaterialGlobalIlluminationFlags value)
{
	_this.globalIlluminationFlags = value;
}

public static bool get_doubleSidedGI(UnityEngine.Material _this)
{
	return _this.doubleSidedGI;
}

public static void set_doubleSidedGI(UnityEngine.Material _this, bool value)
{
	_this.doubleSidedGI = value;
}

public static bool get_enableInstancing(UnityEngine.Material _this)
{
	return _this.enableInstancing;
}

public static void set_enableInstancing(UnityEngine.Material _this, bool value)
{
	_this.enableInstancing = value;
}

public static int get_passCount(UnityEngine.Material _this)
{
	return _this.passCount;
}

public static string[] get_shaderKeywords(UnityEngine.Material _this)
{
	return _this.shaderKeywords;
}

public static void set_shaderKeywords(UnityEngine.Material _this, string[] value)
{
	_this.shaderKeywords = value;
}

public static UnityEngine.Material New(UnityEngine.Shader shader)
{
	return new UnityEngine.Material(shader);
}
public static UnityEngine.Material New(UnityEngine.Material source)
{
	return new UnityEngine.Material(source);
}
}
}
