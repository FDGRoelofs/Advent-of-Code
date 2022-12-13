using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag13 : Dag
    {
        public Dag13(string s) : base(s)
        {

        }
        public override void Puzzel1()
        {
            //signalPair test = new signalPair(lines[0], lines[1]);
            List<signalPair> transmission = new List<signalPair>();
            for(int i = 0; i < lines.Length; i++)
            {
                transmission.Add(new signalPair(lines[i], lines[i+1]));
                i += 2;
            }
            int sumIndices = 0;
            for(int i = 0;i < transmission.Count; i++)
            {
                if (transmission[i].correctorder)
                    sumIndices += i - 1;
            }
            this.result1 = sumIndices.ToString();
        }


        public override void Puzzel2()
        {
            
        }
    }

    public class signalPair
    {
        string left;
        string right;
        int leftindex = -1;
        int rightindex = -1;
        int leftlistdepth = 0;
        int rightlistdepth = 0;
        //int nextleft = -1;
        //int nextright = -1;
        public bool correctorder
        {
            get; set;
        }
        public signalPair(string left, string right)
        {
            this.left = left;
            this.right = right;
            correctorder = true;
            nextIndexes();
            if(left[leftindex] == right[rightindex] && leftindex != 0)
            {
                while(correctorder && leftlistdepth > 0)
                {
                    
                    nextIndexes();
                    if (rightlistdepth == 0)
                    {
                        correctorder = false;
                        break;
                    }
                    if (leftlistdepth == 0)
                        break;
                    if (left[leftindex] > right[rightindex])
                        correctorder = false;
                    else if (left[leftindex] < right[rightindex])
                        break;
                    else if(left[leftindex] == right[rightindex])
                    {
                        if (leftlistdepth > rightlistdepth)
                        {
                            nextLeft();
                        }
                        else if (leftlistdepth < rightlistdepth)
                        {
                            nextRight();
                        }
                        //nextIndexes();
                    }
                }
            }
            else if(rightindex == 0 && leftindex == 0 && left.Length > right.Length)
                correctorder = false;
            //else if(rightindex == 0)
            //    correctorder = false;
            else if(left[leftindex] > right[rightindex] && leftindex != 0)
                correctorder = false;
        }

        private void nextIndexes()
        {
            /*if (leftindex != 0) // als je dit terug zet, zet start indexen op 0
                leftindex++;
            if(rightindex != 0)
                rightindex++;*/
            leftindex++;
            rightindex++;
            for(int i = leftindex; i < left.Length; i++)
            {
                char c = left[i];
                if(Char.IsDigit(c))
                {
                    leftindex = i;
                    break;
                }
                else if(c == '[')
                    leftlistdepth++;
                else if(c == ']')
                    leftlistdepth--;
            }
            for(int i = rightindex;i < right.Length;i++)
            {
                char c = right[i];
                if (Char.IsDigit(c))
                {
                    rightindex = i;
                    break;
                }
                else if (c == '[')
                    rightlistdepth++;
                else if (c == ']')
                    rightlistdepth--;
            }

            //kan hier nog op een lege lijst checkn om wat dingen te versimpelen misschien
        }

        private void nextLeft()
        {
            while(leftlistdepth > rightlistdepth)
            {
                leftindex++;
                char c = left[leftindex];
                if (c == '[')
                    leftlistdepth++;
                else if (c == ']')
                    leftlistdepth--;
            }
            bool isNumber = false;
            while(!isNumber)
            {
                leftindex--;
                char c = left[leftindex];
                isNumber = Char.IsDigit(c);
            }
        }

        private void nextRight()
        {
            while (leftlistdepth < rightlistdepth)
            {
                rightindex++;
                char c = right[rightindex];
                if (c == '[')
                    rightlistdepth++;
                else if (c == ']')
                    rightlistdepth--;
            }
            bool isNumber = false;
            while (!isNumber)
            {
                rightindex--;
                char c = right[rightindex];
                isNumber = Char.IsDigit(c);
            }
        }

    }
}
