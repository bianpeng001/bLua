
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

public static float get_scaleInLightmap(UnityEngine.MeshRenderer _this)
{
	return _this.scaleInLightmap;
}

public static void set_scaleInLightmap(UnityEngine.MeshRenderer _this, float value)
{
	_this.scaleInLightmap = value;
}

public static UnityEngine.ReceiveGI get_receiveGI(UnityEngine.MeshRenderer _this)
{
	return _this.receiveGI;
}

public static void set_receiveGI(UnityEngine.MeshRenderer _this, UnityEngine.ReceiveGI value)
{
	_this.receiveGI = value;
}

public static bool get_stitchLightmapSeams(UnityEngine.MeshRenderer _this)
{
	return _this.stitchLightmapSeams;
}

public static void set_stitchLightmapSeams(UnityEngine.MeshRenderer _this, bool value)
{
	_this.stitchLightmapSeams = value;
}

}
}
