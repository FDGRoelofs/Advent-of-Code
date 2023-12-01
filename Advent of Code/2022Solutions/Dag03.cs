using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag03 : Dag
    {
        public Dag03(string s) : base(s) 
        {
            
        }

        List<Backpack> allBackpacks = new List<Backpack>();

        public override void Puzzel1()
        {
            for(int i = 0; i < lines.Length; i++)
            {
                allBackpacks.Add(new Backpack(lines[i]));
            }
            int result = 0;
            foreach(Backpack backpack in allBackpacks)
            {
                result += backpack.bothComps;
            }
            this.result1 = result.ToString();
        }

        public override void Puzzel2()
        {
            int i = 0;
            int answer = 0;
            while(i < lines.Length)
            {
                for(int j = 0; j < allBackpacks[i].distinctItems.Count; j++)
                {
                    int currentItem = allBackpacks[i].distinctItems[j];
                    if (allBackpacks[i + 1].distinctItems.Contains(currentItem))
                        if (allBackpacks[i + 2].distinctItems.Contains(currentItem))
                        {
                            answer += currentItem;
                            break;
                        }
                }
                i += 3;
            }
            this.result2= answer.ToString();
        }
    }

    class Backpack
    {
        public Backpack(string input)
        {
            int size = input.Length;
            int compSize = size / 2;
            string half1 = input.Substring(0, compSize);
            string half2 = input.Substring(compSize, compSize);
            for(int i = 0; i < compSize; i++)
            {
                comp1.Add(getPrio(half1[i]));
                comp2.Add(getPrio(half2[i]));
            }
            comp1.Sort();
            comp2.Sort();
            int n1 = 0;
            int n2 = 0;
            while(bothComps == -1)
            {
                int val1 = comp1[n1];
                int val2 = comp2[n2];
                if (val1 == val2)
                    bothComps = val1;
                else if (val1 < val2)
                    n1++;
                else
                    n2++;
            }
            distinctItems = comp1.Concat(comp2).Distinct().ToList();
        }

        public List<int> comp1= new List<int>();
        public List<int> comp2 = new List<int>();
        public List<int> distinctItems= new List<int>();

        public int bothComps = -1;

        public int getPrio(char ch)
        {
            int value = (int)ch;
            if (value > 96)
                value -= 96;
            else
                value -= 38;
            return value;
        }
    }
}
