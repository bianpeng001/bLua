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
using System.Collections.Generic;
using UnityEngine;

namespace bLua
{
    [CreateAssetMenu(fileName = "NewAtlas", menuName = "ScriptableObjects/UGUI Atlas", order = 1)]
    public class UGUIAtlas : ScriptableObject
    {
        [System.Serializable]
        public struct SpriteDesc
        {
            public string name;
            public float x, y, width, height;
            public float px, py;
        }

        public SpriteDesc[] spriteDescs;
        public Texture2D texture;
        public Material material;

        private readonly Dictionary<string, Sprite> cache = new Dictionary<string, Sprite>();

        public Sprite GetSprite(string name)
        {
            Sprite sprite;
            if (cache.TryGetValue(name, out sprite))
                return sprite;

            sprite = CreateSprite(name);
            cache.Add(name, sprite);
            return sprite;
        }

        private Sprite CreateSprite(string name)
        {
            var idx = Array.FindIndex(spriteDescs, a => a.name == name);
            if (idx < 0)
                return null;

            ref var item = ref spriteDescs[idx];
            var sprite = Sprite.Create(texture,
                new Rect(item.x, item.y, item.width, item.height),
                new Vector2(item.px, item.py));
            sprite.name = name;

            return sprite;
        }
    }

}

