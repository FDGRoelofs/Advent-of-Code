using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag06 : Dag
    {
        public Dag06(string s) : base(s)
        {

        }
        public override void Puzzel1()
        {
            string code = lines[0];//zet op 0 voor echte input
            int index = 0;
            int key = isKey(code.Substring(index, 4));
            while(key > 0)
            {
                index += key;
                string nextsubstring = code[index..(index+4)];
                key = isKey(nextsubstring);
            }
            this.result1 = (index + 4).ToString();

        }

        public override void Puzzel2()
        {
            string code = lines[0];//zet op 0 voor echte input
            int index = 0;
            int message = isMessage(code[index..(index + 14)]);
            while (message > 0)
            {
                index += message;
                string nextsubstring = code[index..(index+14)];
                message = isMessage(nextsubstring);
            }
            this.result2 = (index + 14).ToString();
        }

        public int isKey(string s)
        {
            if (s[3] == s[2])
                return 3;
            if (s[3] == s[1])
                return 2;
            if (s[3] == s[0])
                return 1;
            if (s[2] == s[1])
                return 2;
            if (s[2] == s[0])
                return 1;
            if (s[1] == s[0])
                return 1;
            return -1;
        }

        public int isMessage(string s)
        {
            char[] distinct = s.Distinct().ToArray();
            int unique = distinct.Length;
            return 14 - unique;
        }
    }
}
