using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag02 : Dag
    {
        public Dag02(string s) : base(s) 
        { 
        
        }

        public override void Puzzel1()
        {
            int score = 0;
            for (int i = 0; i < this.lines.Length; i++)
            {
                switch(lines[i])
                {
                    case "A X":
                        score += 4;
                        break;
                    case "A Y":
                        score += 8;
                        break;
                    case "A Z":
                        score += 3;
                        break;
                    case "B X":
                        score += 1;
                        break;
                    case "B Y":
                        score += 5;
                        break;
                    case "B Z":
                        score += 9;
                        break;
                    case "C X":
                        score += 7;
                        break;
                    case "C Y":
                        score += 2;
                        break;
                    case "C Z":
                        score += 6;
                        break;
                }
            }
            this.result1 = score.ToString();
        }

        public override void Puzzel2()
        {
            int score = 0;
            for (int i = 0; i < this.lines.Length; i++)
            {
                switch (lines[i])
                {
                    case "A X":
                        score += 3;
                        break;
                    case "A Y":
                        score += 4;
                        break;
                    case "A Z":
                        score += 8;
                        break;
                    case "B X":
                        score += 1;
                        break;
                    case "B Y":
                        score += 5;
                        break;
                    case "B Z":
                        score += 9;
                        break;
                    case "C X":
                        score += 2;
                        break;
                    case "C Y":
                        score += 6;
                        break;
                    case "C Z":
                        score += 7;
                        break;
                }
            }
            this.result2 = score.ToString();
        }
    }
}
