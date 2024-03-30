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
    public partial class ReportForm : Form
    {
        private ReportClass rc;
        public ReportForm()
        {
            InitializeComponent();
            rc = new ReportClass(this);
        }

        private void extLbl_Click(object sender, EventArgs e)
        {
            AdminDashboardForm form = new AdminDashboardForm();
            form.Show();
            this.Hide();
            
        }

        private void genOrdRepBtn_Click(object sender, EventArgs e)
        {

        }

        private void genCarStkRptBtn_Click(object sender, EventArgs e)
        {

        }

        private void genPartStkRptBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
