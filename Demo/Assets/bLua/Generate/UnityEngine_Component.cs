
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Component
{
public static UnityEngine.Component GetComponent(UnityEngine.Component _this, System.Type type)
{
	return _this.GetComponent(type);
}

public static UnityEngine.Component GetComponent(UnityEngine.Component _this, string type)
{
	return _this.GetComponent(type);
}

public static UnityEngine.Component GetComponentInChildren(UnityEngine.Component _this, System.Type t, bool includeInactive)
{
	return _this.GetComponentInChildren(t, includeInactive);
}

public static UnityEngine.Component GetComponentInChildren(UnityEngine.Component _this, System.Type t)
{
	return _this.GetComponentInChildren(t);
}

public static UnityEngine.Component[] GetComponentsInChildren(UnityEngine.Component _this, System.Type t, bool includeInactive)
{
	return _this.GetComponentsInChildren(t, includeInactive);
}

public static UnityEngine.Component[] GetComponentsInChildren(UnityEngine.Component _this, System.Type t)
{
	return _this.GetComponentsInChildren(t);
}

public static UnityEngine.Component GetComponentInParent(UnityEngine.Component _this, System.Type t)
{
	return _this.GetComponentInParent(t);
}

public static UnityEngine.Component[] GetComponentsInParent(UnityEngine.Component _this, System.Type t, bool includeInactive)
{
	return _this.GetComponentsInParent(t, includeInactive);
}

public static UnityEngine.Component[] GetComponentsInParent(UnityEngine.Component _this, System.Type t)
{
	return _this.GetComponentsInParent(t);
}

public static UnityEngine.Component[] GetComponents(UnityEngine.Component _this, System.Type type)
{
	return _this.GetComponents(type);
}

public static bool CompareTag(UnityEngine.Component _this, string tag)
{
	return _this.CompareTag(tag);
}

public static void SendMessageUpwards(UnityEngine.Component _this, string methodName, object value, int options)
{
	_this.SendMessageUpwards(methodName, value, (UnityEngine.SendMessageOptions)options);
}

public static void SendMessageUpwards(UnityEngine.Component _this, string methodName, object value)
{
	_this.SendMessageUpwards(methodName, value);
}

public static void SendMessageUpwards(UnityEngine.Component _this, string methodName)
{
	_this.SendMessageUpwards(methodName);
}

public static void SendMessageUpwards(UnityEngine.Component _this, string methodName, int options)
{
	_this.SendMessageUpwards(methodName, (UnityEngine.SendMessageOptions)options);
}

public static void SendMessage(UnityEngine.Component _this, string methodName, object value)
{
	_this.SendMessage(methodName, value);
}

public static void SendMessage(UnityEngine.Component _this, string methodName)
{
	_this.SendMessage(methodName);
}

public static void SendMessage(UnityEngine.Component _this, string methodName, object value, int options)
{
	_this.SendMessage(methodName, value, (UnityEngine.SendMessageOptions)options);
}

public static void SendMessage(UnityEngine.Component _this, string methodName, int options)
{
	_this.SendMessage(methodName, (UnityEngine.SendMessageOptions)options);
}

public static void BroadcastMessage(UnityEngine.Component _this, string methodName, object parameter, int options)
{
	_this.BroadcastMessage(methodName, parameter, (UnityEngine.SendMessageOptions)options);
}

public static void BroadcastMessage(UnityEngine.Component _this, string methodName, object parameter)
{
	_this.BroadcastMessage(methodName, parameter);
}

public static void BroadcastMessage(UnityEngine.Component _this, string methodName)
{
	_this.BroadcastMessage(methodName);
}

public static void BroadcastMessage(UnityEngine.Component _this, string methodName, int options)
{
	_this.BroadcastMessage(methodName, (UnityEngine.SendMessageOptions)options);
}

public static UnityEngine.Transform get_transform(UnityEngine.Component _this)
{
	return _this.transform;
}

public static UnityEngine.GameObject get_gameObject(UnityEngine.Component _this)
{
	return _this.gameObject;
}

public static string get_tag(UnityEngine.Component _this)
{
	return _this.tag;
}

public static void set_tag(UnityEngine.Component _this, string value)
{
	_this.tag = value;
}

}
}
