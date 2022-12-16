namespace Advent_of_Code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            YearChanger.SelectedIndex = 0;
            fillPuzzleSelector();
        }

        public void fillPuzzleSelector()
        {
            string year = YearChanger.SelectedItem.ToString();
            PuzzleSelector.Items.Clear();
            if (year == "2022")
            {
                PuzzleSelector.Items.Add("Dag 1");
                PuzzleSelector.Items.Add("Dag 2");
                PuzzleSelector.Items.Add("Dag 3");
                PuzzleSelector.Items.Add("Dag 4");
                PuzzleSelector.Items.Add("Dag 5");
                PuzzleSelector.Items.Add("Dag 6");
                PuzzleSelector.Items.Add("Dag 7");
                PuzzleSelector.Items.Add("Dag 8");
                PuzzleSelector.Items.Add("Dag 9");
                PuzzleSelector.Items.Add("Dag 10");
                PuzzleSelector.Items.Add("Dag 11");
                PuzzleSelector.Items.Add("Dag 12");
                PuzzleSelector.Items.Add("Dag 15");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PuzzleSelector.SelectedIndex == -1)
                MessageBox.Show("Kies een puzzel om op te lossen.");
            else
                berekenDag();
        }

        public void berekenDag()
        {
            //Hier code toevoegen om te wisselen tussen jaren wanneer nodig
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int bindex = path.IndexOf("bin");
            path = path.Substring(0, bindex);
            path += @"input\";
            path += YearChanger.GetItemText(YearChanger.SelectedItem) + @"\";
            string output = "";
            switch (PuzzleSelector.GetItemText(PuzzleSelector.SelectedItem))
            {
                case "Dag 1":
                    path += "01.in";
                    Dag dag1 = new Dag01(path);
                    output += dag1.result1;
                    output += System.Environment.NewLine;
                    output += dag1.result2;
                    break;
                case "Dag 2":
                    path += "02.in";
                    Dag dag2 = new Dag02(path);
                    output += dag2.result1;
                    output += System.Environment.NewLine;
                    output += dag2.result2;
                    break;
                case "Dag 3":
                    path += "03.in";
                    Dag dag3 = new Dag03(path);
                    output += dag3.result1;
                    output += System.Environment.NewLine;
                    output += dag3.result2;
                    break;
                case "Dag 4":
                    path += "04.in";
                    Dag dag4 = new Dag04(path);
                    output += dag4.result1;
                    output += System.Environment.NewLine;
                    output += dag4.result2;
                    break;
                case "Dag 5":
                    path += "05.in";
                    Dag dag5 = new Dag05(path);
                    output += dag5.result1;
                    output += System.Environment.NewLine;
                    output += dag5.result2;
                    break;
                case "Dag 6":
                    path += "06.in";
                    Dag dag6 = new Dag06(path);
                    output += dag6.result1;
                    output += System.Environment.NewLine;
                    output += dag6.result2;
                    break;
                case "Dag 7":
                    path += "07.in";
                    Dag dag7 = new Dag07(path);
                    output += dag7.result1;
                    output += System.Environment.NewLine;
                    output += dag7.result2;
                    break;
                case "Dag 8":
                    path += "08.in";
                    Dag08 dag8 = new Dag08(path);
                    output += dag8.result1;
                    output += System.Environment.NewLine;
                    output+= dag8.result2;
                    output += System.Environment.NewLine;
                    output += dag8.debugstring[1];
                    output += System.Environment.NewLine;
                    output += dag8.debugstring[2];
                    break;
                case "Dag 9":
                    path += "09.in";
                    Dag dag9 = new Dag09(path);
                    output += dag9.result1;
                    output += System.Environment.NewLine;
                    output += dag9.result2;
                    break;
                case "Dag 10":
                    path += "10.in";
                    Dag dag10= new Dag10(path);
                    output += dag10.result1;
                    output += System.Environment.NewLine;
                    output += dag10.result2;
                    break;
                case "Dag 11":
                    path += "11.in";
                    Dag dag11 = new Dag11(path);
                    output += dag11.result1;
                    output += System.Environment.NewLine;
                    output += dag11.result2;
                    break;
                case "Dag 12":
                    path += "12.in";
                    Dag dag12 = new Dag12(path, false);
                    output += dag12.result1;
                    output += System.Environment.NewLine;
                    output += dag12.result2;
                    break;
                case "Dag 15":
                    path += "15test.in";
                    Dag dag15 = new Dag15(path);
                    output += dag15.result1;
                    break;

            }
            outputBox.Text = output;
            string[] file = path.Split('\\');
            PathField.Text = file[file.Length - 1];
            

        }
    }
}