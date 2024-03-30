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
    public partial class adminGoodServiceForm : UserControl
    {
        private adminCarDetailClass cd;
        private adminPartClass ap;

        public adminGoodServiceForm()
        {
            InitializeComponent();
            cd = new adminCarDetailClass(this);
            ap = new adminPartClass(this);

        }

        private void carSaveBtn_Click(object sender, EventArgs e)
        {
            cd.saveCar();
        }

        private void carUpdBtn_Click(object sender, EventArgs e)
        {
            cd.updCar();
        }

        private void carDltBtn_Click(object sender, EventArgs e)
        {
            cd.deleteCar();
        }

        private void carClrBtn_Click(object sender, EventArgs e)
        {
            cd.clearFields();
        }

        private void adminGoodServiceForm_Load(object sender, EventArgs e)
        {
            //For Car
            cd.loadCarIDs();
            cd.viewGrid();

            //For SparePart
            ap.loadPartIDs();
            ap.viewGrid();
        }

        private void carDetailGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cd.cellClickView(sender, e);
            
        }

        private void partDetailGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ap.cellClickView(sender, e);
        }

        private void partSaveBtn_Click(object sender, EventArgs e)
        {
            ap.savePart();
        }

        private void partDltBtn_Click(object sender, EventArgs e)
        {
            ap.deletePart();
        }

        private void partUpdateBtn_Click(object sender, EventArgs e)
        {
            ap.updPart();
        }

        private void partClrBtn_Click(object sender, EventArgs e)
        {
            ap.clearFields();
        }

        private void carRptBtn_Click(object sender, EventArgs e)
        {
            AdminCarReportForm carReport = new AdminCarReportForm();
            carReport.Show();
        }
    }
}
