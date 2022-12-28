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
            this.label1 = new System.Windows.Forms.Label();
            this.YearChanger = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PathField = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.PuzzleSelector = new System.Windows.Forms.ListBox();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Advent of Code";
            // 
            // YearChanger
            // 
            this.YearChanger.FormattingEnabled = true;
            this.YearChanger.Items.AddRange(new object[] {
            "2022",
            "2021"});
            this.YearChanger.Location = new System.Drawing.Point(24, 69);
            this.YearChanger.Name = "YearChanger";
            this.YearChanger.Size = new System.Drawing.Size(121, 23);
            this.YearChanger.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Input";
            // 
            // PathField
            // 
            this.PathField.AutoSize = true;
            this.PathField.Location = new System.Drawing.Point(24, 371);
            this.PathField.Name = "PathField";
            this.PathField.Size = new System.Drawing.Size(0, 15);
            this.PathField.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Go!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PuzzleSelector
            // 
            this.PuzzleSelector.FormattingEnabled = true;
            this.PuzzleSelector.ItemHeight = 15;
            this.PuzzleSelector.Location = new System.Drawing.Point(275, 42);
            this.PuzzleSelector.Name = "PuzzleSelector";
            this.PuzzleSelector.Size = new System.Drawing.Size(203, 379);
            this.PuzzleSelector.TabIndex = 7;
            // 
            // outputBox
            // 
            this.outputBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.outputBox.Location = new System.Drawing.Point(525, 42);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(240, 379);
            this.outputBox.TabIndex = 8;
            this.outputBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.PuzzleSelector);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PathField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.YearChanger);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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