using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag2306 : Dag
    {
        public Dag2306(string s) : base(s)
        {

        }
        public string[] debugstring = new string[10];
        public override void Puzzel1()
        {
            
            
        }
        new Dictionary<int,bool> results = new Dictionary<int, bool>();
        public int countWins(int recordTime, int recordDistance)
        {
            int middle = recordTime / 2;
            int pivot = middle;
            int lowestwin = -1;
            int hbl;
            int highestwin = -1;
            int ltl;
            if(winRace(pivot, recordDistance, recordTime))
            {
                lowestwin = pivot;
                highestwin = pivot;
            }
            else
            {
                hbl = pivot;
                ltl = pivot;
            }
            bool bottomfound = false;
            int hbl;
            while(!bottomfound)
            {
                if(lowestwin > 0)
                    pivot = pivot / 2;
                else
                    pivot = 
                    
            }
                
            return 0;
        }

        public int calculateSpeed(int holdTime)
        {
            int speed = 0;
            int growth = 1;
            while(holdTime > 0)
            {
                speed += growth;
                growth++;
                holdTime--;
            }
            return speed;
        }

        public bool winRace(int holdTime, int goalDistance, int goalTime)
        {
            int runningTime = goalTime - holdTime;
            int distance = runningTime * calculateSpeed(holdTime);
            results.Add(runningTime, distance > goalDistance);
            return (distance > goalDistance);
        }

        public override void Puzzel2()
        {
            
        }
    }
}
