using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag12 : Dag
    {
        public Dag12(string s, bool f) : base(s,f)
        {
            rowcount = lines.Length;
            columncount = lines[0].Length;
            mountainmap = new int[rowcount, columncount];
            for (int x = 0; x < rowcount; x++)
                for (int y = 0; y < columncount; y++)
                {
                    char temp = lines[x][y];
                    if (temp == 'S')
                    {
                        start = (x, y);
                        p2starters.Add(start);
                        mountainmap[x, y] = (int)'a';
                    }   
                    else if (temp == 'E')
                    {
                        end = (x, y);
                        mountainmap[x, y] = (int)'z';
                    }
                    else if (temp == 'a')
                    {
                        p2starters.Add((x, y));
                        mountainmap[x, y] = (int)temp;
                    }
                    else
                        mountainmap[x, y] = (int)temp;
                }
            Puzzel1();
            Puzzel2();
        }

        public int rowcount;
        public int columncount;
        int[,] mountainmap;
        (int X, int Y) start;
        (int X,int Y) end;
        List<(int X, int Y)> p2starters = new List<(int X, int Y)>();
        public override void Puzzel1()
        {
            List<(int X, int Y)> tocheck = new List<(int X, int Y)>();
            List<(int X, int Y)> alreadychecked = new List<(int X, int Y)>();
            int[,] distance = new int[rowcount, columncount];
            addNeighbours(start, tocheck, alreadychecked);
            int steps = 1;
            while(tocheck.Count > 0)
            {
                List<(int X, int Y)> nextcheck = new List<(int X, int Y)>();
                foreach ((int X, int Y) elem in tocheck)
                {
                    distance[elem.X, elem.Y] = steps;
                    alreadychecked.Add(elem);
                    addNeighbours(elem,nextcheck, alreadychecked);
                }
                tocheck.Clear();
                tocheck = nextcheck.Distinct().ToList();
                steps++;
            }
            this.result1 = distance[end.X,end.Y].ToString();
        }
        public void addNeighbours((int X, int Y) pos, List<(int X, int Y)> tocheck, List<(int X, int Y)> alreadychecked)
        {
            List<(int X, int Y)> newpos = new List<(int X, int Y)>();
            int height = mountainmap[pos.X, pos.Y];
            if (pos.X != 0)
                if(mountainmap[pos.X - 1, pos.Y] - height < 2)
                    newpos.Add((pos.X - 1, pos.Y));
            if (pos.X < this.rowcount - 1)
                if (mountainmap[pos.X + 1, pos.Y] - height < 2)
                    newpos.Add((pos.X + 1, pos.Y));
            if (pos.Y != 0)
                if (mountainmap[pos.X, pos.Y - 1] - height < 2)
                    newpos.Add((pos.X, pos.Y -1));
            if (pos.Y < this.columncount - 1)
                if (mountainmap[pos.X, pos.Y + 1] - height < 2)
                    newpos.Add((pos.X, pos.Y + 1));
            foreach ((int X, int Y) elem in newpos)
            {
                if (!alreadychecked.Contains(elem))
                    tocheck.Add(elem);
            }
        }

        public override void Puzzel2()
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            List<int> routelengths = new List<int>();
            int startpointcount = p2starters.Count;
            Parallel.For(0, startpointcount, x =>
            {
                List<(int X, int Y)> tocheck = new List<(int X, int Y)>();
                List<(int X, int Y)> alreadychecked = new List<(int X, int Y)>();
                int[,] distance = new int[rowcount, columncount];
                distance[end.X,end.Y] = int.MaxValue;
                addNeighbours(p2starters[x], tocheck, alreadychecked);
                int steps = 1;
                while (tocheck.Count > 0)
                {
                    List<(int X, int Y)> nextcheck = new List<(int X, int Y)>();
                    foreach ((int X, int Y) elem in tocheck)
                    {
                        distance[elem.X, elem.Y] = steps;
                        alreadychecked.Add(elem);
                        addNeighbours(elem, nextcheck, alreadychecked);
                    }
                    tocheck.Clear();
                    tocheck = nextcheck.Distinct().ToList();
                    steps++;
                }
                routelengths.Add(distance[end.X,end.Y]);
            });
            routelengths.Sort();
            this.result2 = routelengths[0].ToString();
            st.Stop();
            this.result2 = this.result2 + Environment.NewLine + st.ElapsedMilliseconds.ToString();
        }
    }
}
