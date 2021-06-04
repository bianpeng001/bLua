
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_CharacterController
{
public static bool SimpleMove(UnityEngine.CharacterController _this, UnityEngine.Vector3 speed)
{
	return _this.SimpleMove(speed);
}

public static UnityEngine.CollisionFlags Move(UnityEngine.CharacterController _this, UnityEngine.Vector3 motion)
{
	return _this.Move(motion);
}

public static UnityEngine.Vector3 get_velocity(UnityEngine.CharacterController _this)
{
	return _this.velocity;
}

public static bool get_isGrounded(UnityEngine.CharacterController _this)
{
	return _this.isGrounded;
}

public static UnityEngine.CollisionFlags get_collisionFlags(UnityEngine.CharacterController _this)
{
	return _this.collisionFlags;
}

public static float get_radius(UnityEngine.CharacterController _this)
{
	return _this.radius;
}

public static void set_radius(UnityEngine.CharacterController _this, float value)
{
	_this.radius = value;
}

public static float get_height(UnityEngine.CharacterController _this)
{
	return _this.height;
}

public static void set_height(UnityEngine.CharacterController _this, float value)
{
	_this.height = value;
}

public static UnityEngine.Vector3 get_center(UnityEngine.CharacterController _this)
{
	return _this.center;
}

public static void set_center(UnityEngine.CharacterController _this, UnityEngine.Vector3 value)
{
	_this.center = value;
}

public static float get_slopeLimit(UnityEngine.CharacterController _this)
{
	return _this.slopeLimit;
}

public static void set_slopeLimit(UnityEngine.CharacterController _this, float value)
{
	_this.slopeLimit = value;
}

public static float get_stepOffset(UnityEngine.CharacterController _this)
{
	return _this.stepOffset;
}

public static void set_stepOffset(UnityEngine.CharacterController _this, float value)
{
	_this.stepOffset = value;
}

public static float get_skinWidth(UnityEngine.CharacterController _this)
{
	return _this.skinWidth;
}

public static void set_skinWidth(UnityEngine.CharacterController _this, float value)
{
	_this.skinWidth = value;
}

public static float get_minMoveDistance(UnityEngine.CharacterController _this)
{
	return _this.minMoveDistance;
}

public static void set_minMoveDistance(UnityEngine.CharacterController _this, float value)
{
	_this.minMoveDistance = value;
}

public static bool get_detectCollisions(UnityEngine.CharacterController _this)
{
	return _this.detectCollisions;
}

public static void set_detectCollisions(UnityEngine.CharacterController _this, bool value)
{
	_this.detectCollisions = value;
}

public static bool get_enableOverlapRecovery(UnityEngine.CharacterController _this)
{
	return _this.enableOverlapRecovery;
}

public static void set_enableOverlapRecovery(UnityEngine.CharacterController _this, bool value)
{
	_this.enableOverlapRecovery = value;
}

}
}
