
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_BoxCollider
{
public static UnityEngine.Vector3 get_center(UnityEngine.BoxCollider _this)
{
	return _this.center;
}

public static void set_center(UnityEngine.BoxCollider _this, UnityEngine.Vector3 value)
{
	_this.center = value;
}

public static UnityEngine.Vector3 get_size(UnityEngine.BoxCollider _this)
{
	return _this.size;
}

public static void set_size(UnityEngine.BoxCollider _this, UnityEngine.Vector3 value)
{
	_this.size = value;
}

}
}
