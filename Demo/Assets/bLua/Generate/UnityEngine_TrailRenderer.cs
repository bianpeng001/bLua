
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_TrailRenderer
{
public static void SetPosition(UnityEngine.TrailRenderer _this, int index, UnityEngine.Vector3 position)
{
	_this.SetPosition(index, position);
}

public static UnityEngine.Vector3 GetPosition(UnityEngine.TrailRenderer _this, int index)
{
	return _this.GetPosition(index);
}

public static void Clear(UnityEngine.TrailRenderer _this)
{
	_this.Clear();
}

public static void BakeMesh(UnityEngine.TrailRenderer _this, UnityEngine.Mesh mesh, bool useTransform)
{
	_this.BakeMesh(mesh, useTransform);
}

public static void BakeMesh(UnityEngine.TrailRenderer _this, UnityEngine.Mesh mesh, UnityEngine.Camera camera, bool useTransform)
{
	_this.BakeMesh(mesh, camera, useTransform);
}

public static void SetPositions(UnityEngine.TrailRenderer _this, UnityEngine.Vector3[] positions)
{
	_this.SetPositions(positions);
}

public static void AddPosition(UnityEngine.TrailRenderer _this, UnityEngine.Vector3 position)
{
	_this.AddPosition(position);
}

public static void AddPositions(UnityEngine.TrailRenderer _this, UnityEngine.Vector3[] positions)
{
	_this.AddPositions(positions);
}

public static float get_time(UnityEngine.TrailRenderer _this)
{
	return _this.time;
}

public static void set_time(UnityEngine.TrailRenderer _this, float value)
{
	_this.time = value;
}

public static float get_startWidth(UnityEngine.TrailRenderer _this)
{
	return _this.startWidth;
}

public static void set_startWidth(UnityEngine.TrailRenderer _this, float value)
{
	_this.startWidth = value;
}

public static float get_endWidth(UnityEngine.TrailRenderer _this)
{
	return _this.endWidth;
}

public static void set_endWidth(UnityEngine.TrailRenderer _this, float value)
{
	_this.endWidth = value;
}

public static float get_widthMultiplier(UnityEngine.TrailRenderer _this)
{
	return _this.widthMultiplier;
}

public static void set_widthMultiplier(UnityEngine.TrailRenderer _this, float value)
{
	_this.widthMultiplier = value;
}

public static bool get_autodestruct(UnityEngine.TrailRenderer _this)
{
	return _this.autodestruct;
}

public static void set_autodestruct(UnityEngine.TrailRenderer _this, bool value)
{
	_this.autodestruct = value;
}

public static bool get_emitting(UnityEngine.TrailRenderer _this)
{
	return _this.emitting;
}

public static void set_emitting(UnityEngine.TrailRenderer _this, bool value)
{
	_this.emitting = value;
}

public static int get_numCornerVertices(UnityEngine.TrailRenderer _this)
{
	return _this.numCornerVertices;
}

public static void set_numCornerVertices(UnityEngine.TrailRenderer _this, int value)
{
	_this.numCornerVertices = value;
}

public static int get_numCapVertices(UnityEngine.TrailRenderer _this)
{
	return _this.numCapVertices;
}

public static void set_numCapVertices(UnityEngine.TrailRenderer _this, int value)
{
	_this.numCapVertices = value;
}

public static float get_minVertexDistance(UnityEngine.TrailRenderer _this)
{
	return _this.minVertexDistance;
}

public static void set_minVertexDistance(UnityEngine.TrailRenderer _this, float value)
{
	_this.minVertexDistance = value;
}

public static UnityEngine.Color get_startColor(UnityEngine.TrailRenderer _this)
{
	return _this.startColor;
}

public static void set_startColor(UnityEngine.TrailRenderer _this, UnityEngine.Color value)
{
	_this.startColor = value;
}

public static UnityEngine.Color get_endColor(UnityEngine.TrailRenderer _this)
{
	return _this.endColor;
}

public static void set_endColor(UnityEngine.TrailRenderer _this, UnityEngine.Color value)
{
	_this.endColor = value;
}

public static int get_positionCount(UnityEngine.TrailRenderer _this)
{
	return _this.positionCount;
}

public static float get_shadowBias(UnityEngine.TrailRenderer _this)
{
	return _this.shadowBias;
}

public static void set_shadowBias(UnityEngine.TrailRenderer _this, float value)
{
	_this.shadowBias = value;
}

public static bool get_generateLightingData(UnityEngine.TrailRenderer _this)
{
	return _this.generateLightingData;
}

public static void set_generateLightingData(UnityEngine.TrailRenderer _this, bool value)
{
	_this.generateLightingData = value;
}

public static UnityEngine.LineTextureMode get_textureMode(UnityEngine.TrailRenderer _this)
{
	return _this.textureMode;
}

public static void set_textureMode(UnityEngine.TrailRenderer _this, UnityEngine.LineTextureMode value)
{
	_this.textureMode = value;
}

public static UnityEngine.LineAlignment get_alignment(UnityEngine.TrailRenderer _this)
{
	return _this.alignment;
}

public static void set_alignment(UnityEngine.TrailRenderer _this, UnityEngine.LineAlignment value)
{
	_this.alignment = value;
}

public static UnityEngine.AnimationCurve get_widthCurve(UnityEngine.TrailRenderer _this)
{
	return _this.widthCurve;
}

public static void set_widthCurve(UnityEngine.TrailRenderer _this, UnityEngine.AnimationCurve value)
{
	_this.widthCurve = value;
}

public static UnityEngine.Gradient get_colorGradient(UnityEngine.TrailRenderer _this)
{
	return _this.colorGradient;
}

public static void set_colorGradient(UnityEngine.TrailRenderer _this, UnityEngine.Gradient value)
{
	_this.colorGradient = value;
}

}
}
