
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Motion
{
public static float get_averageDuration(UnityEngine.Motion _this)
{
	return _this.averageDuration;
}

public static float get_averageAngularSpeed(UnityEngine.Motion _this)
{
	return _this.averageAngularSpeed;
}

public static UnityEngine.Vector3 get_averageSpeed(UnityEngine.Motion _this)
{
	return _this.averageSpeed;
}

public static float get_apparentSpeed(UnityEngine.Motion _this)
{
	return _this.apparentSpeed;
}

public static bool get_isLooping(UnityEngine.Motion _this)
{
	return _this.isLooping;
}

public static bool get_legacy(UnityEngine.Motion _this)
{
	return _this.legacy;
}

public static bool get_isHumanMotion(UnityEngine.Motion _this)
{
	return _this.isHumanMotion;
}

}
}
