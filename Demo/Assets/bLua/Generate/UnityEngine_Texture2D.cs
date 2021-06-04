
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Texture2D
{
public static void Compress(UnityEngine.Texture2D _this, bool highQuality)
{
	_this.Compress(highQuality);
}

public static void ClearRequestedMipmapLevel(UnityEngine.Texture2D _this)
{
	_this.ClearRequestedMipmapLevel();
}

public static bool IsRequestedMipmapLevelLoaded(UnityEngine.Texture2D _this)
{
	return _this.IsRequestedMipmapLevelLoaded();
}

public static void ClearMinimumMipmapLevel(UnityEngine.Texture2D _this)
{
	_this.ClearMinimumMipmapLevel();
}

public static void UpdateExternalTexture(UnityEngine.Texture2D _this, System.IntPtr nativeTex)
{
	_this.UpdateExternalTexture(nativeTex);
}

public static System.Byte[] GetRawTextureData(UnityEngine.Texture2D _this)
{
	return _this.GetRawTextureData();
}

public static UnityEngine.Color[] GetPixels(UnityEngine.Texture2D _this, int x, int y, int blockWidth, int blockHeight, int miplevel)
{
	return _this.GetPixels(x, y, blockWidth, blockHeight, miplevel);
}

public static UnityEngine.Color[] GetPixels(UnityEngine.Texture2D _this, int x, int y, int blockWidth, int blockHeight)
{
	return _this.GetPixels(x, y, blockWidth, blockHeight);
}

public static UnityEngine.Color32[] GetPixels32(UnityEngine.Texture2D _this, int miplevel)
{
	return _this.GetPixels32(miplevel);
}

public static UnityEngine.Color32[] GetPixels32(UnityEngine.Texture2D _this)
{
	return _this.GetPixels32();
}

public static UnityEngine.Rect[] PackTextures(UnityEngine.Texture2D _this, UnityEngine.Texture2D[] textures, int padding, int maximumAtlasSize, bool makeNoLongerReadable)
{
	return _this.PackTextures(textures, padding, maximumAtlasSize, makeNoLongerReadable);
}

public static UnityEngine.Rect[] PackTextures(UnityEngine.Texture2D _this, UnityEngine.Texture2D[] textures, int padding, int maximumAtlasSize)
{
	return _this.PackTextures(textures, padding, maximumAtlasSize);
}

public static UnityEngine.Rect[] PackTextures(UnityEngine.Texture2D _this, UnityEngine.Texture2D[] textures, int padding)
{
	return _this.PackTextures(textures, padding);
}

public static void SetPixel(UnityEngine.Texture2D _this, int x, int y, UnityEngine.Color color)
{
	_this.SetPixel(x, y, color);
}

public static void SetPixel(UnityEngine.Texture2D _this, int x, int y, UnityEngine.Color color, int mipLevel)
{
	_this.SetPixel(x, y, color, mipLevel);
}

public static UnityEngine.Color GetPixel(UnityEngine.Texture2D _this, int x, int y)
{
	return _this.GetPixel(x, y);
}

public static UnityEngine.Color GetPixel(UnityEngine.Texture2D _this, int x, int y, int mipLevel)
{
	return _this.GetPixel(x, y, mipLevel);
}

public static UnityEngine.Color GetPixelBilinear(UnityEngine.Texture2D _this, float u, float v)
{
	return _this.GetPixelBilinear(u, v);
}

public static UnityEngine.Color GetPixelBilinear(UnityEngine.Texture2D _this, float u, float v, int mipLevel)
{
	return _this.GetPixelBilinear(u, v, mipLevel);
}

public static void LoadRawTextureData(UnityEngine.Texture2D _this, System.IntPtr data, int size)
{
	_this.LoadRawTextureData(data, size);
}

public static void LoadRawTextureData(UnityEngine.Texture2D _this, System.Byte[] data)
{
	_this.LoadRawTextureData(data);
}

public static void Apply(UnityEngine.Texture2D _this, bool updateMipmaps, bool makeNoLongerReadable)
{
	_this.Apply(updateMipmaps, makeNoLongerReadable);
}

public static void Apply(UnityEngine.Texture2D _this, bool updateMipmaps)
{
	_this.Apply(updateMipmaps);
}

public static void Apply(UnityEngine.Texture2D _this)
{
	_this.Apply();
}

public static void ReadPixels(UnityEngine.Texture2D _this, UnityEngine.Rect source, int destX, int destY, bool recalculateMipMaps)
{
	_this.ReadPixels(source, destX, destY, recalculateMipMaps);
}

public static void ReadPixels(UnityEngine.Texture2D _this, UnityEngine.Rect source, int destX, int destY)
{
	_this.ReadPixels(source, destX, destY);
}

public static void SetPixels32(UnityEngine.Texture2D _this, UnityEngine.Color32[] colors, int miplevel)
{
	_this.SetPixels32(colors, miplevel);
}

public static void SetPixels32(UnityEngine.Texture2D _this, UnityEngine.Color32[] colors)
{
	_this.SetPixels32(colors);
}

public static void SetPixels32(UnityEngine.Texture2D _this, int x, int y, int blockWidth, int blockHeight, UnityEngine.Color32[] colors, int miplevel)
{
	_this.SetPixels32(x, y, blockWidth, blockHeight, colors, miplevel);
}

public static void SetPixels32(UnityEngine.Texture2D _this, int x, int y, int blockWidth, int blockHeight, UnityEngine.Color32[] colors)
{
	_this.SetPixels32(x, y, blockWidth, blockHeight, colors);
}

public static UnityEngine.Color[] GetPixels(UnityEngine.Texture2D _this, int miplevel)
{
	return _this.GetPixels(miplevel);
}

public static UnityEngine.Color[] GetPixels(UnityEngine.Texture2D _this)
{
	return _this.GetPixels();
}

public static UnityEngine.TextureFormat get_format(UnityEngine.Texture2D _this)
{
	return _this.format;
}

public static bool get_isReadable(UnityEngine.Texture2D _this)
{
	return _this.isReadable;
}

public static bool get_vtOnly(UnityEngine.Texture2D _this)
{
	return _this.vtOnly;
}

public static bool get_streamingMipmaps(UnityEngine.Texture2D _this)
{
	return _this.streamingMipmaps;
}

public static int get_streamingMipmapsPriority(UnityEngine.Texture2D _this)
{
	return _this.streamingMipmapsPriority;
}

public static int get_requestedMipmapLevel(UnityEngine.Texture2D _this)
{
	return _this.requestedMipmapLevel;
}

public static void set_requestedMipmapLevel(UnityEngine.Texture2D _this, int value)
{
	_this.requestedMipmapLevel = value;
}

public static int get_minimumMipmapLevel(UnityEngine.Texture2D _this)
{
	return _this.minimumMipmapLevel;
}

public static void set_minimumMipmapLevel(UnityEngine.Texture2D _this, int value)
{
	_this.minimumMipmapLevel = value;
}

public static int get_calculatedMipmapLevel(UnityEngine.Texture2D _this)
{
	return _this.calculatedMipmapLevel;
}

public static int get_desiredMipmapLevel(UnityEngine.Texture2D _this)
{
	return _this.desiredMipmapLevel;
}

public static int get_loadingMipmapLevel(UnityEngine.Texture2D _this)
{
	return _this.loadingMipmapLevel;
}

public static int get_loadedMipmapLevel(UnityEngine.Texture2D _this)
{
	return _this.loadedMipmapLevel;
}

public static bool get_alphaIsTransparency(UnityEngine.Texture2D _this)
{
	return _this.alphaIsTransparency;
}

public static void set_alphaIsTransparency(UnityEngine.Texture2D _this, bool value)
{
	_this.alphaIsTransparency = value;
}

}
}
