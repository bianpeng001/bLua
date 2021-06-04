
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Collider
{
public static UnityEngine.Vector3 ClosestPoint(UnityEngine.Collider _this, UnityEngine.Vector3 position)
{
	return _this.ClosestPoint(position);
}

public static UnityEngine.Vector3 ClosestPointOnBounds(UnityEngine.Collider _this, UnityEngine.Vector3 position)
{
	return _this.ClosestPointOnBounds(position);
}

public static bool get_enabled(UnityEngine.Collider _this)
{
	return _this.enabled;
}

public static void set_enabled(UnityEngine.Collider _this, bool value)
{
	_this.enabled = value;
}

public static UnityEngine.Rigidbody get_attachedRigidbody(UnityEngine.Collider _this)
{
	return _this.attachedRigidbody;
}

public static UnityEngine.ArticulationBody get_attachedArticulationBody(UnityEngine.Collider _this)
{
	return _this.attachedArticulationBody;
}

public static bool get_isTrigger(UnityEngine.Collider _this)
{
	return _this.isTrigger;
}

public static void set_isTrigger(UnityEngine.Collider _this, bool value)
{
	_this.isTrigger = value;
}

public static float get_contactOffset(UnityEngine.Collider _this)
{
	return _this.contactOffset;
}

public static void set_contactOffset(UnityEngine.Collider _this, float value)
{
	_this.contactOffset = value;
}

public static UnityEngine.Bounds get_bounds(UnityEngine.Collider _this)
{
	return _this.bounds;
}

public static UnityEngine.PhysicMaterial get_sharedMaterial(UnityEngine.Collider _this)
{
	return _this.sharedMaterial;
}

public static void set_sharedMaterial(UnityEngine.Collider _this, UnityEngine.PhysicMaterial value)
{
	_this.sharedMaterial = value;
}

public static UnityEngine.PhysicMaterial get_material(UnityEngine.Collider _this)
{
	return _this.material;
}

public static void set_material(UnityEngine.Collider _this, UnityEngine.PhysicMaterial value)
{
	_this.material = value;
}

}
}
