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
 * 2021年6月15日, 边蓬
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
            public bool noPass;
            public int pid;

            public bool CanWalk => !noPass;
            public int RevNumber { get; set; }
        }

        public readonly AStarMap<CellData> map;
        private Vector3 mapOffset = new Vector3(-7.5f, 0, -9.5f);

        public MoveSystem()
        {
            map = new AStarMap<CellData>(16, 20);
        }

        private class MoveData
        {
            public int pid;
            public float speed;
            public float time;
            public PointXZ[] path;

            public bool Move(float deltaTime)
            {
                return true;
            }
        }

        private readonly List<MoveData> moveList = new List<MoveData>();

        public void Update(float deltaTime)
        {
            int lastIndex = moveList.Count - 1;
            for (int i = 0; i < lastIndex;)
            {
                var m = moveList[i];
                if (!m.Move(deltaTime))
                {
                    moveList[i] = moveList[lastIndex];
                    --lastIndex;
                }
                else
                {
                    ++i;
                }

            }
        }

        public MulRet<bool, float> MoveTo(int pid, GameObject obj, float speed, int x1, int z1, int x2, int z2)
        {
            return (false, 0);
        }

        private readonly List<int> pathList = new List<int>();
        private readonly List<PointXZ> pathXZList = new List<PointXZ>();

        public List<int> FindPath(int x1, int z1, int x2, int z2)
        {
            pathList.Clear();
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

        public MulRet<bool, int> GetMulRet()
        {
            return (true, 1234);
        }

    }
}

