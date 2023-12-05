namespace Advent_of_Code
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            YearChanger = new ComboBox();
            label4 = new Label();
            PathField = new Label();
            button1 = new Button();
            PuzzleSelector = new ListBox();
            outputBox = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(24, 20);
            label1.Name = "label1";
            label1.Size = new Size(202, 37);
            label1.TabIndex = 0;
            label1.Text = "Advent of Code";
            // 
            // YearChanger
            // 
            YearChanger.FormattingEnabled = true;
            YearChanger.Items.AddRange(new object[] { "2023", "2022", "2021" });
            YearChanger.Location = new Point(24, 69);
            YearChanger.Name = "YearChanger";
            YearChanger.Size = new Size(121, 23);
            YearChanger.TabIndex = 1;
            YearChanger.SelectedIndexChanged += YearChanger_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 347);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 4;
            label4.Text = "Input";
            // 
            // PathField
            // 
            PathField.AutoSize = true;
            PathField.Location = new Point(24, 371);
            PathField.Name = "PathField";
            PathField.Size = new Size(0, 15);
            PathField.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(57, 400);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Go!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PuzzleSelector
            // 
            PuzzleSelector.FormattingEnabled = true;
            PuzzleSelector.ItemHeight = 15;
            PuzzleSelector.Location = new Point(275, 42);
            PuzzleSelector.Name = "PuzzleSelector";
            PuzzleSelector.Size = new Size(203, 379);
            PuzzleSelector.TabIndex = 7;
            // 
            // outputBox
            // 
            outputBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            outputBox.Location = new Point(525, 42);
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(240, 379);
            outputBox.TabIndex = 8;
            outputBox.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(outputBox);
            Controls.Add(PuzzleSelector);
            Controls.Add(button1);
            Controls.Add(PathField);
            Controls.Add(label4);
            Controls.Add(YearChanger);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox YearChanger;
        private Label label4;
        private Label PathField;
        private Button button1;
        private ListBox PuzzleSelector;
        private RichTextBox outputBox;
    }
}