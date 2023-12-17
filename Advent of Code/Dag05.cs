using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent_of_Code
{
    public class Dag05 : Dag
    {
        public Dag05(string s) : base(s)
        {

        }
        Stack<char>[] stacks = new Stack<char>[9];
        List<(int,int,int)> instructions = new List<(int,int,int)>();
        public string[] debug = new string[4];
        public override void Puzzel1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            initialiseStacks();
            long initStacksTime = stopwatch.ElapsedMilliseconds;
            initialiseInstructions();
            long initInstructionsTime = stopwatch.ElapsedMilliseconds - initStacksTime;
            for(int i = 0; i < instructions.Count; i++)
            {
                (int count, int from, int to) = instructions[i];
                for(int j = 0; j < count; j++)
                {
                    stacks[to].Push(stacks[from].Pop());
                }
            }
            string answer = "";
            for(int i = 0; i < 9; i++)
            {
                answer += stacks[i].Peek();
            }
            stopwatch.Stop();
            long puzzel1time = stopwatch.ElapsedMilliseconds;
            debug[0] = "initialise stacks = " + initStacksTime.ToString();
            debug[1] = "initialise instructions = " + initInstructionsTime.ToString();
            debug[2] = "solve time puzzel 1 = " + puzzel1time.ToString();
            this.result1 = answer;
        }

        public override void Puzzel2()
        {
            initialiseStacks();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Stack<char> temp = new Stack<char>();
            for (int i = 0; i < instructions.Count; i++)
            {
                (int count, int from, int to) = instructions[i];
                for (int j = 0; j < count; j++)
                {
                    temp.Push(stacks[from].Pop());
                }
                while(temp.Count > 0)
                {
                    stacks[to].Push(temp.Pop());
                }
            }
            string answer = "";
            for (int x = 0; x < 9; x++)
            {
                answer += stacks[x].Peek();
            }
            stopwatch.Stop();
            long puzzel2time = stopwatch.ElapsedMilliseconds;
            debug[3] = "solve time puzzel 1 = " + puzzel2time.ToString();
            this.result2 = answer;
        }

        public void initialiseStacks()
        {
            for(int i = 0; i < 9; i++)
            {
                stacks[i] = new Stack<char>();
            }
            for(int currentline = 1; currentline < 100000; currentline++)
            {
                int index = 1;
                for(int currentstack = 0; currentstack < 9; currentstack++)
                {
                    char next = lines[99999 - currentline][index];
                    if (!(next == ' '))
                        stacks[currentstack].Push(next);
                    index += 4;
                }
            }
        }

        public void initialiseInstructions()
        {
            for(int i = 100001; i < lines.Length; i++)
            {
                string[] fullStr = lines[i].Split(' ');
                int count = int.Parse(fullStr[1]);
                int from = int.Parse(fullStr[3]) - 1;
                int to = int.Parse(fullStr[5]) - 1;
                instructions.Add((count,from,to));
            }
        }
    }
}
