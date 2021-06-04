
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_AnimationClip
{
public static void SampleAnimation(UnityEngine.AnimationClip _this, UnityEngine.GameObject go, float time)
{
	_this.SampleAnimation(go, time);
}

public static void SetCurve(UnityEngine.AnimationClip _this, string relativePath, System.Type type, string propertyName, UnityEngine.AnimationCurve curve)
{
	_this.SetCurve(relativePath, type, propertyName, curve);
}

public static void EnsureQuaternionContinuity(UnityEngine.AnimationClip _this)
{
	_this.EnsureQuaternionContinuity();
}

public static void ClearCurves(UnityEngine.AnimationClip _this)
{
	_this.ClearCurves();
}

public static void AddEvent(UnityEngine.AnimationClip _this, UnityEngine.AnimationEvent evt)
{
	_this.AddEvent(evt);
}

public static float get_length(UnityEngine.AnimationClip _this)
{
	return _this.length;
}

public static float get_frameRate(UnityEngine.AnimationClip _this)
{
	return _this.frameRate;
}

public static void set_frameRate(UnityEngine.AnimationClip _this, float value)
{
	_this.frameRate = value;
}

public static UnityEngine.WrapMode get_wrapMode(UnityEngine.AnimationClip _this)
{
	return _this.wrapMode;
}

public static void set_wrapMode(UnityEngine.AnimationClip _this, UnityEngine.WrapMode value)
{
	_this.wrapMode = value;
}

public static UnityEngine.Bounds get_localBounds(UnityEngine.AnimationClip _this)
{
	return _this.localBounds;
}

public static void set_localBounds(UnityEngine.AnimationClip _this, UnityEngine.Bounds value)
{
	_this.localBounds = value;
}

public static bool get_legacy(UnityEngine.AnimationClip _this)
{
	return _this.legacy;
}

public static void set_legacy(UnityEngine.AnimationClip _this, bool value)
{
	_this.legacy = value;
}

public static bool get_humanMotion(UnityEngine.AnimationClip _this)
{
	return _this.humanMotion;
}

public static bool get_empty(UnityEngine.AnimationClip _this)
{
	return _this.empty;
}

public static bool get_hasGenericRootTransform(UnityEngine.AnimationClip _this)
{
	return _this.hasGenericRootTransform;
}

public static bool get_hasMotionFloatCurves(UnityEngine.AnimationClip _this)
{
	return _this.hasMotionFloatCurves;
}

public static bool get_hasMotionCurves(UnityEngine.AnimationClip _this)
{
	return _this.hasMotionCurves;
}

public static bool get_hasRootCurves(UnityEngine.AnimationClip _this)
{
	return _this.hasRootCurves;
}

public static UnityEngine.AnimationEvent[] get_events(UnityEngine.AnimationClip _this)
{
	return _this.events;
}

public static void set_events(UnityEngine.AnimationClip _this, UnityEngine.AnimationEvent[] value)
{
	_this.events = value;
}

}
}
