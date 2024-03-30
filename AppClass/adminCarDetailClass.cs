using ABC_CarTraders.CommonClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace ABC_CarTraders.AppClass
{
    internal class adminCarDetailClass: com
    {
        public adminCarDetailClass() { }

        private ComboBox _carId,_categoryId,_warrentyId,_manufactId;
        private TextBox _model, _color, _cc;
        private DataGridView _carGrid;
        private adminGoodServiceForm form;



        public adminCarDetailClass(adminGoodServiceForm gfForm)
        {
            this.form = gfForm;
            _carId = gfForm.adCarIdCombo;
            _model = gfForm.adCarModBox;
            _cc = gfForm.adCarCcBox;
            _color = gfForm.adCarColBox;
            _manufactId = gfForm.adCarManCombo;
            _carGrid = gfForm.carDetailGrid;
            _categoryId = gfForm.adCarCatBox;
            _warrentyId = gfForm.adCarWntyBox;
        }


        public void viewGrid()
        {
            string CarDataSQL = "SELECT * FROM Car";
            LoadDataInGridView(CarDataSQL,_carGrid);
        }


        public void loadCarIDs()
        {
            loadTableDataAsFK("Select * from Car", _carId, "carID", "carID");
            loadTableDataAsFK("Select * from CarCategory", _categoryId, "category", "carCategoryID");
            loadTableDataAsFK("Select * from CarManufacturer", _manufactId, "name", "c_manufacturerID");
            loadTableDataAsFK("Select * from CarWarrenty", _warrentyId, "months", "c_warrentyID");
        }


        public void saveCar()
        {
            if (_model.Text == ""
                    || _categoryId.Text == ""
                    || _cc.Text == ""
                    || _manufactId.Text == ""
                    || _warrentyId.Text == "")
            {
                MessageBox.Show("Please fill the Mandatory Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    DateTime _updDate = DateTime.Today;
                    int carCategoryID = (int)_categoryId.SelectedValue;
                    int manufacturerID = (int)_manufactId.SelectedValue;
                    int warrentyID = (int)_warrentyId.SelectedValue;

                    string addCar = $"INSERT INTO Car(model,color,carCategoryID_fk,cc,c_manufacturerID_fk,c_warrentyID_fk,updDate) VALUES ('{_model.Text}','{_color.Text}','{carCategoryID}','{_cc.Text}','{manufacturerID}','{warrentyID}','{_updDate}')";
                    ExecuteQuery(addCar, queryType.save);
                    viewGrid();
                    clearFields();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while Saving: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void updCar()
        {
            if (_model.Text == ""
                    || _categoryId.Text == ""
                    || _cc.Text == ""
                    || _manufactId.Text == ""
                    || _warrentyId.Text == "")
            {
                MessageBox.Show("Please fill the Mandatory Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Are you sure want to Update =>" + "Car ID: " + _carId.Text.Trim() + " ?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        DateTime _updDate = DateTime.Today;

                        // Get the selected value (ID) from the ComboBoxes
                        int carCategoryID = (int)_categoryId.SelectedValue;
                        int manufacturerID = (int)_manufactId.SelectedValue;
                        int warrentyID = (int)_warrentyId.SelectedValue;

                        string updateCustomer = $"UPDATE Car SET model = '{_model.Text}',color ='{_color.Text}',carCategoryID_fk = '{carCategoryID}',cc = '{_cc.Text}',c_manufacturerID_fk='{manufacturerID}',c_warrentyID_fk='{warrentyID}', updDate='{_updDate}' WHERE carID = '{_carId.Text}'";
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

        public void deleteCar()
        {
            if (MessageBox.Show("Are you sure want to Delete =>" + "Car ID: " + _carId.Text.Trim() + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string deleteCustomer = $"DELETE FROM Car WHERE carID = '{_carId.Text}'";
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
            _carId.SelectedIndex = -1;
            _model.Clear();
            _color.Clear();
            _warrentyId.SelectedIndex = -1;
            _cc.Clear();
            _manufactId.SelectedIndex = -1;
            _categoryId.SelectedIndex = -1;
        }

        public void cellClickView(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = _carGrid.Rows[e.RowIndex];
                _carId.Text = row.Cells[0].Value.ToString();
                _model.Text = row.Cells[1].Value.ToString();
                _color.Text = row.Cells[2].Value.ToString();
                _categoryId.Text = row.Cells[3].Value.ToString();
                _cc.Text = row.Cells[4].Value.ToString();
                _manufactId.Text = row.Cells[5].Value.ToString();
                _warrentyId.Text = row.Cells[6].Value.ToString();
                
            }
        }


    }
}
