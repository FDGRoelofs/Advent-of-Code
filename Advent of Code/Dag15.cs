using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag15 : Dag
    {
        public Dag15(string s) : base(s)
        {

        }
        public override void Puzzel1()
        {
            (int X, int Y)[] centers = new (int X, int Y)[lines.Length];
            (int X, int Y)[] edges = new (int X, int Y)[lines.Length];
            //parser
            for(int i = 0; i < lines.Length; i++)
            {
                string[] parse = lines[i].Split(':');
                parse[0] = parse[0][parse[0].IndexOf('x')..];
                parse[1] = parse[1][parse[1].IndexOf('x')..];
                string[] center = parse[0].Split(",");
                string[] closest = parse[1].Split(",");
                center[0] = Regex.Match(center[0], @"[+-]?\d+(\.\d+)?").Value;
                center[1] = Regex.Match(center[1], @"[+-]?\d+(\.\d+)?").Value;
                closest[0] = Regex.Match(closest[0], @"[+-]?\d+(\.\d+)?").Value;
                closest[1] = Regex.Match(closest[1], @"[+-]?\d+(\.\d+)?").Value;
                centers[i] = (int.Parse(center[0]),int.Parse(center[1]));
                edges[i] = (int.Parse(closest[0]), int.Parse(closest[1]));
            }
            int[] distance = new int[lines.Length];
            //afstand tussen beacon en senor
            for(int i = 0; i < lines.Length; i++)
            {
                int x = Math.Abs(edges[i].X - centers[i].X);
                int y = Math.Abs(edges[i].Y - centers[i].Y);
                distance[i] = x + y;
            }
            int checkline = 10;//2000000;//aanpassen voor test data
            List<(int start, int end)> ranges = new List<(int start, int end)>();
            //overlap met de checklijn
            for (int i = 0; i < lines.Length; i++) 
            {
                int SensorY = centers[i].Y;
                int SensorX = centers[i].X;
                bool inrange = false;
                int remainder = 0;
                if (SensorY < checkline)
                    if (SensorY + distance[i] > checkline)
                    {
                        inrange = true;
                        remainder = SensorY + distance[i] - checkline;
                    }

                if (SensorY >= checkline)
                    if (SensorY - distance[i] < checkline)
                    {
                        inrange = true;
                        remainder = distance[i] - SensorY + checkline;
                    }
                
                if(inrange)
                {
                    this.Writeresult1($"sensor op regel {i + 1} is binnen bereik. Remainder = {remainder}");
                    remainder *= 2;
                    remainder++;
                    int almosthalfrange = distance[i] - Math.Abs(SensorY - checkline);
                    ranges.Add((SensorX - almosthalfrange, SensorX + almosthalfrange + 1));
                }
            }
            ranges.Sort();
            //overlap op checklijn dedupliceren (verwijderen van overlap op overlap)
            List<(int start, int end)> finalranges = removeOverlap(ranges);
            int answer = 0;
            foreach((int start, int end) in finalranges)
            {
                answer += end - start;
            }
            //check voor beacons op de lijn
            List<(int X, int Y)> oncheckline = new List<(int X, int Y)>();
            foreach ((int X, int Y) in edges)
            {
                if(Y == checkline)
                    if(!oncheckline.Contains((X,Y)))
                    oncheckline.Add((X, Y));
            }
            answer -= oncheckline.Count;
            this.Writeresult1(answer.ToString());
        }

        public List<(int start, int end)> removeOverlap(List<(int start, int end)> ranges)
        {
            List<(int start, int end)> finalranges = new List<(int start, int end)>();
            bool done = true;
            if (ranges.Count == 1)
                return ranges;
            for (int i = 0; i < ranges.Count - 1; i++)
            {
                if (ranges[i].end <= ranges[i + 1].start)
                    finalranges.Add(ranges[i]);
                else
                {
                    finalranges.Add((ranges[i].start, ranges[i + 1].end));
                    done = false;
                    i++;
                }
            }
            if(done)
                return finalranges;
            else
                return removeOverlap(finalranges);
        }

        public override void Puzzel2()
        {
            
        }
    }
}
