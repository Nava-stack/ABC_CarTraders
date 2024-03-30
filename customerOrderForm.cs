using ABC_CarTraders.AppClass;
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
    public partial class customerOrderForm : UserControl
    {
        private customerOrderClass ord;

       
        public customerOrderForm()
        {
            InitializeComponent();
            ord = new customerOrderClass(this);
            ord.initGrids();
            
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

        private void cusOrdPartQtyBox_TextChanged(object sender, EventArgs e)
        {
            ord.calculatePartOrderAmount();
        }

        private void cusOrdCarQtyBox_TextChanged(object sender, EventArgs e)
        {
            ord.calculateCarOrderAmount();
        }

        private void partCheck_CheckedChanged(object sender, EventArgs e)
        {
            ord.checkBox_CheckedChanged(sender, e);
            ord.CalculateCarTotalAmount();
        }

        private void carCheck_CheckedChanged(object sender, EventArgs e)
        {
            ord.checkBox_CheckedChanged(sender, e);
            ord.CalculateCarTotalAmount();
        }

        private void cusOrdAddBtn_Click(object sender, EventArgs e)
        {
            
            ord.saveOrder();
        }

        private void customerOrderForm_Load(object sender, EventArgs e)
        {
            ord.loadOrdIDs();
        }
    }
}
