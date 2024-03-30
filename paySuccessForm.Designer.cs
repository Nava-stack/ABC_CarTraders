namespace ABC_CarTraders
{
    partial class paySuccessForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.paymentSucOkBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(83, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 36);
            this.label1.TabIndex = 71;
            this.label1.Text = "Payment Added Successfully";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(168, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 119);
            this.pictureBox1.TabIndex = 72;
            this.pictureBox1.TabStop = false;
            // 
            // paymentSucOkBtn
            // 
            this.paymentSucOkBtn.BackColor = System.Drawing.Color.Black;
            this.paymentSucOkBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.paymentSucOkBtn.FlatAppearance.BorderSize = 0;
            this.paymentSucOkBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.paymentSucOkBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.paymentSucOkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paymentSucOkBtn.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentSucOkBtn.ForeColor = System.Drawing.Color.White;
            this.paymentSucOkBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentSucOkBtn.Location = new System.Drawing.Point(200, 211);
            this.paymentSucOkBtn.Name = "paymentSucOkBtn";
            this.paymentSucOkBtn.Size = new System.Drawing.Size(59, 30);
            this.paymentSucOkBtn.TabIndex = 94;
            this.paymentSucOkBtn.Text = "Ok";
            this.paymentSucOkBtn.UseVisualStyleBackColor = false;
            // 
            // paySuccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(474, 253);
            this.Controls.Add(this.paymentSucOkBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "paySuccessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "paySuccessForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button paymentSucOkBtn;
    }
}