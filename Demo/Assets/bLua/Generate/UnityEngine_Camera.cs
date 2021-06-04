
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Camera
{
public static void Reset(UnityEngine.Camera _this)
{
	_this.Reset();
}

public static void ResetTransparencySortSettings(UnityEngine.Camera _this)
{
	_this.ResetTransparencySortSettings();
}

public static void ResetAspect(UnityEngine.Camera _this)
{
	_this.ResetAspect();
}

public static void ResetCullingMatrix(UnityEngine.Camera _this)
{
	_this.ResetCullingMatrix();
}

public static void SetReplacementShader(UnityEngine.Camera _this, UnityEngine.Shader shader, string replacementTag)
{
	_this.SetReplacementShader(shader, replacementTag);
}

public static void ResetReplacementShader(UnityEngine.Camera _this)
{
	_this.ResetReplacementShader();
}

public static float GetGateFittedFieldOfView(UnityEngine.Camera _this)
{
	return _this.GetGateFittedFieldOfView();
}

public static UnityEngine.Vector2 GetGateFittedLensShift(UnityEngine.Camera _this)
{
	return _this.GetGateFittedLensShift();
}

public static void SetTargetBuffers(UnityEngine.Camera _this, UnityEngine.RenderBuffer colorBuffer, UnityEngine.RenderBuffer depthBuffer)
{
	_this.SetTargetBuffers(colorBuffer, depthBuffer);
}

public static void SetTargetBuffers(UnityEngine.Camera _this, UnityEngine.RenderBuffer[] colorBuffer, UnityEngine.RenderBuffer depthBuffer)
{
	_this.SetTargetBuffers(colorBuffer, depthBuffer);
}

public static void ResetWorldToCameraMatrix(UnityEngine.Camera _this)
{
	_this.ResetWorldToCameraMatrix();
}

public static void ResetProjectionMatrix(UnityEngine.Camera _this)
{
	_this.ResetProjectionMatrix();
}

public static UnityEngine.Matrix4x4 CalculateObliqueMatrix(UnityEngine.Camera _this, UnityEngine.Vector4 clipPlane)
{
	return _this.CalculateObliqueMatrix(clipPlane);
}

public static UnityEngine.Vector3 WorldToScreenPoint(UnityEngine.Camera _this, UnityEngine.Vector3 position, int eye)
{
	return _this.WorldToScreenPoint(position, (UnityEngine.Camera.MonoOrStereoscopicEye)eye);
}

public static UnityEngine.Vector3 WorldToViewportPoint(UnityEngine.Camera _this, UnityEngine.Vector3 position, int eye)
{
	return _this.WorldToViewportPoint(position, (UnityEngine.Camera.MonoOrStereoscopicEye)eye);
}

public static UnityEngine.Vector3 ViewportToWorldPoint(UnityEngine.Camera _this, UnityEngine.Vector3 position, int eye)
{
	return _this.ViewportToWorldPoint(position, (UnityEngine.Camera.MonoOrStereoscopicEye)eye);
}

public static UnityEngine.Vector3 ScreenToWorldPoint(UnityEngine.Camera _this, UnityEngine.Vector3 position, int eye)
{
	return _this.ScreenToWorldPoint(position, (UnityEngine.Camera.MonoOrStereoscopicEye)eye);
}

public static UnityEngine.Vector3 WorldToScreenPoint(UnityEngine.Camera _this, UnityEngine.Vector3 position)
{
	return _this.WorldToScreenPoint(position);
}

public static UnityEngine.Vector3 WorldToViewportPoint(UnityEngine.Camera _this, UnityEngine.Vector3 position)
{
	return _this.WorldToViewportPoint(position);
}

public static UnityEngine.Vector3 ViewportToWorldPoint(UnityEngine.Camera _this, UnityEngine.Vector3 position)
{
	return _this.ViewportToWorldPoint(position);
}

public static UnityEngine.Vector3 ScreenToWorldPoint(UnityEngine.Camera _this, UnityEngine.Vector3 position)
{
	return _this.ScreenToWorldPoint(position);
}

public static UnityEngine.Vector3 ScreenToViewportPoint(UnityEngine.Camera _this, UnityEngine.Vector3 position)
{
	return _this.ScreenToViewportPoint(position);
}

public static UnityEngine.Vector3 ViewportToScreenPoint(UnityEngine.Camera _this, UnityEngine.Vector3 position)
{
	return _this.ViewportToScreenPoint(position);
}

public static UnityEngine.Ray ViewportPointToRay(UnityEngine.Camera _this, UnityEngine.Vector3 pos, int eye)
{
	return _this.ViewportPointToRay(pos, (UnityEngine.Camera.MonoOrStereoscopicEye)eye);
}

public static UnityEngine.Ray ViewportPointToRay(UnityEngine.Camera _this, UnityEngine.Vector3 pos)
{
	return _this.ViewportPointToRay(pos);
}

public static UnityEngine.Ray ScreenPointToRay(UnityEngine.Camera _this, UnityEngine.Vector3 pos, int eye)
{
	return _this.ScreenPointToRay(pos, (UnityEngine.Camera.MonoOrStereoscopicEye)eye);
}

public static UnityEngine.Ray ScreenPointToRay(UnityEngine.Camera _this, UnityEngine.Vector3 pos)
{
	return _this.ScreenPointToRay(pos);
}

public static void CalculateFrustumCorners(UnityEngine.Camera _this, UnityEngine.Rect viewport, float z, int eye, UnityEngine.Vector3[] outCorners)
{
	_this.CalculateFrustumCorners(viewport, z, (UnityEngine.Camera.MonoOrStereoscopicEye)eye, outCorners);
}

public static UnityEngine.Matrix4x4 GetStereoNonJitteredProjectionMatrix(UnityEngine.Camera _this, int eye)
{
	return _this.GetStereoNonJitteredProjectionMatrix((UnityEngine.Camera.StereoscopicEye)eye);
}

public static UnityEngine.Matrix4x4 GetStereoViewMatrix(UnityEngine.Camera _this, int eye)
{
	return _this.GetStereoViewMatrix((UnityEngine.Camera.StereoscopicEye)eye);
}

public static void CopyStereoDeviceProjectionMatrixToNonJittered(UnityEngine.Camera _this, int eye)
{
	_this.CopyStereoDeviceProjectionMatrixToNonJittered((UnityEngine.Camera.StereoscopicEye)eye);
}

public static UnityEngine.Matrix4x4 GetStereoProjectionMatrix(UnityEngine.Camera _this, int eye)
{
	return _this.GetStereoProjectionMatrix((UnityEngine.Camera.StereoscopicEye)eye);
}

public static void SetStereoProjectionMatrix(UnityEngine.Camera _this, int eye, UnityEngine.Matrix4x4 matrix)
{
	_this.SetStereoProjectionMatrix((UnityEngine.Camera.StereoscopicEye)eye, matrix);
}

public static void ResetStereoProjectionMatrices(UnityEngine.Camera _this)
{
	_this.ResetStereoProjectionMatrices();
}

public static void SetStereoViewMatrix(UnityEngine.Camera _this, int eye, UnityEngine.Matrix4x4 matrix)
{
	_this.SetStereoViewMatrix((UnityEngine.Camera.StereoscopicEye)eye, matrix);
}

public static void ResetStereoViewMatrices(UnityEngine.Camera _this)
{
	_this.ResetStereoViewMatrices();
}

public static bool RenderToCubemap(UnityEngine.Camera _this, UnityEngine.Cubemap cubemap, int faceMask)
{
	return _this.RenderToCubemap(cubemap, faceMask);
}

public static bool RenderToCubemap(UnityEngine.Camera _this, UnityEngine.Cubemap cubemap)
{
	return _this.RenderToCubemap(cubemap);
}

public static bool RenderToCubemap(UnityEngine.Camera _this, UnityEngine.RenderTexture cubemap, int faceMask)
{
	return _this.RenderToCubemap(cubemap, faceMask);
}

public static bool RenderToCubemap(UnityEngine.Camera _this, UnityEngine.RenderTexture cubemap)
{
	return _this.RenderToCubemap(cubemap);
}

public static bool RenderToCubemap(UnityEngine.Camera _this, UnityEngine.RenderTexture cubemap, int faceMask, int stereoEye)
{
	return _this.RenderToCubemap(cubemap, faceMask, (UnityEngine.Camera.MonoOrStereoscopicEye)stereoEye);
}

public static void Render(UnityEngine.Camera _this)
{
	_this.Render();
}

public static void RenderWithShader(UnityEngine.Camera _this, UnityEngine.Shader shader, string replacementTag)
{
	_this.RenderWithShader(shader, replacementTag);
}

public static void RenderDontRestore(UnityEngine.Camera _this)
{
	_this.RenderDontRestore();
}

public static void CopyFrom(UnityEngine.Camera _this, UnityEngine.Camera other)
{
	_this.CopyFrom(other);
}

public static void RemoveCommandBuffers(UnityEngine.Camera _this, int evt)
{
	_this.RemoveCommandBuffers((UnityEngine.Rendering.CameraEvent)evt);
}

public static void RemoveAllCommandBuffers(UnityEngine.Camera _this)
{
	_this.RemoveAllCommandBuffers();
}

public static void AddCommandBuffer(UnityEngine.Camera _this, int evt, UnityEngine.Rendering.CommandBuffer buffer)
{
	_this.AddCommandBuffer((UnityEngine.Rendering.CameraEvent)evt, buffer);
}

public static void AddCommandBufferAsync(UnityEngine.Camera _this, int evt, UnityEngine.Rendering.CommandBuffer buffer, int queueType)
{
	_this.AddCommandBufferAsync((UnityEngine.Rendering.CameraEvent)evt, buffer, (UnityEngine.Rendering.ComputeQueueType)queueType);
}

public static void RemoveCommandBuffer(UnityEngine.Camera _this, int evt, UnityEngine.Rendering.CommandBuffer buffer)
{
	_this.RemoveCommandBuffer((UnityEngine.Rendering.CameraEvent)evt, buffer);
}

public static UnityEngine.Rendering.CommandBuffer[] GetCommandBuffers(UnityEngine.Camera _this, int evt)
{
	return _this.GetCommandBuffers((UnityEngine.Rendering.CameraEvent)evt);
}

public static float get_nearClipPlane(UnityEngine.Camera _this)
{
	return _this.nearClipPlane;
}

public static void set_nearClipPlane(UnityEngine.Camera _this, float value)
{
	_this.nearClipPlane = value;
}

public static float get_farClipPlane(UnityEngine.Camera _this)
{
	return _this.farClipPlane;
}

public static void set_farClipPlane(UnityEngine.Camera _this, float value)
{
	_this.farClipPlane = value;
}

public static float get_fieldOfView(UnityEngine.Camera _this)
{
	return _this.fieldOfView;
}

public static void set_fieldOfView(UnityEngine.Camera _this, float value)
{
	_this.fieldOfView = value;
}

public static UnityEngine.RenderingPath get_renderingPath(UnityEngine.Camera _this)
{
	return _this.renderingPath;
}

public static void set_renderingPath(UnityEngine.Camera _this, UnityEngine.RenderingPath value)
{
	_this.renderingPath = value;
}

public static UnityEngine.RenderingPath get_actualRenderingPath(UnityEngine.Camera _this)
{
	return _this.actualRenderingPath;
}

public static bool get_allowHDR(UnityEngine.Camera _this)
{
	return _this.allowHDR;
}

public static void set_allowHDR(UnityEngine.Camera _this, bool value)
{
	_this.allowHDR = value;
}

public static bool get_allowMSAA(UnityEngine.Camera _this)
{
	return _this.allowMSAA;
}

public static void set_allowMSAA(UnityEngine.Camera _this, bool value)
{
	_this.allowMSAA = value;
}

public static bool get_allowDynamicResolution(UnityEngine.Camera _this)
{
	return _this.allowDynamicResolution;
}

public static void set_allowDynamicResolution(UnityEngine.Camera _this, bool value)
{
	_this.allowDynamicResolution = value;
}

public static bool get_forceIntoRenderTexture(UnityEngine.Camera _this)
{
	return _this.forceIntoRenderTexture;
}

public static void set_forceIntoRenderTexture(UnityEngine.Camera _this, bool value)
{
	_this.forceIntoRenderTexture = value;
}

public static float get_orthographicSize(UnityEngine.Camera _this)
{
	return _this.orthographicSize;
}

public static void set_orthographicSize(UnityEngine.Camera _this, float value)
{
	_this.orthographicSize = value;
}

public static bool get_orthographic(UnityEngine.Camera _this)
{
	return _this.orthographic;
}

public static void set_orthographic(UnityEngine.Camera _this, bool value)
{
	_this.orthographic = value;
}

public static UnityEngine.Rendering.OpaqueSortMode get_opaqueSortMode(UnityEngine.Camera _this)
{
	return _this.opaqueSortMode;
}

public static void set_opaqueSortMode(UnityEngine.Camera _this, UnityEngine.Rendering.OpaqueSortMode value)
{
	_this.opaqueSortMode = value;
}

public static UnityEngine.TransparencySortMode get_transparencySortMode(UnityEngine.Camera _this)
{
	return _this.transparencySortMode;
}

public static void set_transparencySortMode(UnityEngine.Camera _this, UnityEngine.TransparencySortMode value)
{
	_this.transparencySortMode = value;
}

public static UnityEngine.Vector3 get_transparencySortAxis(UnityEngine.Camera _this)
{
	return _this.transparencySortAxis;
}

public static void set_transparencySortAxis(UnityEngine.Camera _this, UnityEngine.Vector3 value)
{
	_this.transparencySortAxis = value;
}

public static float get_depth(UnityEngine.Camera _this)
{
	return _this.depth;
}

public static void set_depth(UnityEngine.Camera _this, float value)
{
	_this.depth = value;
}

public static float get_aspect(UnityEngine.Camera _this)
{
	return _this.aspect;
}

public static void set_aspect(UnityEngine.Camera _this, float value)
{
	_this.aspect = value;
}

public static UnityEngine.Vector3 get_velocity(UnityEngine.Camera _this)
{
	return _this.velocity;
}

public static int get_cullingMask(UnityEngine.Camera _this)
{
	return _this.cullingMask;
}

public static void set_cullingMask(UnityEngine.Camera _this, int value)
{
	_this.cullingMask = value;
}

public static int get_eventMask(UnityEngine.Camera _this)
{
	return _this.eventMask;
}

public static void set_eventMask(UnityEngine.Camera _this, int value)
{
	_this.eventMask = value;
}

public static bool get_layerCullSpherical(UnityEngine.Camera _this)
{
	return _this.layerCullSpherical;
}

public static void set_layerCullSpherical(UnityEngine.Camera _this, bool value)
{
	_this.layerCullSpherical = value;
}

public static UnityEngine.CameraType get_cameraType(UnityEngine.Camera _this)
{
	return _this.cameraType;
}

public static void set_cameraType(UnityEngine.Camera _this, UnityEngine.CameraType value)
{
	_this.cameraType = value;
}

public static ulong get_overrideSceneCullingMask(UnityEngine.Camera _this)
{
	return _this.overrideSceneCullingMask;
}

public static void set_overrideSceneCullingMask(UnityEngine.Camera _this, ulong value)
{
	_this.overrideSceneCullingMask = value;
}

public static float[] get_layerCullDistances(UnityEngine.Camera _this)
{
	return _this.layerCullDistances;
}

public static void set_layerCullDistances(UnityEngine.Camera _this, float[] value)
{
	_this.layerCullDistances = value;
}

public static bool get_useOcclusionCulling(UnityEngine.Camera _this)
{
	return _this.useOcclusionCulling;
}

public static void set_useOcclusionCulling(UnityEngine.Camera _this, bool value)
{
	_this.useOcclusionCulling = value;
}

public static UnityEngine.Matrix4x4 get_cullingMatrix(UnityEngine.Camera _this)
{
	return _this.cullingMatrix;
}

public static void set_cullingMatrix(UnityEngine.Camera _this, UnityEngine.Matrix4x4 value)
{
	_this.cullingMatrix = value;
}

public static UnityEngine.Color get_backgroundColor(UnityEngine.Camera _this)
{
	return _this.backgroundColor;
}

public static void set_backgroundColor(UnityEngine.Camera _this, UnityEngine.Color value)
{
	_this.backgroundColor = value;
}

public static UnityEngine.CameraClearFlags get_clearFlags(UnityEngine.Camera _this)
{
	return _this.clearFlags;
}

public static void set_clearFlags(UnityEngine.Camera _this, UnityEngine.CameraClearFlags value)
{
	_this.clearFlags = value;
}

public static UnityEngine.DepthTextureMode get_depthTextureMode(UnityEngine.Camera _this)
{
	return _this.depthTextureMode;
}

public static void set_depthTextureMode(UnityEngine.Camera _this, UnityEngine.DepthTextureMode value)
{
	_this.depthTextureMode = value;
}

public static bool get_clearStencilAfterLightingPass(UnityEngine.Camera _this)
{
	return _this.clearStencilAfterLightingPass;
}

public static void set_clearStencilAfterLightingPass(UnityEngine.Camera _this, bool value)
{
	_this.clearStencilAfterLightingPass = value;
}

public static bool get_usePhysicalProperties(UnityEngine.Camera _this)
{
	return _this.usePhysicalProperties;
}

public static void set_usePhysicalProperties(UnityEngine.Camera _this, bool value)
{
	_this.usePhysicalProperties = value;
}

public static UnityEngine.Vector2 get_sensorSize(UnityEngine.Camera _this)
{
	return _this.sensorSize;
}

public static void set_sensorSize(UnityEngine.Camera _this, UnityEngine.Vector2 value)
{
	_this.sensorSize = value;
}

public static UnityEngine.Vector2 get_lensShift(UnityEngine.Camera _this)
{
	return _this.lensShift;
}

public static void set_lensShift(UnityEngine.Camera _this, UnityEngine.Vector2 value)
{
	_this.lensShift = value;
}

public static float get_focalLength(UnityEngine.Camera _this)
{
	return _this.focalLength;
}

public static void set_focalLength(UnityEngine.Camera _this, float value)
{
	_this.focalLength = value;
}

public static UnityEngine.Camera.GateFitMode get_gateFit(UnityEngine.Camera _this)
{
	return _this.gateFit;
}

public static void set_gateFit(UnityEngine.Camera _this, UnityEngine.Camera.GateFitMode value)
{
	_this.gateFit = value;
}

public static UnityEngine.Rect get_rect(UnityEngine.Camera _this)
{
	return _this.rect;
}

public static void set_rect(UnityEngine.Camera _this, UnityEngine.Rect value)
{
	_this.rect = value;
}

public static UnityEngine.Rect get_pixelRect(UnityEngine.Camera _this)
{
	return _this.pixelRect;
}

public static void set_pixelRect(UnityEngine.Camera _this, UnityEngine.Rect value)
{
	_this.pixelRect = value;
}

public static int get_pixelWidth(UnityEngine.Camera _this)
{
	return _this.pixelWidth;
}

public static int get_pixelHeight(UnityEngine.Camera _this)
{
	return _this.pixelHeight;
}

public static int get_scaledPixelWidth(UnityEngine.Camera _this)
{
	return _this.scaledPixelWidth;
}

public static int get_scaledPixelHeight(UnityEngine.Camera _this)
{
	return _this.scaledPixelHeight;
}

public static UnityEngine.RenderTexture get_targetTexture(UnityEngine.Camera _this)
{
	return _this.targetTexture;
}

public static void set_targetTexture(UnityEngine.Camera _this, UnityEngine.RenderTexture value)
{
	_this.targetTexture = value;
}

public static UnityEngine.RenderTexture get_activeTexture(UnityEngine.Camera _this)
{
	return _this.activeTexture;
}

public static int get_targetDisplay(UnityEngine.Camera _this)
{
	return _this.targetDisplay;
}

public static void set_targetDisplay(UnityEngine.Camera _this, int value)
{
	_this.targetDisplay = value;
}

public static UnityEngine.Matrix4x4 get_cameraToWorldMatrix(UnityEngine.Camera _this)
{
	return _this.cameraToWorldMatrix;
}

public static UnityEngine.Matrix4x4 get_worldToCameraMatrix(UnityEngine.Camera _this)
{
	return _this.worldToCameraMatrix;
}

public static void set_worldToCameraMatrix(UnityEngine.Camera _this, UnityEngine.Matrix4x4 value)
{
	_this.worldToCameraMatrix = value;
}

public static UnityEngine.Matrix4x4 get_projectionMatrix(UnityEngine.Camera _this)
{
	return _this.projectionMatrix;
}

public static void set_projectionMatrix(UnityEngine.Camera _this, UnityEngine.Matrix4x4 value)
{
	_this.projectionMatrix = value;
}

public static UnityEngine.Matrix4x4 get_nonJitteredProjectionMatrix(UnityEngine.Camera _this)
{
	return _this.nonJitteredProjectionMatrix;
}

public static void set_nonJitteredProjectionMatrix(UnityEngine.Camera _this, UnityEngine.Matrix4x4 value)
{
	_this.nonJitteredProjectionMatrix = value;
}

public static bool get_useJitteredProjectionMatrixForTransparentRendering(UnityEngine.Camera _this)
{
	return _this.useJitteredProjectionMatrixForTransparentRendering;
}

public static void set_useJitteredProjectionMatrixForTransparentRendering(UnityEngine.Camera _this, bool value)
{
	_this.useJitteredProjectionMatrixForTransparentRendering = value;
}

public static UnityEngine.Matrix4x4 get_previousViewProjectionMatrix(UnityEngine.Camera _this)
{
	return _this.previousViewProjectionMatrix;
}

public static UnityEngine.SceneManagement.Scene get_scene(UnityEngine.Camera _this)
{
	return _this.scene;
}

public static void set_scene(UnityEngine.Camera _this, UnityEngine.SceneManagement.Scene value)
{
	_this.scene = value;
}

public static bool get_stereoEnabled(UnityEngine.Camera _this)
{
	return _this.stereoEnabled;
}

public static float get_stereoSeparation(UnityEngine.Camera _this)
{
	return _this.stereoSeparation;
}

public static void set_stereoSeparation(UnityEngine.Camera _this, float value)
{
	_this.stereoSeparation = value;
}

public static float get_stereoConvergence(UnityEngine.Camera _this)
{
	return _this.stereoConvergence;
}

public static void set_stereoConvergence(UnityEngine.Camera _this, float value)
{
	_this.stereoConvergence = value;
}

public static bool get_areVRStereoViewMatricesWithinSingleCullTolerance(UnityEngine.Camera _this)
{
	return _this.areVRStereoViewMatricesWithinSingleCullTolerance;
}

public static UnityEngine.StereoTargetEyeMask get_stereoTargetEye(UnityEngine.Camera _this)
{
	return _this.stereoTargetEye;
}

public static void set_stereoTargetEye(UnityEngine.Camera _this, UnityEngine.StereoTargetEyeMask value)
{
	_this.stereoTargetEye = value;
}

public static UnityEngine.Camera.MonoOrStereoscopicEye get_stereoActiveEye(UnityEngine.Camera _this)
{
	return _this.stereoActiveEye;
}

public static int get_commandBufferCount(UnityEngine.Camera _this)
{
	return _this.commandBufferCount;
}

}
}
