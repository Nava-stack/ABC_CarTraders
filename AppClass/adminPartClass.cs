using ABC_CarTraders.CommonClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ABC_CarTraders.CommonClass.com;

namespace ABC_CarTraders.AppClass
{
    internal class adminPartClass:com
    {
        adminPartClass() { }

        private ComboBox _partId, _categoryId, _warrentyId, _manufactId;
        private TextBox _name;
        private DataGridView _partGrid;
        private adminGoodServiceForm form;


        public adminPartClass(adminGoodServiceForm gsForm)
        {
            this.form = gsForm;
            _partId = gsForm.partIdCombo;
            _name = gsForm.partNameBox;
            _manufactId = gsForm.partManCombo;
            _warrentyId = gsForm.partWrntyCombo;
            _categoryId = gsForm.partCatCombo;
            _partGrid = gsForm.partDetailGrid;
        }


        public void viewGrid()
        {
            string PartDataSQL = "SELECT * FROM SparePart";
            LoadDataInGridView(PartDataSQL, _partGrid);
        }


        public void loadPartIDs()
        {
            loadTableDataAsFK("Select * from SparePart", _partId, "sparePartID", "sparePartID");
            loadTableDataAsFK("Select * from PartCategory", _categoryId, "category", "partCategoryID");
            loadTableDataAsFK("Select * from PartManufacturer", _manufactId, "name", "p_manufactID");
            loadTableDataAsFK("Select * from SpareWarrenty", _warrentyId, "months", "s_warrentyID");
        }


        public void savePart()
        {

            if (_name.Text == ""
                    || _categoryId.Text == ""
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
                    int partCategoryID = (int)_categoryId.SelectedValue;
                    int manufacturerID = (int)_manufactId.SelectedValue;
                    int warrentyID = (int)_warrentyId.SelectedValue;

                    string addPart = $"INSERT INTO SparePart(partName,partCategoryID_fk,s_warrentyID_fk,p_manufacturerID_fk,updDate) VALUES ('{_name.Text}','{partCategoryID}','{warrentyID}','{manufacturerID}','{_updDate}')";
                    ExecuteQuery(addPart, queryType.save);
                    viewGrid();
                    clearFields();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while Saving: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void updPart()
        {
            if (_name.Text == ""
                     || _categoryId.Text == ""
                     || _manufactId.Text == ""
                     || _warrentyId.Text == "")
            {
                MessageBox.Show("Please fill the Mandatory Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Are you sure want to Update =>" + "Spare Part ID: " + _partId.Text.Trim() + " ?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        DateTime _updDate = DateTime.Today;

                        int partCategoryID = (int)_categoryId.SelectedValue;
                        int manufacturerID = (int)_manufactId.SelectedValue;
                        int warrentyID = (int)_warrentyId.SelectedValue;

                        string updatePart = $"UPDATE SparePart SET partName = '{_name.Text}',partCategoryID_fk = '{partCategoryID}', s_warrentyID_fk='{warrentyID}',p_manufacturerID_fk='{manufacturerID}', updDate='{_updDate}' WHERE sparePartID = '{_partId.Text}'";
                        ExecuteQuery(updatePart, queryType.update);
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
        public void deletePart()
        {
            if (MessageBox.Show("Are you sure want to Delete =>" + "Spare Part ID: " + _partId.Text.Trim() + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string deletePart = $"DELETE FROM SparePart WHERE sparePartID = '{_partId.Text}'";
                    ExecuteQuery(deletePart, queryType.delete);
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
            _partId.SelectedIndex = -1;
            _name.Clear();
            _warrentyId.SelectedIndex = -1;
            _manufactId.SelectedIndex = -1;
            _categoryId.SelectedIndex = -1;
        }

        public void cellClickView(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = _partGrid.Rows[e.RowIndex];
                _partId.Text = row.Cells[0].Value.ToString();
                _name.Text = row.Cells[1].Value.ToString();
                _categoryId.Text = row.Cells[2].Value.ToString();
                _warrentyId.Text = row.Cells[3].Value.ToString();
                _manufactId.Text = row.Cells[4].Value.ToString();

            }
        }




    }
}
