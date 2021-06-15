
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class bLua_MoveSystem
{
public static void Update(bLua.MoveSystem _this, float deltaTime)
{
	_this.Update(deltaTime);
}

public static bLua.AutoWrap.MulRet<bool, float> MoveTo(bLua.MoveSystem _this, int pid, UnityEngine.GameObject obj, float speed, int x1, int z1, int x2, int z2)
{
	return _this.MoveTo(pid, obj, speed, x1, z1, x2, z2);
}

public static System.Collections.Generic.List<int> FindPath(bLua.MoveSystem _this, int x1, int z1, int x2, int z2)
{
	return _this.FindPath(x1, z1, x2, z2);
}

public static bLua.AutoWrap.MulRet<bool, int> GetMulRet(bLua.MoveSystem _this)
{
	return _this.GetMulRet();
}

}
}
