using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent_of_Code
{
    public class Dag15 : Dag
    {
        public Dag15(string s) : base(s)
        {

        }
        (int X, int Y)[] centers;
        (int X, int Y)[] edges;
        int[] distance;
        public override void Puzzel1()
        {
            centers = new (int X, int Y)[lines.Length];
            edges = new (int X, int Y)[lines.Length];
            //parser
            ParseInput();
            distance = new int[lines.Length];
            //afstand tussen beacon en senor
            for(int i = 0; i < lines.Length; i++)
            {
                int x = Math.Abs(edges[i].X - centers[i].X);
                int y = Math.Abs(edges[i].Y - centers[i].Y);
                distance[i] = x + y;
            }
            int checkline = 2000000;//aanpassen voor test data
            //bereken per sensor de range van overlap met de checklijn
            List<(int start, int end)> ranges = findBlockedX(checkline);
            //combineer de ranges die met elkaar overlappen
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
            if (ranges.Count == 1)
                return ranges;
            List<(int start, int end)> finalranges = new List<(int start, int end)>();
            for (int i = 0; i < ranges.Count; i++)
            {
                if(i == ranges.Count - 1)
                    finalranges.Add(ranges[i]);//misschien moet hier done = false?
                else if (ranges[i].end < ranges[i + 1].start)
                    finalranges.Add(ranges[i]);
                
                else
                {
                    int newstart = Math.Min(ranges[i].start, ranges[i + 1].start);
                    int newend = Math.Max(ranges[i].end, ranges[i + 1].end);
                    finalranges.Add((newstart, newend));
                    //finalranges.Add((ranges[i].start, ranges[i + 1].end));
                    i++;
                }
                /*
                 * else if (ranges[i].end > ranges[i + 1].start) // ranges[i].start <= ranges[i + 1].start && 
                {
                    int newstart = Math.Min(ranges[i].start, ranges[i + 1].start);
                    int newend = Math.Max(ranges[i].end, ranges[i + 1].end);
                    finalranges.Add((newstart, newend));
                    i++;
                }
                */
            }
            if(ranges.Count == finalranges.Count)
                return finalranges;
            else
                return removeOverlap(finalranges);
        }

        public void ParseInput()
        {
            for (int i = 0; i < lines.Length; i++)
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
                centers[i] = (int.Parse(center[0]), int.Parse(center[1]));
                edges[i] = (int.Parse(closest[0]), int.Parse(closest[1]));
            }
        }

        public List<(int start, int end)> findBlockedX(int checkline)
        {
            List<(int start, int end)> ranges = new List<(int start, int end)>();
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
                if (inrange)
                {
                    //this.Writeresult1($"sensor op regel {i + 1} is binnen bereik. Remainder = {remainder}");
                    remainder *= 2;
                    remainder++;
                    int almosthalfrange = distance[i] - Math.Abs(SensorY - checkline);
                    ranges.Add((SensorX - almosthalfrange, SensorX + almosthalfrange + 1));
                }
            }
            ranges.Sort();
            return ranges;
        }

        public override void Puzzel2()
        {
            List<(int start, int end)> correctrange = new List<(int start, int end)>();
            //findBlockedX(2000000);
            Stopwatch sw = Stopwatch.StartNew();
            for(int checkline = 0; checkline <= 4000000; checkline++)//aanpassen voor testdata
            {
                List<(int start, int end)> ranges = findBlockedX(checkline);
                ranges = boundRanges(ranges);
                ranges = removeOverlap(ranges);
                if (ranges.Count > 1)
                {
                    correctrange = ranges;
                    int x = ranges[0].end;
                    this.Writeresult2($"gap op y = {checkline}, x = {x}");
                }
            }
            sw.Stop();
            long time = sw.ElapsedMilliseconds;
            this.Writeresult2($"time elapsed = {time}");
            /*Parallel.For(0, 400001, checkline =>
            {
                List<(int start, int end)> ranges = findBlockedX(checkline);
                ranges = boundRanges(ranges);
                ranges = removeOverlap(ranges);
                if (ranges.Count > 1)
                {
                    correctrange = ranges;
                    this.Writeresult2($"gap op y = {checkline}");
                }
            });*/
            }

            public List<(int start, int end)> boundRanges(List<(int start, int end)> ranges)
        {
            List<(int start, int end)> bounded = new List<(int start, int end)>();
            foreach(var (start, end) in ranges)
            {
                if(end > 0)
                    if(start < 400000)
                    {
                        int newmin = Math.Max(start, 0);
                        int newmax = Math.Min(end, 400000);
                        bounded.Add((newmin, newmax));
                    }
            }
            return bounded;
        }
    }
}
