/*
Copyright 2021 边蓬(bianpeng001@163.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System.Collections.Generic;
using UnityEditor;
using static bLua.LuaExport;

namespace bLua
{
    public static class ExportSetting
    {
        public static ExportDefinition[] typeList = new ExportDefinition[]
        {
            new ExportDefinition()
            {
                type = typeof(System.Object),
                baseClass = null,
                blackList = new string[] { "Equals" },
            },
            new ExportDefinition()
            {
                type = typeof(System.Type),
                baseClass = null,
                whiteList = new string[] { "FullName", "BaseType", "IsClass", "IsEnum", "IsArray" },
            },
            new ExportDefinition()
            {
                type = typeof(System.Array),
                baseClass = null,
            },
            new ExportDefinition()
            {
                type = typeof(System.Random),
                baseClass = null,
            },
            new ExportDefinition()
            {
                type = typeof(int[]),
                baseClass = typeof(System.Array),
                extClass = typeof(ArrayEx<int>),
                typeName = "ArrayInt",
                whiteList = new string[]{ "Get", "Set" },
            },
            new ExportDefinition()
            {
                type = typeof(float[]),
                baseClass = typeof(System.Array),
                extClass = typeof(ArrayEx<float>),
                typeName = "ArrayFloat",
                whiteList = new string[]{ "Get", "Set" },
            },
            new ExportDefinition()
            {
                type = typeof(string[]),
                baseClass = typeof(System.Array),
                extClass = typeof(ArrayEx<string>),
                typeName = "ArrayString",
                whiteList = new string[]{ "Get", "Set" },
            },
            new ExportDefinition()
            {
                type = typeof(object[]),
                baseClass = typeof(System.Array),
                extClass = typeof(ArrayEx<object>),
                typeName = "ArrayObject",
                whiteList = new string[]{ "Get", "Set" },
            },
            new ExportDefinition()
            {
                type = typeof(List<int>),
                typeName = "ListInt",
                blackList = new string[]{ "GetEnumerator" },
            },
            new ExportDefinition()
            {
                type = typeof(List<float>),
                typeName = "ListFloat",
                blackList = new string[]{ "GetEnumerator" },
            },
            new ExportDefinition()
            {
                type = typeof(List<string>),
                typeName = "ListString",
                blackList = new string[]{ "GetEnumerator" },
            },
            new ExportDefinition()
            {
                type = typeof(List<object>),
                typeName = "ListObject",
                blackList = new string[]{ "GetEnumerator" },
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Object),
                baseClass = null,
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.MonoBehaviour),
                baseClass = typeof(UnityEngine.Behaviour),
                blackList = new string[]{ "runInEditMode", },
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Behaviour),
                baseClass = typeof(UnityEngine.Component),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Component),
                baseClass = typeof(UnityEngine.Object),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.GameObject),
                blackList = new string[] { "gameObject", "GetComponent", "GetComponentInChildren", },
                baseClass = typeof(UnityEngine.Object),
                extClass = typeof(bLua.GameObjectEx),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Debug),
                baseClass = null,
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Input),
                baseClass = null,
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Time),
                baseClass = null,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Graphics),
                baseClass = null,
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Screen),
                baseClass = null,
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Application),
                baseClass = null,
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.AssetBundle),
                baseClass = typeof(UnityEngine.Object),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Transform),
                baseClass = typeof(UnityEngine.Component),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Shader),
                baseClass = typeof(UnityEngine.Object),
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Material),
                baseClass = typeof(UnityEngine.Object),
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.MaterialPropertyBlock),
                baseClass = null,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Renderer),
                baseClass = typeof(UnityEngine.Component),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.MeshRenderer),
                baseClass = typeof(UnityEngine.Renderer),
                blackList = new string[]{ "scaleInLightmap", "receiveGI", "stitchLightmapSeams" },
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.SkinnedMeshRenderer),
                baseClass = typeof(UnityEngine.Renderer),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.MeshFilter),
                baseClass = typeof(UnityEngine.Component),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Mesh),
                baseClass = typeof(UnityEngine.Object),
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Texture),
                baseClass = typeof(UnityEngine.Object),
                blackList = new string[] { "imageContentsHash", },
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.RenderTexture),
                baseClass = typeof(UnityEngine.Texture),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Texture2D),
                baseClass = typeof(UnityEngine.Texture),
                blackList = new string[]{ "Resize", "SetPixels", "alphaIsTransparency",  },
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Physics),
                baseClass = null,
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Collider),
                baseClass = typeof(UnityEngine.Component),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.MeshCollider),
                baseClass = typeof(UnityEngine.Collider),
                blackList = new string[]{ "scaleInLightmap", "receiveGI", "stitchLightmapSeams",  },
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.TrailRenderer),
                baseClass = typeof(UnityEngine.Renderer),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.LineRenderer),
                baseClass = typeof(UnityEngine.Renderer),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.BoxCollider),
                baseClass = typeof(UnityEngine.Collider),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.CapsuleCollider),
                baseClass = typeof(UnityEngine.Collider),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.SphereCollider),
                baseClass = typeof(UnityEngine.Collider),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.CharacterController),
                baseClass = typeof(UnityEngine.Collider),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Rigidbody),
                baseClass = typeof(UnityEngine.Component),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Animator),
                baseClass = typeof(UnityEngine.Behaviour),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Animation),
                baseClass = typeof(UnityEngine.Behaviour),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.AnimationClip),
                baseClass = typeof(UnityEngine.Motion),
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Motion),
                baseClass = typeof(UnityEngine.Object),
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Light),
                baseClass = typeof(UnityEngine.Behaviour),
                blackList = new string[]
                {
                    "SetLightDirty", "shadowRadius",
                    "shadowAngle", "areaSize", "areaSize",
                    "lightmapBakeType",
                },
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Camera),
                baseClass = typeof(UnityEngine.Behaviour),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.ParticleSystem),
                baseClass = typeof(UnityEngine.Component),
                exportCtors = false,
            },
            
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Canvas),
                baseClass = typeof(UnityEngine.Behaviour),
                exportCtors = false,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Mathf),
                baseClass = null,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Color),
                baseClass = null,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Quaternion),
                baseClass = null,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Vector4),
                baseClass = null,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Vector3),
                baseClass = null,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Vector2),
                baseClass = null,
            },
            new ExportDefinition()
            {
                type = typeof(UnityEngine.Matrix4x4),
                baseClass = null,
            },
            new ExportDefinition()
            {
                type = typeof(bLua.AutoWrap.IUnityMethod),
                typeName = "IUnityMethod",
                baseClass = null,
                whiteList = new string[]{ },
            },
            new ExportDefinition()
            {
                type = typeof(bLua.LogUtil),
                baseClass = null,
                exportCtors = false,
            },

            new ExportDefinition()
            {
                type = typeof(bLua.Example),
                baseClass = typeof(UnityEngine.MonoBehaviour),
            },
            new ExportDefinition()
            {
                type = typeof(bLua.Example02),
                baseClass = typeof(UnityEngine.MonoBehaviour),
            },
            new ExportDefinition()
            {
                type = typeof(bLua.MoveSystem),
                baseClass = null,
            },
        };

        [MenuItem("Tools/bLua/Gen Binder")]
        public static void Gen()
        {
            LuaExport.typeList = typeList;
            LuaExport.outputPath = @"Assets\bLua\Generate";
            LuaExport.outputPathLua = @"Assets\StreamingAssets\Lua";
            LuaExport.Gen();
        }

    }
}

