
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Shader
{
public static UnityEngine.Shader GetDependency(UnityEngine.Shader _this, string name)
{
	return _this.GetDependency(name);
}

public static UnityEngine.Rendering.ShaderTagId FindPassTagValue(UnityEngine.Shader _this, int passIndex, UnityEngine.Rendering.ShaderTagId tagName)
{
	return _this.FindPassTagValue(passIndex, tagName);
}

public static int GetPropertyCount(UnityEngine.Shader _this)
{
	return _this.GetPropertyCount();
}

public static int FindPropertyIndex(UnityEngine.Shader _this, string propertyName)
{
	return _this.FindPropertyIndex(propertyName);
}

public static string GetPropertyName(UnityEngine.Shader _this, int propertyIndex)
{
	return _this.GetPropertyName(propertyIndex);
}

public static int GetPropertyNameId(UnityEngine.Shader _this, int propertyIndex)
{
	return _this.GetPropertyNameId(propertyIndex);
}

public static UnityEngine.Rendering.ShaderPropertyType GetPropertyType(UnityEngine.Shader _this, int propertyIndex)
{
	return _this.GetPropertyType(propertyIndex);
}

public static string GetPropertyDescription(UnityEngine.Shader _this, int propertyIndex)
{
	return _this.GetPropertyDescription(propertyIndex);
}

public static UnityEngine.Rendering.ShaderPropertyFlags GetPropertyFlags(UnityEngine.Shader _this, int propertyIndex)
{
	return _this.GetPropertyFlags(propertyIndex);
}

public static string[] GetPropertyAttributes(UnityEngine.Shader _this, int propertyIndex)
{
	return _this.GetPropertyAttributes(propertyIndex);
}

public static float GetPropertyDefaultFloatValue(UnityEngine.Shader _this, int propertyIndex)
{
	return _this.GetPropertyDefaultFloatValue(propertyIndex);
}

public static UnityEngine.Vector4 GetPropertyDefaultVectorValue(UnityEngine.Shader _this, int propertyIndex)
{
	return _this.GetPropertyDefaultVectorValue(propertyIndex);
}

public static UnityEngine.Vector2 GetPropertyRangeLimits(UnityEngine.Shader _this, int propertyIndex)
{
	return _this.GetPropertyRangeLimits(propertyIndex);
}

public static UnityEngine.Rendering.TextureDimension GetPropertyTextureDimension(UnityEngine.Shader _this, int propertyIndex)
{
	return _this.GetPropertyTextureDimension(propertyIndex);
}

public static string GetPropertyTextureDefaultName(UnityEngine.Shader _this, int propertyIndex)
{
	return _this.GetPropertyTextureDefaultName(propertyIndex);
}

public static int get_maximumLOD(UnityEngine.Shader _this)
{
	return _this.maximumLOD;
}

public static void set_maximumLOD(UnityEngine.Shader _this, int value)
{
	_this.maximumLOD = value;
}

public static bool get_isSupported(UnityEngine.Shader _this)
{
	return _this.isSupported;
}

public static int get_renderQueue(UnityEngine.Shader _this)
{
	return _this.renderQueue;
}

public static int get_passCount(UnityEngine.Shader _this)
{
	return _this.passCount;
}

}
}
