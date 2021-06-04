
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_RenderTexture
{
public static System.IntPtr GetNativeDepthBufferPtr(UnityEngine.RenderTexture _this)
{
	return _this.GetNativeDepthBufferPtr();
}

public static void DiscardContents(UnityEngine.RenderTexture _this, bool discardColor, bool discardDepth)
{
	_this.DiscardContents(discardColor, discardDepth);
}

public static void MarkRestoreExpected(UnityEngine.RenderTexture _this)
{
	_this.MarkRestoreExpected();
}

public static void DiscardContents(UnityEngine.RenderTexture _this)
{
	_this.DiscardContents();
}

public static void ResolveAntiAliasedSurface(UnityEngine.RenderTexture _this)
{
	_this.ResolveAntiAliasedSurface();
}

public static void ResolveAntiAliasedSurface(UnityEngine.RenderTexture _this, UnityEngine.RenderTexture target)
{
	_this.ResolveAntiAliasedSurface(target);
}

public static void SetGlobalShaderProperty(UnityEngine.RenderTexture _this, string propertyName)
{
	_this.SetGlobalShaderProperty(propertyName);
}

public static bool Create(UnityEngine.RenderTexture _this)
{
	return _this.Create();
}

public static void Release(UnityEngine.RenderTexture _this)
{
	_this.Release();
}

public static bool IsCreated(UnityEngine.RenderTexture _this)
{
	return _this.IsCreated();
}

public static void GenerateMips(UnityEngine.RenderTexture _this)
{
	_this.GenerateMips();
}

public static void ConvertToEquirect(UnityEngine.RenderTexture _this, UnityEngine.RenderTexture equirect, int eye)
{
	_this.ConvertToEquirect(equirect, (UnityEngine.Camera.MonoOrStereoscopicEye)eye);
}

public static int get_width(UnityEngine.RenderTexture _this)
{
	return _this.width;
}

public static void set_width(UnityEngine.RenderTexture _this, int value)
{
	_this.width = value;
}

public static int get_height(UnityEngine.RenderTexture _this)
{
	return _this.height;
}

public static void set_height(UnityEngine.RenderTexture _this, int value)
{
	_this.height = value;
}

public static UnityEngine.Rendering.TextureDimension get_dimension(UnityEngine.RenderTexture _this)
{
	return _this.dimension;
}

public static void set_dimension(UnityEngine.RenderTexture _this, UnityEngine.Rendering.TextureDimension value)
{
	_this.dimension = value;
}

public static UnityEngine.Experimental.Rendering.GraphicsFormat get_graphicsFormat(UnityEngine.RenderTexture _this)
{
	return _this.graphicsFormat;
}

public static void set_graphicsFormat(UnityEngine.RenderTexture _this, UnityEngine.Experimental.Rendering.GraphicsFormat value)
{
	_this.graphicsFormat = value;
}

public static bool get_useMipMap(UnityEngine.RenderTexture _this)
{
	return _this.useMipMap;
}

public static void set_useMipMap(UnityEngine.RenderTexture _this, bool value)
{
	_this.useMipMap = value;
}

public static bool get_sRGB(UnityEngine.RenderTexture _this)
{
	return _this.sRGB;
}

public static UnityEngine.VRTextureUsage get_vrUsage(UnityEngine.RenderTexture _this)
{
	return _this.vrUsage;
}

public static void set_vrUsage(UnityEngine.RenderTexture _this, UnityEngine.VRTextureUsage value)
{
	_this.vrUsage = value;
}

public static UnityEngine.RenderTextureMemoryless get_memorylessMode(UnityEngine.RenderTexture _this)
{
	return _this.memorylessMode;
}

public static void set_memorylessMode(UnityEngine.RenderTexture _this, UnityEngine.RenderTextureMemoryless value)
{
	_this.memorylessMode = value;
}

public static UnityEngine.RenderTextureFormat get_format(UnityEngine.RenderTexture _this)
{
	return _this.format;
}

public static void set_format(UnityEngine.RenderTexture _this, UnityEngine.RenderTextureFormat value)
{
	_this.format = value;
}

public static UnityEngine.Experimental.Rendering.GraphicsFormat get_stencilFormat(UnityEngine.RenderTexture _this)
{
	return _this.stencilFormat;
}

public static void set_stencilFormat(UnityEngine.RenderTexture _this, UnityEngine.Experimental.Rendering.GraphicsFormat value)
{
	_this.stencilFormat = value;
}

public static bool get_autoGenerateMips(UnityEngine.RenderTexture _this)
{
	return _this.autoGenerateMips;
}

public static void set_autoGenerateMips(UnityEngine.RenderTexture _this, bool value)
{
	_this.autoGenerateMips = value;
}

public static int get_volumeDepth(UnityEngine.RenderTexture _this)
{
	return _this.volumeDepth;
}

public static void set_volumeDepth(UnityEngine.RenderTexture _this, int value)
{
	_this.volumeDepth = value;
}

public static int get_antiAliasing(UnityEngine.RenderTexture _this)
{
	return _this.antiAliasing;
}

public static void set_antiAliasing(UnityEngine.RenderTexture _this, int value)
{
	_this.antiAliasing = value;
}

public static bool get_bindTextureMS(UnityEngine.RenderTexture _this)
{
	return _this.bindTextureMS;
}

public static void set_bindTextureMS(UnityEngine.RenderTexture _this, bool value)
{
	_this.bindTextureMS = value;
}

public static bool get_enableRandomWrite(UnityEngine.RenderTexture _this)
{
	return _this.enableRandomWrite;
}

public static void set_enableRandomWrite(UnityEngine.RenderTexture _this, bool value)
{
	_this.enableRandomWrite = value;
}

public static bool get_useDynamicScale(UnityEngine.RenderTexture _this)
{
	return _this.useDynamicScale;
}

public static void set_useDynamicScale(UnityEngine.RenderTexture _this, bool value)
{
	_this.useDynamicScale = value;
}

public static bool get_isPowerOfTwo(UnityEngine.RenderTexture _this)
{
	return _this.isPowerOfTwo;
}

public static void set_isPowerOfTwo(UnityEngine.RenderTexture _this, bool value)
{
	_this.isPowerOfTwo = value;
}

public static UnityEngine.RenderBuffer get_colorBuffer(UnityEngine.RenderTexture _this)
{
	return _this.colorBuffer;
}

public static UnityEngine.RenderBuffer get_depthBuffer(UnityEngine.RenderTexture _this)
{
	return _this.depthBuffer;
}

public static int get_depth(UnityEngine.RenderTexture _this)
{
	return _this.depth;
}

public static void set_depth(UnityEngine.RenderTexture _this, int value)
{
	_this.depth = value;
}

public static UnityEngine.RenderTextureDescriptor get_descriptor(UnityEngine.RenderTexture _this)
{
	return _this.descriptor;
}

public static void set_descriptor(UnityEngine.RenderTexture _this, UnityEngine.RenderTextureDescriptor value)
{
	_this.descriptor = value;
}

}
}
