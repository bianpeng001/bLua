
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class bLua_Example02
{
public static UnityEngine.Camera GetMainCamera(bLua.Example02 _this)
{
	return _this.GetMainCamera();
}

public static UnityEngine.Vector3 GetFloorPoint(bLua.Example02 _this)
{
	return _this.GetFloorPoint();
}

}
}
