
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_MeshRenderer
{
public static UnityEngine.Mesh get_additionalVertexStreams(UnityEngine.MeshRenderer _this)
{
	return _this.additionalVertexStreams;
}

public static void set_additionalVertexStreams(UnityEngine.MeshRenderer _this, UnityEngine.Mesh value)
{
	_this.additionalVertexStreams = value;
}

public static UnityEngine.Mesh get_enlightenVertexStream(UnityEngine.MeshRenderer _this)
{
	return _this.enlightenVertexStream;
}

public static void set_enlightenVertexStream(UnityEngine.MeshRenderer _this, UnityEngine.Mesh value)
{
	_this.enlightenVertexStream = value;
}

public static int get_subMeshStartIndex(UnityEngine.MeshRenderer _this)
{
	return _this.subMeshStartIndex;
}

}
}
