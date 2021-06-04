
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Behaviour
{
public static bool get_enabled(UnityEngine.Behaviour _this)
{
	return _this.enabled;
}

public static void set_enabled(UnityEngine.Behaviour _this, bool value)
{
	_this.enabled = value;
}

public static bool get_isActiveAndEnabled(UnityEngine.Behaviour _this)
{
	return _this.isActiveAndEnabled;
}

}
}
