﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag2315 : Dag
    {
        public Dag2315(string s) : base(s)
        {

        }
        public string[] debugstring = new string[10];
        public override void Puzzel1()
        {
            //int test = cHash("pc=6");
            string[] sequence = lines[0].Split(',');
            int answer = 0;
            foreach (string line in sequence)
            {
                answer += cHash(line);
                this.debugstring[0] += line;
                this.debugstring[0] += System.Environment.NewLine;
            }
            this.result1 = answer.ToString();
            
        }

        public int cHash(string input)
        {
            int output = 0;
            int steps = input.Length;
            for(int i = 0; i < steps; i++)
            {
                int value = (int)input[i];
                output += value;
                output *= 17;
                output = output % 256;
            }
            return output;
        }

        public override void Puzzel2()
        {
            string[] sequence = lines[0].Split(',');
            //Dictionary<string, int> inner = new Dictionary<string, int>();
            Dictionary<int, LinkedHashMap<string,int>> Boxes = new Dictionary<int, LinkedHashMap<string, int>>();
            
            for (int i = 0; i < 256; i++) // initialise boxes
                Boxes.Add(i, new LinkedHashMap<string, int>());
            foreach (string line in sequence)
            {
                if(line[^1] == '-')
                {
                    int end = line.Length - 1;
                    string prehash = line.Substring(0, end);
                    int box = cHash(prehash);
                    if(Boxes[box].ContainsKey(prehash))
                        Boxes[box].Remove(prehash);
                }
                else
                {
                    string[] t = line.Split('=');
                    string prehash = t[0];
                    int flength = int.Parse(t[1]);
                }

            }
        }

        /*public int handleDash(string line)
        {

        }*/
    }
}
