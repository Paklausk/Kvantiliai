namespace Viewer
{
    partial class MainWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.companiesListBox = new System.Windows.Forms.ListBox();
            this.companyInfoBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m75Salaryv2Label = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.avg75SalaryLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m75SalaryLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.medianSalaryLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m25SalaryLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.avgSalaryLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.employeesLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.companiesLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.minAvgSalaryBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.itCheckBox = new System.Windows.Forms.CheckBox();
            this.minEmployeesBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cityBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter text";
            // 
            // filterTextBox
            // 
            this.filterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterTextBox.Location = new System.Drawing.Point(12, 22);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(183, 20);
            this.filterTextBox.TabIndex = 2;
            this.filterTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // companiesListBox
            // 
            this.companiesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.companiesListBox.FormattingEnabled = true;
            this.companiesListBox.IntegralHeight = false;
            this.companiesListBox.Location = new System.Drawing.Point(12, 48);
            this.companiesListBox.Name = "companiesListBox";
            this.companiesListBox.Size = new System.Drawing.Size(362, 219);
            this.companiesListBox.TabIndex = 3;
            this.companiesListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // companyInfoBox
            // 
            this.companyInfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.companyInfoBox.Location = new System.Drawing.Point(12, 3);
            this.companyInfoBox.Multiline = true;
            this.companyInfoBox.Name = "companyInfoBox";
            this.companyInfoBox.ReadOnly = true;
            this.companyInfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.companyInfoBox.Size = new System.Drawing.Size(504, 267);
            this.companyInfoBox.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m75Salaryv2Label);
            this.splitContainer1.Panel1.Controls.Add(this.label18);
            this.splitContainer1.Panel1.Controls.Add(this.avg75SalaryLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.m75SalaryLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.medianSalaryLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.m25SalaryLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.avgSalaryLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.employeesLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.companiesLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.minAvgSalaryBox);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.itCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.minEmployeesBox);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.cityBox);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.filterTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.companiesListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.companyInfoBox);
            this.splitContainer1.Size = new System.Drawing.Size(528, 556);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 5;
            // 
            // m75Salaryv2Label
            // 
            this.m75Salaryv2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m75Salaryv2Label.AutoSize = true;
            this.m75Salaryv2Label.Location = new System.Drawing.Point(465, 139);
            this.m75Salaryv2Label.Name = "m75Salaryv2Label";
            this.m75Salaryv2Label.Size = new System.Drawing.Size(13, 13);
            this.m75Salaryv2Label.TabIndex = 28;
            this.m75Salaryv2Label.Text = "0";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(380, 139);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 13);
            this.label18.TabIndex = 27;
            this.label18.Text = "M.v2 75% salary:";
            // 
            // avg75SalaryLabel
            // 
            this.avg75SalaryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.avg75SalaryLabel.AutoSize = true;
            this.avg75SalaryLabel.Location = new System.Drawing.Point(465, 126);
            this.avg75SalaryLabel.Name = "avg75SalaryLabel";
            this.avg75SalaryLabel.Size = new System.Drawing.Size(13, 13);
            this.avg75SalaryLabel.TabIndex = 26;
            this.avg75SalaryLabel.Text = "0";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(380, 126);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Avg. 75% salary:";
            // 
            // m75SalaryLabel
            // 
            this.m75SalaryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m75SalaryLabel.AutoSize = true;
            this.m75SalaryLabel.Location = new System.Drawing.Point(465, 113);
            this.m75SalaryLabel.Name = "m75SalaryLabel";
            this.m75SalaryLabel.Size = new System.Drawing.Size(13, 13);
            this.m75SalaryLabel.TabIndex = 24;
            this.m75SalaryLabel.Text = "0";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(380, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "M. 75% salary:";
            // 
            // medianSalaryLabel
            // 
            this.medianSalaryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.medianSalaryLabel.AutoSize = true;
            this.medianSalaryLabel.Location = new System.Drawing.Point(465, 100);
            this.medianSalaryLabel.Name = "medianSalaryLabel";
            this.medianSalaryLabel.Size = new System.Drawing.Size(13, 13);
            this.medianSalaryLabel.TabIndex = 22;
            this.medianSalaryLabel.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(380, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Median salary:";
            // 
            // m25SalaryLabel
            // 
            this.m25SalaryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m25SalaryLabel.AutoSize = true;
            this.m25SalaryLabel.Location = new System.Drawing.Point(465, 87);
            this.m25SalaryLabel.Name = "m25SalaryLabel";
            this.m25SalaryLabel.Size = new System.Drawing.Size(13, 13);
            this.m25SalaryLabel.TabIndex = 20;
            this.m25SalaryLabel.Text = "0";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(380, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "M. 25% salary:";
            // 
            // avgSalaryLabel
            // 
            this.avgSalaryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.avgSalaryLabel.AutoSize = true;
            this.avgSalaryLabel.Location = new System.Drawing.Point(465, 74);
            this.avgSalaryLabel.Name = "avgSalaryLabel";
            this.avgSalaryLabel.Size = new System.Drawing.Size(13, 13);
            this.avgSalaryLabel.TabIndex = 18;
            this.avgSalaryLabel.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(380, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Avg. salary:";
            // 
            // employeesLabel
            // 
            this.employeesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.employeesLabel.AutoSize = true;
            this.employeesLabel.Location = new System.Drawing.Point(465, 61);
            this.employeesLabel.Name = "employeesLabel";
            this.employeesLabel.Size = new System.Drawing.Size(13, 13);
            this.employeesLabel.TabIndex = 16;
            this.employeesLabel.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(380, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Employees:";
            // 
            // companiesLabel
            // 
            this.companiesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.companiesLabel.AutoSize = true;
            this.companiesLabel.Location = new System.Drawing.Point(465, 48);
            this.companiesLabel.Name = "companiesLabel";
            this.companiesLabel.Size = new System.Drawing.Size(13, 13);
            this.companiesLabel.TabIndex = 14;
            this.companiesLabel.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(380, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Companies:";
            // 
            // minAvgSalaryBox
            // 
            this.minAvgSalaryBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minAvgSalaryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minAvgSalaryBox.FormattingEnabled = true;
            this.minAvgSalaryBox.Items.AddRange(new object[] {
            "0",
            "500",
            "700",
            "800",
            "900",
            "1000",
            "1200",
            "1500",
            "1800",
            "2000",
            "2200",
            "2500",
            "2800",
            "3000"});
            this.minAvgSalaryBox.Location = new System.Drawing.Point(429, 22);
            this.minAvgSalaryBox.Name = "minAvgSalaryBox";
            this.minAvgSalaryBox.Size = new System.Drawing.Size(87, 21);
            this.minAvgSalaryBox.TabIndex = 12;
            this.minAvgSalaryBox.SelectedIndexChanged += new System.EventHandler(this.minAvgSalaryBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Min. avg. salary";
            // 
            // itCheckBox
            // 
            this.itCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.itCheckBox.AutoSize = true;
            this.itCheckBox.Location = new System.Drawing.Point(201, 24);
            this.itCheckBox.Name = "itCheckBox";
            this.itCheckBox.Size = new System.Drawing.Size(36, 17);
            this.itCheckBox.TabIndex = 10;
            this.itCheckBox.Text = "IT";
            this.itCheckBox.UseVisualStyleBackColor = true;
            this.itCheckBox.CheckedChanged += new System.EventHandler(this.itCheckBox_CheckedChanged);
            // 
            // minEmployeesBox
            // 
            this.minEmployeesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minEmployeesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minEmployeesBox.FormattingEnabled = true;
            this.minEmployeesBox.Items.AddRange(new object[] {
            "0",
            "3",
            "5",
            "10",
            "15",
            "20",
            "25",
            "50",
            "100",
            "200",
            "300",
            "500",
            "1000"});
            this.minEmployeesBox.Location = new System.Drawing.Point(336, 22);
            this.minEmployeesBox.Name = "minEmployeesBox";
            this.minEmployeesBox.Size = new System.Drawing.Size(87, 21);
            this.minEmployeesBox.TabIndex = 8;
            this.minEmployeesBox.SelectedIndexChanged += new System.EventHandler(this.minEmployeesBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Min. employees";
            // 
            // cityBox
            // 
            this.cityBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityBox.FormattingEnabled = true;
            this.cityBox.Items.AddRange(new object[] {
            "",
            "Vilniaus m",
            "Kauno m",
            "Rest..."});
            this.cityBox.Location = new System.Drawing.Point(243, 22);
            this.cityBox.Name = "cityBox";
            this.cityBox.Size = new System.Drawing.Size(87, 21);
            this.cityBox.TabIndex = 6;
            this.cityBox.SelectedIndexChanged += new System.EventHandler(this.cityBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "City";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 556);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kvantiliai.Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.ListBox companiesListBox;
        private System.Windows.Forms.TextBox companyInfoBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cityBox;
        private System.Windows.Forms.ComboBox minEmployeesBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox itCheckBox;
        private System.Windows.Forms.ComboBox minAvgSalaryBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label companiesLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label employeesLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label avgSalaryLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label m25SalaryLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label m75SalaryLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label medianSalaryLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label avg75SalaryLabel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label m75Salaryv2Label;
        private System.Windows.Forms.Label label18;
    }
}

