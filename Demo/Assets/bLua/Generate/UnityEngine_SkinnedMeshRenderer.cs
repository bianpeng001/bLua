
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_SkinnedMeshRenderer
{
public static float GetBlendShapeWeight(UnityEngine.SkinnedMeshRenderer _this, int index)
{
	return _this.GetBlendShapeWeight(index);
}

public static void SetBlendShapeWeight(UnityEngine.SkinnedMeshRenderer _this, int index, float value)
{
	_this.SetBlendShapeWeight(index, value);
}

public static void BakeMesh(UnityEngine.SkinnedMeshRenderer _this, UnityEngine.Mesh mesh)
{
	_this.BakeMesh(mesh);
}

public static void BakeMesh(UnityEngine.SkinnedMeshRenderer _this, UnityEngine.Mesh mesh, bool useScale)
{
	_this.BakeMesh(mesh, useScale);
}

public static UnityEngine.SkinQuality get_quality(UnityEngine.SkinnedMeshRenderer _this)
{
	return _this.quality;
}

public static void set_quality(UnityEngine.SkinnedMeshRenderer _this, UnityEngine.SkinQuality value)
{
	_this.quality = value;
}

public static bool get_updateWhenOffscreen(UnityEngine.SkinnedMeshRenderer _this)
{
	return _this.updateWhenOffscreen;
}

public static void set_updateWhenOffscreen(UnityEngine.SkinnedMeshRenderer _this, bool value)
{
	_this.updateWhenOffscreen = value;
}

public static bool get_forceMatrixRecalculationPerRender(UnityEngine.SkinnedMeshRenderer _this)
{
	return _this.forceMatrixRecalculationPerRender;
}

public static void set_forceMatrixRecalculationPerRender(UnityEngine.SkinnedMeshRenderer _this, bool value)
{
	_this.forceMatrixRecalculationPerRender = value;
}

public static UnityEngine.Transform get_rootBone(UnityEngine.SkinnedMeshRenderer _this)
{
	return _this.rootBone;
}

public static void set_rootBone(UnityEngine.SkinnedMeshRenderer _this, UnityEngine.Transform value)
{
	_this.rootBone = value;
}

public static UnityEngine.Transform[] get_bones(UnityEngine.SkinnedMeshRenderer _this)
{
	return _this.bones;
}

public static void set_bones(UnityEngine.SkinnedMeshRenderer _this, UnityEngine.Transform[] value)
{
	_this.bones = value;
}

public static UnityEngine.Mesh get_sharedMesh(UnityEngine.SkinnedMeshRenderer _this)
{
	return _this.sharedMesh;
}

public static void set_sharedMesh(UnityEngine.SkinnedMeshRenderer _this, UnityEngine.Mesh value)
{
	_this.sharedMesh = value;
}

public static bool get_skinnedMotionVectors(UnityEngine.SkinnedMeshRenderer _this)
{
	return _this.skinnedMotionVectors;
}

public static void set_skinnedMotionVectors(UnityEngine.SkinnedMeshRenderer _this, bool value)
{
	_this.skinnedMotionVectors = value;
}

public static UnityEngine.Bounds get_localBounds(UnityEngine.SkinnedMeshRenderer _this)
{
	return _this.localBounds;
}

public static void set_localBounds(UnityEngine.SkinnedMeshRenderer _this, UnityEngine.Bounds value)
{
	_this.localBounds = value;
}

}
}
