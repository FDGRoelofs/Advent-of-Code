using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag04 : Dag
    {
        public Dag04(string s) : base(s)
        {

        }
        public override void Puzzel1()
        {
            int count = 0;
            int puzzel2 = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] elves = lines[i].Split(',');
                string[] e1= elves[0].Split("-");
                string[] e2 = elves[1].Split("-");
                int e1start = int.Parse(e1[0]);
                int e1end = int.Parse(e1[1]);
                int e2start = int.Parse(e2[0]);
                int e2end = int.Parse(e2[1]);
                if(e1start <= e2start && e1end >= e2end)
                    count++;
                else if (e2start <= e1start && e2end >= e1end) 
                    count++;
                //puzzel2
                puzzel2 += overlap(e1start, e1end, e2start, e2end);
                
            }
            this.result1 = count.ToString();
            this.result2 = puzzel2.ToString();

        }

        public override void Puzzel2()
        {
            /*if (e1start <= e2start && e2start >= e1end)
                puzzel2++;
            else if (e2start <= e1start && e1start >= e2end)
                puzzel2++;
            else if (e1start <= e2end && e2end >= e1end)
                puzzel2++;
            else if (e2start <= e1end && e1end >= e2end)
                puzzel2++;
            */

        }

        public int overlap(int a1, int a2, int b1, int b2)
        {
            if (a1 >= b1)
                if (a1 <= b2)
                    return 1;
            if (a2 >= b1)
                if (a2 <= b2)
                    return 1;
            if(b1 >= a1)
                if(b1 <= a2)
                    return 1;
            if(b2 >= a1)
                if(b2 <= a2)
                    return 1;
            return 0;
            /*
             * Geval 1, a1 zit tussen b1 en b2
             * geval 2, a2 zit tussen b1 en b2
             * geval 3 b1 zit tussen a1 en a2
             * geval 4 b2 zit tussen a1 en a2
             */
        }
    }
}
