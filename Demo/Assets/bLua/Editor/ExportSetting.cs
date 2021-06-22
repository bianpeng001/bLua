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

namespace bLua
{
    public static partial class LuaExport
    {
        public static readonly string outputNs = "namespace bLua.Extension";
        public static readonly string[] usingBlock = new string[]
        {
            "using System;",
            "using UnityEngine;",
        };

        public static readonly string outputPath = @"Assets\bLua\Generate";
        public static readonly string outputPathLua = @"Assets\StreamingAssets\Lua";

        public const string _this = "_this";

        public static ExportType[] typeList = new ExportType[]
        {
            new ExportType()
            {
                type = typeof(System.Object),
                baseClass = null,
                blackList = new string[] { "Equals" },
            },
            new ExportType()
            {
                type = typeof(System.Type),
                baseClass = null,
                whiteList = new string[] { "FullName", "BaseType", "IsClass", "IsEnum", "IsArray" },
            },
            new ExportType()
            {
                type = typeof(System.Array),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(System.Random),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(int[]),
                baseClass = typeof(System.Array),
                extClass = typeof(ArrayEx<int>),
                typeName = "ArrayInt",
                whiteList = new string[]{ "Get", "Set" },
            },
            new ExportType()
            {
                type = typeof(float[]),
                baseClass = typeof(System.Array),
                extClass = typeof(ArrayEx<float>),
                typeName = "ArrayFloat",
                whiteList = new string[]{ "Get", "Set" },
            },
            new ExportType()
            {
                type = typeof(string[]),
                baseClass = typeof(System.Array),
                extClass = typeof(ArrayEx<string>),
                typeName = "ArrayString",
                whiteList = new string[]{ "Get", "Set" },
            },
            new ExportType()
            {
                type = typeof(object[]),
                baseClass = typeof(System.Array),
                extClass = typeof(ArrayEx<object>),
                typeName = "ArrayObject",
                whiteList = new string[]{ "Get", "Set" },
            },
            new ExportType()
            {
                type = typeof(List<int>),
                typeName = "ListInt",
                blackList = new string[]{ "GetEnumerator" },
            },
            new ExportType()
            {
                type = typeof(List<float>),
                typeName = "ListFloat",
                blackList = new string[]{ "GetEnumerator" },
            },
            new ExportType()
            {
                type = typeof(List<string>),
                typeName = "ListString",
                blackList = new string[]{ "GetEnumerator" },
            },
            new ExportType()
            {
                type = typeof(List<object>),
                typeName = "ListObject",
                blackList = new string[]{ "GetEnumerator" },
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Object),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.MonoBehaviour),
                baseClass = typeof(UnityEngine.Behaviour),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Behaviour),
                baseClass = typeof(UnityEngine.Component),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Component),
                baseClass = typeof(UnityEngine.Object),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.GameObject),
                blackList = new string[] { "gameObject", "GetComponent", "GetComponentInChildren", },
                baseClass = typeof(UnityEngine.Object),
                extClass = typeof(bLua.GameObjectEx),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Debug),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Input),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Time),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Graphics),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Screen),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Application),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.AssetBundle),
                baseClass = typeof(UnityEngine.Object),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Transform),
                baseClass = typeof(UnityEngine.Component),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Shader),
                baseClass = typeof(UnityEngine.Object),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Material),
                baseClass = typeof(UnityEngine.Object),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.MaterialPropertyBlock),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Renderer),
                baseClass = typeof(UnityEngine.Component),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.MeshRenderer),
                baseClass = typeof(UnityEngine.Renderer),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.SkinnedMeshRenderer),
                baseClass = typeof(UnityEngine.Renderer),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.MeshFilter),
                baseClass = typeof(UnityEngine.Component),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Mesh),
                baseClass = typeof(UnityEngine.Object),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Texture),
                baseClass = typeof(UnityEngine.Object),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.RenderTexture),
                baseClass = typeof(UnityEngine.Texture),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Texture2D),
                baseClass = typeof(UnityEngine.Texture),
                blackList = new string[]{ "Resize", "SetPixels" },
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Physics),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Collider),
                baseClass = typeof(UnityEngine.Component),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.MeshCollider),
                baseClass = typeof(UnityEngine.Collider),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.TrailRenderer),
                baseClass = typeof(UnityEngine.Renderer),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.LineRenderer),
                baseClass = typeof(UnityEngine.Renderer),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.BoxCollider),
                baseClass = typeof(UnityEngine.Collider),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.CapsuleCollider),
                baseClass = typeof(UnityEngine.Collider),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.SphereCollider),
                baseClass = typeof(UnityEngine.Collider),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.CharacterController),
                baseClass = typeof(UnityEngine.Collider),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Rigidbody),
                baseClass = typeof(UnityEngine.Component),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Animator),
                baseClass = typeof(UnityEngine.Behaviour),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Animation),
                baseClass = typeof(UnityEngine.Behaviour),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.AnimationClip),
                baseClass = typeof(UnityEngine.Motion),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Motion),
                baseClass = typeof(UnityEngine.Object),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Light),
                baseClass = typeof(UnityEngine.Behaviour),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Camera),
                baseClass = typeof(UnityEngine.Behaviour),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.ParticleSystem),
                baseClass = typeof(UnityEngine.Component),
            },
            
            new ExportType()
            {
                type = typeof(UnityEngine.Canvas),
                baseClass = typeof(UnityEngine.Behaviour),
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Mathf),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Color),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Quaternion),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Vector4),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Vector3),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Vector2),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(UnityEngine.Matrix4x4),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(bLua.LuaDelegate),
                baseClass = null,
            },
            new ExportType()
            {
                type = typeof(bLua.LogUtil),
                baseClass = null,
            },

            new ExportType()
            {
                type = typeof(bLua.Example),
                baseClass = typeof(UnityEngine.MonoBehaviour),
            },
            new ExportType()
            {
                type = typeof(bLua.Example02),
                baseClass = typeof(UnityEngine.MonoBehaviour),
            },
            new ExportType()
            {
                type = typeof(bLua.MoveSystem),
                baseClass = null,
            },
        };
    }
}


