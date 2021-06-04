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
using System.Runtime.InteropServices;

namespace bLua
{
    public static class LuaLib
    {
        public static readonly string LuaVendor = "lua.org";
        public static readonly string LuaVersion = "5.4.3";

#if !UNITY_EDITOR && UNITY_IOS
        const string DLLNAME = "__Internal";
#else
        const string DLLNAME = "lua54";
#endif

        public enum DataType : int
        {
            LUA_TNONE = -1,
            LUA_TNIL = 0,
            LUA_TBOOLEAN = 1,
            LUA_TLIGHTUSERDATA = 2,
            LUA_TNUMBER = 3,
            LUA_TSTRING = 4,
            LUA_TTABLE = 5,
            LUA_TFUNCTION = 6,
            LUA_TUSERDATA = 7,
            LUA_TTHREAD = 8,
            LUA_NUMTYPES = 9,
        }

        public enum GCOption : int
        {
            LUA_GCSTOP = 0,
            LUA_GCRESTART = 1,
            LUA_GCCOLLECT = 2,
            LUA_GCCOUNT = 3,
            LUA_GCCOUNTB = 4,
            LUA_GCSTEP = 5,
            LUA_GCSETPAUSE = 6,
            LUA_GCSETSTEPMUL = 7,
            LUA_GCISRUNNING = 9,
            LUA_GCGEN = 10,
            LUA_GCINC = 11,
        }

        public enum ErrorCode : int
        {
            LUA_OK = 0,
            LUA_YIELD = 1,
            LUA_ERRRUN = 2,
            LUA_ERRSYNTAX = 3,
            LUA_ERRMEM = 4,
            LUA_ERRERR = 5,
        }

        public const int LUA_MULTRET = -1;

        [StructLayout(LayoutKind.Sequential)]
        public struct Lua_Debug
        {
            public int eventcode;
            public IntPtr _name;                /* (n) */
            public IntPtr _namewhat;            /* (n) `global', `local', `field', `method' */
            public IntPtr _what;                /* (S) `Lua', `C', `main', `tail' */
            public IntPtr _source;              /* (S) */
            public int currentline;             /* (l) */
            public int nups;                    /* (u) number of upvalues */
            public int linedefined;             /* (S) */
            public int lastlinedefined;         /* (S) */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public byte[] _short_src;
            public int i_ci;                    /* active function */
        }


        public const int LUAI_MAXSTACK = 1000000;
        public const int LUA_REGISTRYINDEX = (-LUAI_MAXSTACK - 1000);

        public const int LUA_NOREF = -2;
        public const int LUA_REFNIL = -1;

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int lua_CFunction(IntPtr L);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int lua_KFunction(IntPtr L, int status, int ctx);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void lua_HookFunc(IntPtr L, ref Lua_Debug ar);
#else
        public delegate int lua_CFunction(IntPtr L);
        public delegate int lua_KFunction(IntPtr L, int status, int ctx);
        public delegate void lua_HookFunc(IntPtr L, ref Lua_Debug ar);    
#endif

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushnil(IntPtr L);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushnumber(IntPtr L, double number);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushinteger(IntPtr L, long number);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushlstring(IntPtr L, IntPtr str, int length);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushstring(IntPtr L, string str);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern void lua_pushcclosure(IntPtr L, IntPtr fn, int n);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushboolean(IntPtr L, int value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushlightuserdata(IntPtr L, IntPtr udata);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_pushthread(IntPtr L);


        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_getglobal(IntPtr L, string key);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gettable(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_getfield(IntPtr L, int idx, string key);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_geti(IntPtr L, int idx, int n);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawget(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawgeti(IntPtr L, int idx, int n);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_getmetatable(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawset(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawseti(IntPtr L, int idx, int index);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_setmetatable(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setfield(IntPtr L, int idx, string name);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setglobal(IntPtr L, string name);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_settable(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_close(IntPtr L);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_newthread(IntPtr L);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gettop(IntPtr L);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_settop(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushvalue(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rotate(IntPtr L, int idx, int n);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_copy(IntPtr L, int fromidx, int toidx);

        public static void lua_remove(IntPtr L, int idx)
        {
            lua_rotate(L, idx, -1);
            lua_pop(L, 1);
        }

        public static void lua_insert(IntPtr L, int idx)
        {
            lua_rotate(L, idx, 1);
        }

        public static void lua_replace(IntPtr L, int idx)
        {
            lua_copy(L, -1, idx);
            lua_pop(L, 1);
        }

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool lua_isnumber(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool lua_isinteger(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool lua_isstring(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool lua_iscfunction(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool lua_isuserdata(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern DataType lua_type(IntPtr L, int idx);

        public static bool lua_isnil(IntPtr L, int idx)
        {
            return lua_type(L, idx) == DataType.LUA_TNIL;
        }

        public static bool lua_istable(IntPtr L, int idx)
        {
            return lua_type(L, idx) == DataType.LUA_TTABLE;
        }

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_setfenv(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_checkstack(IntPtr L, int extra);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_xmove(IntPtr from, IntPtr to, int n);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool lua_equal(IntPtr L, int idx1, int idx2);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_rawequal(IntPtr L, int idx1, int idx2);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_lessthan(IntPtr L, int idx1, int idx2);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern double lua_tonumberx(IntPtr L, int idx, IntPtr isnum);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern long lua_tointegerx(IntPtr L, int idx, IntPtr isnum);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_tolstring(IntPtr L, int idx, out int length);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern long lua_toboolean(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern long lua_rawlen(IntPtr L, int idx);

        public static string lua_tostring(IntPtr L, int idx)
        {
            var ptr = lua_tolstring(L, idx, out var len);
            if (ptr == IntPtr.Zero)
                return null;

            unsafe
            {
                byte* a = (byte*)ptr.ToPointer();
                return System.Text.Encoding.UTF8.GetString(a, len);
            }
        }

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_tocfunction(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_touserdata(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_tothread(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_topointer(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_createtable(IntPtr L, int narr, int nrec);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_getfenv(IntPtr L, int idx);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_callk(
            IntPtr L,
            int nArgs,
            int nResults,
            int ctx,
            lua_KFunction k);

        public static void lua_call(IntPtr L, int nargs, int nresults)
        {
            lua_callk(L, nargs, nresults, 0, null);
        }

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern ErrorCode lua_pcallk(
            IntPtr L,
            int nArgs,
            int nResults,
            int errfunc,
            int ctx,
            lua_KFunction k);

        public static ErrorCode lua_pcall(IntPtr L, int nargs, int nresults, int errfunc)
        {
            return lua_pcallk(L, nargs, nresults, errfunc, 0, null);
        }

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_cpcall(IntPtr L, IntPtr func, IntPtr ud);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_yield(IntPtr L, int nresults);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_resume(IntPtr L, int narg);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_status(IntPtr L);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gc(IntPtr L, GCOption what, int data);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gc(IntPtr L, GCOption what, int data1, int data2);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_next(IntPtr L, int index);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_concat(IntPtr L, int n);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_getstack(IntPtr L, int level, ref Lua_Debug ar);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_getinfo(IntPtr L, string what, ref Lua_Debug ar);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern string lua_getlocal(IntPtr L, ref Lua_Debug ar, int n);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern string lua_setlocal(IntPtr L, ref Lua_Debug ar, int n);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern string lua_getupvalue(IntPtr L, int funcindex, int n);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern string lua_setupvalue(IntPtr L, int funcindex, int n);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_sethook(IntPtr L, lua_HookFunc func, int mask, int count);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern lua_HookFunc lua_gethook(IntPtr L);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gethookmask(IntPtr L);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gethookcount(IntPtr L);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_openlibs(IntPtr L);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern ErrorCode luaL_loadbufferx(
            IntPtr L,
            byte[] buf, int bufsize,
            byte[] name, string mode);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_loadstring(IntPtr L, string chunk);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_loadfile(IntPtr L, string filename);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr luaL_newstate();

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_ref(IntPtr L, int t);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_unref(IntPtr L, int t, int aref);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr luaL_tolstring(IntPtr L, int idx, out int len);

        public static string luaL_tostring(IntPtr L, int idx)
        {
            var ptr = luaL_tolstring(L, idx, out var len);
            if (ptr == IntPtr.Zero)
                return null;

            unsafe
            {
                byte* a = (byte*)ptr.ToPointer();
                return System.Text.Encoding.UTF8.GetString(a, len);
            }
        }

        public static void lua_pop(IntPtr L, int n)
        {
            lua_settop(L, -(n) - 1);
        }

        public static long lua_tointeger(IntPtr L, int idx)
        {
            return lua_tointegerx(L, idx, IntPtr.Zero);
        }

        public static double lua_tonumber(IntPtr L, int idx)
        {
            return lua_tonumberx(L, idx, IntPtr.Zero);
        }

        public static void lua_newtable(IntPtr L)
        {
            lua_createtable(L, 0, 0);
        }

        public static void lua_register(IntPtr L, string name, lua_CFunction func)
        {
            lua_pushcfunction(L, func);
            lua_setglobal(L, name);
        }

        public static void lua_pushcfunction(IntPtr L, lua_CFunction func)
        {
            IntPtr fn = Marshal.GetFunctionPointerForDelegate(func);
            lua_pushcclosure(L, fn, 0);
        }

    }

}

