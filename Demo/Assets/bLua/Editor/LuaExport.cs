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

/*
 * 2021年5月11日, 边蓬
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace bLua
{
    public static partial class LuaExport
    {
        public struct ExportType
        {
            public Type type, baseClass;
            public Type extClass;

            public string[] blackList, whiteList;
            public string typeName;

            public string GetHelpClassName()
            {
                if (typeName != null)
                    return $"{type.Namespace.Replace('.', '_')}_{typeName}";
                return type.FullName.Replace('.', '_');
            }

            public string GetFullName()
            {
                if (string.IsNullOrEmpty(typeName))
                    return type.FullName;
                return $"{type.Namespace}.{typeName}";
            }
        }

        private static int totalMethodCount = 0, totalPropCount = 0;

        [MenuItem("Tools/Lua/Gen Binder", priority = 1, validate = false)]
        public static void Gen()
        {
            totalMethodCount = 0;
            totalPropCount = 0;

            for (int i = 0; i < typeList.Length; ++i)
                GenHelper(typeList[i]);

            GenBinder();
            GenBinderLua();
            
            AssetDatabase.Refresh();

            Debug.Log($"process {typeList.Length} types");
            Debug.Log($"generate {totalMethodCount} methods");
            Debug.Log($"generate {totalPropCount} props");
        }

        [MenuItem("Tools/Lua/Clear", priority = 2, validate = false)]
        public static void Clear()
        {

        }

        private static void GenBinderLua()
        {
            var cache = new HashSet<string>();

            using (var fs = File.CreateText(Path.Combine(outputPathLua, "Binder.lua")))
            {
                fs.WriteLine("-- auto generate");
                fs.WriteLine("local AutoWrap = require(\"Core/AutoWrap\")");
                fs.WriteLine("local DefineClass = AutoWrap.DefineClass");
                fs.WriteLine();

                fs.WriteLine("------------------------------------------------------------");
                fs.WriteLine("-- c# types ");
                fs.WriteLine("------------------------------------------------------------");

                void EnsureNs(string fullname)
                {
                    if (fullname.LastIndexOf('.') is var rpos && rpos >= 0)
                    {
                        var ns = fullname.Substring(0, rpos);
                        if (!cache.Contains(ns))
                        {
                            cache.Add(ns);

                            EnsureNs(ns);

                            fs.WriteLine();
                            fs.WriteLine($"{ns} = {{}}");
                        }
                    }
                    if (!cache.Contains(fullname))
                        cache.Add(fullname);
                }

                for (int i = 0; i < typeList.Length; ++i)
                {
                    var item = typeList[i];
                    var fullname = item.GetFullName();
                    EnsureNs(fullname);
                    fs.Write(fullname);
                    fs.Write(" = DefineClass({ ");
                    fs.Write("class = \"");
                    fs.Write(item.GetFullName());

                    if (item.baseClass != null)
                    {
                        fs.Write("\", baseClass = \"");
                        fs.Write(item.baseClass.FullName);
                    }
                    fs.WriteLine("\" })");
                }
                fs.WriteLine();

                if (Array.FindIndex(typeList, a => a.type == typeof(LuaDelegate)) >= 0)
                {
                    fs.WriteLine("bLua.LuaDelegate.__call = CallLuaDelegate or function(obj, ...)");
                    fs.WriteLine("\tprint(obj, ...)");
                    fs.WriteLine("end");
                    fs.WriteLine();
                }

                fs.WriteLine("------------------------------------------------------------");
                fs.WriteLine("-- enum types");
                fs.WriteLine("------------------------------------------------------------");
                foreach (var type in typeNameCache.Keys)
                {
                    if (type.IsEnum)
                    {
                        var fullName = type.FullName.Replace('+', '.');
                        EnsureNs(fullName);

                        var names = type.GetEnumNames();
                        var values = type.GetEnumValues();
                        
                        fs.WriteLine($"{fullName} =");
                        WriteBlock(fs, () =>
                        {
                            for (int i = 0; i < names.Length; ++i)
                            {
                                fs.WriteLine($"\t{names[i]} = {(int)values.GetValue(i)},");
                            }
                        });
                        fs.WriteLine();
                    }
                }

                fs.WriteLine("print(\"lua binder ok\")");
                fs.WriteLine();
            }
        }

        private static void GenBinder()
        {
            using (var fs = File.CreateText(Path.Combine(outputPath, "Binder.cs")))
            {
                fs.WriteLine("using System;");
                fs.WriteLine();

                fs.WriteLine(outputNs);
                WriteBlock(fs, () =>
                {
                    fs.WriteLine("public static class Binder");
                    WriteBlock(fs, () =>
                    {
                        fs.WriteLine("public static void Bind(LuaRegister reg)");
                        WriteBlock(fs, () =>
                        {
                            for (int i = 0; i < typeList.Length; ++i)
                            {
                                var item = typeList[i];
                                fs.Write("reg.Add(\"");
                                fs.Write(item.GetFullName());
                                fs.Write("\", ");

                                fs.Write("typeof(");
                                fs.Write(GetTypeName(item.type));
                                fs.Write("), ");

                                if (item.extClass != null)
                                {
                                    fs.Write("typeof(");
                                    fs.Write(item.extClass.FullName);
                                    fs.Write("), ");
                                }

                                if (item.baseClass == null)
                                    fs.Write("null, ");
                                else
                                {
                                    fs.Write("typeof(");
                                    fs.Write(item.baseClass.FullName);
                                    fs.Write("), ");
                                }

                                fs.Write("typeof(");
                                fs.Write(item.GetHelpClassName());
                                fs.WriteLine("));");
                            }
                        });

                        fs.WriteLine("public static void DoNotCallMe()");
                        WriteBlock(fs, () =>
                        {
                        });
                    });
                });
            }
        }

        private static void GenHelper(in ExportType item)
        {
            var thisType = item.type;
            var helpClassName = item.GetHelpClassName();
            var methods = Array.FindAll(
                item.type.GetMethods(AutoWrap.InstanceMemberFlag),
                AutoWrap.CheckMethodSupportAutoWrap);
            
            var props = Array.FindAll(
                item.type.GetProperties(AutoWrap.InstanceMemberFlag),
                AutoWrap.CheckPropSupportAutoWrap);

            if (item.whiteList != null)
            {
                var whilteList = item.whiteList;
                methods = Array.FindAll(methods, a => Array.IndexOf(whilteList, a.Name) >= 0);
                props = Array.FindAll(props, a => Array.IndexOf(whilteList, a.Name) >= 0);
            }
            else if (item.blackList != null)
            {
                var blackList = item.blackList;
                methods = Array.FindAll(methods, a=> Array.IndexOf(blackList, a.Name) < 0);
                props = Array.FindAll(props, a => Array.IndexOf(blackList, a.Name) < 0);
            }

            totalMethodCount += methods.Length;
            totalPropCount += props.Length;

            using (var fs = File.CreateText(Path.Combine(outputPath, helpClassName + ".cs")))
            {
                fs.WriteLine("// auto generate");
                fs.WriteLine();

                for(int i = 0; i < usingBlock.Length; ++i)
                    fs.WriteLine(usingBlock[i]);
                fs.WriteLine();

                fs.WriteLine(outputNs);
                WriteBlock(fs, () =>
                {
                    fs.WriteLine($"// {GetTypeName(thisType)}");
                    fs.WriteLine($"// {methods.Length} methods");
                    fs.WriteLine($"// {props.Length} properties");
                    fs.WriteLine($"public static class {helpClassName}");
                    WriteBlock(fs, () =>
                    {
                        WriteMethods(thisType, methods, fs);
                        WriteProps(thisType, props, fs);
                    });
                });
            }
        }

        private static void WriteProps(Type thisType, PropertyInfo[] props, StreamWriter fs)
        {
            foreach(var prop in props)
            {
                fs.WriteLine($"// {prop.Name}");

                var propTypeName = GetTypeName(prop.PropertyType);

                var thisTypeName = GetTypeName(thisType);
                var thisName = _this;
                if (!thisType.IsClass)
                {
                    thisTypeName = $"Box<{thisTypeName}>";
                    thisName = $"{_this}.value";
                }

                if (prop.GetIndexParameters() is var indexParams
                    && indexParams != null
                    && indexParams.Length > 0)
                {
                    if (indexParams.Length == 1)
                    {
                        var indexTypeName = GetTypeName(indexParams[0].ParameterType);

                        if (prop.CanRead)
                        {
                            fs.Write("public static ");
                            fs.Write(propTypeName);
                            fs.WriteLine($" get_Item({thisTypeName} {_this}, {indexTypeName} index)");
                            WriteBlock(fs, () =>
                            {
                                fs.WriteLine($"\treturn {thisName}[index];");
                            });
                        }

                        if (prop.CanWrite)
                        {
                            fs.Write("public static ");
                            fs.Write(propTypeName);
                            fs.WriteLine($" set_Item({thisTypeName} {_this}, {indexTypeName} index, {propTypeName} value)");
                            WriteBlock(fs, () =>
                            {
                                fs.WriteLine($"\treturn {thisName}[index] = value;");
                            });
                        }
                    }
                    
                    return;
                }

                if (prop.CanRead)
                {
                    fs.Write("public static ");
                    fs.Write(propTypeName);
                    fs.WriteLine($" get_{prop.Name}({thisTypeName} {_this})");
                    WriteBlock(fs, ()=>
                    {
                        fs.WriteLine($"\treturn {thisName}.{prop.Name};");
                    });
                    fs.WriteLine();
                }

                if (prop.CanWrite)
                {
                    fs.Write("public static void set_");
                    fs.WriteLine($"{prop.Name}({thisTypeName} {_this}, {propTypeName} value)");
                    WriteBlock(fs, () =>
                    {
                        fs.WriteLine($"\t{thisName}.{prop.Name} = value;");
                    });
                    fs.WriteLine();
                }

            }
        }

        private static void WriteMethods(Type thisType, MethodInfo[] methods, StreamWriter fs)
        {
            foreach (var method in methods)
            {
                var arguments = method.GetParameters();
                var isVoid = method.ReturnType == typeof(void);

                fs.WriteLine($"// {method.Name}");

                fs.Write("public static ");
                fs.Write(GetTypeName(method.ReturnType));
                fs.Write(' ');
                fs.Write(method.Name);
                WriteArguments(fs, thisType, arguments);
                fs.WriteLine();

                WriteBlock(fs, () =>
                {
                    if (thisType.IsArray)
                    {
                        switch(method.Name)
                        {
                            case "Get":
                                fs.WriteLine($"\treturn {_this}[{GetArgName(arguments[0], 0)}];");
                                break;
                            case "Set":
                                fs.WriteLine($"\t{_this}[{GetArgName(arguments[0], 0)}] = {GetArgName(arguments[1], 1)};");
                                break;
                        }
                        return;
                    }

                    fs.Write('\t');

                    if (!isVoid)
                        fs.Write("return ");

                    if (thisType.IsClass)
                        fs.Write(_this);
                    else
                        fs.Write($"{_this}.value");

                    fs.Write('.');
                    fs.Write(method.Name);
                    fs.Write('(');
                    for (int i = 0; i < arguments.Length; ++i)
                    {
                        if (i > 0)
                            fs.Write(", ");
                        var arg = arguments[i];

                        if (arg.IsOut)
                            fs.Write("out ");

                        if (arg.ParameterType.IsEnum)
                        {
                            fs.Write('(');
                            fs.Write(GetTypeName(arg.ParameterType));
                            fs.Write(')');
                        }
                        fs.Write(GetArgName(arg, i));
                    }
                    fs.WriteLine(");");
                });
                fs.WriteLine();
            }
        }

        private static void WriteArguments(StreamWriter fs, Type thisType, ParameterInfo[] arguments)
        {
            fs.Write('(');
            if (thisType.IsClass)
                fs.Write(GetTypeName(thisType));
            else
                fs.Write($"Box<{GetTypeName(thisType)}>");

            fs.Write(' ');
            fs.Write(_this);

            for(int i = 0; i < arguments.Length; ++i)
            {
                fs.Write(", ");

                var arg = arguments[i];
                var argType = arg.ParameterType;

                if (arg.IsIn)
                {
                    fs.Write("in ");
                    argType = argType.GetElementType();
                }
                else if (arg.IsOut)
                {
                    fs.Write("out ");
                    argType = argType.GetElementType();
                }
                
                if (!argType.IsEnum)
                    fs.Write(GetTypeName(argType));
                else
                    fs.Write("int");

                fs.Write(' ');
                fs.Write(GetArgName(arg, i));
            }

            fs.Write(')');
        }

        private static string GetArgName(ParameterInfo arg, int i)
        {
            if (string.IsNullOrEmpty(arg.Name))
                return $"arg{i}";
            else
                return arg.Name;
        }

        private static readonly Dictionary<Type, string> typeNameCache = new Dictionary<Type, string>();

        private static string GetTypeName(Type type)
        {
            if (typeNameCache.TryGetValue(type, out var name))
                return name;
            else
            {
                name = MakeTypeName(type);
                typeNameCache.Add(type, name);
                return name;
            }
        }

        private static string MakeTypeName(Type type)
        {
            if (type == typeof(void))
                return "void";
            else if (type == typeof(bool))
                return "bool";
            else if (type == typeof(char))
                return "char";
            else if (type == typeof(short))
                return "short";
            else if (type == typeof(ushort))
                return "ushort";
            else if (type == typeof(int))
                return "int";
            else if (type == typeof(uint))
                return "uint";
            else if (type == typeof(short))
                return "short";
            else if (type == typeof(ushort))
                return "ushort";
            else if (type == typeof(long))
                return "long";
            else if (type == typeof(ulong))
                return "ulong";
            else if (type == typeof(double))
                return "double";
            else if (type == typeof(float))
                return "float";
            else if (type == typeof(string))
                return "string";
            else if (type == typeof(object))
                return "object";
            else if (type.IsArray)
                return $"{GetTypeName(type.GetElementType())}[]";
            else if (type.IsGenericType)
            {
                var tname = type.Name;
                var idx = tname.LastIndexOf('`');
                tname = tname.Substring(0, idx);
                var gargs = string.Join(", ", Array.ConvertAll(type.GetGenericArguments(), GetTypeName));

                string ns;
                if (type.DeclaringType == null)
                    ns = type.Namespace;
                else
                    ns = GetTypeName(type.DeclaringType);

                return $"{ns}.{tname}<{gargs}>";
            }

            var name = type.FullName;
            if (name.IndexOf('+') >= 0)
                name = name.Replace('+', '.');
            return name;
        }

        private static void WriteBlock(StreamWriter fs, Action cb)
        {
            fs.WriteLine("{");
            cb();
            fs.WriteLine("}");
        }
    }

}


