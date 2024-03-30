namespace ABC_CarTraders
{
    partial class customerSparePartForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(customerSparePartForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cusSearchWrntyPrdCombo = new System.Windows.Forms.ComboBox();
            this.cusSearchPartBtn = new System.Windows.Forms.Button();
            this.cusSearchPartCatCombo = new System.Windows.Forms.ComboBox();
            this.cusSearchPartCombo = new System.Windows.Forms.ComboBox();
            this.cusSearchPartIdCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cusPartOrdBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cusPartDetailGrid = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cusPartDetailGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.cusPartOrdBtn);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cusPartDetailGrid);
            this.panel2.Location = new System.Drawing.Point(9, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 610);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.cusSearchWrntyPrdCombo);
            this.panel1.Controls.Add(this.cusSearchPartBtn);
            this.panel1.Controls.Add(this.cusSearchPartCatCombo);
            this.panel1.Controls.Add(this.cusSearchPartCombo);
            this.panel1.Controls.Add(this.cusSearchPartIdCombo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(10, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 101);
            this.panel1.TabIndex = 0;
            // 
            // cusSearchWrntyPrdCombo
            // 
            this.cusSearchWrntyPrdCombo.Font = new System.Drawing.Font("Poppins", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cusSearchWrntyPrdCombo.FormattingEnabled = true;
            this.cusSearchWrntyPrdCombo.Location = new System.Drawing.Point(473, 44);
            this.cusSearchWrntyPrdCombo.Name = "cusSearchWrntyPrdCombo";
            this.cusSearchWrntyPrdCombo.Size = new System.Drawing.Size(171, 30);
            this.cusSearchWrntyPrdCombo.TabIndex = 66;
            this.cusSearchWrntyPrdCombo.Text = "--Select Warrenty period";
            // 
            // cusSearchPartBtn
            // 
            this.cusSearchPartBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(37)))));
            this.cusSearchPartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cusSearchPartBtn.FlatAppearance.BorderSize = 0;
            this.cusSearchPartBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(88)))), ((int)(((byte)(42)))));
            this.cusSearchPartBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(88)))), ((int)(((byte)(42)))));
            this.cusSearchPartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cusSearchPartBtn.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cusSearchPartBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cusSearchPartBtn.Image = ((System.Drawing.Image)(resources.GetObject("cusSearchPartBtn.Image")));
            this.cusSearchPartBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cusSearchPartBtn.Location = new System.Drawing.Point(674, 42);
            this.cusSearchPartBtn.Name = "cusSearchPartBtn";
            this.cusSearchPartBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.cusSearchPartBtn.Size = new System.Drawing.Size(128, 35);
            this.cusSearchPartBtn.TabIndex = 49;
            this.cusSearchPartBtn.Text = "          Search";
            this.cusSearchPartBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cusSearchPartBtn.UseVisualStyleBackColor = false;
            // 
            // cusSearchPartCatCombo
            // 
            this.cusSearchPartCatCombo.Font = new System.Drawing.Font("Poppins", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cusSearchPartCatCombo.FormattingEnabled = true;
            this.cusSearchPartCatCombo.Location = new System.Drawing.Point(309, 44);
            this.cusSearchPartCatCombo.Name = "cusSearchPartCatCombo";
            this.cusSearchPartCatCombo.Size = new System.Drawing.Size(158, 30);
            this.cusSearchPartCatCombo.TabIndex = 64;
            this.cusSearchPartCatCombo.Text = "--Select Part Category";
            // 
            // cusSearchPartCombo
            // 
            this.cusSearchPartCombo.Font = new System.Drawing.Font("Poppins", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cusSearchPartCombo.FormattingEnabled = true;
            this.cusSearchPartCombo.Location = new System.Drawing.Point(163, 44);
            this.cusSearchPartCombo.Name = "cusSearchPartCombo";
            this.cusSearchPartCombo.Size = new System.Drawing.Size(140, 30);
            this.cusSearchPartCombo.TabIndex = 62;
            this.cusSearchPartCombo.Text = "--Select Spare Part";
            // 
            // cusSearchPartIdCombo
            // 
            this.cusSearchPartIdCombo.Font = new System.Drawing.Font("Poppins", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cusSearchPartIdCombo.FormattingEnabled = true;
            this.cusSearchPartIdCombo.Location = new System.Drawing.Point(6, 44);
            this.cusSearchPartIdCombo.Name = "cusSearchPartIdCombo";
            this.cusSearchPartIdCombo.Size = new System.Drawing.Size(151, 30);
            this.cusSearchPartIdCombo.TabIndex = 61;
            this.cusSearchPartIdCombo.Text = "--Select Spare Part ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 26);
            this.label1.TabIndex = 18;
            this.label1.Text = "Search Parts By :";
            // 
            // cusPartOrdBtn
            // 
            this.cusPartOrdBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(37)))));
            this.cusPartOrdBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cusPartOrdBtn.FlatAppearance.BorderSize = 0;
            this.cusPartOrdBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(88)))), ((int)(((byte)(42)))));
            this.cusPartOrdBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(88)))), ((int)(((byte)(42)))));
            this.cusPartOrdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cusPartOrdBtn.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cusPartOrdBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cusPartOrdBtn.Image = ((System.Drawing.Image)(resources.GetObject("cusPartOrdBtn.Image")));
            this.cusPartOrdBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cusPartOrdBtn.Location = new System.Drawing.Point(615, 554);
            this.cusPartOrdBtn.Name = "cusPartOrdBtn";
            this.cusPartOrdBtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.cusPartOrdBtn.Size = new System.Drawing.Size(210, 46);
            this.cusPartOrdBtn.TabIndex = 50;
            this.cusPartOrdBtn.Text = "  Place Order";
            this.cusPartOrdBtn.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 31);
            this.label2.TabIndex = 19;
            this.label2.Text = "All Available Spare Parts";
            // 
            // cusPartDetailGrid
            // 
            this.cusPartDetailGrid.AllowUserToAddRows = false;
            this.cusPartDetailGrid.AllowUserToDeleteRows = false;
            this.cusPartDetailGrid.AllowUserToOrderColumns = true;
            this.cusPartDetailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cusPartDetailGrid.Location = new System.Drawing.Point(10, 158);
            this.cusPartDetailGrid.Name = "cusPartDetailGrid";
            this.cusPartDetailGrid.ReadOnly = true;
            this.cusPartDetailGrid.Size = new System.Drawing.Size(815, 390);
            this.cusPartDetailGrid.TabIndex = 19;
            // 
            // customerSparePartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "customerSparePartForm";
            this.Size = new System.Drawing.Size(859, 628);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cusPartDetailGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cusSearchWrntyPrdCombo;
        private System.Windows.Forms.Button cusSearchPartBtn;
        private System.Windows.Forms.ComboBox cusSearchPartCatCombo;
        private System.Windows.Forms.ComboBox cusSearchPartCombo;
        private System.Windows.Forms.ComboBox cusSearchPartIdCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cusPartOrdBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView cusPartDetailGrid;
    }
}
