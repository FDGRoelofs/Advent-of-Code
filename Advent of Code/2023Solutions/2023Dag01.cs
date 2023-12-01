using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag2301 : Dag
    {
        public Dag2301(string s) : base(s)
        {

        }
        public List<int> CalVal = new List<int>();
        public override void Puzzel1()
        {
            for(int i = 0; i < this.lines.Length; i++)
            {
                string AllNumber = "";
                for(int j = 0; j < this.lines[i].Length; j++)
                {
                    if (Char.IsDigit(this.lines[i][j]))
                        AllNumber += this.lines[i][j];
                }
                string calibration = "";
                calibration += AllNumber[0];
                calibration += AllNumber[AllNumber.Length - 1];
                CalVal.Add(int.Parse(calibration));
            }
            this.result1 = CalVal.Sum().ToString();
            
        }

        public override void Puzzel2()
        {
            CalVal.Clear();
            for (int i = 0; i < this.lines.Length; i++)
            {
                string AllNumber = "";
                for (int j = 0; j < this.lines[i].Length; j++)
                {
                    if (Char.IsDigit(this.lines[i][j]))
                        AllNumber += this.lines[i][j];
                    if (lines[i].Length > j+2)
                    {
                        string possiblenumber = lines[i].Substring(j, 3);
                        if (possiblenumber == "one")
                        {
                            AllNumber += '1';
                            //j += 2;
                        }
                        else if (possiblenumber == "two")
                        {
                            AllNumber += '2';
                            //j += 2;
                        }
                        else if (possiblenumber == "six")
                        {
                            AllNumber += '6';
                            //j += 2;
                        }
                    }
                    if (lines[i].Length > j + 3)
                    {
                        string possiblenumber = lines[i].Substring(j, 4);
                        if (possiblenumber == "nine")
                        {
                            AllNumber += '9';
                            //j += 3;
                        }
                        else if (possiblenumber == "five")
                        {
                            AllNumber += '5';
                            //j += 3;
                        }
                        else if (possiblenumber == "four")
                        {
                            AllNumber += '4';
                            //j += 3;
                        }
                    }
                    if (lines[i].Length > j + 4)
                    {
                        string possiblenumber = lines[i].Substring(j, 5);
                        if (possiblenumber == "seven")
                        {
                            AllNumber += '7';
                            //j += 4;
                        }
                        else if (possiblenumber == "eight")
                        {
                            AllNumber += '8';
                            //j += 4;
                        }
                        else if (possiblenumber == "three")
                        {
                            AllNumber += '3';
                            //j += 4;
                        }
                    }
                }
                string calibration = "";
                calibration += AllNumber[0];
                calibration += AllNumber[AllNumber.Length - 1];
                CalVal.Add(int.Parse(calibration));
            }
            this.result2 = CalVal.Sum().ToString();

        }
    }
}
