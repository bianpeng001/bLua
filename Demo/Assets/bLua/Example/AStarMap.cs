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

namespace bLua
{
    public struct PointXZ
    {
        public static PointXZ zero = new PointXZ(0, 0);

        public readonly int x, z;

        public PointXZ(int x, int z)
        {
            this.x = x;
            this.z = z;
        }

        public override string ToString()
        {
            return $"({x},{z})";
        }

        public override bool Equals(object obj)
        {
            return obj is PointXZ point &&
                    x == point.x &&
                    z == point.z;
        }

        public override int GetHashCode()
        {
            int hashCode = 1553271884;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            return hashCode;
        }

        public bool EqualTo(in PointXZ b)
        {
            return x == b.x && z == b.z;
        }

        public static bool operator ==(in PointXZ a, in PointXZ b) => a.EqualTo(b);
        public static bool operator !=(in PointXZ a, in PointXZ b) => !a.EqualTo(b);

        public static PointXZ operator+(in PointXZ a, in PointXZ b)
        {
            return new PointXZ(a.x + b.x, a.z + b.z);
        }

        public static PointXZ operator -(in PointXZ a, in PointXZ b)
        {
            return new PointXZ(a.x - b.x, a.z - b.z);
        }
    }

    public interface ICellData
    {
        bool CheckPass();
    }

    public class AStarMap<TCellData> where TCellData : ICellData
    {
        public struct Cell
        {
            public PointXZ prev;
            public int F, G, H;
            public int revNumber;

            public TCellData data;
        }

        private readonly int width, length;
        private readonly Cell[,] map;

        private readonly List<PointXZ> openList = new List<PointXZ>();

        private PointXZ start, stop;

        private int revNumber;

        public AStarMap(int width, int length)
        {
            this.width = width;
            this.length = length;
            map = new Cell[width, length];
        }

        public bool FindPath(in PointXZ start, in PointXZ stop)
        {
            this.start = start;
            this.stop = stop;

            ref var cell = ref this[start];
            cell.G = 0;
            cell.prev = PointXZ.zero;

            openList.Clear();
            ++revNumber;

            return DoFindPath();
        }

        public bool FindPath(int x1, int z1, int x2, int z2)
        {
            return FindPath(new PointXZ(x1, z1), new PointXZ(x2, z2));
        }

        private const int DIS_PLUS = 10;
        private const int DIS_MULT = 14;

        private struct Cross
        {
            public int r0, r2, r6, r8;
        }

        private bool DoFindPath()
        {
            var curr = start;
            int loop = width + length;
            loop *= 2;

            while (--loop >= 0)
            {
                var s = new Cross();
                int offset = openList.Count;

                if (Candidate(curr, new PointXZ(curr.x - 1, curr.z), DIS_PLUS) == CandiResult.NoPass)
                {
                    ++s.r0;
                    ++s.r6;
                }
                if (Candidate(curr, new PointXZ(curr.x + 1, curr.z), DIS_PLUS) == CandiResult.NoPass)
                {
                    ++s.r2;
                    ++s.r8;
                }
                if (Candidate(curr, new PointXZ(curr.x, curr.z - 1), DIS_PLUS) == CandiResult.NoPass)
                {
                    ++s.r6;
                    ++s.r8;
                }
                if (Candidate(curr, new PointXZ(curr.x, curr.z + 1), DIS_PLUS) == CandiResult.NoPass)
                {
                    ++s.r0;
                    ++s.r2;
                }

                if (s.r0 == 0)
                    Candidate(curr, new PointXZ(curr.x - 1, curr.z + 1), DIS_MULT);
                if (s.r2 == 0)
                    Candidate(curr, new PointXZ(curr.x + 1, curr.z + 1), DIS_MULT);
                if (s.r8 == 0)
                    Candidate(curr, new PointXZ(curr.x + 1, curr.z - 1), DIS_MULT);
                if (s.r6 == 0)
                    Candidate(curr, new PointXZ(curr.x - 1, curr.z - 1), DIS_MULT);

                for (int i = offset; i < openList.Count; ++i)
                {
                    if (openList[i] == stop)
                        return true;
                }

                int min = 0;
                int last = openList.Count - 1;
                for (int i = 1; i <= last; ++i)
                {
                    if (this[openList[i]].F < this[openList[min]].F)
                        min = i;
                }
                curr = openList[min];
                openList[min] = openList[last];
                openList.RemoveAt(last);
            }

            return false;
        }

        private enum CandiResult
        {
            OpenList,   // 进入开放列表
            Visited,    // 已经访问过的, 则更新距离
            NoPass,     // 无法通过
        }

        private CandiResult Candidate(in PointXZ currPos, in PointXZ nextPos, int distance)
        {
            if (!CheckWalk(nextPos))
                return CandiResult.NoPass;

            ref var currCell = ref this[currPos];
            ref var nextCell = ref this[nextPos];
            if (nextCell.revNumber == revNumber)
            {
                if (nextCell.G > currCell.G + distance)
                {
                    var g = currCell.G + distance;
                    var f = g + nextCell.H;

                    nextCell.prev = currPos;
                    nextCell.G = g;
                    nextCell.F = f;
                }
                return CandiResult.Visited;
            }
            else
            {
                var g = currCell.G + distance;
                var h = CalcH(nextPos, stop);

                nextCell.revNumber = revNumber;
                nextCell.prev = currPos;
                nextCell.G = g;
                nextCell.H = h;
                nextCell.F = g + h;

                openList.Add(nextPos);
                return CandiResult.OpenList;
            }
        }

        private static int CalcH(in PointXZ p, in PointXZ stop)
        {
            static int Abs(int x)
            {
                return x >= 0 ? x : -x;
            }
            return 10 * (Abs(p.x - stop.x) + Abs(p.z - stop.z));
        }

        private bool CheckWalk(in PointXZ point)
        {
            if (!(point.x >= 0 && point.x < width
                    && point.z >= 0 && point.z < length))
                return false;
            return this[point].data.CheckPass();
        }

        public ref Cell this[in PointXZ p] => ref map[p.x, p.z];
        public ref Cell this[int x, int z] => ref map[x, z];
        public ref TCellData GetCellData(int x, int z) => ref this[x, z].data;

        public void GetPath(List<PointXZ> path)
        {

            var lastStep = PointXZ.zero;
            
            path.Add(stop);
            int lastIndex = 0;

            var curr = this[stop].prev;
            while (true)
            {
                var step = curr - path[lastIndex];
                if (step == lastStep)
                    path[lastIndex] = curr;
                else
                {
                    path.Add(curr);
                    lastStep = step;
                    ++lastIndex;
                }

                if (curr == start)
                    break;

                curr = this[curr].prev;
            }
        }

    }
}

