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

//
// 2021年5月11日, 边蓬
//

namespace bLua
{
    //
    // lua的加载器
    //
    public interface ILoader
    {
        byte[] Load(string path);
    }

    //
    // 系统支持文件系统比如, editor, ios, pc
    //
    public class LuaFileLoader : ILoader
    {
        public byte[] Load(string path)
        {
            return LoaderUtil.ReadAsset(path);
        }
    }

    //
    // 安卓平台下面的读取, 没有文件系统, 得用webrequest
    //
    public class LuaFileLoaderAndroid : ILoader
    {
        public byte[] Load(string path)
        {
            return LoaderUtil.ReadAssetAndroid(path);
        }
    }


}

