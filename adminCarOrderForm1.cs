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
    public partial class adminCarOrderForm : UserControl
    {
        private adminOrderClass ord;

        public adminCarOrderForm()
        {
            InitializeComponent();
            ord = new adminOrderClass(this);
            ord.initGrids();
           
        }

        private void adOrdSaveBtn_Click(object sender, EventArgs e)
        {

        }

        private void adOrdUpdateBtn_Click(object sender, EventArgs e)
        {

        }

        private void adOrdDltBtn_Click(object sender, EventArgs e)
        {

        }

        private void adOrdClrBtn_Click(object sender, EventArgs e)
        {

        }

        private void adOrdCarDetailGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void adminCarOrderForm_Load(object sender, EventArgs e)
        {
            ord.loadOrdIDs();

        }

        private void addNewSpareBtn_Click(object sender, EventArgs e)
        {
            ord.addPartToGrid();
            ord.CalculatePartTotalAmount();
            ord.CalculateTotalOrderAmount();

        }

        private void rmvSelPartOrdBtn_Click(object sender, EventArgs e)
        {
            ord.removePartOrder();
            ord.CalculateTotalOrderAmount();
        }

        private void addNewCarBtn_Click(object sender, EventArgs e)
        {
            ord.addCarToGrid();
            ord.CalculateCarTotalAmount();
            ord.CalculateTotalOrderAmount();
        }

        private void rmvSelCarOrdBtn_Click(object sender, EventArgs e)
        {
            ord.removeCarOrder();
            ord.CalculateTotalOrderAmount();
        }

        private void adOrdPartGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void adOrdCarAmntBox_TextChanged(object sender, EventArgs e)
        {
            // Update the total order amount
            //ord.CalculateTotalOrderAmount();
        }

        private void adOrdCarQtyBox_TextChanged(object sender, EventArgs e)
        {
            // Calculate the car order amount
            ord.calculateCarOrderAmount();

            // Update the total order amount
            //ord.CalculateTotalOrderAmount();

        }

        private void adOrdPartQtyBox_TextChanged(object sender, EventArgs e)
        {
            // Calculate the part order amount
            ord.calculatePartOrderAmount();

            // Update the total order amount
            //ord.CalculateTotalOrderAmount();
        }

        private void carCheck_CheckedChanged(object sender, EventArgs e)
        {
            ord.checkBox_CheckedChanged(sender, e);
            ord.CalculateCarTotalAmount();
        }

        private void partCheck_CheckedChanged(object sender, EventArgs e)
        {
            ord.checkBox_CheckedChanged(sender, e);
            ord.CalculateCarTotalAmount();
        }

        private void adPartOrdTotBox_TextChanged(object sender, EventArgs e)
        {
            //ord.CalculateTotalOrderAmount();
        }

        private void adCarOrdTotBox_TextChanged(object sender, EventArgs e)
        {
            //ord.CalculateTotalOrderAmount();
        }

        private void adOrdPartAmntBox_TextChanged(object sender, EventArgs e)
        {
            // Update the total order amount
            //ord.CalculateTotalOrderAmount();
        }

        private void adOrdDisCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void adTotAmntBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void adOrdSaveBtn_Click_1(object sender, EventArgs e)
        {
            ord.saveOrder();
        }

        private void adOrdUpdateBtn_Click_1(object sender, EventArgs e)
        {
            ord.updateOrder();
        }

        private void adOrdDltBtn_Click_1(object sender, EventArgs e)
        {
            ord.deleteOrder();
        }

        private void adOrdIdCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ord.checkOrdID();
        }

        private void adOrdIdCombo_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
