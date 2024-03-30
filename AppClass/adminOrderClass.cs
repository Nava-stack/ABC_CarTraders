using ABC_CarTraders.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ABC_CarTraders.AppClass
{
    internal class adminOrderClass: com
    {
        public adminOrderClass() { }

        private adminCarOrderForm form;
        private ComboBox _orderId,_cusId,_carId,_partId,_disId,_ordSttsId;
        private TextBox _carQty, _partQty, _carAmount, _partAmount,_carTotAmount,_partTotAmount, _totalAmount;
        private CheckBox _carCheck, _partCheck;
        private DateTimePicker _datePick;
        private DataGridView _carOrdGrid, _partOrdGrid;
        private GroupBox _carGroup, _partGroup;

        public adminOrderClass(adminCarOrderForm ordForm)
        {
            this.form = ordForm;
            _orderId = ordForm.adOrdIdCombo;
            _cusId = ordForm.adOrdCusCombo;
            _carCheck = ordForm.carCheck;
            _partCheck =ordForm.partCheck;
            _carId = ordForm.adOrdCarCombo;
            _partId = ordForm.adOrdPartCombo;
            _disId = ordForm.adOrdDisCombo;
            _ordSttsId = ordForm.adOrdSttsCombo;
            _carQty = ordForm.adOrdCarQtyBox;
            _partQty = ordForm.adOrdPartQtyBox;
            _carAmount = ordForm.adOrdCarAmntBox;
            _partAmount = ordForm.adOrdPartAmntBox;
            _totalAmount = ordForm.adTotAmntBox;
            _datePick = ordForm.adOrdDatePick;
            _carOrdGrid = ordForm.adOrdCarDetailGrid;
            _partOrdGrid = ordForm.adOrdPartDetailGrid;
            _carGroup = ordForm.carGroupBox;
            _partGroup = ordForm.partGroupBox;
            _carTotAmount = ordForm.adCarOrdTotBox;
            _partTotAmount = ordForm.adPartOrdTotBox;
                        
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
            initGridHeading(_partOrdGrid, new string[] { "Part", "Quantity", "Total Amount" });
            initGridHeading(_carOrdGrid, new string[] { "Car", "Quantity", "Total Amount" });
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
            loadTableDataAsFK("Select * from [Order]", _orderId, "orderID", "orderID");
            loadTableDataAsFK("Select * from Customer", _cusId, "cusID", "cusID");
            loadTableDataAsFK("Select * from Car", _carId, "model", "carID");
            loadTableDataAsFK("Select * from SparePart", _partId, "partName", "sparePartID");
            loadTableDataAsFK("Select * from Discount", _disId, "disCode", "discountID");
            loadTableDataAsFK("Select * from OrderStatus", _ordSttsId, "status", "orderStatusID");
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




        public void saveOrder()
        {
            if (_cusId.Text == "" || _ordSttsId.Text == "" || _totalAmount.Text == "")
            {
                MessageBox.Show("Please select or fill the Mandatory Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int cusID = (int)_cusId.SelectedValue;
                int disID = (int)_disId.SelectedValue;
                int ordSttsID = (int)_ordSttsId.SelectedValue;

                // Construct the SQL command with the OUTPUT clause to get the inserted OrderID
                string addOrder = $"INSERT INTO [Order] (cusID_fk, orderDate, discountID_fk, orderStatusID_fk, amount) OUTPUT INSERTED.orderID VALUES ('{cusID}', '{_datePick.Text}', '{disID}', '{ordSttsID}', '{_totalAmount.Text}')";

                int orderID = getOrderID(addOrder);

                // Check if the order ID is retrieved successfully
                if (orderID > 0)
                {
                    // Save the order details for car and parts if the respective checkboxes are checked
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



        public void updateOrder()
        {
            if (_cusId.Text == "" || _ordSttsId.Text == "" || _totalAmount.Text == "")
            {
                MessageBox.Show("Please select or fill the Mandatory Details.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure want to Update =>" + "Order ID: " + _orderId.Text.Trim() + " ?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int cusID = (int)_cusId.SelectedValue;
                    int disID = (int)_disId.SelectedValue;
                    int ordSttsID = (int)_ordSttsId.SelectedValue;
                    string updOrder = $"UPDATE [Order] SET cusID_fk = '{cusID}',orderDate ='{_datePick.Text}',discountID_fk = '{disID}',orderStatusID_fk = '{ordSttsID}',amount='{_totalAmount.Text}' WHERE orderID = '{_orderId.Text}'";

                    ExecuteQuery(updOrder, com.queryType.update);
                    MessageBox.Show("Order updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while Updating: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void deleteOrder()
        {
            try
            {
                if (MessageBox.Show("Are you sure want to Delete =>" + "Order ID: " + _orderId.Text.Trim() + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        string deleteOrder = $"DELETE FROM [Order] WHERE orderID = '{_orderId.Text}'";
                        ExecuteQuery(deleteOrder, queryType.delete);
                        MessageBox.Show("Order deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error while Deleting: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void saveCarOrder(int orderID)
        {
            // Insert into OrderCarDetails
            foreach (DataGridViewRow row in _carOrdGrid.Rows)
            {
                if (!row.IsNewRow)
                {
                    string carModel = row.Cells["Car"].Value.ToString();
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
                    string partName = row.Cells["Part"].Value.ToString();
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

        //public void checkOrdID()
        //{
        //    if (_orderId.SelectedItem != null && !string.IsNullOrEmpty(_orderId.SelectedItem.ToString()))
        //    {
        //        if (int.TryParse(_orderId.SelectedItem.ToString(), out int selectedOrderId))
        //        {
        //            if (selectedOrderId > 0)
        //            {
        //                populateOrderDetails(selectedOrderId);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Selected order ID is not a valid number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Selected order ID is not a valid number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select an order ID.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}



        // Modified populateOrderDetails() function
        //public void populateOrderDetails(int orderID)
        //{
        //    try
        //    {
        //        // Retrieve order details
        //        string getOrderDetails = $"SELECT * FROM [Order] WHERE orderID = {orderID}";
        //        SqlDataReader dr = LoadDataText(getOrderDetails, "@orderID", orderID);

        //        if (dr.Read())
        //        {
        //            _cusId.SelectedValue = dr["cusID_fk"];
        //            _datePick.Text = dr["orderDate"].ToString();
        //            _disId.SelectedValue = dr["discountID_fk"];
        //            _ordSttsId.SelectedValue = dr["orderStatusID_fk"];
        //            _totalAmount.Text = dr["amount"].ToString();
        //        }

        //        // Populate part orders grid
        //        string getPartOrders = $"SELECT SparePart.partName AS Part,OP.quantity AS Quantity,PS.salesPrice * OP.quantity AS Total FROM [Order] INNER JOIN OrderPartDetails OP ON [Order].orderID = OP.orderID_fk INNER JOIN SparePart ON OP.sparePartID_fk = SparePart.sparePartID INNER JOIN PartStockDetails PS ON SparePart.sparePartID  = PS.sparePartID_fk WHERE orderID = {orderID}";
        //        LoadDataInGridView(getPartOrders, _partOrdGrid);

        //        // Populate car orders grid
        //        string getCarOrders = $"SELECT Car.model AS Car,OC.quantity AS Quantity,CS.salesPrice * OC.quantity AS Total FROM [Order] INNER JOIN OrderCarDetails OC ON [Order].orderID = OC.orderID_fk INNER JOIN Car ON OC.carID_fk = Car.carID INNER JOIN CarStockDetails CS ON Car.carID = CS.carID_fk WHERE orderID = {orderID}";
        //        LoadDataInGridView(getCarOrders, _carOrdGrid);

        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error while populating order details: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}






        public void updateCarOrder(int orderID)
        {

        }

        public void updatePartOrder(int orderID)
        {

        }


        public void deletePartOrder(int orderID)
        {

        }

        public void deleteCarOrder(int orderID)
        {

        }
    }
}
