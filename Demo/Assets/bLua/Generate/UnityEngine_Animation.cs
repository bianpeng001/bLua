
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Animation
{
public static void Stop(UnityEngine.Animation _this)
{
	_this.Stop();
}

public static void Stop(UnityEngine.Animation _this, string name)
{
	_this.Stop(name);
}

public static void Rewind(UnityEngine.Animation _this)
{
	_this.Rewind();
}

public static void Rewind(UnityEngine.Animation _this, string name)
{
	_this.Rewind(name);
}

public static void Sample(UnityEngine.Animation _this)
{
	_this.Sample();
}

public static bool IsPlaying(UnityEngine.Animation _this, string name)
{
	return _this.IsPlaying(name);
}

public static bool Play(UnityEngine.Animation _this)
{
	return _this.Play();
}

public static bool Play(UnityEngine.Animation _this, int mode)
{
	return _this.Play((UnityEngine.PlayMode)mode);
}

public static bool Play(UnityEngine.Animation _this, string animation)
{
	return _this.Play(animation);
}

public static bool Play(UnityEngine.Animation _this, string animation, int mode)
{
	return _this.Play(animation, (UnityEngine.PlayMode)mode);
}

public static void CrossFade(UnityEngine.Animation _this, string animation)
{
	_this.CrossFade(animation);
}

public static void CrossFade(UnityEngine.Animation _this, string animation, float fadeLength)
{
	_this.CrossFade(animation, fadeLength);
}

public static void CrossFade(UnityEngine.Animation _this, string animation, float fadeLength, int mode)
{
	_this.CrossFade(animation, fadeLength, (UnityEngine.PlayMode)mode);
}

public static void Blend(UnityEngine.Animation _this, string animation)
{
	_this.Blend(animation);
}

public static void Blend(UnityEngine.Animation _this, string animation, float targetWeight)
{
	_this.Blend(animation, targetWeight);
}

public static void Blend(UnityEngine.Animation _this, string animation, float targetWeight, float fadeLength)
{
	_this.Blend(animation, targetWeight, fadeLength);
}

public static UnityEngine.AnimationState CrossFadeQueued(UnityEngine.Animation _this, string animation)
{
	return _this.CrossFadeQueued(animation);
}

public static UnityEngine.AnimationState CrossFadeQueued(UnityEngine.Animation _this, string animation, float fadeLength)
{
	return _this.CrossFadeQueued(animation, fadeLength);
}

public static UnityEngine.AnimationState CrossFadeQueued(UnityEngine.Animation _this, string animation, float fadeLength, int queue)
{
	return _this.CrossFadeQueued(animation, fadeLength, (UnityEngine.QueueMode)queue);
}

public static UnityEngine.AnimationState CrossFadeQueued(UnityEngine.Animation _this, string animation, float fadeLength, int queue, int mode)
{
	return _this.CrossFadeQueued(animation, fadeLength, (UnityEngine.QueueMode)queue, (UnityEngine.PlayMode)mode);
}

public static UnityEngine.AnimationState PlayQueued(UnityEngine.Animation _this, string animation)
{
	return _this.PlayQueued(animation);
}

public static UnityEngine.AnimationState PlayQueued(UnityEngine.Animation _this, string animation, int queue)
{
	return _this.PlayQueued(animation, (UnityEngine.QueueMode)queue);
}

public static UnityEngine.AnimationState PlayQueued(UnityEngine.Animation _this, string animation, int queue, int mode)
{
	return _this.PlayQueued(animation, (UnityEngine.QueueMode)queue, (UnityEngine.PlayMode)mode);
}

public static void AddClip(UnityEngine.Animation _this, UnityEngine.AnimationClip clip, string newName)
{
	_this.AddClip(clip, newName);
}

public static void AddClip(UnityEngine.Animation _this, UnityEngine.AnimationClip clip, string newName, int firstFrame, int lastFrame)
{
	_this.AddClip(clip, newName, firstFrame, lastFrame);
}

public static void AddClip(UnityEngine.Animation _this, UnityEngine.AnimationClip clip, string newName, int firstFrame, int lastFrame, bool addLoopFrame)
{
	_this.AddClip(clip, newName, firstFrame, lastFrame, addLoopFrame);
}

public static void RemoveClip(UnityEngine.Animation _this, UnityEngine.AnimationClip clip)
{
	_this.RemoveClip(clip);
}

public static void RemoveClip(UnityEngine.Animation _this, string clipName)
{
	_this.RemoveClip(clipName);
}

public static int GetClipCount(UnityEngine.Animation _this)
{
	return _this.GetClipCount();
}

public static void SyncLayer(UnityEngine.Animation _this, int layer)
{
	_this.SyncLayer(layer);
}

public static System.Collections.IEnumerator GetEnumerator(UnityEngine.Animation _this)
{
	return _this.GetEnumerator();
}

public static UnityEngine.AnimationClip GetClip(UnityEngine.Animation _this, string name)
{
	return _this.GetClip(name);
}

public static UnityEngine.AnimationClip get_clip(UnityEngine.Animation _this)
{
	return _this.clip;
}

public static void set_clip(UnityEngine.Animation _this, UnityEngine.AnimationClip value)
{
	_this.clip = value;
}

public static bool get_playAutomatically(UnityEngine.Animation _this)
{
	return _this.playAutomatically;
}

public static void set_playAutomatically(UnityEngine.Animation _this, bool value)
{
	_this.playAutomatically = value;
}

public static UnityEngine.WrapMode get_wrapMode(UnityEngine.Animation _this)
{
	return _this.wrapMode;
}

public static void set_wrapMode(UnityEngine.Animation _this, UnityEngine.WrapMode value)
{
	_this.wrapMode = value;
}

public static bool get_isPlaying(UnityEngine.Animation _this)
{
	return _this.isPlaying;
}

public static UnityEngine.AnimationState get_Item(UnityEngine.Animation _this, string index)
{
	return _this[index];
}
}
}
