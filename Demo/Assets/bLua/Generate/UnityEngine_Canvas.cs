
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Canvas
{
public static UnityEngine.RenderMode get_renderMode(UnityEngine.Canvas _this)
{
	return _this.renderMode;
}

public static void set_renderMode(UnityEngine.Canvas _this, UnityEngine.RenderMode value)
{
	_this.renderMode = value;
}

public static bool get_isRootCanvas(UnityEngine.Canvas _this)
{
	return _this.isRootCanvas;
}

public static UnityEngine.Rect get_pixelRect(UnityEngine.Canvas _this)
{
	return _this.pixelRect;
}

public static float get_scaleFactor(UnityEngine.Canvas _this)
{
	return _this.scaleFactor;
}

public static void set_scaleFactor(UnityEngine.Canvas _this, float value)
{
	_this.scaleFactor = value;
}

public static float get_referencePixelsPerUnit(UnityEngine.Canvas _this)
{
	return _this.referencePixelsPerUnit;
}

public static void set_referencePixelsPerUnit(UnityEngine.Canvas _this, float value)
{
	_this.referencePixelsPerUnit = value;
}

public static bool get_overridePixelPerfect(UnityEngine.Canvas _this)
{
	return _this.overridePixelPerfect;
}

public static void set_overridePixelPerfect(UnityEngine.Canvas _this, bool value)
{
	_this.overridePixelPerfect = value;
}

public static bool get_pixelPerfect(UnityEngine.Canvas _this)
{
	return _this.pixelPerfect;
}

public static void set_pixelPerfect(UnityEngine.Canvas _this, bool value)
{
	_this.pixelPerfect = value;
}

public static float get_planeDistance(UnityEngine.Canvas _this)
{
	return _this.planeDistance;
}

public static void set_planeDistance(UnityEngine.Canvas _this, float value)
{
	_this.planeDistance = value;
}

public static int get_renderOrder(UnityEngine.Canvas _this)
{
	return _this.renderOrder;
}

public static bool get_overrideSorting(UnityEngine.Canvas _this)
{
	return _this.overrideSorting;
}

public static void set_overrideSorting(UnityEngine.Canvas _this, bool value)
{
	_this.overrideSorting = value;
}

public static int get_sortingOrder(UnityEngine.Canvas _this)
{
	return _this.sortingOrder;
}

public static void set_sortingOrder(UnityEngine.Canvas _this, int value)
{
	_this.sortingOrder = value;
}

public static int get_targetDisplay(UnityEngine.Canvas _this)
{
	return _this.targetDisplay;
}

public static void set_targetDisplay(UnityEngine.Canvas _this, int value)
{
	_this.targetDisplay = value;
}

public static int get_sortingLayerID(UnityEngine.Canvas _this)
{
	return _this.sortingLayerID;
}

public static void set_sortingLayerID(UnityEngine.Canvas _this, int value)
{
	_this.sortingLayerID = value;
}

public static int get_cachedSortingLayerValue(UnityEngine.Canvas _this)
{
	return _this.cachedSortingLayerValue;
}

public static UnityEngine.AdditionalCanvasShaderChannels get_additionalShaderChannels(UnityEngine.Canvas _this)
{
	return _this.additionalShaderChannels;
}

public static void set_additionalShaderChannels(UnityEngine.Canvas _this, UnityEngine.AdditionalCanvasShaderChannels value)
{
	_this.additionalShaderChannels = value;
}

public static string get_sortingLayerName(UnityEngine.Canvas _this)
{
	return _this.sortingLayerName;
}

public static void set_sortingLayerName(UnityEngine.Canvas _this, string value)
{
	_this.sortingLayerName = value;
}

public static UnityEngine.Canvas get_rootCanvas(UnityEngine.Canvas _this)
{
	return _this.rootCanvas;
}

public static UnityEngine.Vector2 get_renderingDisplaySize(UnityEngine.Canvas _this)
{
	return _this.renderingDisplaySize;
}

public static UnityEngine.Camera get_worldCamera(UnityEngine.Canvas _this)
{
	return _this.worldCamera;
}

public static void set_worldCamera(UnityEngine.Canvas _this, UnityEngine.Camera value)
{
	_this.worldCamera = value;
}

public static float get_normalizedSortingGridSize(UnityEngine.Canvas _this)
{
	return _this.normalizedSortingGridSize;
}

public static void set_normalizedSortingGridSize(UnityEngine.Canvas _this, float value)
{
	_this.normalizedSortingGridSize = value;
}

}
}
