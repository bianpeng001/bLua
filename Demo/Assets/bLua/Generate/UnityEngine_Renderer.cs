
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Renderer
{
public static bool HasPropertyBlock(UnityEngine.Renderer _this)
{
	return _this.HasPropertyBlock();
}

public static void SetPropertyBlock(UnityEngine.Renderer _this, UnityEngine.MaterialPropertyBlock properties)
{
	_this.SetPropertyBlock(properties);
}

public static void SetPropertyBlock(UnityEngine.Renderer _this, UnityEngine.MaterialPropertyBlock properties, int materialIndex)
{
	_this.SetPropertyBlock(properties, materialIndex);
}

public static void GetPropertyBlock(UnityEngine.Renderer _this, UnityEngine.MaterialPropertyBlock properties)
{
	_this.GetPropertyBlock(properties);
}

public static void GetPropertyBlock(UnityEngine.Renderer _this, UnityEngine.MaterialPropertyBlock properties, int materialIndex)
{
	_this.GetPropertyBlock(properties, materialIndex);
}

public static UnityEngine.Bounds get_bounds(UnityEngine.Renderer _this)
{
	return _this.bounds;
}

public static bool get_enabled(UnityEngine.Renderer _this)
{
	return _this.enabled;
}

public static void set_enabled(UnityEngine.Renderer _this, bool value)
{
	_this.enabled = value;
}

public static bool get_isVisible(UnityEngine.Renderer _this)
{
	return _this.isVisible;
}

public static UnityEngine.Rendering.ShadowCastingMode get_shadowCastingMode(UnityEngine.Renderer _this)
{
	return _this.shadowCastingMode;
}

public static void set_shadowCastingMode(UnityEngine.Renderer _this, UnityEngine.Rendering.ShadowCastingMode value)
{
	_this.shadowCastingMode = value;
}

public static bool get_receiveShadows(UnityEngine.Renderer _this)
{
	return _this.receiveShadows;
}

public static void set_receiveShadows(UnityEngine.Renderer _this, bool value)
{
	_this.receiveShadows = value;
}

public static bool get_forceRenderingOff(UnityEngine.Renderer _this)
{
	return _this.forceRenderingOff;
}

public static void set_forceRenderingOff(UnityEngine.Renderer _this, bool value)
{
	_this.forceRenderingOff = value;
}

public static UnityEngine.MotionVectorGenerationMode get_motionVectorGenerationMode(UnityEngine.Renderer _this)
{
	return _this.motionVectorGenerationMode;
}

public static void set_motionVectorGenerationMode(UnityEngine.Renderer _this, UnityEngine.MotionVectorGenerationMode value)
{
	_this.motionVectorGenerationMode = value;
}

public static UnityEngine.Rendering.LightProbeUsage get_lightProbeUsage(UnityEngine.Renderer _this)
{
	return _this.lightProbeUsage;
}

public static void set_lightProbeUsage(UnityEngine.Renderer _this, UnityEngine.Rendering.LightProbeUsage value)
{
	_this.lightProbeUsage = value;
}

public static UnityEngine.Rendering.ReflectionProbeUsage get_reflectionProbeUsage(UnityEngine.Renderer _this)
{
	return _this.reflectionProbeUsage;
}

public static void set_reflectionProbeUsage(UnityEngine.Renderer _this, UnityEngine.Rendering.ReflectionProbeUsage value)
{
	_this.reflectionProbeUsage = value;
}

public static uint get_renderingLayerMask(UnityEngine.Renderer _this)
{
	return _this.renderingLayerMask;
}

public static void set_renderingLayerMask(UnityEngine.Renderer _this, uint value)
{
	_this.renderingLayerMask = value;
}

public static int get_rendererPriority(UnityEngine.Renderer _this)
{
	return _this.rendererPriority;
}

public static void set_rendererPriority(UnityEngine.Renderer _this, int value)
{
	_this.rendererPriority = value;
}

public static UnityEngine.Experimental.Rendering.RayTracingMode get_rayTracingMode(UnityEngine.Renderer _this)
{
	return _this.rayTracingMode;
}

public static void set_rayTracingMode(UnityEngine.Renderer _this, UnityEngine.Experimental.Rendering.RayTracingMode value)
{
	_this.rayTracingMode = value;
}

public static string get_sortingLayerName(UnityEngine.Renderer _this)
{
	return _this.sortingLayerName;
}

public static void set_sortingLayerName(UnityEngine.Renderer _this, string value)
{
	_this.sortingLayerName = value;
}

public static int get_sortingLayerID(UnityEngine.Renderer _this)
{
	return _this.sortingLayerID;
}

public static void set_sortingLayerID(UnityEngine.Renderer _this, int value)
{
	_this.sortingLayerID = value;
}

public static int get_sortingOrder(UnityEngine.Renderer _this)
{
	return _this.sortingOrder;
}

public static void set_sortingOrder(UnityEngine.Renderer _this, int value)
{
	_this.sortingOrder = value;
}

public static bool get_allowOcclusionWhenDynamic(UnityEngine.Renderer _this)
{
	return _this.allowOcclusionWhenDynamic;
}

public static void set_allowOcclusionWhenDynamic(UnityEngine.Renderer _this, bool value)
{
	_this.allowOcclusionWhenDynamic = value;
}

public static bool get_isPartOfStaticBatch(UnityEngine.Renderer _this)
{
	return _this.isPartOfStaticBatch;
}

public static UnityEngine.Matrix4x4 get_worldToLocalMatrix(UnityEngine.Renderer _this)
{
	return _this.worldToLocalMatrix;
}

public static UnityEngine.Matrix4x4 get_localToWorldMatrix(UnityEngine.Renderer _this)
{
	return _this.localToWorldMatrix;
}

public static UnityEngine.GameObject get_lightProbeProxyVolumeOverride(UnityEngine.Renderer _this)
{
	return _this.lightProbeProxyVolumeOverride;
}

public static void set_lightProbeProxyVolumeOverride(UnityEngine.Renderer _this, UnityEngine.GameObject value)
{
	_this.lightProbeProxyVolumeOverride = value;
}

public static UnityEngine.Transform get_probeAnchor(UnityEngine.Renderer _this)
{
	return _this.probeAnchor;
}

public static void set_probeAnchor(UnityEngine.Renderer _this, UnityEngine.Transform value)
{
	_this.probeAnchor = value;
}

public static int get_lightmapIndex(UnityEngine.Renderer _this)
{
	return _this.lightmapIndex;
}

public static void set_lightmapIndex(UnityEngine.Renderer _this, int value)
{
	_this.lightmapIndex = value;
}

public static int get_realtimeLightmapIndex(UnityEngine.Renderer _this)
{
	return _this.realtimeLightmapIndex;
}

public static void set_realtimeLightmapIndex(UnityEngine.Renderer _this, int value)
{
	_this.realtimeLightmapIndex = value;
}

public static UnityEngine.Vector4 get_lightmapScaleOffset(UnityEngine.Renderer _this)
{
	return _this.lightmapScaleOffset;
}

public static void set_lightmapScaleOffset(UnityEngine.Renderer _this, UnityEngine.Vector4 value)
{
	_this.lightmapScaleOffset = value;
}

public static UnityEngine.Vector4 get_realtimeLightmapScaleOffset(UnityEngine.Renderer _this)
{
	return _this.realtimeLightmapScaleOffset;
}

public static void set_realtimeLightmapScaleOffset(UnityEngine.Renderer _this, UnityEngine.Vector4 value)
{
	_this.realtimeLightmapScaleOffset = value;
}

public static UnityEngine.Material[] get_materials(UnityEngine.Renderer _this)
{
	return _this.materials;
}

public static void set_materials(UnityEngine.Renderer _this, UnityEngine.Material[] value)
{
	_this.materials = value;
}

public static UnityEngine.Material get_material(UnityEngine.Renderer _this)
{
	return _this.material;
}

public static void set_material(UnityEngine.Renderer _this, UnityEngine.Material value)
{
	_this.material = value;
}

public static UnityEngine.Material get_sharedMaterial(UnityEngine.Renderer _this)
{
	return _this.sharedMaterial;
}

public static void set_sharedMaterial(UnityEngine.Renderer _this, UnityEngine.Material value)
{
	_this.sharedMaterial = value;
}

public static UnityEngine.Material[] get_sharedMaterials(UnityEngine.Renderer _this)
{
	return _this.sharedMaterials;
}

public static void set_sharedMaterials(UnityEngine.Renderer _this, UnityEngine.Material[] value)
{
	_this.sharedMaterials = value;
}

}
}
