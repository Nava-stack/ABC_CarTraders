using ABC_CarTraders.AppClass;
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
    public partial class adminDashForm : UserControl
    {
        private adminDashClass ad;
        public adminDashForm()
        {
            InitializeComponent();
            ad = new adminDashClass(this);
            ad.displayCustomer();
            ad.displayOrder();
            ad.displaySupplier();
            ad.displayEmployee();
        }

        private void adminDashForm_Load(object sender, EventArgs e)
        {
            ad.chartAppoint();
            ad.chartRevenue();
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
            
        }
    }
}
