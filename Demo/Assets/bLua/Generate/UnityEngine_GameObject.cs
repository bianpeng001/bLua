
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_GameObject
{
public static UnityEngine.Component GetComponent(UnityEngine.GameObject _this, System.Type type)
{
	return _this.GetComponent(type);
}

public static UnityEngine.Component GetComponent(UnityEngine.GameObject _this, string type)
{
	return _this.GetComponent(type);
}

public static UnityEngine.Component GetComponentInChildren(UnityEngine.GameObject _this, System.Type type, bool includeInactive)
{
	return _this.GetComponentInChildren(type, includeInactive);
}

public static UnityEngine.Component GetComponentInChildren(UnityEngine.GameObject _this, System.Type type)
{
	return _this.GetComponentInChildren(type);
}

public static UnityEngine.Component GetComponentInParent(UnityEngine.GameObject _this, System.Type type, bool includeInactive)
{
	return _this.GetComponentInParent(type, includeInactive);
}

public static UnityEngine.Component GetComponentInParent(UnityEngine.GameObject _this, System.Type type)
{
	return _this.GetComponentInParent(type);
}

public static UnityEngine.Component[] GetComponents(UnityEngine.GameObject _this, System.Type type)
{
	return _this.GetComponents(type);
}

public static UnityEngine.Component[] GetComponentsInChildren(UnityEngine.GameObject _this, System.Type type)
{
	return _this.GetComponentsInChildren(type);
}

public static UnityEngine.Component[] GetComponentsInChildren(UnityEngine.GameObject _this, System.Type type, bool includeInactive)
{
	return _this.GetComponentsInChildren(type, includeInactive);
}

public static UnityEngine.Component[] GetComponentsInParent(UnityEngine.GameObject _this, System.Type type)
{
	return _this.GetComponentsInParent(type);
}

public static UnityEngine.Component[] GetComponentsInParent(UnityEngine.GameObject _this, System.Type type, bool includeInactive)
{
	return _this.GetComponentsInParent(type, includeInactive);
}

public static void SendMessageUpwards(UnityEngine.GameObject _this, string methodName, int options)
{
	_this.SendMessageUpwards(methodName, (UnityEngine.SendMessageOptions)options);
}

public static void SendMessage(UnityEngine.GameObject _this, string methodName, int options)
{
	_this.SendMessage(methodName, (UnityEngine.SendMessageOptions)options);
}

public static void BroadcastMessage(UnityEngine.GameObject _this, string methodName, int options)
{
	_this.BroadcastMessage(methodName, (UnityEngine.SendMessageOptions)options);
}

public static UnityEngine.Component AddComponent(UnityEngine.GameObject _this, System.Type componentType)
{
	return _this.AddComponent(componentType);
}

public static void SetActive(UnityEngine.GameObject _this, bool value)
{
	_this.SetActive(value);
}

public static bool CompareTag(UnityEngine.GameObject _this, string tag)
{
	return _this.CompareTag(tag);
}

public static void SendMessageUpwards(UnityEngine.GameObject _this, string methodName, object value, int options)
{
	_this.SendMessageUpwards(methodName, value, (UnityEngine.SendMessageOptions)options);
}

public static void SendMessageUpwards(UnityEngine.GameObject _this, string methodName, object value)
{
	_this.SendMessageUpwards(methodName, value);
}

public static void SendMessageUpwards(UnityEngine.GameObject _this, string methodName)
{
	_this.SendMessageUpwards(methodName);
}

public static void SendMessage(UnityEngine.GameObject _this, string methodName, object value, int options)
{
	_this.SendMessage(methodName, value, (UnityEngine.SendMessageOptions)options);
}

public static void SendMessage(UnityEngine.GameObject _this, string methodName, object value)
{
	_this.SendMessage(methodName, value);
}

public static void SendMessage(UnityEngine.GameObject _this, string methodName)
{
	_this.SendMessage(methodName);
}

public static void BroadcastMessage(UnityEngine.GameObject _this, string methodName, object parameter, int options)
{
	_this.BroadcastMessage(methodName, parameter, (UnityEngine.SendMessageOptions)options);
}

public static void BroadcastMessage(UnityEngine.GameObject _this, string methodName, object parameter)
{
	_this.BroadcastMessage(methodName, parameter);
}

public static void BroadcastMessage(UnityEngine.GameObject _this, string methodName)
{
	_this.BroadcastMessage(methodName);
}

public static UnityEngine.Transform get_transform(UnityEngine.GameObject _this)
{
	return _this.transform;
}

public static int get_layer(UnityEngine.GameObject _this)
{
	return _this.layer;
}

public static void set_layer(UnityEngine.GameObject _this, int value)
{
	_this.layer = value;
}

public static bool get_activeSelf(UnityEngine.GameObject _this)
{
	return _this.activeSelf;
}

public static bool get_activeInHierarchy(UnityEngine.GameObject _this)
{
	return _this.activeInHierarchy;
}

public static bool get_isStatic(UnityEngine.GameObject _this)
{
	return _this.isStatic;
}

public static void set_isStatic(UnityEngine.GameObject _this, bool value)
{
	_this.isStatic = value;
}

public static string get_tag(UnityEngine.GameObject _this)
{
	return _this.tag;
}

public static void set_tag(UnityEngine.GameObject _this, string value)
{
	_this.tag = value;
}

public static UnityEngine.SceneManagement.Scene get_scene(UnityEngine.GameObject _this)
{
	return _this.scene;
}

public static ulong get_sceneCullingMask(UnityEngine.GameObject _this)
{
	return _this.sceneCullingMask;
}

public static UnityEngine.GameObject get_gameObject(UnityEngine.GameObject _this)
{
	return _this.gameObject;
}

}
}
