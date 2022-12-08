using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag08 : Dag
    {
        public Dag08(string s) : base(s)
        {

        }
        int[,] trees;
        int[,] scenic;
        bool[,] visible;
        public string debugstring;
        public override void Puzzel1()
        {
            //maak het bos aan
            int forestwidth = lines[0].Length;
            int forestlength = lines.Length;
            trees = new int[forestwidth, forestlength];
            scenic = new int[forestwidth, forestlength];
            //zet randen van het bos op zichtbaar
            initVisible(forestwidth, forestlength);
            //vul int array met bomen uit input
            initTrees();
            //gecommente code die test of checkRow werkt.
            /*checkRow(7, 0, 0, 1);
            bool test;
            for(int y = 0; y < 50; y ++)
                if(visible[7, y])
                    test = true;*/
            //check voor de boom of ze zichtbaar zijn, vanaf elke rand
            checkVisibility("left");
            checkVisibility("right");
            checkVisibility("top");
            checkVisibility("bottom");
            //tel het aantal zichtbare bomen
            int count = 0;
            for (int x = 0; x < forestwidth; x++)
                for (int y = 0; y < forestlength; y++)
                    if (visible[x, y])
                        count++;
            this.result1 = count.ToString();
            /*string debugstring = "";
            for (int y = 0; y < forestlength; y++)
            {
                for (int x = 0; x < forestwidth; x++)
                {
                    if (visible[x, y])
                        debugstring += '1';
                    else
                        debugstring += "0";
                }
                debugstring += System.Environment.NewLine;
                this.result2= debugstring;
            }*/
               

        }
        
        public override void Puzzel2()
        {
            //bereken voor elke boom mbh howScenic zijn score
            Parallel.For(0, scenic.GetLength(0), x =>
            {
                for (int y = 0; y < scenic.GetLength(1); y++)
                    howScenic(x, y);
            });
            //vind de hoogste score
            int highest = 0;
            for (int x = 0; x < scenic.GetLength(0); x++)
                for (int y = 0; y < scenic.GetLength(1); y++)
                    if (scenic[x,y] > highest)
                        highest = scenic[x,y];
            this.result2 = highest.ToString();
            //stop alle scores in een string om weergeven te worden.
            debugstring = "";
            for (int y = 0; y < scenic.GetLength(1); y++)
            {
                for (int x = 0; x < scenic.GetLength(0); x++)
                {
                    debugstring += scenic[x, y].ToString();
                    debugstring += ' ';
                }
                debugstring += System.Environment.NewLine;
            }

        }

        public void initVisible(int width, int length)
        {

            visible = new bool[width, length];
            for (int x = 0; x < length; x++)
            {
                visible[x, 0] = true;
                visible[x,length - 1] = true;
            }
            for(int y = 0; y < width; y++)
            {
                visible[0,y] = true;
                visible[width -1,y] = true;
            }
        }

        public void initTrees()
        {
            for(int x = 0; x < lines[0].Length; x++)
                for(int y = 0; y < lines.Length; y++)
                    trees[x,y] = int.Parse("" + lines[x][y]);
        }

        public void checkVisibility(string startside)
        {
            switch(startside)
            {
                case "left":
                    Parallel.For(0, lines.Length, x => checkRow(x, 0, 0, 1));
                    break;
                case "right":
                    Parallel.For(0, lines.Length, x => checkRow(x, lines.Length - 1, 0, -1));
                    break;
                case "top":
                    Parallel.For(0, lines[0].Length, y => checkRow(0,y,1,0));
                    break; 
                case "bottom":
                    Parallel.For(0, lines[0].Length, y => checkRow(lines[0].Length - 1, y, -1, 0));
                    break;
            }
        }

        public void howScenic(int x, int y)
        {
            int scenicscore = 1;
            //bereken voor elke richting hoeveel bomen er te zien zijn en vermenigvuldig de uitkomst met de huidige score
            scenicscore *= treeView(x, y, 0, 1);
            scenicscore *= treeView(x, y, 1, 0);
            scenicscore *= treeView(x, y, 0, -1);
            scenicscore *= treeView(x, y, -1, 0);
            //plaats de score in het array met scores per boom
            scenic[x,y] = scenicscore;
        }

        public void checkRow(int x, int y, int xInc, int yInc)
        {
            int highest = trees[x, y];
            if(xInc != 0)
                for(int nextX = x + xInc; nextX < trees.GetLength(0) && nextX >= 0; nextX += xInc)
                {
                    int current = trees[nextX, y];
                    if(current > highest)
                    {
                        visible[nextX, y] = true;
                        highest = current;
                        if (highest == 9) 
                            break;
                    }
                }
            else if (yInc != 0)
                for (int nextY = y + yInc; nextY < trees.GetLength(1) && nextY >= 0; nextY += yInc)
                {
                    int current = trees[x,nextY];
                    if(current > highest)
                    {
                        visible[x, nextY] = true;
                        highest = current;
                        if (highest == 9)
                            break;
                    }
                }
        }

        public int treeView(int x, int y, int xInc, int yInc)
        {
            int hometree = trees[y, x];
            int count = 0;
            //deze ifjes gebruik ik om met twee for loops de 4 richtingen te kunnen uitvoeren
            //in de for loopjes word elke stap een boom verder gekeken, als de boom even hoog of hoger is dan de boom vanaf waar gekeken word, word niet meer verder gekeken.
            if (xInc != 0)
                for (int nextX = x + xInc; nextX < trees.GetLength(0) && nextX >= 0; nextX += xInc)
                {
                    count++;
                    int current = trees[nextX, y];
                    if (current >= hometree)
                        break;
                }
            else if (yInc != 0)
                for (int nextY = y + yInc; nextY < trees.GetLength(1) && nextY >= 0; nextY += yInc)
                {
                    count++;
                    int current = trees[x, nextY];
                    if (current >= hometree)
                        break;
                }
            return Math.Max(1, count);
            
        }
    }
}
