
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_SphereCollider
{
public static UnityEngine.Vector3 get_center(UnityEngine.SphereCollider _this)
{
	return _this.center;
}

public static void set_center(UnityEngine.SphereCollider _this, UnityEngine.Vector3 value)
{
	_this.center = value;
}

public static float get_radius(UnityEngine.SphereCollider _this)
{
	return _this.radius;
}

public static void set_radius(UnityEngine.SphereCollider _this, float value)
{
	_this.radius = value;
}

}
}
