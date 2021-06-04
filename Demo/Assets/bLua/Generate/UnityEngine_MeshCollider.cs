
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_MeshCollider
{
public static UnityEngine.Mesh get_sharedMesh(UnityEngine.MeshCollider _this)
{
	return _this.sharedMesh;
}

public static void set_sharedMesh(UnityEngine.MeshCollider _this, UnityEngine.Mesh value)
{
	_this.sharedMesh = value;
}

public static bool get_convex(UnityEngine.MeshCollider _this)
{
	return _this.convex;
}

public static void set_convex(UnityEngine.MeshCollider _this, bool value)
{
	_this.convex = value;
}

public static UnityEngine.MeshColliderCookingOptions get_cookingOptions(UnityEngine.MeshCollider _this)
{
	return _this.cookingOptions;
}

public static void set_cookingOptions(UnityEngine.MeshCollider _this, UnityEngine.MeshColliderCookingOptions value)
{
	_this.cookingOptions = value;
}

}
}
