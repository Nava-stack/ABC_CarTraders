using ABC_CarTraders.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_CarTraders
{
    internal class ReportClass : com
    {
        public ReportClass() { }    

        private ReportForm reportForm;
        public ReportClass(ReportForm rForm)
        {
            this.reportForm = rForm;

        }
    }
}
