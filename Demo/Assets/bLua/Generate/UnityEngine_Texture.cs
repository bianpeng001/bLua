
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Texture
{
public static System.IntPtr GetNativeTexturePtr(UnityEngine.Texture _this)
{
	return _this.GetNativeTexturePtr();
}

public static void IncrementUpdateCount(UnityEngine.Texture _this)
{
	_this.IncrementUpdateCount();
}

public static int get_mipmapCount(UnityEngine.Texture _this)
{
	return _this.mipmapCount;
}

public static UnityEngine.Experimental.Rendering.GraphicsFormat get_graphicsFormat(UnityEngine.Texture _this)
{
	return _this.graphicsFormat;
}

public static int get_width(UnityEngine.Texture _this)
{
	return _this.width;
}

public static void set_width(UnityEngine.Texture _this, int value)
{
	_this.width = value;
}

public static int get_height(UnityEngine.Texture _this)
{
	return _this.height;
}

public static void set_height(UnityEngine.Texture _this, int value)
{
	_this.height = value;
}

public static UnityEngine.Rendering.TextureDimension get_dimension(UnityEngine.Texture _this)
{
	return _this.dimension;
}

public static void set_dimension(UnityEngine.Texture _this, UnityEngine.Rendering.TextureDimension value)
{
	_this.dimension = value;
}

public static bool get_isReadable(UnityEngine.Texture _this)
{
	return _this.isReadable;
}

public static UnityEngine.TextureWrapMode get_wrapMode(UnityEngine.Texture _this)
{
	return _this.wrapMode;
}

public static void set_wrapMode(UnityEngine.Texture _this, UnityEngine.TextureWrapMode value)
{
	_this.wrapMode = value;
}

public static UnityEngine.TextureWrapMode get_wrapModeU(UnityEngine.Texture _this)
{
	return _this.wrapModeU;
}

public static void set_wrapModeU(UnityEngine.Texture _this, UnityEngine.TextureWrapMode value)
{
	_this.wrapModeU = value;
}

public static UnityEngine.TextureWrapMode get_wrapModeV(UnityEngine.Texture _this)
{
	return _this.wrapModeV;
}

public static void set_wrapModeV(UnityEngine.Texture _this, UnityEngine.TextureWrapMode value)
{
	_this.wrapModeV = value;
}

public static UnityEngine.TextureWrapMode get_wrapModeW(UnityEngine.Texture _this)
{
	return _this.wrapModeW;
}

public static void set_wrapModeW(UnityEngine.Texture _this, UnityEngine.TextureWrapMode value)
{
	_this.wrapModeW = value;
}

public static UnityEngine.FilterMode get_filterMode(UnityEngine.Texture _this)
{
	return _this.filterMode;
}

public static void set_filterMode(UnityEngine.Texture _this, UnityEngine.FilterMode value)
{
	_this.filterMode = value;
}

public static int get_anisoLevel(UnityEngine.Texture _this)
{
	return _this.anisoLevel;
}

public static void set_anisoLevel(UnityEngine.Texture _this, int value)
{
	_this.anisoLevel = value;
}

public static float get_mipMapBias(UnityEngine.Texture _this)
{
	return _this.mipMapBias;
}

public static void set_mipMapBias(UnityEngine.Texture _this, float value)
{
	_this.mipMapBias = value;
}

public static UnityEngine.Vector2 get_texelSize(UnityEngine.Texture _this)
{
	return _this.texelSize;
}

public static uint get_updateCount(UnityEngine.Texture _this)
{
	return _this.updateCount;
}

public static UnityEngine.Hash128 get_imageContentsHash(UnityEngine.Texture _this)
{
	return _this.imageContentsHash;
}

public static void set_imageContentsHash(UnityEngine.Texture _this, UnityEngine.Hash128 value)
{
	_this.imageContentsHash = value;
}

}
}
