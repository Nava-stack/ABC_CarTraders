using ABC_CarTraders.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ABC_CarTraders.AppClass
{
    internal class adminDashClass : com
    {
        public adminDashClass() { }


        private Label _customer, _order, _employee, _supplier;
        private adminDashForm form;
        private Chart _revenue, _appointment;


        public adminDashClass(adminDashForm adForm)
        {
            this.form = adForm;
            _customer = adForm.totalCusLbl;
            _order = adForm.totalOrdLbl;
            _employee = adForm.totalEmpLbl;
            _supplier = adForm.totalSupLbl;
            _revenue = adForm.revenueChart;
            _appointment = adForm.appointChart;

        }

        public void displayCustomer()
        {
            dashBoardLabelView("SELECT COUNT(cusID) FROM Customer", _customer);
        }

        public void displayOrder()
        {
            dashBoardLabelView("SELECT COUNT(orderID) FROM [Order]", _order);
        }

        public void displayEmployee()
        {
            dashBoardLabelView("SELECT COUNT(empID) FROM Employee", _employee);
        }

        public void displaySupplier()
        {
            dashBoardLabelView("SELECT SUM(totalCount) AS TotalCount FROM ( SELECT COUNT(p_supplierID) AS totalCount FROM PartSupplier UNION ALL SELECT COUNT(c_supplierID) AS totalCount FROM CarSupplier) AS CombinedCounts", _supplier);
        }


        public void chartRevenue()
        {
            using (ABC_Car_TradersDBEntities db = new ABC_Car_TradersDBEntities())
            {
                _revenue.DataSource = db.Revenues.ToList();
                _revenue.Series["Revenue"].XValueMember = "year";
                _revenue.Series["Revenue"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                _revenue.Series["Revenue"].YValueMembers = "total";
                _revenue.Series["Revenue"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            }
        }

        public void chartAppoint()
        {
            _appointment.Series["No of Appointment"].Points.AddXY("Jan", 400);
            _appointment.Series["No of Appointment"].Points.AddXY("Feb", 100);
            _appointment.Series["No of Appointment"].Points.AddXY("Mar", 600);
            _appointment.Series["No of Appointment"].Points.AddXY("Apr", 800);
            _appointment.Series["No of Appointment"].Points.AddXY("May", 400);
            _appointment.Series["No of Appointment"].Points.AddXY("Jun", 200);
        }
    }
}
