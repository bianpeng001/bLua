
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_MonoBehaviour
{
public static bool IsInvoking(UnityEngine.MonoBehaviour _this)
{
	return _this.IsInvoking();
}

public static void CancelInvoke(UnityEngine.MonoBehaviour _this)
{
	_this.CancelInvoke();
}

public static void Invoke(UnityEngine.MonoBehaviour _this, string methodName, float time)
{
	_this.Invoke(methodName, time);
}

public static void InvokeRepeating(UnityEngine.MonoBehaviour _this, string methodName, float time, float repeatRate)
{
	_this.InvokeRepeating(methodName, time, repeatRate);
}

public static void CancelInvoke(UnityEngine.MonoBehaviour _this, string methodName)
{
	_this.CancelInvoke(methodName);
}

public static bool IsInvoking(UnityEngine.MonoBehaviour _this, string methodName)
{
	return _this.IsInvoking(methodName);
}

public static UnityEngine.Coroutine StartCoroutine(UnityEngine.MonoBehaviour _this, string methodName)
{
	return _this.StartCoroutine(methodName);
}

public static UnityEngine.Coroutine StartCoroutine(UnityEngine.MonoBehaviour _this, string methodName, object value)
{
	return _this.StartCoroutine(methodName, value);
}

public static UnityEngine.Coroutine StartCoroutine(UnityEngine.MonoBehaviour _this, System.Collections.IEnumerator routine)
{
	return _this.StartCoroutine(routine);
}

public static void StopCoroutine(UnityEngine.MonoBehaviour _this, System.Collections.IEnumerator routine)
{
	_this.StopCoroutine(routine);
}

public static void StopCoroutine(UnityEngine.MonoBehaviour _this, UnityEngine.Coroutine routine)
{
	_this.StopCoroutine(routine);
}

public static void StopCoroutine(UnityEngine.MonoBehaviour _this, string methodName)
{
	_this.StopCoroutine(methodName);
}

public static void StopAllCoroutines(UnityEngine.MonoBehaviour _this)
{
	_this.StopAllCoroutines();
}

public static bool get_useGUILayout(UnityEngine.MonoBehaviour _this)
{
	return _this.useGUILayout;
}

public static void set_useGUILayout(UnityEngine.MonoBehaviour _this, bool value)
{
	_this.useGUILayout = value;
}

public static bool get_runInEditMode(UnityEngine.MonoBehaviour _this)
{
	return _this.runInEditMode;
}

public static void set_runInEditMode(UnityEngine.MonoBehaviour _this, bool value)
{
	_this.runInEditMode = value;
}

}
}
