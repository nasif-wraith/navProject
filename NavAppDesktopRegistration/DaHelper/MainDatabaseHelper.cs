using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NavAppDesktopRegistration
{
    class MainDatabaseHelper
    {
        string connection()
        {
            //string connectionString = @"Data Source=192.168.0.105,49170;Initial Catalog=FInal_navy ;User ID=sa;Password=sa";
            string connectionString = @"Data Source=DESKTOP-AG0F2UT\NASIF;Initial Catalog=FInal_navy;Integrated Security=True";
            return connectionString;
        }
        
        public int RunQuerryInBranch(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(connection());
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            int BranchID = int.Parse(cmd.Parameters["@BranchID"].Value.ToString());
            con.Close();
            return BranchID;
        }

        public int RunQuerryInEmployee(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(connection());
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            int employeeID = int.Parse(cmd.Parameters["@EmployeeID"].Value.ToString());
            con.Close();
            return employeeID;
        }
    }
}
