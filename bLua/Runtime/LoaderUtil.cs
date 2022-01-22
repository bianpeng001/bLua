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


using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace bLua
{
    public static class LoaderUtil
    {
        private static readonly string LuaExt = ".lua";

        #region Unity3D Platform

        public static readonly RuntimePlatform Platform = Application.platform;
        public static readonly string PersistentDataPath = Application.persistentDataPath;
        public static readonly string StreamingAssetsPath = Application.streamingAssetsPath;
        public static readonly string DataPath = Application.dataPath;

        #endregion

        private static string GetAssetPath(string path)
        {
            var ext = path.EndsWith(LuaExt) ? string.Empty : LuaExt;
            return $"{StreamingAssetsPath}/Lua/{path}{ext}";
        }

        public static byte[] ReadAsset(string path)
        {
            var assetPath = GetAssetPath(path);

            if (!File.Exists(assetPath))
            {
                throw new IOException($"file not exists: {path}");
            }

            return File.ReadAllBytes(assetPath);
        }

        public static byte[] ReadAssetAndroid(string path)
        {
            var assetPath = GetAssetPath(path);
            var localPath = Path.Combine(PersistentDataPath, path);

            var req = new UnityWebRequest(assetPath);
            req.downloadHandler = new DownloadHandlerFile(localPath);

            var waiter = req.SendWebRequest();
            while (!waiter.isDone)
            {
            }

            return File.ReadAllBytes(localPath);
        }


    }
}

