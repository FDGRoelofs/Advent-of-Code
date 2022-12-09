using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag09 : Dag
    {
        public Dag09(string s) : base(s)
        {

        }
        
        private Vector2 head;
        private Vector2 tail;
        private Queue<char> movements;
        Dictionary<Vector2,int> tailHis = new Dictionary<Vector2,int>();
        Dictionary<Vector2, int> longtailHis = new Dictionary<Vector2, int>();
        public override void Puzzel1()
        {
            parseInstructions();
            Queue<char> p1moves = new Queue<char>(movements);
            tailHis.Add(tail, 1);
            while (p1moves.Count > 0)
            {
                headMove(p1moves);
                tail = tailMove(head,tail);
                if (tailHis.ContainsKey(tail))
                    tailHis[tail]++;
                else
                    tailHis.Add(tail, 1);
            }
            this.result1 = tailHis.Count.ToString();

        }

        public override void Puzzel2()
        {
            Queue<char> p2moves = new Queue<char>(movements);
            head = new Vector2(0,0);
            Vector2[] longtail = new Vector2[9];
            while(p2moves.Count > 0)
            {
                headMove(p2moves);
                longtail[0] = tailMove(head, longtail[0]);
                longtail[1] = tailMove(longtail[0], longtail[1]);
                longtail[2] = tailMove(longtail[1], longtail[2]);
                longtail[3] = tailMove(longtail[2], longtail[3]);
                longtail[4] = tailMove(longtail[3], longtail[4]);
                longtail[5] = tailMove(longtail[4], longtail[5]);
                longtail[6] = tailMove(longtail[5], longtail[6]);
                longtail[7] = tailMove(longtail[6], longtail[7]);
                longtail[8] = tailMove(longtail[7], longtail[8]);
                if (longtailHis.ContainsKey(longtail[8]))
                    longtailHis[longtail[8]]++;
                else
                    longtailHis.Add(longtail[8], 1);
            }
            this.result2 = longtailHis.Count.ToString();

        }

        public void parseInstructions()
        {
            movements = new Queue<char>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] current = lines[i].Split(' ');
                int count = int.Parse(current[1]);
                for(int c = 0; c < count; c++)
                {
                    movements.Enqueue(current[0][0]);
                }
            }
        }

        public void headMove(Queue<char> moves)
        {
            char d = moves.Dequeue();
            switch(d)
            {
                case 'D':
                    head.Y -= 1;
                    break;
                case 'U':
                    head.Y += 1;
                    break;
                case 'L':
                    head.X -= 1;
                    break;
                case 'R':
                    head.X += 1;
                    break;
            }
        }

        public Vector2 tailMove(Vector2 leader, Vector2 follower)
        {
            Vector2 distance = leader - follower;
            if(distance.LengthSquared() > 2)
            {
                Vector2 step = Vector2.Normalize(distance);
                if (step.X < 0)
                    step.X = -1;
                else if (step.X > 0)
                    step.X = 1;
                if(step.Y < 0)
                    step.Y = -1;
                else if(step.Y > 0)
                    step.Y = 1;
                //step.X = (float)Math.Round(step.X,0,MidpointRounding.AwayFromZero);
                //step.Y = (float)Math.Round(step.Y, 0, MidpointRounding.AwayFromZero);
                return follower + step;
            }
            return follower;
        }

    }
}
