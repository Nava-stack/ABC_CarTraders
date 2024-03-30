using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_CarTraders
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 4;
            if (panel2.Width >= 800)
            {
                timer1.Stop();
                LoginAsForm lgform = new LoginAsForm();
                lgform.Show();
                this.Hide();
            }
        }
    }
}
