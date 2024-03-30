namespace ABC_CarTraders
{
    partial class ReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.extLbl = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.genOrdRepBtn = new System.Windows.Forms.Button();
            this.carDetailGrid = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.adOrdShareRptBtn = new System.Windows.Forms.Button();
            this.adOrdRepPrintBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carDetailGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.adOrdShareRptBtn);
            this.panel1.Controls.Add(this.adOrdRepPrintBtn);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.extLbl);
            this.panel1.Controls.Add(this.genOrdRepBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.carDetailGrid);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 584);
            this.panel1.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Poppins SemiBold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(7, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(336, 48);
            this.label8.TabIndex = 68;
            this.label8.Text = "Order Summary Report";
            // 
            // extLbl
            // 
            this.extLbl.AutoSize = true;
            this.extLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.extLbl.Font = new System.Drawing.Font("Poppins ExtraBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extLbl.Location = new System.Drawing.Point(807, -1);
            this.extLbl.Name = "extLbl";
            this.extLbl.Size = new System.Drawing.Size(30, 36);
            this.extLbl.TabIndex = 109;
            this.extLbl.Text = "X";
            this.extLbl.Click += new System.EventHandler(this.extLbl_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(303, 75);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(198, 20);
            this.dateTimePicker2.TabIndex = 91;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 22);
            this.label7.TabIndex = 92;
            this.label7.Text = "Range :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 22);
            this.label4.TabIndex = 93;
            this.label4.Text = "-";
            // 
            // genOrdRepBtn
            // 
            this.genOrdRepBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(37)))));
            this.genOrdRepBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.genOrdRepBtn.FlatAppearance.BorderSize = 0;
            this.genOrdRepBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(88)))), ((int)(((byte)(42)))));
            this.genOrdRepBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(88)))), ((int)(((byte)(42)))));
            this.genOrdRepBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.genOrdRepBtn.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genOrdRepBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.genOrdRepBtn.Location = new System.Drawing.Point(538, 66);
            this.genOrdRepBtn.Name = "genOrdRepBtn";
            this.genOrdRepBtn.Size = new System.Drawing.Size(98, 35);
            this.genOrdRepBtn.TabIndex = 106;
            this.genOrdRepBtn.Text = "Generate";
            this.genOrdRepBtn.UseVisualStyleBackColor = false;
            this.genOrdRepBtn.Click += new System.EventHandler(this.genOrdRepBtn_Click);
            // 
            // carDetailGrid
            // 
            this.carDetailGrid.AllowUserToAddRows = false;
            this.carDetailGrid.AllowUserToDeleteRows = false;
            this.carDetailGrid.AllowUserToResizeColumns = false;
            this.carDetailGrid.AllowUserToResizeRows = false;
            this.carDetailGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.carDetailGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.carDetailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carDetailGrid.EnableHeadersVisualStyles = false;
            this.carDetailGrid.Location = new System.Drawing.Point(10, 123);
            this.carDetailGrid.Name = "carDetailGrid";
            this.carDetailGrid.ReadOnly = true;
            this.carDetailGrid.RowHeadersVisible = false;
            this.carDetailGrid.Size = new System.Drawing.Size(818, 381);
            this.carDetailGrid.TabIndex = 87;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(68, 75);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(198, 20);
            this.dateTimePicker1.TabIndex = 110;
            // 
            // adOrdShareRptBtn
            // 
            this.adOrdShareRptBtn.BackColor = System.Drawing.Color.Black;
            this.adOrdShareRptBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adOrdShareRptBtn.FlatAppearance.BorderSize = 0;
            this.adOrdShareRptBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.adOrdShareRptBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.adOrdShareRptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adOrdShareRptBtn.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adOrdShareRptBtn.ForeColor = System.Drawing.Color.White;
            this.adOrdShareRptBtn.Image = ((System.Drawing.Image)(resources.GetObject("adOrdShareRptBtn.Image")));
            this.adOrdShareRptBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.adOrdShareRptBtn.Location = new System.Drawing.Point(488, 527);
            this.adOrdShareRptBtn.Name = "adOrdShareRptBtn";
            this.adOrdShareRptBtn.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.adOrdShareRptBtn.Size = new System.Drawing.Size(148, 40);
            this.adOrdShareRptBtn.TabIndex = 112;
            this.adOrdShareRptBtn.Text = "Share";
            this.adOrdShareRptBtn.UseVisualStyleBackColor = false;
            // 
            // adOrdRepPrintBtn
            // 
            this.adOrdRepPrintBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(37)))));
            this.adOrdRepPrintBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adOrdRepPrintBtn.FlatAppearance.BorderSize = 0;
            this.adOrdRepPrintBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(88)))), ((int)(((byte)(42)))));
            this.adOrdRepPrintBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(88)))), ((int)(((byte)(42)))));
            this.adOrdRepPrintBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adOrdRepPrintBtn.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adOrdRepPrintBtn.ForeColor = System.Drawing.Color.White;
            this.adOrdRepPrintBtn.Image = ((System.Drawing.Image)(resources.GetObject("adOrdRepPrintBtn.Image")));
            this.adOrdRepPrintBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.adOrdRepPrintBtn.Location = new System.Drawing.Point(680, 527);
            this.adOrdRepPrintBtn.Name = "adOrdRepPrintBtn";
            this.adOrdRepPrintBtn.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.adOrdRepPrintBtn.Size = new System.Drawing.Size(148, 40);
            this.adOrdRepPrintBtn.TabIndex = 111;
            this.adOrdRepPrintBtn.Text = "Print";
            this.adOrdRepPrintBtn.UseVisualStyleBackColor = false;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 604);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carDetailGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label extLbl;
        private System.Windows.Forms.Button genOrdRepBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        internal System.Windows.Forms.DataGridView carDetailGrid;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button adOrdShareRptBtn;
        private System.Windows.Forms.Button adOrdRepPrintBtn;
    }
}