using ABC_CarTraders.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_CarTraders.AppClass
{
    internal class Customer : com
    {
        com c = new com();
        private RegisterAsForm form;
        private TextBox _name, _nic, _address, _mobile, _email, _uname, _pword;
        private RadioButton _male, _female;
        
        public Customer(RegisterAsForm regForm)
        {
            this.form = regForm;
            _name = regForm.regNameBox;
            _nic = regForm.regNicBox;
            _address = regForm.regAdBox;
            _mobile = regForm.regMobBox;
            _email = regForm.regMailBox;
            _uname = regForm.regUnameBox;
            _pword = regForm.regPassBox;
            _male = regForm.regMaleRadio;
            _female = regForm.regFemaleRadio;
        }

        

        public Customer()
        {
        }

        public int GetCustomerId(string username)
        {
            string query = $"SELECT cusId FROM Customers WHERE uname = '{username}'";
            DataTable result = ExecuteSelectQuery(query);

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["cusID"]);
            }
            else
            {
                // Handle the case where the username is not found
                throw new ArgumentException("Username not found");
            }
        }
        public void save()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_name.Text) || string.IsNullOrWhiteSpace(_nic.Text))
                {
                    MessageBox.Show("Please fill the Mandatory Details.", "Login Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (string.IsNullOrWhiteSpace(_uname.Text) || string.IsNullOrWhiteSpace(_pword.Text))
                {
                    MessageBox.Show("Please enter both Username and Password.", "Login Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (!c.checkCustomer(_uname.Text))
                    {
                        DateTime _regDate = DateTime.Today;
                        string gender = _male.Checked ? "Male" : "Female";
                        string sql = $"INSERT INTO Customer(name,nic,address,gender,email,uname,pword,mobile,regDate) VALUES ('{_name.Text}','{_nic.Text}','{_address.Text}','{gender}','{_email.Text}','{_uname.Text}','{_pword.Text}','{_mobile.Text}','{_regDate}')";
                        c.ExecuteQuery(sql, queryType.save);
                        goToLogin();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while Registering: " + ex.Message);
            }
           
        }

        public void goToLogin()
        {
            LoginAsForm lgForm = new LoginAsForm();
            lgForm.Show();
            form.Hide();

        }

        private void clearForm()
        {
            _name.Clear();
            _nic.Clear();
            _pword.Clear();
            _mobile.Clear();
            _email.Clear();
            _uname.Clear();
            _address.Clear();
            _male.Checked = false;
            _female.Checked = false;
        }

        public static void exitForm()
        {
            if ((MessageBox.Show("Are you sure to exit?", "ABC Car Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Error)) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public bool cusLoginAuth(string username, string pass)
        {
            bool loginStatus = false;
            try
            {
                string sql = $"SELECT * FROM Customer WHERE uname = '{username}' and pword = '{pass}'";
                DataTable dt = getDataFromDB(sql);
                if (dt.Rows.Count > 0)
                {
                    loginStatus = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return loginStatus;
        }
    }
}
