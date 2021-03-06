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
using UnityEngine;
using static bLua.AutoWrap;

namespace bLua
{
    public class MoveSystem
    {
        public struct CellData : ICellData
        {
            public int pid;
            public bool nopass;

            public bool CheckPass() => !nopass;
            public int RevNumber { get; set; }
        }

        public readonly AStarMap<CellData> map;

        public MoveSystem()
        {
            map = new AStarMap<CellData>(16, 20);
            for(int i = 0; i <= 2; ++i)
            {
                map.GetCellData(i, 8).nopass = true;
                map.GetCellData(i, 9).nopass = true;
                map.GetCellData(i, 10).nopass = true;
            }
            for (int i = 6; i <= 9; ++i)
            {
                map.GetCellData(i, 8).nopass = true;
                map.GetCellData(i, 9).nopass = true;
                map.GetCellData(i, 10).nopass = true;
            }
            for (int i = 13; i <= 15; ++i)
            {
                map.GetCellData(i, 8).nopass = true;
                map.GetCellData(i, 9).nopass = true;
                map.GetCellData(i, 10).nopass = true;
            }

        }

        public void Update(float deltaTime)
        {
        }

        public MultRet<bool, float> MoveTo(int pid, GameObject obj, float speed, int x1, int z1, int x2, int z2)
        {
            return (false, 0);
        }

        private readonly List<PointXZ> pathXZList = new List<PointXZ>();

        public List<int> FindPath(int x1, int z1, int x2, int z2)
        {
            var pathList = new List<int>();
            if (map.FindPath(x1, z1, x2, z2))
            {
                pathXZList.Clear();
                map.GetPath(pathXZList);
                for (int i = pathXZList.Count - 1; i >= 0; --i)
                {
                    pathList.Add(pathXZList[i].x);
                    pathList.Add(pathXZList[i].z);
                }
            }
            return pathList;
        }

        public MultRet<bool, int> GetMulRet()
        {
            return (true, 12345);
        }

        public static int[] GetInts()
        {
            return new int[] { 1, 2, 3, 4, 5 };
        }
    }
}

