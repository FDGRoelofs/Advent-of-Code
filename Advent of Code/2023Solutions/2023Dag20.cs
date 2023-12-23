using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag2320 : Dag
    {
        public Dag2320(string s) : base(s)
        {

        }
        public string[] debugstring = new string[10];
        public override void Puzzel1()
        {
            
        }


        public override void Puzzel2()
        {
            
        }
    }

    public abstract class Module
    {
        public Module()
        {

        }
        public char type
        {
            get;
            set;
        }
        public List<bool> incoming
        {
            get;
            set;
        }

        public abstract void handleIncoming();
        public List<Module> recipients;
        public int rhigh
        {
            get;
            set;
        }
        public int rlow
        {
            get;
            set;
        }
    }

    public class Ff : Module
    {
        public Ff(char type) : base()
        {
            this.type = type;
            this.incoming = new List<bool>();
            this.recipients = new List<Module>();
            this.rhigh = 0;
            this.rlow = 0;
            this.on = false;
        }

        private bool on;

        public override void handleIncoming()
        {

        }
    }

}
