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


using AOT;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using static bLua.LuaLib;

namespace bLua
{
    public class DataBind
    {
        public enum DataType
        {
            Nil,
            Boolean,
            Integer,
            Number,
            String,
            Object,
        }

        public struct Data
        {
            public DataType type;

            public long ival;
            public double number;
            public object obj;

            public static implicit operator Data(long value)
            {
                return new Data()
                {
                    type = DataType.Integer,
                    ival = value,
                };
            }

            public static implicit operator Data(string value)
            {
                return new Data()
                {
                    type = DataType.String,
                    obj = value,
                };
            }

            public static implicit operator Data(double value)
            {
                return new Data()
                {
                    type = DataType.Number,
                    number = value,
                };
            }

            public override string ToString()
            {
                return GetString();
            }

            public string GetString()
            {
                switch (type)
                {
                    case DataType.Boolean:
                        return ival != 0 ? "true" : "false";

                    case DataType.Integer:
                        return ival.ToString();

                    case DataType.Number:
                        return number.ToString();

                    case DataType.String:
                        if (obj == null)
                            goto default;
                        return (string)obj;

                    case DataType.Object:
                        if (obj == null)
                            goto default;
                        return obj.ToString();

                    default:
                        return string.Empty;
                }
            }
        }

        public delegate void OnSetCallback(Data v);

        private readonly Dictionary<string, OnSetCallback> bindmap = new Dictionary<string, OnSetCallback>();

        public void Connect(string k, Text text)
        {
            bindmap.Add(k, (Data v) => text.text = v.GetString());
        }

        public void Set(string k, Data v)
        {
            if (bindmap.TryGetValue(k, out var cb))
                cb(v);
        }

        public static void Init(LuaState state)
        {
            state.Register("DataSetWriteField", DataSetWriteField);
        }

        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
        private static int DataSetWriteField(IntPtr L)
        {
            lua_rawgeti(L, 1, 2);
            var bind = AutoWrap.TypeTrait<DataBind>.pull(L, -1);
            lua_pop(L, 1);

            if (bind == null)
                return 0;

            LogUtil.Assert(lua_isstring(L, 2));
            var k = blua_tostring(L, 2);

            var v = new Data();
            if (lua_isnil(L, 3))
                v.type = DataType.Nil;
            else if (lua_isinteger(L, 3))
                v = lua_tointeger(L, 3);
            else if (lua_isstring(L, 3))
                v = blua_tostring(L, 3);
            else if (lua_isnumber(L, 3))
                v = lua_tonumber(L, 3);

            bind.Set(k, v);

            return 0;
        }
    }

}


