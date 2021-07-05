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
using System.IO;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace bLua
{
    public static partial class LuaExport
    {
        public class ExportDefinition
        {
            public Type type, baseClass;
            public Type extClass;

            public string[] blackList, whiteList;
            public string typeName;

            public bool exportCtors = true;

            public string GetHelpClassName()
            {
                if (typeName != null)
                    return $"{type.Namespace.Replace('.', '_')}_{typeName}";
                return type.FullName.Replace('.', '_').Replace('+', '_');
            }

            public string GetFullName()
            {
                if (string.IsNullOrEmpty(typeName))
                    return type.FullName.Replace('+', '.');
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
                fs.WriteLine("-- csharp types ");
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

                fs.WriteLine("bLua.IUnityMethod.__call = CallUnityMethod or function(...)");
                fs.WriteLine("\tprint(...)");
                fs.WriteLine("end");
                fs.WriteLine();

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

        public static void GenBinder()
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
                        WriteBind(fs);
                        WriteAOT(fs);
                    });
                });
            }

            static void WriteBind(StreamWriter fs)
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
                            fs.Write(GetTypeName(item.extClass));
                            fs.Write("), ");
                        }

                        if (item.baseClass == null)
                            fs.Write("null, ");
                        else
                        {
                            fs.Write("typeof(");
                            fs.Write(GetTypeName(item.baseClass));
                            fs.Write("), ");
                        }

                        fs.Write("typeof(");
                        fs.Write(item.GetHelpClassName());
                        fs.WriteLine("));");
                    }

                });
            }

            static void WriteAOT(StreamWriter fs)
            {
                fs.WriteLine("public static void TouchWrapFuncs()");
                WriteBlock(fs, () =>
                {
                    fs.WriteLine("var L = IntPtr.Zero;");
                    var set = new HashSet<string>();
                    var methodList = new List<MethodInfo>();
                    var propList = new List<PropertyInfo>();

                    for (int i = 0; i < typeList.Length; ++i)
                    {
                        var (methods, props) = GetMethodsProps(typeList[i]);
                        var (staticMethods, staticProps) = GetStaticMethodsProps(typeList[i]);

                        methodList.AddRange(methods);
                        propList.AddRange(props);

                        methodList.AddRange(staticMethods);
                        propList.AddRange(staticProps);

                        if (typeList[i].extClass is var extClass && extClass != null)
                        {
                            methodList.AddRange(extClass.GetMethods(AutoWrap.StaticMemberFlag));
                            propList.AddRange(extClass.GetProperties(AutoWrap.StaticMemberFlag));
                        }

                        for (int j = 0; j < propList.Count; ++j)
                        {
                            var p = propList[j];
                            if (p.CanRead)
                                methodList.Add(p.GetGetMethod());
                            if (p.CanWrite)
                                methodList.Add(p.GetSetMethod());
                        }


                        for (int j = 0; j < methodList.Count; ++j)
                        {
                            var m = methodList[j];
                            set.Add(GetFuncDescAOT(m));
                            if (m.ReturnType != typeof(void)
                                && typeof(AutoWrap.IMultRet).IsAssignableFrom(m.ReturnType))
                                set.Add(MakeMultRet(m.ReturnType));
                        }
                        methodList.Clear();
                        propList.Clear();
                    }

                    var mList = new List<string>(set);
                    mList.Sort();
                    foreach (var line in mList)
                    {
                        fs.WriteLine(line);
                    }
                });
            }
        }

        #region AOT

        private static readonly StringBuilder sb = new StringBuilder();
        private static readonly List<Type> argList = new List<Type>();
        private static string GetFuncDescAOT(MethodInfo mi)
        {
            var isVoid = mi.ReturnType == typeof(void);
            var args = mi.GetParameters();

            argList.Clear();
            if (!mi.IsStatic)
                argList.Add(typeof(object));
            for (int i = 0; i < args.Length; ++i)
                argList.Add(args[i].ParameterType);
            if (!isVoid)
                argList.Add(mi.ReturnType);

            if (isVoid && argList.Count == 0)
                return "new AutoWrap.Action().Call(L);";

            sb.Clear();
            sb.Append("new AutoWrap.");

            if (isVoid)
                sb.Append("Action<");
            else
            {
                sb.Append("Func<");
            }
            for (int i = 0; i < argList.Count; ++i)
            {
                if (i > 0)
                    sb.Append(", ");
                sb.Append(GetTypeLabel(argList[i]));
            }
            sb.Append(">().Call(L);");

            return sb.ToString();

            static string GetTypeLabel(Type pType)
            {
                if (pType.IsEnum)
                    return "int";
                else if (pType.IsPrimitive || pType.IsValueType)
                    return GetTypeName(pType);
                else if (pType.IsClass)
                    return "object";
                else
                    return "object";
            }
        }

        public static string MakeMultRet(Type type)
        {
            var label = GetTypeName(type);
            return $"AutoWrap.PushMultRetNoGC(L, new {label}());";
        }

        #endregion

        private static void GenHelper(ExportDefinition item)
        {
            var type = item.type;
            var helpClassName = item.GetHelpClassName();
            var (methods, props) = GetMethodsProps(item);

            totalMethodCount += methods.Length;
            totalPropCount += props.Length;

            using (var fs = File.CreateText(Path.Combine(outputPath, helpClassName + ".cs")))
            {
                fs.WriteLine("// auto generate");
                fs.WriteLine();

                for (int i = 0; i < usingBlock.Length; ++i)
                    fs.WriteLine(usingBlock[i]);
                fs.WriteLine();

                fs.WriteLine(outputNs);
                WriteBlock(fs, () =>
                {
                    fs.WriteLine($"// {GetTypeName(type)}");
                    fs.WriteLine($"// {methods.Length} methods");
                    fs.WriteLine($"// {props.Length} properties");
                    fs.WriteLine($"public static class {helpClassName}");
                    WriteBlock(fs, () =>
                    {
                        WriteMethods(type, methods, fs);
                        WriteProps(type, props, fs);
                        WriteFlds(type, fs);

                        if (item.exportCtors
                                && !type.IsAbstract
                                && !typeof(UnityEngine.Component).IsAssignableFrom(type))
                            WriteCtors(type, fs);
                    });
                });
            }
        }

        private static void WriteFlds(Type type, StreamWriter fs)
        {
            var flds = type.GetFields(AutoWrap.InstanceMemberFlag);
            for(int i = 0; i < flds.Length; ++i)
            {
                var fld = flds[i];
                fs.WriteLine($"// {fld.Name}");

                fs.Write($"public static {GetTypeName(fld.FieldType)} get_{fld.Name}(");
                fs.Write($"{GetTypeName(type)} {_this}) => ");
                fs.WriteLine($"{_this}.{fld.Name};");

                if (!fld.IsInitOnly)
                {
                    fs.Write($"public static void set_{fld.Name}({GetTypeName(type)} {_this}, {GetTypeName(fld.FieldType)} value) => ");
                    fs.WriteLine($"{_this}.{fld.Name} = value;");
                }
                fs.WriteLine();
            }
        }

        private static void WriteCtors(Type type, StreamWriter fs)
        {
            var ctors = type.GetConstructors(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            for(int i = 0; i < ctors.Length; ++i)
            {
                var ctor = ctors[i];
                if (ctor.GetCustomAttribute<ObsoleteAttribute>() != null)
                    continue;

                var args = ctor.GetParameters();
                fs.Write($"public static ");

                if (type.IsValueType)
                    fs.Write($"bLua.Box<{GetTypeName(type)}>");
                else
                    fs.Write(GetTypeName(type));

                fs.Write(" New(");
                WriteArgsDecl(fs, args);
                fs.WriteLine(")");

                WriteBlock(fs, ()=>
                {
                    if (type.IsArray)
                    {
                        fs.WriteLine($"\treturn new {GetTypeName(type.GetElementType())}[arg0];");
                    }
                    else
                    {
                        fs.Write($"\treturn new {GetTypeName(type)}(");
                        WriteArgsPass(fs, args);
                        fs.WriteLine(");");
                    }
                });
            }
        }

        private static (MethodInfo[], PropertyInfo[]) GetMethodsProps(in ExportDefinition item)
        {
            var methods = Array.FindAll(
                            item.type.GetMethods(AutoWrap.InstanceMemberFlag),
                            AutoWrap.CheckMethodSupportAutoWrap);
            var  props = Array.FindAll(
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
                methods = Array.FindAll(methods, a => Array.IndexOf(blackList, a.Name) < 0);
                props = Array.FindAll(props, a => Array.IndexOf(blackList, a.Name) < 0);
            }
            return (methods, props);
        }

        private static (MethodInfo[], PropertyInfo[]) GetStaticMethodsProps(in ExportDefinition item)
        {
            var methods = Array.FindAll(
                            item.type.GetMethods(AutoWrap.StaticMemberFlag),
                            AutoWrap.CheckMethodSupportAutoWrap);
            var props = Array.FindAll(
                item.type.GetProperties(AutoWrap.StaticMemberFlag),
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
                methods = Array.FindAll(methods, a => Array.IndexOf(blackList, a.Name) < 0);
                props = Array.FindAll(props, a => Array.IndexOf(blackList, a.Name) < 0);
            }
            return (methods, props);
        }

        private static void WriteProps(Type type, PropertyInfo[] props, StreamWriter fs)
        {
            foreach(var prop in props)
            {
                fs.WriteLine($"// {prop.Name}");

                var propTypeName = GetTypeName(prop.PropertyType);

                var typeName = GetTypeName(type);
                var thisName = _this;
                if (type.IsValueType)
                {
                    typeName = $"Box<{typeName}>";
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
                            fs.WriteLine($" get_Item({typeName} {_this}, {indexTypeName} index)");
                            WriteBlock(fs, () =>
                            {
                                fs.WriteLine($"\treturn {thisName}[index];");
                            });
                        }

                        if (prop.CanWrite)
                        {
                            fs.Write("public static ");
                            fs.Write(propTypeName);
                            fs.WriteLine($" set_Item({typeName} {_this}, {indexTypeName} index, {propTypeName} value)");
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
                    fs.WriteLine($" get_{prop.Name}({typeName} {_this})");
                    WriteBlock(fs, ()=>
                    {
                        fs.WriteLine($"\treturn {thisName}.{prop.Name};");
                    });
                    fs.WriteLine();
                }

                if (prop.CanWrite)
                {
                    fs.Write("public static void set_");
                    fs.WriteLine($"{prop.Name}({typeName} {_this}, {propTypeName} value)");
                    WriteBlock(fs, () =>
                    {
                        fs.WriteLine($"\t{thisName}.{prop.Name} = value;");
                    });
                    fs.WriteLine();
                }

            }
        }

        private static void WriteMethods(Type type, MethodInfo[] methods, StreamWriter fs)
        {
            foreach (var method in methods)
            {
                var args = method.GetParameters();
                var isVoid = method.ReturnType == typeof(void);

                fs.WriteLine($"// {method.Name}");

                fs.Write("public static ");
                fs.Write(GetTypeName(method.ReturnType));
                fs.Write(' ');
                fs.Write(method.Name);
                WriteInstanceMethodArgsDecl(fs, type, args);
                fs.WriteLine();

                WriteBlock(fs, () =>
                {
                    if (type.IsArray)
                    {
                        switch (method.Name)
                        {
                            case "Get":
                                fs.WriteLine($"\treturn {_this}[{GetArgName(args[0], 0)}];");
                                break;
                            case "Set":
                                fs.WriteLine($"\t{_this}[{GetArgName(args[0], 0)}] = {GetArgName(args[1], 1)};");
                                break;
                        }
                        return;
                    }

                    fs.Write('\t');

                    if (!isVoid)
                        fs.Write("return ");

                    if (type.IsValueType)
                        fs.Write($"{_this}.value");
                    else
                        fs.Write(_this);

                    fs.Write('.');
                    fs.Write(method.Name);
                    fs.Write('(');
                    WriteArgsPass(fs, args);
                    fs.WriteLine(");");
                });
                fs.WriteLine();
            }
        }

        private static void WriteArgsPass(StreamWriter fs, ParameterInfo[] args)
        {
            int lastIndex = args.Length - 1;
            for (int i = 0; i <= lastIndex; ++i)
            {
                var arg = args[i];

                if (arg.IsOut)
                    fs.Write("out ");

                if (arg.ParameterType.IsEnum)
                {
                    fs.Write('(');
                    fs.Write(GetTypeName(arg.ParameterType));
                    fs.Write(')');
                }
                fs.Write(GetArgName(arg, i));

                if (i != lastIndex)
                    fs.Write(", ");
            }
        }

        private static void WriteInstanceMethodArgsDecl(StreamWriter fs, Type type, ParameterInfo[] args)
        {
            fs.Write('(');
            if (type.IsValueType)
                fs.Write($"Box<{GetTypeName(type)}>"); 
            else
                fs.Write(GetTypeName(type));

            fs.Write($" {_this}");
            if (args.Length > 0)
                fs.Write(", ");
            WriteArgsDecl(fs, args);
            fs.Write(')');
        }

        private static void WriteArgsDecl(StreamWriter fs, ParameterInfo[] args)
        {
            int lastIndex = args.Length - 1;
            for (int i = 0; i <= lastIndex; ++i)
            {
                var arg = args[i];
                var argtype = arg.ParameterType;

                if (arg.IsIn)
                {
                    fs.Write("in ");
                    argtype = argtype.GetElementType();
                }
                else if (arg.IsOut)
                {
                    fs.Write("out ");
                    argtype = argtype.GetElementType();
                }

                if (!argtype.IsEnum)
                    fs.Write(GetTypeName(argtype));
                else
                    fs.Write("int");

                fs.Write(' ');
                fs.Write(GetArgName(arg, i));

                if (i < lastIndex)
                    fs.Write(", ");
            }
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


