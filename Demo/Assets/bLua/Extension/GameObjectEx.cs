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

namespace bLua.Extension
{
    public static class GameObjectEx
    {
        public static Component GetComponent2(GameObject _this, Type type)
        {
            return _this.GetComponent(type);
        }

        public static GameObject Clone(GameObject _this)
        {
            return GameObject.Instantiate<GameObject>(_this);
        }

        public static void Destroy2(GameObject obj)
        {
            GameObject.Destroy(obj);
        }

        public static void LookAt(GameObject _this, Vector3 point)
        {
            _this.transform.LookAt(point, Vector3.up);
        }

    }

}
