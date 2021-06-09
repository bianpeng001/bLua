
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_LineRenderer
{
public static void SetPosition(UnityEngine.LineRenderer _this, int index, UnityEngine.Vector3 position)
{
	_this.SetPosition(index, position);
}

public static UnityEngine.Vector3 GetPosition(UnityEngine.LineRenderer _this, int index)
{
	return _this.GetPosition(index);
}

public static void Simplify(UnityEngine.LineRenderer _this, float tolerance)
{
	_this.Simplify(tolerance);
}

public static void BakeMesh(UnityEngine.LineRenderer _this, UnityEngine.Mesh mesh, bool useTransform)
{
	_this.BakeMesh(mesh, useTransform);
}

public static void BakeMesh(UnityEngine.LineRenderer _this, UnityEngine.Mesh mesh, UnityEngine.Camera camera, bool useTransform)
{
	_this.BakeMesh(mesh, camera, useTransform);
}

public static void SetPositions(UnityEngine.LineRenderer _this, UnityEngine.Vector3[] positions)
{
	_this.SetPositions(positions);
}

public static float get_startWidth(UnityEngine.LineRenderer _this)
{
	return _this.startWidth;
}

public static void set_startWidth(UnityEngine.LineRenderer _this, float value)
{
	_this.startWidth = value;
}

public static float get_endWidth(UnityEngine.LineRenderer _this)
{
	return _this.endWidth;
}

public static void set_endWidth(UnityEngine.LineRenderer _this, float value)
{
	_this.endWidth = value;
}

public static float get_widthMultiplier(UnityEngine.LineRenderer _this)
{
	return _this.widthMultiplier;
}

public static void set_widthMultiplier(UnityEngine.LineRenderer _this, float value)
{
	_this.widthMultiplier = value;
}

public static int get_numCornerVertices(UnityEngine.LineRenderer _this)
{
	return _this.numCornerVertices;
}

public static void set_numCornerVertices(UnityEngine.LineRenderer _this, int value)
{
	_this.numCornerVertices = value;
}

public static int get_numCapVertices(UnityEngine.LineRenderer _this)
{
	return _this.numCapVertices;
}

public static void set_numCapVertices(UnityEngine.LineRenderer _this, int value)
{
	_this.numCapVertices = value;
}

public static bool get_useWorldSpace(UnityEngine.LineRenderer _this)
{
	return _this.useWorldSpace;
}

public static void set_useWorldSpace(UnityEngine.LineRenderer _this, bool value)
{
	_this.useWorldSpace = value;
}

public static bool get_loop(UnityEngine.LineRenderer _this)
{
	return _this.loop;
}

public static void set_loop(UnityEngine.LineRenderer _this, bool value)
{
	_this.loop = value;
}

public static UnityEngine.Color get_startColor(UnityEngine.LineRenderer _this)
{
	return _this.startColor;
}

public static void set_startColor(UnityEngine.LineRenderer _this, UnityEngine.Color value)
{
	_this.startColor = value;
}

public static UnityEngine.Color get_endColor(UnityEngine.LineRenderer _this)
{
	return _this.endColor;
}

public static void set_endColor(UnityEngine.LineRenderer _this, UnityEngine.Color value)
{
	_this.endColor = value;
}

public static int get_positionCount(UnityEngine.LineRenderer _this)
{
	return _this.positionCount;
}

public static void set_positionCount(UnityEngine.LineRenderer _this, int value)
{
	_this.positionCount = value;
}

public static float get_shadowBias(UnityEngine.LineRenderer _this)
{
	return _this.shadowBias;
}

public static void set_shadowBias(UnityEngine.LineRenderer _this, float value)
{
	_this.shadowBias = value;
}

public static bool get_generateLightingData(UnityEngine.LineRenderer _this)
{
	return _this.generateLightingData;
}

public static void set_generateLightingData(UnityEngine.LineRenderer _this, bool value)
{
	_this.generateLightingData = value;
}

public static UnityEngine.LineTextureMode get_textureMode(UnityEngine.LineRenderer _this)
{
	return _this.textureMode;
}

public static void set_textureMode(UnityEngine.LineRenderer _this, UnityEngine.LineTextureMode value)
{
	_this.textureMode = value;
}

public static UnityEngine.LineAlignment get_alignment(UnityEngine.LineRenderer _this)
{
	return _this.alignment;
}

public static void set_alignment(UnityEngine.LineRenderer _this, UnityEngine.LineAlignment value)
{
	_this.alignment = value;
}

public static UnityEngine.AnimationCurve get_widthCurve(UnityEngine.LineRenderer _this)
{
	return _this.widthCurve;
}

public static void set_widthCurve(UnityEngine.LineRenderer _this, UnityEngine.AnimationCurve value)
{
	_this.widthCurve = value;
}

public static UnityEngine.Gradient get_colorGradient(UnityEngine.LineRenderer _this)
{
	return _this.colorGradient;
}

public static void set_colorGradient(UnityEngine.LineRenderer _this, UnityEngine.Gradient value)
{
	_this.colorGradient = value;
}

}
}
