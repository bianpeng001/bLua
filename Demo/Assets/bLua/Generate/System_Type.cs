
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class System_Type
{
public static string get_FullName(System.Type _this)
{
	return _this.FullName;
}

public static System.Type get_BaseType(System.Type _this)
{
	return _this.BaseType;
}

public static bool get_IsClass(System.Type _this)
{
	return _this.IsClass;
}

public static bool get_IsEnum(System.Type _this)
{
	return _this.IsEnum;
}

public static bool get_IsArray(System.Type _this)
{
	return _this.IsArray;
}

}
}
