using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag10 : Dag
    {
        public Dag10(string s) : base(s)
        {

        }
        int reg;
        int cyc;
        List<int> res;
        public override void Puzzel1()
        {
            reg = 1;
            cyc = 0;
            res = new List<int>();
            int ins = 0;
            while(cyc < 221 && ins < lines.Length)
            {
                string[] current = lines[ins].Split(' ');
                if (current[0] == "noop")
                    addCycle();
                if (current[0] == "addx")
                {
                    addCycle();
                    addCycle();
                    int add = int.Parse(current[1]);
                    reg += add;
                }
                ins++;
            }
            int total = 0;
            foreach(int i in res)
            {
                total += i;
            }
            this.result1 = total.ToString();
        }

        public void addCycle()
        {
            cyc++;
            if (cyc % 40 == 20)
                res.Add(reg*cyc);
        }

        
        public override void Puzzel2()
        {
            //CRT tekenpunt schuift elke stap 1 punt, van pos 0 t/m 239(of 1 tm 240)
            //Als tekenpunt Minder dan 2 verschilt van register x, teken een #, anders een .

            //misschien instructies in queue laden. noop = 0, addx = 0,x

            //misschien op te lossen met alleen een aanpassing aan addCycle? (en meer indexen doorlopen dan in deel 1)

            reg = 1;
            cyc = 0;
            List<int> mod = new List<int>();
            //bool[] screen = new bool[240];
            string answer = "";
            for (int i = 0; i < lines.Length; i++)
            {
                string[] current = lines[i].Split(' ');
                if (current[0] == "noop")
                    mod.Add(0);
                else if (current[0] == "addx")
                {
                    mod.Add(0);
                    mod.Add(int.Parse(current[1]));
                }
            }
            for (int i = 0; i < mod.Count; i++)
            {
                int dist = Math.Abs(reg - (i%40));
                if (dist < 2)
                    answer += '#';  //screen[i] = true;
                else
                    answer += '.';
                reg += mod[i];
                if (i % 41 == 0)
                    answer += System.Environment.NewLine;
            }
            this.result2= answer;
        }
    }
}
