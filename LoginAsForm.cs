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

namespace ABC_CarTraders
{
    public partial class LoginAsForm : Form
    {
        public LoginAsForm()
        {
            InitializeComponent();
        }


        private Admin ad = new Admin();
        private Customer cm = new Customer();



        private void extLbl_Click(object sender, EventArgs e)
        {
            com.exitConfirm();
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            RegisterAsForm rgform = new RegisterAsForm();
            rgform.Show();
            this.Hide();
        }

        private void lgnBtn_Click(object sender, EventArgs e)
        {
            string username = lgnUnameBox.Text;
            string password = lgnPassBox.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both Username and Password.","Login Failure",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (enterAsCombo.Text == "Admin")
                {
                    if (ad.adminLoginAuth(username, password))
                    {
                        MessageBox.Show("Login as Admin Successfully", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdminDashboardForm adDash = new AdminDashboardForm();
                        adDash.Show();
                        this.Hide();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password for Admin.", "Login Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (enterAsCombo.Text == "Customer")
                {
                    if (cm.cusLoginAuth(username, password))
                    {
                        MessageBox.Show("Login as Customer Successfully", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CustomerDashboardForm cmDash = new CustomerDashboardForm();
                        cmDash.Show();
                        this.Hide();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password for Customer.", "Login Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid user type.", "Login Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login: " + ex.Message, "Login Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginAsForm_Load(object sender, EventArgs e)
        {

        }

        private void lgnShowPass_CheckedChanged(object sender, EventArgs e)
        {
            lgnPassBox.PasswordChar = lgnShowPass.Checked ? '\0' : '*'; 
        }
    }
}
