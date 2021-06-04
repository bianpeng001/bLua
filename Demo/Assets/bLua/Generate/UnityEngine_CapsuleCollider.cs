
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_CapsuleCollider
{
public static UnityEngine.Vector3 get_center(UnityEngine.CapsuleCollider _this)
{
	return _this.center;
}

public static void set_center(UnityEngine.CapsuleCollider _this, UnityEngine.Vector3 value)
{
	_this.center = value;
}

public static float get_radius(UnityEngine.CapsuleCollider _this)
{
	return _this.radius;
}

public static void set_radius(UnityEngine.CapsuleCollider _this, float value)
{
	_this.radius = value;
}

public static float get_height(UnityEngine.CapsuleCollider _this)
{
	return _this.height;
}

public static void set_height(UnityEngine.CapsuleCollider _this, float value)
{
	_this.height = value;
}

public static int get_direction(UnityEngine.CapsuleCollider _this)
{
	return _this.direction;
}

public static void set_direction(UnityEngine.CapsuleCollider _this, int value)
{
	_this.direction = value;
}

}
}
