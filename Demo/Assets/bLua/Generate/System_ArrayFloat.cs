
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class System_ArrayFloat
{
public static float Get(float[] _this, int arg0)
{
	return _this[arg0];
}

public static void Set(float[] _this, int arg0, float arg1)
{
	_this[arg0] = arg1;
}

public static float[] New(int arg0)
{
	return new float[arg0];
}
}
}
