using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABC_CarTraders.AppClass;
using ABC_CarTraders.CommonClass;

namespace ABC_CarTraders
{
    public partial class adminCustomerForm : UserControl
    {
        private adminCustomerDetailClass adCus; 

        public adminCustomerForm()
        {
            InitializeComponent();
            adCus = new adminCustomerDetailClass(this);
        }



        private void adminCustomerForm_Load(object sender, EventArgs e)
        {
            adCus.loadCusIDs();
            adCus.viewGrid();
        }

        private void adCusImgBtn_Click(object sender, EventArgs e)
        {
            adCus.cusImageImport();
        }

        private void adCusSaveBtn_Click(object sender, EventArgs e)
        {
            adCus.saveCus();
        }

        private void cusShowPass_CheckedChanged(object sender, EventArgs e)
        {
            adCusPwordBox.PasswordChar = cusShowPass.Checked ? '\0' : '*';
        }

        private void adCusUpdateBtn_Click(object sender, EventArgs e)
        {
            adCus.updateCus();
        }

        private void adCusDltBtn_Click(object sender, EventArgs e)
        {
            adCus.deleteCus();
        }

        private void adCusClrBtn_Click(object sender, EventArgs e)
        {
            adCus.clearFields();
        }

        private void adCusDetailGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            adCus.cellClickView(sender,e);
        }
    }
}
