using ABC_CarTraders.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ABC_CarTraders.AppClass
{
    internal class customerOrderClass: com
    {
        public customerOrderClass() { }

        private customerOrderForm form;
        private ComboBox _orderId, _carId, _partId;
        private TextBox _carQty, _partQty, _disId, _carAmount, _partAmount, _carTotAmount, _partTotAmount, _totalAmount,_cusId;
        private CheckBox _carCheck, _partCheck;
        private DataGridView _carOrdGrid, _partOrdGrid;
        private GroupBox _carGroup, _partGroup;

        public customerOrderClass(customerOrderForm ordForm)
        {
            this.form = ordForm;
            _orderId = ordForm.cusOrdIdCombo;
            _carCheck = ordForm.carCheck;
            _partCheck = ordForm.partCheck;
            _carId = ordForm.cusOrdCarCombo;
            _partId = ordForm.cusOrdPartCombo;
            _disId = ordForm.cusOrdDisBox;
            _carQty = ordForm.cusOrdCarQtyBox;
            _partQty = ordForm.cusOrdPartQtyBox;
            _carAmount = ordForm.cusOrdCarAmntBox;
            _partAmount = ordForm.cusOrdPartAmntBox;
            _totalAmount = ordForm.cusOrdTotAmntBox;
            _carOrdGrid = ordForm.cusOrdCarDetailGrid;
            _partOrdGrid = ordForm.cusOrdPartDetailGrid;
            _carGroup = ordForm.carGroupBox;
            _partGroup = ordForm.partGroupBox;
            _carTotAmount = ordForm.cusCarOrdTotBox;
            _partTotAmount = ordForm.cusPartOrdTotBox;
            _cusId = ordForm.idbox;
        }

        public void removeCarOrder()
        {
            removeSelectedOrder(_carOrdGrid);
            CalculateCarTotalAmount();
            CalculateTotalOrderAmount();
        }

        public void removePartOrder()
        {
            removeSelectedOrder(_partOrdGrid);
            CalculatePartTotalAmount();
            CalculateTotalOrderAmount();

        }

        public void addPartToGrid()
        {
            try
            {
                // Add a row to the Part DataGridView
                addRowToGrid(_partOrdGrid, new string[] { _partId.Text, _partQty.Text, _partAmount.Text });
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show($"An error occurred while adding part row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addCarToGrid()
        {
            try
            {
                // Add a row to the Car DataGridView
                addRowToGrid(_carOrdGrid, new string[] { _carId.Text, _carQty.Text, _carAmount.Text });
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show($"An error occurred while adding car row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void initGrids()
        {
            initGridHeading(_partOrdGrid, new string[] { "Part ID", "Quantity", "Total Amount" });
            initGridHeading(_carOrdGrid, new string[] { "Car ID", "Quantity", "Total Amount" });
        }


        public void CalculateCarTotalAmount()
        {
            CalculateTotalAmount(_carOrdGrid, "Total Amount", _carTotAmount);


        }

        public void CalculatePartTotalAmount()
        {
            CalculateTotalAmount(_partOrdGrid, "Total Amount", _partTotAmount);

        }

        private void _carOrdGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1 && _carOrdGrid.Columns[e.ColumnIndex].Name == "Remove")
            {
                _carOrdGrid.Rows.RemoveAt(e.RowIndex);
                CalculateCarTotalAmount(); // Recalculate total amount after removing the row
            }
        }

        private void _partOrdGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1 && _partOrdGrid.Columns[e.ColumnIndex].Name == "Remove")
            {
                _partOrdGrid.Rows.RemoveAt(e.RowIndex);
                CalculatePartTotalAmount(); // Recalculate total amount after removing the row
            }
        }

        public void loadOrdIDs()
        {
            //int cusID = retID();
            //loadTableDataAsFK($"Select * from [Order]  WHERE cusID_fk = '{cusID}'", _orderId, "orderID", "orderID");
            loadTableDataAsFK("Select * from Car", _carId, "model", "carID");
            loadTableDataAsFK("Select * from SparePart", _partId, "partName", "sparePartID");
        }

        public void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            // Cast the sender object to a CheckBox to determine which checkbox triggered the event
            CheckBox checkBox = (CheckBox)sender;

            // Check if the Car checkbox is checked
            if (checkBox == _carCheck)
            {
                // If the Car checkbox is checked, show the CarGroupBox
                _carGroup.Visible = checkBox.Checked;
                _carTotAmount.Text = "0";
            }
            else if (checkBox == _partCheck)
            {
                // If the Part checkbox is checked, show the PartGroupBox
                _partGroup.Visible = checkBox.Checked;
                _partTotAmount.Text = "0";
            }

            // Check if both checkboxes are checked
            if (_carCheck.Checked && _partCheck.Checked)
            {
                // If both checkboxes are checked, show both group boxes
                _carGroup.Visible = true;
                _partGroup.Visible = true;
            }


        }



        public void calculateCarOrderAmount()
        {
            try
            {
                int selectedCarID = (int)_carId.SelectedValue;
                decimal salesPrice = getSalesPrice(selectedCarID);

                if (salesPrice > 0)
                {
                    if (int.TryParse(_carQty.Text, out int quantityOrdered))
                    {
                        _carAmount.Text = (salesPrice * quantityOrdered).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid quantity format.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Sales price not found for the selected car.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while calculating amount: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void calculatePartOrderAmount()
        {
            try
            {
                int selectedPartID = (int)_partId.SelectedValue;
                decimal salesPrice = getSalesPrice(selectedPartID);

                if (salesPrice > 0)
                {
                    if (int.TryParse(_partQty.Text, out int quantityOrdered))
                    {
                        _partAmount.Text = (salesPrice * quantityOrdered).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid quantity format.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Sales price not found for the selected part.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while calculating amount: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void CalculateTotalOrderAmount()
        {
            try
            {
                double totalOrderAmount = 0;

                if (_carCheck.Checked)
                {
                    // Get the car order amount from the car amount text box
                    double carOrderAmount = double.Parse(_carTotAmount.Text);
                    totalOrderAmount += carOrderAmount;
                }

                if (_partCheck.Checked)
                {
                    // Get the part order amount from the part amount text box
                    double partOrderAmount = double.Parse(_partTotAmount.Text);
                    totalOrderAmount += partOrderAmount;
                }

                // Display the total order amount in the total order amount text box  
                _totalAmount.Text = totalOrderAmount.ToString();

            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur while calculating the total order amount
                MessageBox.Show("Error calculating total order amount: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal getSalesPrice(int id)
        {
            string tableName = id == (int)_carId.SelectedValue ? "CarStockDetails" : "PartStockDetails";
            string salesPriceQuery = $"SELECT salesPrice FROM {tableName} WHERE {(id == (int)_carId.SelectedValue ? "carID_fk" : "sparePartID_fk")} = {id}";
            DataTable salesPriceData = getDataFromDB(salesPriceQuery);

            if (salesPriceData.Rows.Count > 0)
            {
                return Convert.ToDecimal(salesPriceData.Rows[0]["salesPrice"]);
            }
            return 0;
        }


        //public int retID()
        //{
        //    string cusQuery = $"SELECT cusID FROM Customer WHERE uname = '{_uname.Text}'";
        //    int cusID = loadDataInTextBox(cusQuery, _cusId);
        //    return cusID;
        //}


        public void saveOrder()
        {
            if (_carQty.Text == "" || _partQty.Text == "")
            {
                MessageBox.Show("Please select or fill the Mandatory Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                //int cusID = retID();
                DateTime ordDate = DateTime.Today;
                //string addOrder = $"INSERT INTO [Order](cusID_fk,orderDate,amount) VALUES ('{cusID}','{ordDate}','{_totalAmount.Text}')";
                //ExecuteQuery(addOrder, com.queryType.save);

                // Get the inserted OrderID
                string getOrderID = "SELECT SCOPE_IDENTITY()";
                DataTable orderIDTable = getDataFromDB(getOrderID);

                if (orderIDTable.Rows.Count > 0)
                {
                    int orderID = Convert.ToInt32(orderIDTable.Rows[0][0]);

                    if (_partCheck.Checked)
                    {
                        savePartOrder(orderID);
                    }

                    if (_carCheck.Checked)
                    {
                        saveCarOrder(orderID);
                    }

                    MessageBox.Show("Order saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error: No Order ID found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while Saving: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void saveCarOrder(int orderID)
        {
            // Insert into OrderCarDetails
            foreach (DataGridViewRow row in _carOrdGrid.Rows)
            {
                if (!row.IsNewRow)
                {
                    string carModel = row.Cells["Car ID"].Value.ToString();
                    string getCarID = $"SELECT carID FROM Car WHERE model = '{carModel}'";

                    // Get the result of the query
                    object result = getDataFromDB(getCarID).Rows[0][0];

                    // Check if the result is DBNull.Value
                    if (result != DBNull.Value)
                    {
                        // Convert the result to an int
                        int carID = Convert.ToInt32(result);

                        string quantity = row.Cells["Quantity"].Value.ToString();
                        string totalAmount = row.Cells["Total Amount"].Value.ToString();

                        string addCarOrd = $"INSERT INTO OrderCarDetails(orderID_fk,carID_fk,quantity,totalAmount) VALUES ('{orderID}','{carID}','{quantity}','{totalAmount}')";
                        ExecuteQuery(addCarOrd, com.queryType.save);
                    }
                    else
                    {
                        // Handle the case where the result is DBNull.Value
                        MessageBox.Show("Car ID not found for model: " + carModel, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void savePartOrder(int orderID)
        {
            // Insert into OrderPartDetails
            foreach (DataGridViewRow row in _partOrdGrid.Rows)
            {
                if (!row.IsNewRow)
                {
                    string partName = row.Cells["Part ID"].Value.ToString();
                    string getPartID = $"SELECT sparePartID FROM SparePart WHERE partName = '{partName}'";

                    // Get the partID from the database
                    object partIDResult = getDataFromDB(getPartID).Rows[0][0];

                    // Check if the result is DBNull.Value
                    if (partIDResult != DBNull.Value)
                    {
                        int partID = Convert.ToInt32(partIDResult);

                        string quantity = row.Cells["Quantity"].Value.ToString();
                        string totalAmount = row.Cells["Total Amount"].Value.ToString();

                        string addPartOrd = $"INSERT INTO OrderPartDetails(orderID_fk,sparePartID_fk,quantity,totalAmount) VALUES ('{orderID}','{partID}','{quantity}','{totalAmount}')";
                        ExecuteQuery(addPartOrd, com.queryType.save);
                    }
                    else
                    {
                        // Handle the case where the result is DBNull.Value
                        MessageBox.Show("Spare Part ID not found for part name: " + partName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


    }
}
