using ABC_CarTraders.CommonClass;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ABC_CarTraders.AppClass
{
    internal class adminCustomerDetailClass: com
    {
        public adminCustomerDetailClass() {}

        private ComboBox _idCombo;
        private TextBox _name, _nic, _address, _mobile, _email, _uname, _pword;
        private RadioButton _male, _female;
        private DataGridView _dataGrid;
        private adminCustomerForm cusForm;
        private PictureBox _picture;


        public adminCustomerDetailClass(adminCustomerForm CustomerForm)
        {
            this.cusForm = CustomerForm;
            _idCombo = cusForm.adCusIdCombo;
            _name = cusForm.adCusNameBox;
            _nic = cusForm.adCusNicBox;
            _address = cusForm.adCusAdBox;
            _mobile = cusForm.adCusMobBox;
            _email = cusForm.adCusMailBox;
            _uname = cusForm.adCusUnameBox;
            _pword = cusForm.adCusPwordBox;
            _male = cusForm.adCusMaleRadio;
            _female = cusForm.adCusFemaleRadio;
            _dataGrid = cusForm.adCusDetailGrid;
            _picture = cusForm.adCusImageBox;
        }

        public void viewGrid()
        {
            string CusDataSQL = "SELECT * FROM Customer";
            LoadDataInGridView(CusDataSQL,_dataGrid);
        }

        public void saveCus()
        {
            if (_name.Text == ""
                    || _nic.Text == ""
                    || _address.Text == ""
                    || _mobile.Text == ""
                    || _email.Text == ""
                    || _uname.Text == ""
                    || _pword.Text == ""
                    || _picture.Image == null)
            {
                MessageBox.Show("Please fill the Mandatory Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
               try
                {
                    if (!checkCustomer(_uname.Text))
                    {
                        DateTime _regDate = DateTime.Today;

                        string path = Path.Combine(@"I:\BEng - LMU\Application Development\CW1\ABC\ABC_CarTraders\ImageDirectory\" + _uname.Text.Trim() + ".jpg");
                        string directoryPath = Path.GetDirectoryName(path);

                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        File.Copy(_picture.ImageLocation, path, true);

                        string gender = _male.Checked ? "Male" : "Female";
                        string addCustomer = $"INSERT INTO Customer(name,nic,address,gender,email,uname,pword,mobile,cusImage,regDate) VALUES ('{_name.Text}','{_nic.Text}','{_address.Text}','{gender}','{_email.Text}','{_uname.Text}','{_pword.Text}','{_mobile.Text}','{path}','{_regDate}')";

                        ExecuteQuery(addCustomer, queryType.save);
                        viewGrid();
                        clearFields();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while Registering: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void updateCus()
        {
            if (_name.Text == ""
                    || _nic.Text == ""
                    || _address.Text == ""
                    || _mobile.Text == ""
                    || _email.Text == ""
                    || _uname.Text == ""
                    || _pword.Text == ""
                    || _picture.Image == null)
            {
                MessageBox.Show("Please fill the Mandatory Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if(MessageBox.Show("Are you sure want to Update =>" + "Customer ID: " + _idCombo.Text.Trim() + " ?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    try
                    {
                        DateTime _updDate = DateTime.Today;

                        string path = Path.Combine(@"I:\BEng - LMU\Application Development\CW1\ABC\ABC_CarTraders\ImageDirectory\" + _uname.Text.Trim() + ".jpg");
                        string directoryPath = Path.GetDirectoryName(path);

                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        File.Copy(_picture.ImageLocation, path, true);
                        string gender = _male.Checked ? "Male" : "Female";
                        string updateCustomer = $"UPDATE Customer SET [name] = '{_name.Text}',nic ='{_nic.Text}',[address] = '{_address.Text}',gender = '{gender}',email='{_email.Text}',uname='{_uname.Text}',pword='{_pword.Text}',mobile='{_mobile.Text}',cusImage='{path}',updDate='{_updDate}' WHERE cusID = '{_idCombo.Text}'";
                        ExecuteQuery(updateCustomer, queryType.update);
                        viewGrid();
                        clearFields();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                   MessageBox.Show("Update Cancelled", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void deleteCus()
        {
            if (MessageBox.Show("Are you sure want to Delete =>" + "Customer ID: " + _idCombo.Text.Trim() + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string deleteCustomer = $"DELETE FROM Customer WHERE cusID = '{_idCombo.Text}'";
                    ExecuteQuery(deleteCustomer, queryType.delete);
                    viewGrid();
                    clearFields();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Delete Cancelled", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearFields()
        {
            _idCombo.SelectedIndex = -1;
            _name.Clear();
            _nic.Clear();
            _address.Clear();
            _mobile.Clear();
            _uname.Clear();
            _pword.Clear();
            _email.Clear();
            _male.Checked = false;
            _female.Checked = false;
            _picture.Image = null;
        }


        public void loadCusIDs()
        {
            loadTableDataAsFK("Select * from Customer", _idCombo,"cusID","cusID");
        }

        public void cusImageImport()
        {
            importImage(_picture);
        }


        public void cellClickView(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = _dataGrid.Rows[e.RowIndex];
                _idCombo.Text = row.Cells[0].Value.ToString();
                _name.Text = row.Cells[1].Value.ToString();
                _nic.Text = row.Cells[2].Value.ToString();
                _address.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value.ToString() == "Male")
                {
                    _male.Checked = true;
                    _female.Checked = false;
                }
                _email.Text = row.Cells[5].Value.ToString();
                _uname.Text = row.Cells[6].Value.ToString();
                _pword.Text = row.Cells[7].Value.ToString();
                _mobile.Text = row.Cells[8].Value.ToString();
                string imagePath = row.Cells[9].Value.ToString();
                if (imagePath != "")
                {
                    _picture.Image = Image.FromFile(imagePath);
                }
                else
                {
                    _picture.Image = null;  
                }
            }
        }
    }
}
