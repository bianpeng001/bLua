
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Transform
{
public static void SetParent(UnityEngine.Transform _this, UnityEngine.Transform p)
{
	_this.SetParent(p);
}

public static void SetParent(UnityEngine.Transform _this, UnityEngine.Transform parent, bool worldPositionStays)
{
	_this.SetParent(parent, worldPositionStays);
}

public static void SetPositionAndRotation(UnityEngine.Transform _this, UnityEngine.Vector3 position, UnityEngine.Quaternion rotation)
{
	_this.SetPositionAndRotation(position, rotation);
}

public static void Translate(UnityEngine.Transform _this, UnityEngine.Vector3 translation, int relativeTo)
{
	_this.Translate(translation, (UnityEngine.Space)relativeTo);
}

public static void Translate(UnityEngine.Transform _this, UnityEngine.Vector3 translation)
{
	_this.Translate(translation);
}

public static void Translate(UnityEngine.Transform _this, float x, float y, float z, int relativeTo)
{
	_this.Translate(x, y, z, (UnityEngine.Space)relativeTo);
}

public static void Translate(UnityEngine.Transform _this, float x, float y, float z)
{
	_this.Translate(x, y, z);
}

public static void Translate(UnityEngine.Transform _this, UnityEngine.Vector3 translation, UnityEngine.Transform relativeTo)
{
	_this.Translate(translation, relativeTo);
}

public static void Translate(UnityEngine.Transform _this, float x, float y, float z, UnityEngine.Transform relativeTo)
{
	_this.Translate(x, y, z, relativeTo);
}

public static void Rotate(UnityEngine.Transform _this, UnityEngine.Vector3 eulers, int relativeTo)
{
	_this.Rotate(eulers, (UnityEngine.Space)relativeTo);
}

public static void Rotate(UnityEngine.Transform _this, UnityEngine.Vector3 eulers)
{
	_this.Rotate(eulers);
}

public static void Rotate(UnityEngine.Transform _this, float xAngle, float yAngle, float zAngle, int relativeTo)
{
	_this.Rotate(xAngle, yAngle, zAngle, (UnityEngine.Space)relativeTo);
}

public static void Rotate(UnityEngine.Transform _this, float xAngle, float yAngle, float zAngle)
{
	_this.Rotate(xAngle, yAngle, zAngle);
}

public static void Rotate(UnityEngine.Transform _this, UnityEngine.Vector3 axis, float angle, int relativeTo)
{
	_this.Rotate(axis, angle, (UnityEngine.Space)relativeTo);
}

public static void Rotate(UnityEngine.Transform _this, UnityEngine.Vector3 axis, float angle)
{
	_this.Rotate(axis, angle);
}

public static void RotateAround(UnityEngine.Transform _this, UnityEngine.Vector3 point, UnityEngine.Vector3 axis, float angle)
{
	_this.RotateAround(point, axis, angle);
}

public static void LookAt(UnityEngine.Transform _this, UnityEngine.Transform target, UnityEngine.Vector3 worldUp)
{
	_this.LookAt(target, worldUp);
}

public static void LookAt(UnityEngine.Transform _this, UnityEngine.Transform target)
{
	_this.LookAt(target);
}

public static void LookAt(UnityEngine.Transform _this, UnityEngine.Vector3 worldPosition, UnityEngine.Vector3 worldUp)
{
	_this.LookAt(worldPosition, worldUp);
}

public static void LookAt(UnityEngine.Transform _this, UnityEngine.Vector3 worldPosition)
{
	_this.LookAt(worldPosition);
}

public static UnityEngine.Vector3 TransformDirection(UnityEngine.Transform _this, UnityEngine.Vector3 direction)
{
	return _this.TransformDirection(direction);
}

public static UnityEngine.Vector3 TransformDirection(UnityEngine.Transform _this, float x, float y, float z)
{
	return _this.TransformDirection(x, y, z);
}

public static UnityEngine.Vector3 InverseTransformDirection(UnityEngine.Transform _this, UnityEngine.Vector3 direction)
{
	return _this.InverseTransformDirection(direction);
}

public static UnityEngine.Vector3 InverseTransformDirection(UnityEngine.Transform _this, float x, float y, float z)
{
	return _this.InverseTransformDirection(x, y, z);
}

public static UnityEngine.Vector3 TransformVector(UnityEngine.Transform _this, UnityEngine.Vector3 vector)
{
	return _this.TransformVector(vector);
}

public static UnityEngine.Vector3 TransformVector(UnityEngine.Transform _this, float x, float y, float z)
{
	return _this.TransformVector(x, y, z);
}

public static UnityEngine.Vector3 InverseTransformVector(UnityEngine.Transform _this, UnityEngine.Vector3 vector)
{
	return _this.InverseTransformVector(vector);
}

public static UnityEngine.Vector3 InverseTransformVector(UnityEngine.Transform _this, float x, float y, float z)
{
	return _this.InverseTransformVector(x, y, z);
}

public static UnityEngine.Vector3 TransformPoint(UnityEngine.Transform _this, UnityEngine.Vector3 position)
{
	return _this.TransformPoint(position);
}

public static UnityEngine.Vector3 TransformPoint(UnityEngine.Transform _this, float x, float y, float z)
{
	return _this.TransformPoint(x, y, z);
}

public static UnityEngine.Vector3 InverseTransformPoint(UnityEngine.Transform _this, UnityEngine.Vector3 position)
{
	return _this.InverseTransformPoint(position);
}

public static UnityEngine.Vector3 InverseTransformPoint(UnityEngine.Transform _this, float x, float y, float z)
{
	return _this.InverseTransformPoint(x, y, z);
}

public static void DetachChildren(UnityEngine.Transform _this)
{
	_this.DetachChildren();
}

public static void SetAsFirstSibling(UnityEngine.Transform _this)
{
	_this.SetAsFirstSibling();
}

public static void SetAsLastSibling(UnityEngine.Transform _this)
{
	_this.SetAsLastSibling();
}

public static void SetSiblingIndex(UnityEngine.Transform _this, int index)
{
	_this.SetSiblingIndex(index);
}

public static int GetSiblingIndex(UnityEngine.Transform _this)
{
	return _this.GetSiblingIndex();
}

public static UnityEngine.Transform Find(UnityEngine.Transform _this, string n)
{
	return _this.Find(n);
}

public static bool IsChildOf(UnityEngine.Transform _this, UnityEngine.Transform parent)
{
	return _this.IsChildOf(parent);
}

public static System.Collections.IEnumerator GetEnumerator(UnityEngine.Transform _this)
{
	return _this.GetEnumerator();
}

public static UnityEngine.Transform GetChild(UnityEngine.Transform _this, int index)
{
	return _this.GetChild(index);
}

public static UnityEngine.Vector3 get_position(UnityEngine.Transform _this)
{
	return _this.position;
}

public static void set_position(UnityEngine.Transform _this, UnityEngine.Vector3 value)
{
	_this.position = value;
}

public static UnityEngine.Vector3 get_localPosition(UnityEngine.Transform _this)
{
	return _this.localPosition;
}

public static void set_localPosition(UnityEngine.Transform _this, UnityEngine.Vector3 value)
{
	_this.localPosition = value;
}

public static UnityEngine.Vector3 get_eulerAngles(UnityEngine.Transform _this)
{
	return _this.eulerAngles;
}

public static void set_eulerAngles(UnityEngine.Transform _this, UnityEngine.Vector3 value)
{
	_this.eulerAngles = value;
}

public static UnityEngine.Vector3 get_localEulerAngles(UnityEngine.Transform _this)
{
	return _this.localEulerAngles;
}

public static void set_localEulerAngles(UnityEngine.Transform _this, UnityEngine.Vector3 value)
{
	_this.localEulerAngles = value;
}

public static UnityEngine.Vector3 get_right(UnityEngine.Transform _this)
{
	return _this.right;
}

public static void set_right(UnityEngine.Transform _this, UnityEngine.Vector3 value)
{
	_this.right = value;
}

public static UnityEngine.Vector3 get_up(UnityEngine.Transform _this)
{
	return _this.up;
}

public static void set_up(UnityEngine.Transform _this, UnityEngine.Vector3 value)
{
	_this.up = value;
}

public static UnityEngine.Vector3 get_forward(UnityEngine.Transform _this)
{
	return _this.forward;
}

public static void set_forward(UnityEngine.Transform _this, UnityEngine.Vector3 value)
{
	_this.forward = value;
}

public static UnityEngine.Quaternion get_rotation(UnityEngine.Transform _this)
{
	return _this.rotation;
}

public static void set_rotation(UnityEngine.Transform _this, UnityEngine.Quaternion value)
{
	_this.rotation = value;
}

public static UnityEngine.Quaternion get_localRotation(UnityEngine.Transform _this)
{
	return _this.localRotation;
}

public static void set_localRotation(UnityEngine.Transform _this, UnityEngine.Quaternion value)
{
	_this.localRotation = value;
}

public static UnityEngine.Vector3 get_localScale(UnityEngine.Transform _this)
{
	return _this.localScale;
}

public static void set_localScale(UnityEngine.Transform _this, UnityEngine.Vector3 value)
{
	_this.localScale = value;
}

public static UnityEngine.Transform get_parent(UnityEngine.Transform _this)
{
	return _this.parent;
}

public static void set_parent(UnityEngine.Transform _this, UnityEngine.Transform value)
{
	_this.parent = value;
}

public static UnityEngine.Matrix4x4 get_worldToLocalMatrix(UnityEngine.Transform _this)
{
	return _this.worldToLocalMatrix;
}

public static UnityEngine.Matrix4x4 get_localToWorldMatrix(UnityEngine.Transform _this)
{
	return _this.localToWorldMatrix;
}

public static UnityEngine.Transform get_root(UnityEngine.Transform _this)
{
	return _this.root;
}

public static int get_childCount(UnityEngine.Transform _this)
{
	return _this.childCount;
}

public static UnityEngine.Vector3 get_lossyScale(UnityEngine.Transform _this)
{
	return _this.lossyScale;
}

public static bool get_hasChanged(UnityEngine.Transform _this)
{
	return _this.hasChanged;
}

public static void set_hasChanged(UnityEngine.Transform _this, bool value)
{
	_this.hasChanged = value;
}

public static int get_hierarchyCapacity(UnityEngine.Transform _this)
{
	return _this.hierarchyCapacity;
}

public static void set_hierarchyCapacity(UnityEngine.Transform _this, int value)
{
	_this.hierarchyCapacity = value;
}

public static int get_hierarchyCount(UnityEngine.Transform _this)
{
	return _this.hierarchyCount;
}

}
}
