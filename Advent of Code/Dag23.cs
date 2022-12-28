using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Advent_of_Code
{
    public class Dag23 : Dag
    {
        public Dag23(string s) : base(s)
        {

        }
        List<Vector2> currentPos;
        int minx;
        int miny;
        int maxx;
        int maxy;
        bool[,] field;
        List<Vector2>[,] propPos;
        public override void Puzzel1()
        {
            /*
             *  lijst coordinaten (List<Vector2>)
                bereken min x en y (int)
	                verhoog alles met min x y
                teken in array (Bool[,])
                maak proposals voor nieuwe pos. List<vector2>[,]
                dubbele proposals terug naar vorige pos.
	            als list.count is 1, verplaats, als 2, terug naar vorige plek
                samenvoegen
                List2 coordinaten
             */

            currentPos = new List<Vector2>();
            for(int y =0; y < lines.Length;y++)
                for(int x = 0; x < lines[0].Length; x++)
                    if (lines[y][x] == '#')
                        currentPos.Add(new Vector2(x + 1, y + 1));
            for(int i = 0; i < 10; i++) // limit aanpassen voor test data
            {
                currentPos = boundList(currentPos);
                drawfield();
                drawDebug();
                proposePositions(i);
                currentPos = handleProposals();
            }
            minx = int.MaxValue;
            miny = int.MaxValue;
            foreach (Vector2 elem in currentPos)
            {
                if (elem.X < minx)
                    minx = (int)elem.X;
                else if (elem.X > maxx)
                    maxx = (int)elem.X;
                if (elem.Y < miny)
                    miny = (int)elem.Y;
                else if (elem.Y > maxy)
                    maxy = (int)elem.Y;
            }
            int boundx = maxx - minx;
            int boundy = maxy - miny;
            int fieldsize = boundx * boundy;
            int open = fieldsize - currentPos.Count;
            this.Writeresult1(open.ToString());
            drawDebug();
                
        }
        public void drawDebug()
        {
            string debug = "";

            for (int y = 0; y < field.GetLength(1); y++)
            {
                for (int x = 0; x < field.GetLength(0); x++)
                {
                    if (field[x, y])
                        debug += '#';
                    else
                        debug += '-';
                }
                debug += Environment.NewLine;
            }
            this.Writeresult1(debug);
        }

        public List<Vector2> boundList(List<Vector2> checklist)
        {
            minx = 0;
            miny = 0;
            maxx = 0;
            maxy = 0;
            foreach(Vector2 elem in checklist)
            {
                if (elem.X < minx)
                    minx = (int)elem.X;
                else if (elem.X > maxx)
                    maxx = (int)elem.X;
                if (elem.Y < miny)
                    miny = (int)elem.Y;
                else if (elem.Y > maxy)
                    maxy = (int)elem.Y;
            }
            
            if (minx == 0 && miny == 0)
                return checklist;
            List<Vector2> result = new List<Vector2>();
            foreach(Vector2 elem in checklist)
            {
                int x = (int)elem.X - minx;
                int y = (int)elem.Y - miny;
                result.Add(new Vector2(x, y));
            }
            maxx -= minx;
            maxy -= miny;
            return result;
        }

        public void drawfield()
        {
            field = new bool[maxx + 3, maxy + 3];
            propPos = new List<Vector2>[maxx + 3, maxy + 3];
            foreach (Vector2 elem in currentPos)
                field[(int)elem.X, (int)elem.Y] = true;
        }

        public void proposePositions(int round)
        {
            foreach(Vector2 oldpos in currentPos)
            {
                int x = (int)oldpos.X;
                int y = (int)oldpos.Y;
                int n = countNeighbours(x, y);
                if (n > 0 && n < 6)
                    propDirection(oldpos, round);
                else
                    appendProp(x+1, y+1, oldpos); // +1 om het hele veld een stukje te schuiven
                //propPos[x, y].Add(oldpos);
            }
        }

        public int countNeighbours(int x, int y)
        {
            int n = 0;
            if (field[x - 1, y - 1])
                n++;
            if (field[x, y - 1])
                n++;
            if (field[x + 1, y - 1])
                n++;
            if (field[x - 1, y])
                n++;
            if (field[x + 1, y ])
                n++;
            if (field[x - 1, y + 1])
                n++;
            if (field[x, y + 1])
                n++;
            if (field[x + 1, y + 1])
                n++;
            return n;
        }

        public bool propDirection(Vector2 oldpos, int round)
        {
            int x = (int)oldpos.X;
            int y = (int)oldpos.Y;
            //check north
            bool northfree = !field[x - 1, y - 1] && !field[x, y - 1] && !field[x + 1, y - 1];
            bool southfree = !field[x - 1, y + 1] && !field[x, y + 1] && !field[x + 1, y + 1];
            bool westfree = !field[x - 1, y - 1] && !field[x - 1, y] && !field[x - 1, y + 1];
            bool eastfree = !field[x + 1, y - 1] && !field[x + 1, y] && !field[x + 1, y + 1];
            x++;
            y++;//++ om het hele veld een stukje te schuiven
            oldpos.X++;
            oldpos.Y++;
            int n = round % 4;
            switch(n)
            {
                case 0:
                    if (northfree)
                    {
                        appendProp(x, y - 1, oldpos);
                        return true;
                    }
                    if (southfree)
                    {
                        appendProp(x, y + 1, oldpos);
                        return true;
                    }
                    if (westfree)
                    {
                        appendProp(x - 1, y, oldpos);
                        return true;
                    }
                    if (eastfree)
                    {
                        appendProp(x + 1, y, oldpos);
                        return true;
                    }
                    appendProp(x, y, oldpos);
                    return false;
                case 1:
                    if (southfree)
                    {
                        appendProp(x, y + 1, oldpos);
                        return true;
                    }
                    if (westfree)
                    {
                        appendProp(x - 1, y, oldpos);
                        return true;
                    }
                    if (eastfree)
                    {
                        appendProp(x + 1, y, oldpos);
                        return true;
                    }
                    if (northfree)
                    {
                        appendProp(x, y - 1, oldpos);
                        return true;
                    }
                    appendProp(x, y, oldpos);
                    return false;
                case 2:
                    if (westfree)
                    {
                        appendProp(x - 1, y, oldpos);
                        return true;
                    }
                    if (eastfree)
                    {
                        appendProp(x + 1, y, oldpos);
                        return true;
                    }
                    if (northfree)
                    {
                        appendProp(x, y - 1, oldpos);
                        return true;
                    }
                    if (southfree)
                    {
                        appendProp(x, y + 1, oldpos);
                        return true;
                    }
                    appendProp(x, y, oldpos);
                    return false;
                case 3:
                    if (eastfree)
                    {
                        appendProp(x + 1, y, oldpos);
                        return true;
                    }
                    if (northfree)
                    {
                        appendProp(x, y - 1, oldpos);
                        return true;
                    }
                    if (southfree)
                    {
                        appendProp(x, y + 1, oldpos);
                        return true;
                    }
                    if (westfree)
                    {
                        appendProp(x - 1, y, oldpos);
                        return true;
                    }
                    appendProp(x, y, oldpos);
                    return false;
            }
            throw new Exception();
            return false;
        }

        public void appendProp(int x, int y, Vector2 oldpos)
        {
            if (propPos[x, y] == null)
                propPos[x, y] = new List<Vector2>();
            propPos[x, y].Add(oldpos);
        }

        public List<Vector2> handleProposals()
        {
            List<Vector2> newpos = new List<Vector2>();
            for(int y = 0; y < propPos.GetLength(1); y++)
                for(int x = 0; x < propPos.GetLength(0); x++)
                {
                    if (propPos[x,y] != null)
                    {
                        int c = propPos[x, y].Count;
                        if (c == 1)
                            newpos.Add(new Vector2(x, y));
                        else if (c > 1)
                            newpos.AddRange(propPos[x, y]);
                    }
                }
            return newpos;
        }

        public override void Puzzel2()
        {
           
        }
    }
}
