
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class System_Random
{
public static int Next(System.Random _this)
{
	return _this.Next();
}

public static int Next(System.Random _this, int minValue, int maxValue)
{
	return _this.Next(minValue, maxValue);
}

public static int Next(System.Random _this, int maxValue)
{
	return _this.Next(maxValue);
}

public static double NextDouble(System.Random _this)
{
	return _this.NextDouble();
}

public static void NextBytes(System.Random _this, System.Byte[] buffer)
{
	_this.NextBytes(buffer);
}

}
}
