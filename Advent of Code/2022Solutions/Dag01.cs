using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag01 : Dag
    {
        public Dag01(string s) : base(s)
        {

        }
        public List<int> elves = new List<int>();
        public override void Puzzel1()
        {
            
            int elf = 0;
            for(int i = 0; i < this.lines.Length; i++)
            {
                if (this.lines[i] == "")
                {
                    elves.Add(elf);
                    elf = 0;
                }
                else
                {
                    int current = Int32.Parse(this.lines[i]);
                    elf += current;
                }
                
            }
            int answer = elves.Max();
            this.result1 = answer.ToString();
        }

        public override void Puzzel2()
        {
            int best = elves.Max();
            int deleteIndex = elves.IndexOf(best);
            elves.RemoveAt(deleteIndex);
            int second = elves.Max();
            deleteIndex = elves.IndexOf(second);
            elves.RemoveAt(deleteIndex);
            int third = elves.Max();
            int answer = best + second + third;
            this.result2 = answer.ToString();

        }
    }
}
