using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_CarTraders.AppClass
{
    internal class customerDashClass
    {
        public customerDashClass() { }
        public static void exitForm()
        {
            if ((MessageBox.Show("Are you sure want to Exit?", "ABC Car Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Error)) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
