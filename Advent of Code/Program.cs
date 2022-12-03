namespace Advent_of_Code
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    public abstract class Dag
    {
        private string path;
        public string[] lines
        {
            get;
            set;
        }
        public string result1
        {
            get;
            set;
        }
        public string result2
        {
            get;
            set;
        }
        public Dag(string input)
        {
            this.path = input;
            string rawinput = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8);
            this.lines = rawinput.Split('\n');
            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].Trim('\r');
            Puzzel1();
            Puzzel2();
        }
        public Dag(string input, bool runPuzzel)
        {
            this.path = input;
            string rawinput = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8);
            this.lines = rawinput.Split('\n');
            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].Trim('\r');
            if (runPuzzel)
            {
                Puzzel1();
                Puzzel2();
            }
        }

        public abstract void Puzzel1();
        public abstract void Puzzel2();
    }
}