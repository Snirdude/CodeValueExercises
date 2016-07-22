namespace PrimesCalculator
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxMinRange = new System.Windows.Forms.TextBox();
            this.textBoxMaxRange = new System.Windows.Forms.TextBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxPrimeNumbers = new System.Windows.Forms.ListBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxMinRange
            // 
            this.textBoxMinRange.Location = new System.Drawing.Point(80, 3);
            this.textBoxMinRange.Name = "textBoxMinRange";
            this.textBoxMinRange.Size = new System.Drawing.Size(72, 20);
            this.textBoxMinRange.TabIndex = 0;
            this.textBoxMinRange.TextChanged += new System.EventHandler(this.textBoxMinRange_TextChanged);
            // 
            // textBoxMaxRange
            // 
            this.textBoxMaxRange.Location = new System.Drawing.Point(80, 27);
            this.textBoxMaxRange.Name = "textBoxMaxRange";
            this.textBoxMaxRange.Size = new System.Drawing.Size(72, 20);
            this.textBoxMaxRange.TabIndex = 1;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(158, 3);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(114, 20);
            this.buttonCalculate.TabIndex = 2;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Min Range:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max Range:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // listBoxPrimeNumbers
            // 
            this.listBoxPrimeNumbers.FormattingEnabled = true;
            this.listBoxPrimeNumbers.Location = new System.Drawing.Point(12, 63);
            this.listBoxPrimeNumbers.Name = "listBoxPrimeNumbers";
            this.listBoxPrimeNumbers.Size = new System.Drawing.Size(140, 186);
            this.listBoxPrimeNumbers.TabIndex = 5;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(158, 27);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(114, 20);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.listBoxPrimeNumbers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.textBoxMaxRange);
            this.Controls.Add(this.textBoxMinRange);
            this.Name = "Form";
            this.Text = "Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMinRange;
        private System.Windows.Forms.TextBox textBoxMaxRange;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxPrimeNumbers;
        private System.Windows.Forms.Button buttonCancel;
    }
}

