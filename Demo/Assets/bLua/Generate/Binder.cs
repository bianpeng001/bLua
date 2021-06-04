using System;

namespace bLua.Extension
{
public static class Binder
{
public static void Bind(LuaRegister reg)
{
reg.Add("System.Object", typeof(object), null, typeof(System_Object));
reg.Add("System.Type", typeof(System.Type), null, typeof(System_Type));
reg.Add("System.Array", typeof(System.Array), null, typeof(System_Array));
reg.Add("System.Random", typeof(System.Random), null, typeof(System_Random));
reg.Add("System.ArrayInt", typeof(int[]), typeof(System.Array), typeof(System_ArrayInt));
reg.Add("System.ArrayFloat", typeof(float[]), typeof(System.Array), typeof(System_ArrayFloat));
reg.Add("System.ArrayString", typeof(string[]), typeof(System.Array), typeof(System_ArrayString));
reg.Add("System.ArrayObject", typeof(object[]), typeof(System.Array), typeof(System_ArrayObject));
reg.Add("System.Collections.Generic.ListInt", typeof(System.Collections.Generic.List<int>), null, typeof(System_Collections_Generic_ListInt));
reg.Add("System.Collections.Generic.ListFloat", typeof(System.Collections.Generic.List<float>), null, typeof(System_Collections_Generic_ListFloat));
reg.Add("System.Collections.Generic.ListString", typeof(System.Collections.Generic.List<string>), null, typeof(System_Collections_Generic_ListString));
reg.Add("System.Collections.Generic.ListObject", typeof(System.Collections.Generic.List<object>), null, typeof(System_Collections_Generic_ListObject));
reg.Add("UnityEngine.Object", typeof(UnityEngine.Object), null, typeof(UnityEngine_Object));
reg.Add("UnityEngine.MonoBehaviour", typeof(UnityEngine.MonoBehaviour), typeof(UnityEngine.Behaviour), typeof(UnityEngine_MonoBehaviour));
reg.Add("UnityEngine.Behaviour", typeof(UnityEngine.Behaviour), typeof(UnityEngine.Component), typeof(UnityEngine_Behaviour));
reg.Add("UnityEngine.Component", typeof(UnityEngine.Component), typeof(UnityEngine.Object), typeof(UnityEngine_Component));
reg.Add("UnityEngine.GameObject", typeof(UnityEngine.GameObject), typeof(bLua.Extension.GameObjectEx), typeof(UnityEngine.Object), typeof(UnityEngine_GameObject));
reg.Add("UnityEngine.Debug", typeof(UnityEngine.Debug), null, typeof(UnityEngine_Debug));
reg.Add("UnityEngine.Input", typeof(UnityEngine.Input), null, typeof(UnityEngine_Input));
reg.Add("UnityEngine.Time", typeof(UnityEngine.Time), null, typeof(UnityEngine_Time));
reg.Add("UnityEngine.Graphics", typeof(UnityEngine.Graphics), null, typeof(UnityEngine_Graphics));
reg.Add("UnityEngine.Screen", typeof(UnityEngine.Screen), null, typeof(UnityEngine_Screen));
reg.Add("UnityEngine.Application", typeof(UnityEngine.Application), null, typeof(UnityEngine_Application));
reg.Add("UnityEngine.AssetBundle", typeof(UnityEngine.AssetBundle), typeof(UnityEngine.Object), typeof(UnityEngine_AssetBundle));
reg.Add("UnityEngine.Transform", typeof(UnityEngine.Transform), typeof(UnityEngine.Component), typeof(UnityEngine_Transform));
reg.Add("UnityEngine.Shader", typeof(UnityEngine.Shader), typeof(UnityEngine.Object), typeof(UnityEngine_Shader));
reg.Add("UnityEngine.Material", typeof(UnityEngine.Material), typeof(UnityEngine.Object), typeof(UnityEngine_Material));
reg.Add("UnityEngine.MaterialPropertyBlock", typeof(UnityEngine.MaterialPropertyBlock), null, typeof(UnityEngine_MaterialPropertyBlock));
reg.Add("UnityEngine.Renderer", typeof(UnityEngine.Renderer), typeof(UnityEngine.Component), typeof(UnityEngine_Renderer));
reg.Add("UnityEngine.MeshRenderer", typeof(UnityEngine.MeshRenderer), typeof(UnityEngine.Renderer), typeof(UnityEngine_MeshRenderer));
reg.Add("UnityEngine.SkinnedMeshRenderer", typeof(UnityEngine.SkinnedMeshRenderer), typeof(UnityEngine.Renderer), typeof(UnityEngine_SkinnedMeshRenderer));
reg.Add("UnityEngine.MeshFilter", typeof(UnityEngine.MeshFilter), typeof(UnityEngine.Component), typeof(UnityEngine_MeshFilter));
reg.Add("UnityEngine.Mesh", typeof(UnityEngine.Mesh), typeof(UnityEngine.Object), typeof(UnityEngine_Mesh));
reg.Add("UnityEngine.Texture", typeof(UnityEngine.Texture), typeof(UnityEngine.Object), typeof(UnityEngine_Texture));
reg.Add("UnityEngine.RenderTexture", typeof(UnityEngine.RenderTexture), typeof(UnityEngine.Texture), typeof(UnityEngine_RenderTexture));
reg.Add("UnityEngine.Texture2D", typeof(UnityEngine.Texture2D), typeof(UnityEngine.Texture), typeof(UnityEngine_Texture2D));
reg.Add("UnityEngine.Physics", typeof(UnityEngine.Physics), null, typeof(UnityEngine_Physics));
reg.Add("UnityEngine.Collider", typeof(UnityEngine.Collider), typeof(UnityEngine.Component), typeof(UnityEngine_Collider));
reg.Add("UnityEngine.MeshCollider", typeof(UnityEngine.MeshCollider), typeof(UnityEngine.Collider), typeof(UnityEngine_MeshCollider));
reg.Add("UnityEngine.BoxCollider", typeof(UnityEngine.BoxCollider), typeof(UnityEngine.Collider), typeof(UnityEngine_BoxCollider));
reg.Add("UnityEngine.CapsuleCollider", typeof(UnityEngine.CapsuleCollider), typeof(UnityEngine.Collider), typeof(UnityEngine_CapsuleCollider));
reg.Add("UnityEngine.SphereCollider", typeof(UnityEngine.SphereCollider), typeof(UnityEngine.Collider), typeof(UnityEngine_SphereCollider));
reg.Add("UnityEngine.CharacterController", typeof(UnityEngine.CharacterController), typeof(UnityEngine.Collider), typeof(UnityEngine_CharacterController));
reg.Add("UnityEngine.Rigidbody", typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Component), typeof(UnityEngine_Rigidbody));
reg.Add("UnityEngine.Animator", typeof(UnityEngine.Animator), typeof(UnityEngine.Behaviour), typeof(UnityEngine_Animator));
reg.Add("UnityEngine.Animation", typeof(UnityEngine.Animation), typeof(UnityEngine.Behaviour), typeof(UnityEngine_Animation));
reg.Add("UnityEngine.AnimationClip", typeof(UnityEngine.AnimationClip), typeof(UnityEngine.Motion), typeof(UnityEngine_AnimationClip));
reg.Add("UnityEngine.Motion", typeof(UnityEngine.Motion), typeof(UnityEngine.Object), typeof(UnityEngine_Motion));
reg.Add("UnityEngine.Light", typeof(UnityEngine.Light), typeof(UnityEngine.Behaviour), typeof(UnityEngine_Light));
reg.Add("UnityEngine.Camera", typeof(UnityEngine.Camera), typeof(UnityEngine.Behaviour), typeof(UnityEngine_Camera));
reg.Add("UnityEngine.ParticleSystem", typeof(UnityEngine.ParticleSystem), typeof(UnityEngine.Component), typeof(UnityEngine_ParticleSystem));
reg.Add("UnityEngine.Canvas", typeof(UnityEngine.Canvas), typeof(UnityEngine.Behaviour), typeof(UnityEngine_Canvas));
reg.Add("UnityEngine.Mathf", typeof(UnityEngine.Mathf), null, typeof(UnityEngine_Mathf));
reg.Add("UnityEngine.Color", typeof(UnityEngine.Color), null, typeof(UnityEngine_Color));
reg.Add("UnityEngine.Quaternion", typeof(UnityEngine.Quaternion), null, typeof(UnityEngine_Quaternion));
reg.Add("UnityEngine.Vector4", typeof(UnityEngine.Vector4), null, typeof(UnityEngine_Vector4));
reg.Add("UnityEngine.Vector3", typeof(UnityEngine.Vector3), null, typeof(UnityEngine_Vector3));
reg.Add("UnityEngine.Vector2", typeof(UnityEngine.Vector2), null, typeof(UnityEngine_Vector2));
reg.Add("UnityEngine.Matrix4x4", typeof(UnityEngine.Matrix4x4), null, typeof(UnityEngine_Matrix4x4));
reg.Add("bLua.LuaDelegate", typeof(bLua.LuaDelegate), null, typeof(bLua_LuaDelegate));
reg.Add("bLua.LogUtil", typeof(bLua.LogUtil), null, typeof(bLua_LogUtil));
reg.Add("bLua.Example", typeof(bLua.Example), typeof(UnityEngine.MonoBehaviour), typeof(bLua_Example));
}
public static void DoNotCallMe()
{
}
}
}
