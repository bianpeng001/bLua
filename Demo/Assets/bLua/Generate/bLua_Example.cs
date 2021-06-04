
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class bLua_Example
{
public static void SayHello(bLua.Example _this, string message)
{
	_this.SayHello(message);
}

public static void SayHello(bLua.Example _this, string name, string message)
{
	_this.SayHello(name, message);
}

public static string get_Name(bLua.Example _this)
{
	return _this.Name;
}

public static int get_Hp(bLua.Example _this)
{
	return _this.Hp;
}

public static void set_Hp(bLua.Example _this, int value)
{
	_this.Hp = value;
}

}
}
