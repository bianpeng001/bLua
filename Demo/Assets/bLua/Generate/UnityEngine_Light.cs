
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Light
{
public static void Reset(UnityEngine.Light _this)
{
	_this.Reset();
}

public static void SetLightDirty(UnityEngine.Light _this)
{
	_this.SetLightDirty();
}

public static void AddCommandBuffer(UnityEngine.Light _this, int evt, UnityEngine.Rendering.CommandBuffer buffer)
{
	_this.AddCommandBuffer((UnityEngine.Rendering.LightEvent)evt, buffer);
}

public static void AddCommandBuffer(UnityEngine.Light _this, int evt, UnityEngine.Rendering.CommandBuffer buffer, int shadowPassMask)
{
	_this.AddCommandBuffer((UnityEngine.Rendering.LightEvent)evt, buffer, (UnityEngine.Rendering.ShadowMapPass)shadowPassMask);
}

public static void AddCommandBufferAsync(UnityEngine.Light _this, int evt, UnityEngine.Rendering.CommandBuffer buffer, int queueType)
{
	_this.AddCommandBufferAsync((UnityEngine.Rendering.LightEvent)evt, buffer, (UnityEngine.Rendering.ComputeQueueType)queueType);
}

public static void AddCommandBufferAsync(UnityEngine.Light _this, int evt, UnityEngine.Rendering.CommandBuffer buffer, int shadowPassMask, int queueType)
{
	_this.AddCommandBufferAsync((UnityEngine.Rendering.LightEvent)evt, buffer, (UnityEngine.Rendering.ShadowMapPass)shadowPassMask, (UnityEngine.Rendering.ComputeQueueType)queueType);
}

public static void RemoveCommandBuffer(UnityEngine.Light _this, int evt, UnityEngine.Rendering.CommandBuffer buffer)
{
	_this.RemoveCommandBuffer((UnityEngine.Rendering.LightEvent)evt, buffer);
}

public static void RemoveCommandBuffers(UnityEngine.Light _this, int evt)
{
	_this.RemoveCommandBuffers((UnityEngine.Rendering.LightEvent)evt);
}

public static void RemoveAllCommandBuffers(UnityEngine.Light _this)
{
	_this.RemoveAllCommandBuffers();
}

public static UnityEngine.Rendering.CommandBuffer[] GetCommandBuffers(UnityEngine.Light _this, int evt)
{
	return _this.GetCommandBuffers((UnityEngine.Rendering.LightEvent)evt);
}

public static UnityEngine.LightType get_type(UnityEngine.Light _this)
{
	return _this.type;
}

public static void set_type(UnityEngine.Light _this, UnityEngine.LightType value)
{
	_this.type = value;
}

public static UnityEngine.LightShape get_shape(UnityEngine.Light _this)
{
	return _this.shape;
}

public static void set_shape(UnityEngine.Light _this, UnityEngine.LightShape value)
{
	_this.shape = value;
}

public static float get_spotAngle(UnityEngine.Light _this)
{
	return _this.spotAngle;
}

public static void set_spotAngle(UnityEngine.Light _this, float value)
{
	_this.spotAngle = value;
}

public static float get_innerSpotAngle(UnityEngine.Light _this)
{
	return _this.innerSpotAngle;
}

public static void set_innerSpotAngle(UnityEngine.Light _this, float value)
{
	_this.innerSpotAngle = value;
}

public static UnityEngine.Color get_color(UnityEngine.Light _this)
{
	return _this.color;
}

public static void set_color(UnityEngine.Light _this, UnityEngine.Color value)
{
	_this.color = value;
}

public static float get_colorTemperature(UnityEngine.Light _this)
{
	return _this.colorTemperature;
}

public static void set_colorTemperature(UnityEngine.Light _this, float value)
{
	_this.colorTemperature = value;
}

public static bool get_useColorTemperature(UnityEngine.Light _this)
{
	return _this.useColorTemperature;
}

public static void set_useColorTemperature(UnityEngine.Light _this, bool value)
{
	_this.useColorTemperature = value;
}

public static float get_intensity(UnityEngine.Light _this)
{
	return _this.intensity;
}

public static void set_intensity(UnityEngine.Light _this, float value)
{
	_this.intensity = value;
}

public static float get_bounceIntensity(UnityEngine.Light _this)
{
	return _this.bounceIntensity;
}

public static void set_bounceIntensity(UnityEngine.Light _this, float value)
{
	_this.bounceIntensity = value;
}

public static bool get_useBoundingSphereOverride(UnityEngine.Light _this)
{
	return _this.useBoundingSphereOverride;
}

public static void set_useBoundingSphereOverride(UnityEngine.Light _this, bool value)
{
	_this.useBoundingSphereOverride = value;
}

public static UnityEngine.Vector4 get_boundingSphereOverride(UnityEngine.Light _this)
{
	return _this.boundingSphereOverride;
}

public static void set_boundingSphereOverride(UnityEngine.Light _this, UnityEngine.Vector4 value)
{
	_this.boundingSphereOverride = value;
}

public static bool get_useViewFrustumForShadowCasterCull(UnityEngine.Light _this)
{
	return _this.useViewFrustumForShadowCasterCull;
}

public static void set_useViewFrustumForShadowCasterCull(UnityEngine.Light _this, bool value)
{
	_this.useViewFrustumForShadowCasterCull = value;
}

public static int get_shadowCustomResolution(UnityEngine.Light _this)
{
	return _this.shadowCustomResolution;
}

public static void set_shadowCustomResolution(UnityEngine.Light _this, int value)
{
	_this.shadowCustomResolution = value;
}

public static float get_shadowBias(UnityEngine.Light _this)
{
	return _this.shadowBias;
}

public static void set_shadowBias(UnityEngine.Light _this, float value)
{
	_this.shadowBias = value;
}

public static float get_shadowNormalBias(UnityEngine.Light _this)
{
	return _this.shadowNormalBias;
}

public static void set_shadowNormalBias(UnityEngine.Light _this, float value)
{
	_this.shadowNormalBias = value;
}

public static float get_shadowNearPlane(UnityEngine.Light _this)
{
	return _this.shadowNearPlane;
}

public static void set_shadowNearPlane(UnityEngine.Light _this, float value)
{
	_this.shadowNearPlane = value;
}

public static bool get_useShadowMatrixOverride(UnityEngine.Light _this)
{
	return _this.useShadowMatrixOverride;
}

public static void set_useShadowMatrixOverride(UnityEngine.Light _this, bool value)
{
	_this.useShadowMatrixOverride = value;
}

public static UnityEngine.Matrix4x4 get_shadowMatrixOverride(UnityEngine.Light _this)
{
	return _this.shadowMatrixOverride;
}

public static void set_shadowMatrixOverride(UnityEngine.Light _this, UnityEngine.Matrix4x4 value)
{
	_this.shadowMatrixOverride = value;
}

public static float get_range(UnityEngine.Light _this)
{
	return _this.range;
}

public static void set_range(UnityEngine.Light _this, float value)
{
	_this.range = value;
}

public static UnityEngine.Flare get_flare(UnityEngine.Light _this)
{
	return _this.flare;
}

public static void set_flare(UnityEngine.Light _this, UnityEngine.Flare value)
{
	_this.flare = value;
}

public static UnityEngine.LightBakingOutput get_bakingOutput(UnityEngine.Light _this)
{
	return _this.bakingOutput;
}

public static void set_bakingOutput(UnityEngine.Light _this, UnityEngine.LightBakingOutput value)
{
	_this.bakingOutput = value;
}

public static int get_cullingMask(UnityEngine.Light _this)
{
	return _this.cullingMask;
}

public static void set_cullingMask(UnityEngine.Light _this, int value)
{
	_this.cullingMask = value;
}

public static int get_renderingLayerMask(UnityEngine.Light _this)
{
	return _this.renderingLayerMask;
}

public static void set_renderingLayerMask(UnityEngine.Light _this, int value)
{
	_this.renderingLayerMask = value;
}

public static UnityEngine.LightShadowCasterMode get_lightShadowCasterMode(UnityEngine.Light _this)
{
	return _this.lightShadowCasterMode;
}

public static void set_lightShadowCasterMode(UnityEngine.Light _this, UnityEngine.LightShadowCasterMode value)
{
	_this.lightShadowCasterMode = value;
}

public static float get_shadowRadius(UnityEngine.Light _this)
{
	return _this.shadowRadius;
}

public static void set_shadowRadius(UnityEngine.Light _this, float value)
{
	_this.shadowRadius = value;
}

public static float get_shadowAngle(UnityEngine.Light _this)
{
	return _this.shadowAngle;
}

public static void set_shadowAngle(UnityEngine.Light _this, float value)
{
	_this.shadowAngle = value;
}

public static UnityEngine.LightShadows get_shadows(UnityEngine.Light _this)
{
	return _this.shadows;
}

public static void set_shadows(UnityEngine.Light _this, UnityEngine.LightShadows value)
{
	_this.shadows = value;
}

public static float get_shadowStrength(UnityEngine.Light _this)
{
	return _this.shadowStrength;
}

public static void set_shadowStrength(UnityEngine.Light _this, float value)
{
	_this.shadowStrength = value;
}

public static UnityEngine.Rendering.LightShadowResolution get_shadowResolution(UnityEngine.Light _this)
{
	return _this.shadowResolution;
}

public static void set_shadowResolution(UnityEngine.Light _this, UnityEngine.Rendering.LightShadowResolution value)
{
	_this.shadowResolution = value;
}

public static float[] get_layerShadowCullDistances(UnityEngine.Light _this)
{
	return _this.layerShadowCullDistances;
}

public static void set_layerShadowCullDistances(UnityEngine.Light _this, float[] value)
{
	_this.layerShadowCullDistances = value;
}

public static float get_cookieSize(UnityEngine.Light _this)
{
	return _this.cookieSize;
}

public static void set_cookieSize(UnityEngine.Light _this, float value)
{
	_this.cookieSize = value;
}

public static UnityEngine.Texture get_cookie(UnityEngine.Light _this)
{
	return _this.cookie;
}

public static void set_cookie(UnityEngine.Light _this, UnityEngine.Texture value)
{
	_this.cookie = value;
}

public static UnityEngine.LightRenderMode get_renderMode(UnityEngine.Light _this)
{
	return _this.renderMode;
}

public static void set_renderMode(UnityEngine.Light _this, UnityEngine.LightRenderMode value)
{
	_this.renderMode = value;
}

public static UnityEngine.Vector2 get_areaSize(UnityEngine.Light _this)
{
	return _this.areaSize;
}

public static void set_areaSize(UnityEngine.Light _this, UnityEngine.Vector2 value)
{
	_this.areaSize = value;
}

public static UnityEngine.LightmapBakeType get_lightmapBakeType(UnityEngine.Light _this)
{
	return _this.lightmapBakeType;
}

public static void set_lightmapBakeType(UnityEngine.Light _this, UnityEngine.LightmapBakeType value)
{
	_this.lightmapBakeType = value;
}

public static int get_commandBufferCount(UnityEngine.Light _this)
{
	return _this.commandBufferCount;
}

}
}
