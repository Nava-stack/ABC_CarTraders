using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABC_CarTraders.AppClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ABC_CarTraders
{
    public partial class CustomerDashboardForm : Form
    {
       
        public CustomerDashboardForm()
        {
            InitializeComponent();
        }

        private void extLbl_Click(object sender, EventArgs e)
        {
           customerDashClass.exitForm();
        }

        private void cusLogoutBtn_Click(object sender, EventArgs e)
        {
            logoutConfirm();
        }

        public void logoutConfirm()
        {
            if ((MessageBox.Show("Are you sure want to Logout?", "ABC Car Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Error)) == DialogResult.Yes)
            {
                goToLogin();
            }

        }

        public void goToLogin()
        {
            LoginAsForm lgForm = new LoginAsForm();
            lgForm.Show();
            this.Hide();
        }

        private void cusHomeBtn_Click(object sender, EventArgs e)
        {

            customerDashForm1.Visible = true;
            customerCarForm1.Visible = false;
            customerSparePartForm1.Visible = false ;
            customerAppointForm1.Visible = false ;
            customerOrderForm1.Visible = false ;
            customerPaymentForm1.Visible = false ;
            customerProfileForm1.Visible = false ;
        }

        private void cusCarBtn_Click(object sender, EventArgs e)
        {
            customerDashForm1.Visible = false;
            customerCarForm1.Visible = true;
            customerSparePartForm1.Visible = false;
            customerAppointForm1.Visible = false;
            customerOrderForm1.Visible = false;
            customerPaymentForm1.Visible = false;
            customerProfileForm1.Visible = false;
        }

        private void cusSpareBtn_Click(object sender, EventArgs e)
        {
            customerDashForm1.Visible = false;
            customerCarForm1.Visible = false;
            customerSparePartForm1.Visible = true;
            customerAppointForm1.Visible = false;
            customerOrderForm1.Visible = false;
            customerPaymentForm1.Visible = false;
            customerProfileForm1.Visible = false;
        }

        private void cusServBtn_Click(object sender, EventArgs e)
        {
            customerDashForm1.Visible = false;
            customerCarForm1.Visible = false;
            customerSparePartForm1.Visible = false;
            customerAppointForm1.Visible = true;
            customerOrderForm1.Visible = false;
            customerPaymentForm1.Visible = false;
            customerProfileForm1.Visible = false;
        }

        private void cusOrdDashBtn_Click(object sender, EventArgs e)
        {
            customerDashForm1.Visible = false;
            customerCarForm1.Visible = false;
            customerSparePartForm1.Visible = false;
            customerAppointForm1.Visible = false;
            customerOrderForm1.Visible = true;
            customerPaymentForm1.Visible = false;
            customerProfileForm1.Visible = false;

        }

        private void cusPayDashBtn_Click(object sender, EventArgs e)
        {
            customerDashForm1.Visible = false;
            customerCarForm1.Visible = false;
            customerSparePartForm1.Visible = false;
            customerAppointForm1.Visible = false;
            customerOrderForm1.Visible = false;
            customerPaymentForm1.Visible = true;
            customerProfileForm1.Visible = false;
        }

        private void cusProfileSetBtn_Click(object sender, EventArgs e)
        {
            customerDashForm1.Visible = false;
            customerCarForm1.Visible = false;
            customerSparePartForm1.Visible = false;
            customerAppointForm1.Visible = false;
            customerOrderForm1.Visible = false;
            customerPaymentForm1.Visible = false;
            customerProfileForm1.Visible = true;
        }
    }
}
