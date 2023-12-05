using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag2302 : Dag
    {
        public Dag2302(string s) : base(s)
        {

        }
        public string[] debugstring = new string[10];
        public override void Puzzel1()
        {
            int possiblesum = 0;
            for (int i = 0;i < this.lines.Length; i++)
            {
                string[] game = this.lines[i].Split(": ");
                int currentgame = int.Parse(game[0].Substring(5));
                //game[1] = game[1].Replace(" ", "");
                string[] sets = game[1].Split("; ");
                //if(i < 10)
                //    debugstring[i] = game[1];
                bool possible = true;
                for(int j = 0;j < sets.Length; j++)
                {
                    string[] current = sets[j].Split(", ");
                    for(int c = 0;c < current.Length;c++)
                    {
                        string[] lr = current[c].Split(" ");
                        switch (lr[1]) 
                        {
                            case "blue":
                                if (int.Parse(lr[0]) > 14)
                                    possible = false;
                                break;
                            case "red":
                                if (int.Parse(lr[0]) > 12)
                                    possible = false;
                                break;
                            case "green":
                                if (int.Parse(lr[0]) > 13)
                                    possible = false;
                                break;
                        }
                    }
                }
                if (possible)
                    possiblesum += currentgame;

            }
            this.result1 = possiblesum.ToString();
            
        }

        public override void Puzzel2()
        {
            long powersum = 0;
            for (int i = 0; i < this.lines.Length; i++)
            {
                string[] game = this.lines[i].Split(": ");
                int currentgame = int.Parse(game[0].Substring(5));
                //game[1] = game[1].Replace(" ", "");
                string[] sets = game[1].Split("; ");
                //if(i < 10)
                //    debugstring[i] = game[1];
                bool possible = true;
                int minb = 0;
                int minr = 0;
                int ming = 0;
                for (int j = 0; j < sets.Length; j++)
                {
                    string[] current = sets[j].Split(", ");
                    for (int c = 0; c < current.Length; c++)
                    {
                        string[] lr = current[c].Split(" ");
                        switch (lr[1])
                        {
                            case "blue":
                                int blue = int.Parse(lr[0]);
                                if (blue > minb)
                                    minb = blue;
                                break;
                            case "red":
                                int red = int.Parse(lr[0]);
                                if (red > minr)
                                    minr = red;
                                break;
                            case "green":
                                int green = int.Parse(lr[0]);
                                if (green > ming)
                                    ming = green;
                                break;
                        }
                    }
                }
                long currentpower = minb * minr * ming;
                powersum += currentpower;
            }
            this.result2 = powersum.ToString();
        }
    }
}
