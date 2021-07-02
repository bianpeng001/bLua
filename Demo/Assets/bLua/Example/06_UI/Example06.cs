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

using System;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace bLua
{
    public class Example06 : LuaBehaviour
    {
        public Text lblName;
        public Image imgCircle, imgRect;

        public SpriteAtlas atlas;

        private void Awake()
        {
            var state = LuaClient.State;
            LoadModule(state);

            onAwake.Call();

            var bind = new DataBind();
            bind.Connect("name", lblName);

            using (var t = module.GetTable("dataset"))
            {
                using (var f = t.GetFunction("SetBind"))
                {
                    f.Call<LuaTable, DataBind, int>(t, bind);
                }
            }

            using (var f = module.GetFunction("Test1"))
            {
                f.Call();
            }

            module.SetField("MethodRaiseError", new LuaDelegate(AutoWrap.CreateFunc<int, int>(MethodRaiseError)));

            PrintInfo(imgCircle);
            PrintInfo(imgRect);

            var sprites = new Sprite[atlas.spriteCount];
            atlas.GetSprites(sprites);
            foreach(var sprite in sprites)
            {
                UnityEngine.Debug.Log($"{sprite.name} {sprite.texture}");
            }
            Debug.Log(atlas.tag);
        }

        private void PrintInfo(Image image)
        {
            UnityEngine.Debug.Log(image.mainTexture, image.mainTexture);
            UnityEngine.Debug.Log($"{image.mainTexture.width} {image.mainTexture.height}");
            UnityEngine.Debug.Log(image.sprite.texture, image.sprite.texture);
            UnityEngine.Debug.LogFormat("{0}, {1}, {2}, {3}, {4}",
                image.sprite.rect,
                image.sprite.pivot,
                image.sprite.bounds,
                image.sprite.textureRect,
                image.sprite.textureRectOffset);
            UnityEngine.Debug.Log(string.Join(",", Array.ConvertAll(image.sprite.uv, a => $"({a.x},{a.y})")));
            UnityEngine.Debug.Log(string.Join(",", Array.ConvertAll(image.sprite.vertices, a => $"({a.x},{a.y})")));
            UnityEngine.Debug.Log(string.Join(",", Array.ConvertAll(image.sprite.triangles, a => a.ToString())));

#if UNITY_EDITOR
            Debug.Log(UnityEditor.Sprites.SpriteUtility.GetSpriteTexture(image.sprite, true));
            Debug.Log(UnityEditor.Sprites.SpriteUtility.GetSpriteTexture(image.sprite, false));
#endif
        }

        private int MethodRaiseError(int a)
        {
            LogUtil.Debug("11");
            throw new Exception($"MethodRaiseError: {a}");
        }

        public void OnButtonClick(GameObject sender)
        {
            LogUtil.Debug($"sender: {sender}");
            using(var f = module.GetFunction("Test2"))
            {
                f.Call();
            }
        }
    }
}


