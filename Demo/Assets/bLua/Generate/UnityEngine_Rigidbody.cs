
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Rigidbody
{
public static void SetDensity(UnityEngine.Rigidbody _this, float density)
{
	_this.SetDensity(density);
}

public static void MovePosition(UnityEngine.Rigidbody _this, UnityEngine.Vector3 position)
{
	_this.MovePosition(position);
}

public static void MoveRotation(UnityEngine.Rigidbody _this, UnityEngine.Quaternion rot)
{
	_this.MoveRotation(rot);
}

public static void Sleep(UnityEngine.Rigidbody _this)
{
	_this.Sleep();
}

public static bool IsSleeping(UnityEngine.Rigidbody _this)
{
	return _this.IsSleeping();
}

public static void WakeUp(UnityEngine.Rigidbody _this)
{
	_this.WakeUp();
}

public static void ResetCenterOfMass(UnityEngine.Rigidbody _this)
{
	_this.ResetCenterOfMass();
}

public static void ResetInertiaTensor(UnityEngine.Rigidbody _this)
{
	_this.ResetInertiaTensor();
}

public static UnityEngine.Vector3 GetRelativePointVelocity(UnityEngine.Rigidbody _this, UnityEngine.Vector3 relativePoint)
{
	return _this.GetRelativePointVelocity(relativePoint);
}

public static UnityEngine.Vector3 GetPointVelocity(UnityEngine.Rigidbody _this, UnityEngine.Vector3 worldPoint)
{
	return _this.GetPointVelocity(worldPoint);
}

public static void AddForce(UnityEngine.Rigidbody _this, UnityEngine.Vector3 force, int mode)
{
	_this.AddForce(force, (UnityEngine.ForceMode)mode);
}

public static void AddForce(UnityEngine.Rigidbody _this, UnityEngine.Vector3 force)
{
	_this.AddForce(force);
}

public static void AddForce(UnityEngine.Rigidbody _this, float x, float y, float z, int mode)
{
	_this.AddForce(x, y, z, (UnityEngine.ForceMode)mode);
}

public static void AddForce(UnityEngine.Rigidbody _this, float x, float y, float z)
{
	_this.AddForce(x, y, z);
}

public static void AddRelativeForce(UnityEngine.Rigidbody _this, UnityEngine.Vector3 force, int mode)
{
	_this.AddRelativeForce(force, (UnityEngine.ForceMode)mode);
}

public static void AddRelativeForce(UnityEngine.Rigidbody _this, UnityEngine.Vector3 force)
{
	_this.AddRelativeForce(force);
}

public static void AddRelativeForce(UnityEngine.Rigidbody _this, float x, float y, float z, int mode)
{
	_this.AddRelativeForce(x, y, z, (UnityEngine.ForceMode)mode);
}

public static void AddRelativeForce(UnityEngine.Rigidbody _this, float x, float y, float z)
{
	_this.AddRelativeForce(x, y, z);
}

public static void AddTorque(UnityEngine.Rigidbody _this, UnityEngine.Vector3 torque, int mode)
{
	_this.AddTorque(torque, (UnityEngine.ForceMode)mode);
}

public static void AddTorque(UnityEngine.Rigidbody _this, UnityEngine.Vector3 torque)
{
	_this.AddTorque(torque);
}

public static void AddTorque(UnityEngine.Rigidbody _this, float x, float y, float z, int mode)
{
	_this.AddTorque(x, y, z, (UnityEngine.ForceMode)mode);
}

public static void AddTorque(UnityEngine.Rigidbody _this, float x, float y, float z)
{
	_this.AddTorque(x, y, z);
}

public static void AddRelativeTorque(UnityEngine.Rigidbody _this, UnityEngine.Vector3 torque, int mode)
{
	_this.AddRelativeTorque(torque, (UnityEngine.ForceMode)mode);
}

public static void AddRelativeTorque(UnityEngine.Rigidbody _this, UnityEngine.Vector3 torque)
{
	_this.AddRelativeTorque(torque);
}

public static void AddRelativeTorque(UnityEngine.Rigidbody _this, float x, float y, float z, int mode)
{
	_this.AddRelativeTorque(x, y, z, (UnityEngine.ForceMode)mode);
}

public static void AddRelativeTorque(UnityEngine.Rigidbody _this, float x, float y, float z)
{
	_this.AddRelativeTorque(x, y, z);
}

public static void AddForceAtPosition(UnityEngine.Rigidbody _this, UnityEngine.Vector3 force, UnityEngine.Vector3 position, int mode)
{
	_this.AddForceAtPosition(force, position, (UnityEngine.ForceMode)mode);
}

public static void AddForceAtPosition(UnityEngine.Rigidbody _this, UnityEngine.Vector3 force, UnityEngine.Vector3 position)
{
	_this.AddForceAtPosition(force, position);
}

public static void AddExplosionForce(UnityEngine.Rigidbody _this, float explosionForce, UnityEngine.Vector3 explosionPosition, float explosionRadius, float upwardsModifier, int mode)
{
	_this.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardsModifier, (UnityEngine.ForceMode)mode);
}

public static void AddExplosionForce(UnityEngine.Rigidbody _this, float explosionForce, UnityEngine.Vector3 explosionPosition, float explosionRadius, float upwardsModifier)
{
	_this.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardsModifier);
}

public static void AddExplosionForce(UnityEngine.Rigidbody _this, float explosionForce, UnityEngine.Vector3 explosionPosition, float explosionRadius)
{
	_this.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
}

public static UnityEngine.Vector3 ClosestPointOnBounds(UnityEngine.Rigidbody _this, UnityEngine.Vector3 position)
{
	return _this.ClosestPointOnBounds(position);
}

public static UnityEngine.RaycastHit[] SweepTestAll(UnityEngine.Rigidbody _this, UnityEngine.Vector3 direction, float maxDistance, int queryTriggerInteraction)
{
	return _this.SweepTestAll(direction, maxDistance, (UnityEngine.QueryTriggerInteraction)queryTriggerInteraction);
}

public static UnityEngine.RaycastHit[] SweepTestAll(UnityEngine.Rigidbody _this, UnityEngine.Vector3 direction, float maxDistance)
{
	return _this.SweepTestAll(direction, maxDistance);
}

public static UnityEngine.RaycastHit[] SweepTestAll(UnityEngine.Rigidbody _this, UnityEngine.Vector3 direction)
{
	return _this.SweepTestAll(direction);
}

public static UnityEngine.Vector3 get_velocity(UnityEngine.Rigidbody _this)
{
	return _this.velocity;
}

public static void set_velocity(UnityEngine.Rigidbody _this, UnityEngine.Vector3 value)
{
	_this.velocity = value;
}

public static UnityEngine.Vector3 get_angularVelocity(UnityEngine.Rigidbody _this)
{
	return _this.angularVelocity;
}

public static void set_angularVelocity(UnityEngine.Rigidbody _this, UnityEngine.Vector3 value)
{
	_this.angularVelocity = value;
}

public static float get_drag(UnityEngine.Rigidbody _this)
{
	return _this.drag;
}

public static void set_drag(UnityEngine.Rigidbody _this, float value)
{
	_this.drag = value;
}

public static float get_angularDrag(UnityEngine.Rigidbody _this)
{
	return _this.angularDrag;
}

public static void set_angularDrag(UnityEngine.Rigidbody _this, float value)
{
	_this.angularDrag = value;
}

public static float get_mass(UnityEngine.Rigidbody _this)
{
	return _this.mass;
}

public static void set_mass(UnityEngine.Rigidbody _this, float value)
{
	_this.mass = value;
}

public static bool get_useGravity(UnityEngine.Rigidbody _this)
{
	return _this.useGravity;
}

public static void set_useGravity(UnityEngine.Rigidbody _this, bool value)
{
	_this.useGravity = value;
}

public static float get_maxDepenetrationVelocity(UnityEngine.Rigidbody _this)
{
	return _this.maxDepenetrationVelocity;
}

public static void set_maxDepenetrationVelocity(UnityEngine.Rigidbody _this, float value)
{
	_this.maxDepenetrationVelocity = value;
}

public static bool get_isKinematic(UnityEngine.Rigidbody _this)
{
	return _this.isKinematic;
}

public static void set_isKinematic(UnityEngine.Rigidbody _this, bool value)
{
	_this.isKinematic = value;
}

public static bool get_freezeRotation(UnityEngine.Rigidbody _this)
{
	return _this.freezeRotation;
}

public static void set_freezeRotation(UnityEngine.Rigidbody _this, bool value)
{
	_this.freezeRotation = value;
}

public static UnityEngine.RigidbodyConstraints get_constraints(UnityEngine.Rigidbody _this)
{
	return _this.constraints;
}

public static void set_constraints(UnityEngine.Rigidbody _this, UnityEngine.RigidbodyConstraints value)
{
	_this.constraints = value;
}

public static UnityEngine.CollisionDetectionMode get_collisionDetectionMode(UnityEngine.Rigidbody _this)
{
	return _this.collisionDetectionMode;
}

public static void set_collisionDetectionMode(UnityEngine.Rigidbody _this, UnityEngine.CollisionDetectionMode value)
{
	_this.collisionDetectionMode = value;
}

public static UnityEngine.Vector3 get_centerOfMass(UnityEngine.Rigidbody _this)
{
	return _this.centerOfMass;
}

public static void set_centerOfMass(UnityEngine.Rigidbody _this, UnityEngine.Vector3 value)
{
	_this.centerOfMass = value;
}

public static UnityEngine.Vector3 get_worldCenterOfMass(UnityEngine.Rigidbody _this)
{
	return _this.worldCenterOfMass;
}

public static UnityEngine.Quaternion get_inertiaTensorRotation(UnityEngine.Rigidbody _this)
{
	return _this.inertiaTensorRotation;
}

public static void set_inertiaTensorRotation(UnityEngine.Rigidbody _this, UnityEngine.Quaternion value)
{
	_this.inertiaTensorRotation = value;
}

public static UnityEngine.Vector3 get_inertiaTensor(UnityEngine.Rigidbody _this)
{
	return _this.inertiaTensor;
}

public static void set_inertiaTensor(UnityEngine.Rigidbody _this, UnityEngine.Vector3 value)
{
	_this.inertiaTensor = value;
}

public static bool get_detectCollisions(UnityEngine.Rigidbody _this)
{
	return _this.detectCollisions;
}

public static void set_detectCollisions(UnityEngine.Rigidbody _this, bool value)
{
	_this.detectCollisions = value;
}

public static UnityEngine.Vector3 get_position(UnityEngine.Rigidbody _this)
{
	return _this.position;
}

public static void set_position(UnityEngine.Rigidbody _this, UnityEngine.Vector3 value)
{
	_this.position = value;
}

public static UnityEngine.Quaternion get_rotation(UnityEngine.Rigidbody _this)
{
	return _this.rotation;
}

public static void set_rotation(UnityEngine.Rigidbody _this, UnityEngine.Quaternion value)
{
	_this.rotation = value;
}

public static UnityEngine.RigidbodyInterpolation get_interpolation(UnityEngine.Rigidbody _this)
{
	return _this.interpolation;
}

public static void set_interpolation(UnityEngine.Rigidbody _this, UnityEngine.RigidbodyInterpolation value)
{
	_this.interpolation = value;
}

public static int get_solverIterations(UnityEngine.Rigidbody _this)
{
	return _this.solverIterations;
}

public static void set_solverIterations(UnityEngine.Rigidbody _this, int value)
{
	_this.solverIterations = value;
}

public static float get_sleepThreshold(UnityEngine.Rigidbody _this)
{
	return _this.sleepThreshold;
}

public static void set_sleepThreshold(UnityEngine.Rigidbody _this, float value)
{
	_this.sleepThreshold = value;
}

public static float get_maxAngularVelocity(UnityEngine.Rigidbody _this)
{
	return _this.maxAngularVelocity;
}

public static void set_maxAngularVelocity(UnityEngine.Rigidbody _this, float value)
{
	_this.maxAngularVelocity = value;
}

public static int get_solverVelocityIterations(UnityEngine.Rigidbody _this)
{
	return _this.solverVelocityIterations;
}

public static void set_solverVelocityIterations(UnityEngine.Rigidbody _this, int value)
{
	_this.solverVelocityIterations = value;
}

}
}
