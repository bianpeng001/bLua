
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_AssetBundle
{
public static bool Contains(UnityEngine.AssetBundle _this, string name)
{
	return _this.Contains(name);
}

public static UnityEngine.Object LoadAsset(UnityEngine.AssetBundle _this, string name)
{
	return _this.LoadAsset(name);
}

public static UnityEngine.Object LoadAsset(UnityEngine.AssetBundle _this, string name, System.Type type)
{
	return _this.LoadAsset(name, type);
}

public static UnityEngine.AssetBundleRequest LoadAssetAsync(UnityEngine.AssetBundle _this, string name)
{
	return _this.LoadAssetAsync(name);
}

public static UnityEngine.AssetBundleRequest LoadAssetAsync(UnityEngine.AssetBundle _this, string name, System.Type type)
{
	return _this.LoadAssetAsync(name, type);
}

public static UnityEngine.Object[] LoadAssetWithSubAssets(UnityEngine.AssetBundle _this, string name)
{
	return _this.LoadAssetWithSubAssets(name);
}

public static UnityEngine.Object[] LoadAssetWithSubAssets(UnityEngine.AssetBundle _this, string name, System.Type type)
{
	return _this.LoadAssetWithSubAssets(name, type);
}

public static UnityEngine.AssetBundleRequest LoadAssetWithSubAssetsAsync(UnityEngine.AssetBundle _this, string name)
{
	return _this.LoadAssetWithSubAssetsAsync(name);
}

public static UnityEngine.AssetBundleRequest LoadAssetWithSubAssetsAsync(UnityEngine.AssetBundle _this, string name, System.Type type)
{
	return _this.LoadAssetWithSubAssetsAsync(name, type);
}

public static UnityEngine.Object[] LoadAllAssets(UnityEngine.AssetBundle _this)
{
	return _this.LoadAllAssets();
}

public static UnityEngine.Object[] LoadAllAssets(UnityEngine.AssetBundle _this, System.Type type)
{
	return _this.LoadAllAssets(type);
}

public static UnityEngine.AssetBundleRequest LoadAllAssetsAsync(UnityEngine.AssetBundle _this)
{
	return _this.LoadAllAssetsAsync();
}

public static UnityEngine.AssetBundleRequest LoadAllAssetsAsync(UnityEngine.AssetBundle _this, System.Type type)
{
	return _this.LoadAllAssetsAsync(type);
}

public static void Unload(UnityEngine.AssetBundle _this, bool unloadAllLoadedObjects)
{
	_this.Unload(unloadAllLoadedObjects);
}

public static string[] GetAllAssetNames(UnityEngine.AssetBundle _this)
{
	return _this.GetAllAssetNames();
}

public static string[] GetAllScenePaths(UnityEngine.AssetBundle _this)
{
	return _this.GetAllScenePaths();
}

public static bool get_isStreamedSceneAssetBundle(UnityEngine.AssetBundle _this)
{
	return _this.isStreamedSceneAssetBundle;
}

}
}
