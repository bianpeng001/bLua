
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class System_Array
{
public static void CopyTo(System.Array _this, System.Array array, int index)
{
	_this.CopyTo(array, index);
}

public static object Clone(System.Array _this)
{
	return _this.Clone();
}

public static void CopyTo(System.Array _this, System.Array array, long index)
{
	_this.CopyTo(array, index);
}

public static long GetLongLength(System.Array _this, int dimension)
{
	return _this.GetLongLength(dimension);
}

public static object GetValue(System.Array _this, long index)
{
	return _this.GetValue(index);
}

public static object GetValue(System.Array _this, long index1, long index2)
{
	return _this.GetValue(index1, index2);
}

public static object GetValue(System.Array _this, long index1, long index2, long index3)
{
	return _this.GetValue(index1, index2, index3);
}

public static object GetValue(System.Array _this, long[] indices)
{
	return _this.GetValue(indices);
}

public static void SetValue(System.Array _this, object value, long index)
{
	_this.SetValue(value, index);
}

public static void SetValue(System.Array _this, object value, long index1, long index2)
{
	_this.SetValue(value, index1, index2);
}

public static void SetValue(System.Array _this, object value, long index1, long index2, long index3)
{
	_this.SetValue(value, index1, index2, index3);
}

public static void SetValue(System.Array _this, object value, long[] indices)
{
	_this.SetValue(value, indices);
}

public static System.Collections.IEnumerator GetEnumerator(System.Array _this)
{
	return _this.GetEnumerator();
}

public static int GetLength(System.Array _this, int dimension)
{
	return _this.GetLength(dimension);
}

public static int GetLowerBound(System.Array _this, int dimension)
{
	return _this.GetLowerBound(dimension);
}

public static object GetValue(System.Array _this, int[] indices)
{
	return _this.GetValue(indices);
}

public static void SetValue(System.Array _this, object value, int[] indices)
{
	_this.SetValue(value, indices);
}

public static int GetUpperBound(System.Array _this, int dimension)
{
	return _this.GetUpperBound(dimension);
}

public static object GetValue(System.Array _this, int index)
{
	return _this.GetValue(index);
}

public static object GetValue(System.Array _this, int index1, int index2)
{
	return _this.GetValue(index1, index2);
}

public static object GetValue(System.Array _this, int index1, int index2, int index3)
{
	return _this.GetValue(index1, index2, index3);
}

public static void SetValue(System.Array _this, object value, int index)
{
	_this.SetValue(value, index);
}

public static void SetValue(System.Array _this, object value, int index1, int index2)
{
	_this.SetValue(value, index1, index2);
}

public static void SetValue(System.Array _this, object value, int index1, int index2, int index3)
{
	_this.SetValue(value, index1, index2, index3);
}

public static void Initialize(System.Array _this)
{
	_this.Initialize();
}

public static long get_LongLength(System.Array _this)
{
	return _this.LongLength;
}

public static bool get_IsFixedSize(System.Array _this)
{
	return _this.IsFixedSize;
}

public static bool get_IsReadOnly(System.Array _this)
{
	return _this.IsReadOnly;
}

public static bool get_IsSynchronized(System.Array _this)
{
	return _this.IsSynchronized;
}

public static object get_SyncRoot(System.Array _this)
{
	return _this.SyncRoot;
}

public static int get_Length(System.Array _this)
{
	return _this.Length;
}

public static int get_Rank(System.Array _this)
{
	return _this.Rank;
}

}
}
