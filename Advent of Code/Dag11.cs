using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag11 : Dag
    {
        public Dag11(string s) : base(s)
        {
            
        }
        monkey[] Monkeys = new monkey[8];
        public override void Puzzel1()
        {
            Monkeys[0] = new monkey(3, -1, 2, 6, 2);
            Monkeys[1] = new monkey(11, -1, 7, 4, 3);
            Monkeys[2] = new monkey(-1, 6, 3, 1, 5);
            Monkeys[3] = new monkey(-1, 4, 11, 4, 7);
            Monkeys[4] = new monkey(-1, 8, 17, 7, 0);
            Monkeys[5] = new monkey(-1, 2, 5, 3, 1);
            Monkeys[6] = new monkey(int.MaxValue, -1, 13, 5, 2);
            Monkeys[7] = new monkey(-1, 5, 19, 0, 6);

            for (int i = 0; i < 8; i ++)
            {
                string[] currentline = lines[i * 7 + 1].Split(',');
                for(int j = 0; j < currentline.Length; j++)
                {
                    int value = int.Parse(currentline[j][^2..]);
                    Monkeys[i].Catch(value);
                }
            }
            for (int throws = 0; throws < 10000; throws++)
                AllMonkeysThrow();
            this.result1 = "";
            for(int i = 0; i < 8; i ++)
            {
                long count = Monkeys[i].inspectioncount;
                result1 += $"Monkey {i} has thrown {count} times";
                result1 += System.Environment.NewLine;
            }
            long[] highest = new long[2];
            highest[0] = Monkeys[0].inspectioncount;
            for (int i = 1; i < 8; i ++)
            {
                long next = Monkeys[i].inspectioncount;
                if (next > highest[0])
                {
                    highest[1] = highest[0];
                    highest[0] = next;
                }
                else if (next > highest[1])
                    highest[1] = next;
            }
            long monkeybusiness = highest[0] * highest[1];
            result1 += $"monkeybusiness = {monkeybusiness}";

        }

        public void AllMonkeysThrow()
        {
            for(int i = 0; i < 8; i++)
            {
                FlyingItems(Monkeys[i].InspectThrowAll());
            }
        }

        public void FlyingItems(List<(long, long)> flying)
        {
            foreach ((long to, long value) item in flying)
                Monkeys[item.to].Catch(item.value);
        }

        public override void Puzzel2()
        {
            
        }
    }

    public class monkey
    {
        Queue<long> items= new Queue<long>();
        int opMult = -1;
        int opAdd = -1;
        int test;
        int testfail = -1;
        int testpass = -1;
        public long inspectioncount
        {
            get; set;
        }

        public monkey(int opMult, int opAdd, int test, int testfail, int testpass)
        {
            this.opMult = opMult;
            this.opAdd = opAdd;
            this.test = test;
            this.testfail = testfail;
            this.testpass = testpass;
            inspectioncount = 0;
        }

        public void Catch(long input)
        {
            items.Enqueue(input);
        }

        public List<(long,long)> InspectThrowAll()
        {
            List<(long, long)> output = new List<(long, long)>();
            while(items.Count> 0)
            {
                long next = items.Dequeue();
                if (opMult == int.MaxValue)
                    next *= next;
                else if (opMult > 0)
                    next *= opMult;
                else if (opAdd > 0)
                    next += opAdd;
                else
                    throw new Exception();
                //next = next / 3;
                next = next % 9699690;
                int nextMonkey;
                if (next % test == 0)
                    nextMonkey = testpass;
                else
                    nextMonkey = testfail;
                output.Add((nextMonkey, next));
                inspectioncount++;
            }
            return output;
        }
    }
}
