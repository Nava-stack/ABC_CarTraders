using ABC_CarTraders.AppClass;
using ABC_CarTraders.CommonClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ABC_CarTraders
{
    public partial class RegisterAsForm : Form
    {
        private Customer cm;

        public RegisterAsForm()
        {
            InitializeComponent();
            cm = new Customer(this);
        }

        

        private void extLbl_Click(object sender, EventArgs e)
        {
            com.exitConfirm();
        }

        private void regLogBtn1_Click(object sender, EventArgs e)
        {
            cm.goToLogin();
        }

        private void backBox_Click(object sender, EventArgs e)
        {
            cm.goToLogin();
        }
        private void regBtn_Click(object sender, EventArgs e)
        {
            cm.save();
        }




        private void regShowPass_CheckedChanged(object sender, EventArgs e)
        {
            regPassBox.PasswordChar = regShowPass.Checked ? '\0' : '*';
        }
    }
}
