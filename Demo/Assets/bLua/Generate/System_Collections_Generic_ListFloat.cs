
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class System_Collections_Generic_ListFloat
{
public static void Add(System.Collections.Generic.List<float> _this, float item)
{
	_this.Add(item);
}

public static int BinarySearch(System.Collections.Generic.List<float> _this, float item)
{
	return _this.BinarySearch(item);
}

public static void Clear(System.Collections.Generic.List<float> _this)
{
	_this.Clear();
}

public static bool Contains(System.Collections.Generic.List<float> _this, float item)
{
	return _this.Contains(item);
}

public static void CopyTo(System.Collections.Generic.List<float> _this, float[] array)
{
	_this.CopyTo(array);
}

public static void CopyTo(System.Collections.Generic.List<float> _this, int index, float[] array, int arrayIndex, int count)
{
	_this.CopyTo(index, array, arrayIndex, count);
}

public static void CopyTo(System.Collections.Generic.List<float> _this, float[] array, int arrayIndex)
{
	_this.CopyTo(array, arrayIndex);
}

public static int IndexOf(System.Collections.Generic.List<float> _this, float item)
{
	return _this.IndexOf(item);
}

public static int IndexOf(System.Collections.Generic.List<float> _this, float item, int index)
{
	return _this.IndexOf(item, index);
}

public static int IndexOf(System.Collections.Generic.List<float> _this, float item, int index, int count)
{
	return _this.IndexOf(item, index, count);
}

public static void Insert(System.Collections.Generic.List<float> _this, int index, float item)
{
	_this.Insert(index, item);
}

public static int LastIndexOf(System.Collections.Generic.List<float> _this, float item)
{
	return _this.LastIndexOf(item);
}

public static int LastIndexOf(System.Collections.Generic.List<float> _this, float item, int index)
{
	return _this.LastIndexOf(item, index);
}

public static int LastIndexOf(System.Collections.Generic.List<float> _this, float item, int index, int count)
{
	return _this.LastIndexOf(item, index, count);
}

public static bool Remove(System.Collections.Generic.List<float> _this, float item)
{
	return _this.Remove(item);
}

public static void RemoveAt(System.Collections.Generic.List<float> _this, int index)
{
	_this.RemoveAt(index);
}

public static void RemoveRange(System.Collections.Generic.List<float> _this, int index, int count)
{
	_this.RemoveRange(index, count);
}

public static void Reverse(System.Collections.Generic.List<float> _this)
{
	_this.Reverse();
}

public static void Reverse(System.Collections.Generic.List<float> _this, int index, int count)
{
	_this.Reverse(index, count);
}

public static void Sort(System.Collections.Generic.List<float> _this)
{
	_this.Sort();
}

public static float[] ToArray(System.Collections.Generic.List<float> _this)
{
	return _this.ToArray();
}

public static void TrimExcess(System.Collections.Generic.List<float> _this)
{
	_this.TrimExcess();
}

public static int get_Capacity(System.Collections.Generic.List<float> _this)
{
	return _this.Capacity;
}

public static void set_Capacity(System.Collections.Generic.List<float> _this, int value)
{
	_this.Capacity = value;
}

public static int get_Count(System.Collections.Generic.List<float> _this)
{
	return _this.Count;
}

public static float get_Item(System.Collections.Generic.List<float> _this, int index)
{
	return _this[index];
}
public static float set_Item(System.Collections.Generic.List<float> _this, int index, float value)
{
	return _this[index] = value;
}
}
}
