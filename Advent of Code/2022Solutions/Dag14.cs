using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Advent_of_Code
{
    public class Dag14 : Dag
    {
        public Dag14(string s) : base(s)
        {

        }
        List<List<Vector2>> rockpaths = new List<List<Vector2>>();
        int maxdepth;
        bool[,] rockwall;
        Vector2 hell;
        Vector2 start;
        public override void Puzzel1()
        {
            maxdepth = 0;
            hell = new Vector2(-1, -1);
            start = new Vector2(500, 0);
            parseLines();
            rockwall = new bool[1000, maxdepth + 3];
            foreach(List<Vector2> elem in rockpaths)
                drawLine(elem);
            for (int i = 0; i < 1000; i++)
                rockwall[i, maxdepth + 2] = true;
            long sandcount = 0;
            while(!rockwall[500,0]) // aanpassen voor echte data en/of na debuggen
            {
                newSand();
                sandcount++;
            }
            this.Writeresult1(sandcount.ToString());
        }

        public override void Puzzel2()
        {

        }

        public void parseLines()
        {
            for(int i = 0; i < lines.Length; i++)
            {
                List<Vector2> nodes = new List<Vector2>();
                string[] input = lines[i].Replace(" -> ", ",").Split(',');
                for(int j = 0; j < input.Length;j+=2)
                {
                    int x = int.Parse(input[j]);
                    int y = int.Parse(input[j+1]);
                    if(y > maxdepth)
                        maxdepth = y;
                    Vector2 next = new Vector2(x, y);
                    nodes.Add(next);
                }
                rockpaths.Add(nodes);
            }
        }

        public void drawLine(List<Vector2> nodes)
        {
            Vector2 current = nodes[0];
            Vector2 next = nodes[1];
            connectNodes(current, next);
            for(int i = 1; i < nodes.Count - 1; i++)
            {
                current = nodes[i];
                next = nodes[i+1];
                connectNodes(current, next);
            }
        }

        public void connectNodes(Vector2 start, Vector2 end)
        {
            Vector2 current = start;
            Vector2 direction = end - start;
            direction = Vector2.Normalize(direction);
            while(current != end)
            {
                rockwall[(int)current.X, (int)current.Y] = true;
                current += direction;
            }
            rockwall[(int)end.X, (int)end.Y] = true;
        }

        public bool newSand()
        {
            Vector2 landing = collisionBelow(start);
            bool falling = true;
            while(falling)
            {
                Vector2 newspot = checkSides(landing);
                    if (newspot == hell)
                    {
                        landing.Y--;
                        falling = false;
                    }
                    else
                    {
                        landing = collisionBelow(newspot);
                    }
                
            }
            this.Writeresult2(landing.ToString());
            rockwall[(int)landing.X, (int)landing.Y] = true;
            return true;
        }

        public Vector2 collisionBelow(Vector2 start)
        {
            int x = (int)start.X;
            int y = (int)start.Y;
            for(;y < rockwall.GetLength(1); y++)
            {
                if (rockwall[x, y])
                    return new Vector2(x,y);
            }

            return new Vector2(x, maxdepth);
        }

        public Vector2 checkSides(Vector2 mid)
        {
            int midX = (int)mid.X;
            int midY = (int)mid.Y;
            
            if (midX > 0 && (!rockwall[midX - 1, midY]))
                return new Vector2(mid.X - 1, mid.Y);
            else if (midX < 1000 && (!rockwall[midX + 1, midY]))
                return new Vector2(mid.X + 1, mid.Y);
            else
                return hell;
        }
    }
}
