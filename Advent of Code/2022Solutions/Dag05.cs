using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag05 : Dag
    {
        public Dag05(string s) : base(s)
        {

        }
        Stack<char>[] stacks = new Stack<char>[9];
        List<(int,int,int)> instructions = new List<(int,int,int)>();
        public override void Puzzel1()
        {
            initialiseStacks();
            initialiseInstructions();
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
            this.result1 = answer;
        }

        public override void Puzzel2()
        {
            initialiseStacks();
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
            this.result2 = answer;
        }

        public void initialiseStacks()
        {
            for(int i = 0; i < 9; i++)
            {
                stacks[i] = new Stack<char>();
            }
            for(int i = 1; i < 9; i++)
            {
                int index = 1;
                for(int j = 0; j < 9; j++)
                {
                    char next = lines[8 - i][index];
                    if(!(next == ' '))
                        stacks[j].Push(next);
                    index += 4;
                }
            }
        }

        public void initialiseInstructions()
        {
            for(int i = 10; i < lines.Length; i++)
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
