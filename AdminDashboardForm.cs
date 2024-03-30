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
using ABC_CarTraders.CommonClass;

namespace ABC_CarTraders
{
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();

        }

        private void extLbl_Click(object sender, EventArgs e)
        {
            com.exitConfirm();
        }

        private void adLogoutBtn_Click(object sender, EventArgs e)
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

        private void adHomeBtn_Click(object sender, EventArgs e)
        {
            adminDashForm1.Visible = true;
            adminCustomerForm1.Visible = false;
            adminCarOrderForm1.Visible = false;
            adminGoodServiceForm1.Visible = false;
            adminEmployeeForm1.Visible = false;
            adminPayForm1.Visible = false;
            adminAppointForm1.Visible = false;
            adminSupplyForm1.Visible = false;
            adminInventoryForm1.Visible = false;


        }

        private void adCusBtn_Click(object sender, EventArgs e)
        {
            adminDashForm1.Visible = false;
            adminCustomerForm1.Visible = true;
            adminCarOrderForm1.Visible = false;
            adminGoodServiceForm1.Visible = false;
            adminEmployeeForm1.Visible = false;
            adminPayForm1.Visible = false;
            adminAppointForm1.Visible = false;
            adminSupplyForm1.Visible = false;
            adminInventoryForm1.Visible = false;
        }

        private void adOrderBtn_Click(object sender, EventArgs e)
        {
            adminDashForm1.Visible = false;
            adminCustomerForm1.Visible = false;
            adminCarOrderForm1.Visible = true;
            adminGoodServiceForm1.Visible = false;
            adminEmployeeForm1.Visible = false;
            adminPayForm1.Visible = false;
            adminAppointForm1.Visible = false;
            adminSupplyForm1.Visible = false;
            adminInventoryForm1.Visible = false;
        }

        private void adGoodBtn_Click(object sender, EventArgs e)
        {
            adminDashForm1.Visible = false;
            adminCustomerForm1.Visible = false;
            adminCarOrderForm1.Visible = false;
            adminGoodServiceForm1.Visible = true;
            adminEmployeeForm1.Visible = false;
            adminPayForm1.Visible = false;
            adminAppointForm1.Visible = false;
            adminSupplyForm1.Visible = false;
            adminInventoryForm1.Visible = false;
        }

        private void adEmpBtn_Click(object sender, EventArgs e)
        {
            adminDashForm1.Visible = false;
            adminCustomerForm1.Visible = false;
            adminCarOrderForm1.Visible = false;
            adminGoodServiceForm1.Visible = false;
            adminEmployeeForm1.Visible = true;
            adminPayForm1.Visible = false;
            adminAppointForm1.Visible = false;
            adminSupplyForm1.Visible = false;
            adminInventoryForm1.Visible = false;
        }

        private void adPayBtn_Click(object sender, EventArgs e)
        {
            adminDashForm1.Visible = false;
            adminCustomerForm1.Visible = false;
            adminCarOrderForm1.Visible = false;
            adminGoodServiceForm1.Visible = false;
            adminEmployeeForm1.Visible = false;
            adminPayForm1.Visible = true;
            adminAppointForm1.Visible = false;
            adminSupplyForm1.Visible = false;
            adminInventoryForm1.Visible = false;
        }

        private void adSupplyBtn_Click(object sender, EventArgs e)
        {
            adminDashForm1.Visible = false;
            adminCustomerForm1.Visible = false;
            adminCarOrderForm1.Visible = false;
            adminGoodServiceForm1.Visible = false;
            adminEmployeeForm1.Visible = false;
            adminPayForm1.Visible = false;
            adminAppointForm1.Visible = false;
            adminSupplyForm1.Visible = true;
            adminInventoryForm1.Visible = false;
        }

        private void adServBtn_Click(object sender, EventArgs e)
        {
            adminDashForm1.Visible = false;
            adminCustomerForm1.Visible = false;
            adminCarOrderForm1.Visible = false;
            adminGoodServiceForm1.Visible = false;
            adminEmployeeForm1.Visible = false;
            adminPayForm1.Visible = false;
            adminAppointForm1.Visible = false;
            adminSupplyForm1.Visible = false;
            adminInventoryForm1.Visible = true;
        }

        private void adServiceBtn_Click(object sender, EventArgs e)
        {
            adminDashForm1.Visible = false;
            adminCustomerForm1.Visible = false;
            adminCarOrderForm1.Visible = false;
            adminGoodServiceForm1.Visible = false;
            adminEmployeeForm1.Visible = false;
            adminPayForm1.Visible = false;
            adminAppointForm1.Visible = true;
            adminSupplyForm1.Visible = false;
            adminInventoryForm1.Visible = false;
        }
    }
}
