
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_MeshFilter
{
public static UnityEngine.Mesh get_sharedMesh(UnityEngine.MeshFilter _this)
{
	return _this.sharedMesh;
}

public static void set_sharedMesh(UnityEngine.MeshFilter _this, UnityEngine.Mesh value)
{
	_this.sharedMesh = value;
}

public static UnityEngine.Mesh get_mesh(UnityEngine.MeshFilter _this)
{
	return _this.mesh;
}

public static void set_mesh(UnityEngine.MeshFilter _this, UnityEngine.Mesh value)
{
	_this.mesh = value;
}

}
}
