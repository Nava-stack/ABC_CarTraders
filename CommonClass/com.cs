using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_CarTraders.CommonClass
{
    internal class com
    {
        public com() { }

        internal enum queryType
        {
            save, update, delete
        }

        private SqlConnection _dbcon = new SqlConnection(@"Data Source=NAVA;Initial Catalog=ABC_Car_TradersDB;Integrated Security=True;Encrypt=False");


        internal bool ExecuteQuery(string sql, queryType _queryType)
        {
            bool result = true;

            try
            {
                _dbcon.Open();
                SqlCommand cmd = new SqlCommand(sql, _dbcon);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    string message = getMessage(_queryType);
                    MessageBox.Show(message, "ABC Car Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result = true;
                }
                else
                {
                    MessageBox.Show("No rows affected.", "ABC Car Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result = false;
                }
            }
            catch (SqlException ex)
            {
                // Handle specific SQL exceptions
                string errorMessage = "Error occurred during " + _queryType + ": " + ex.Message;
                MessageBox.Show(errorMessage, "ABC Car Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                string errorMessage = "Error occurred during " + _queryType + ": " + ex.Message;
                MessageBox.Show(errorMessage, "ABC Car Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            finally
            {
                // Always close the connection, even if an exception occurs
                _dbcon.Close();
            }

            return result;
        }

        internal DataTable ExecuteSelectQuery(string sql)
        {
            DataTable result = new DataTable();

            try
            {
                _dbcon.Open();
                SqlCommand cmd = new SqlCommand(sql, _dbcon);
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
            }
            catch (SqlException ex)
            {
                // Handle specific SQL exceptions
                string errorMessage = "Error occurred during SELECT query: " + ex.Message;
                MessageBox.Show(errorMessage, "ABC Car Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                string errorMessage = "Error occurred during SELECT query: " + ex.Message;
                MessageBox.Show(errorMessage, "ABC Car Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Always close the connection, even if an exception occurs
                _dbcon.Close();
            }

            return result;
        }




        private string getMessage(queryType _queryType)
        {
            return queryType.save == _queryType
                    ? "Data Added Successfully"
                    : queryType.update == _queryType
                    ? "Data Updated Successfully"
                    : "Data Deleted Successfully";
        }

        public DataTable getDataFromDB(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                _dbcon.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, _dbcon);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while retrieving data from database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _dbcon.Close();
            }

            return dt;
        }

        public void loadTableDataAsFK(string sql, ComboBox combo, string nameColumnName, string idColumnName)
        {
            DataTable dt = getDataFromDB(sql);
            combo.DataSource = dt;
            combo.DisplayMember = nameColumnName;
            combo.ValueMember = idColumnName;
        }

        public void LoadDataInGridView(string sql, DataGridView loadTable)
        {
            DataTable dt = getDataFromDB(sql);
            loadTable.DataSource = dt; 
        }

        public SqlDataReader LoadDataText(string sql,string @id,int nameId)
        {
            SqlDataReader dr = null;
            try
            {
                _dbcon.Open();
                SqlCommand cmd = new SqlCommand(sql, _dbcon);
                cmd.Parameters.AddWithValue(@id, nameId);
                SqlDataReader reader = cmd.ExecuteReader();
                dr = reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while retrieving data from database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _dbcon.Close();
            }
            return dr;
           
        }
        

        public int getOrderID(string sql)
        {
            int checkedID = 0;

            try
            {
                _dbcon.Open();
                SqlCommand cmd = new SqlCommand(sql, _dbcon);
                checkedID = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while retrieving Order ID: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _dbcon.Close();
            }

            return checkedID;
        }


        public bool checkCustomer(string txtBx)
        {
            //Checking the Customer has already Exits in the Database or Not
            bool checkStts = false;

            try
            {
                _dbcon.Open();
                string findCusQuery = "SELECT COUNT(cusID) FROM Customer WHERE uname = @Customer";
                SqlCommand checkCmd = new SqlCommand(findCusQuery, _dbcon);

                checkCmd.Parameters.AddWithValue("@Customer", txtBx.Trim());
                int count = (int)checkCmd.ExecuteScalar();

                if (count >= 1)
                {
                    MessageBox.Show("Username: " + txtBx.Trim() + " is already taken, Try another.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkStts = true;
                  
                }
                _dbcon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return checkStts;
        }

        public void goToLogin(Form hideform)
        {
            LoginAsForm lgForm = new LoginAsForm();
            lgForm.Show();
            hideform.Hide();
        }

        public void importImage(PictureBox imageBox)
        {
            try
            {
                //Importing Images from file explorer locations
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg,*.png)|*.jpg;*.png";
                string imagePath = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    imageBox.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while Registering: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static void exitConfirm()
        {
            if (MessageBox.Show("Are you sure want to Exit ?", "Exit Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void initGridHeading(DataGridView dataGridView, string[] columnNames)
        {
            try
            {
                //For Multiple Orders
                foreach (string columnName in columnNames)
                {
                    dataGridView.Columns.Add(columnName.ToLower(), columnName);
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                MessageBox.Show($"An error occurred while initializing the grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addRowToGrid(DataGridView dataGridView, string[] cellValues)
        {
            try
            {
                // Check if all cell values are valid
                bool allValuesValid = true;
                foreach (string cellValue in cellValues)
                {
                    if (string.IsNullOrWhiteSpace(cellValue))
                    {
                        allValuesValid = false;
                        break;
                    }
                }
                // If all values are valid, add the row to the DataGridView
                if (allValuesValid)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    // Add cells to the row
                    foreach (string cellValue in cellValues)
                    {
                        DataGridViewCell cell = new DataGridViewTextBoxCell();
                        cell.Value = cellValue;
                        row.Cells.Add(cell);
                    }

                    // Add the row to the DataGridView
                    dataGridView.Rows.Add(row);
                }
                else
                {
                    MessageBox.Show("Please enter valid data in all fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show($"An error occurred while adding row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void removeSelectedOrder(DataGridView dataGridView)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                dataGridView.Rows.RemoveAt(selectedRowIndex);
            }
            else
            {
                MessageBox.Show("Please select a row to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void CalculateTotalAmount(DataGridView dataGridView, string amountColumnName, TextBox totalAmountTextBox)
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow && row.Cells[amountColumnName].Value != null)
                {
                    totalAmount += Convert.ToDecimal(row.Cells[amountColumnName].Value);
                }
            }

            totalAmountTextBox.Text = totalAmount.ToString();
        }



        public void dashBoardLabelView(string sql,Label label)
        {
            try
            {
                _dbcon.Open();
                string query = sql;

                SqlCommand cmd = new SqlCommand(query,_dbcon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int count = Convert.ToInt32(reader[0]);
                    label.Text = count.ToString();
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _dbcon.Close();
            }
        }




    }
}
