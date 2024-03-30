using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABC_CarTraders.CommonClass;

namespace ABC_CarTraders.AppClass
{
    internal class Admin: com
    {

        public bool adminLoginAuth(string username, string pass)
        {
            bool loginStatus = false;
            try
            {
                string sql = $"SELECT * FROM Admin WHERE uname = '{username}' and pword = '{pass}'";
                DataTable dt = getDataFromDB(sql);
                if (dt.Rows.Count > 0)
                {
                    loginStatus = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Failure:"+ ex.Message);
            }
            return loginStatus;
        }
    }
}
