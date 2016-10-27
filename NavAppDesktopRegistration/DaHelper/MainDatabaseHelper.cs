using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NavAppDesktopRegistration
{
    class MainDatabaseHelper
    {
        string connection()
        {
            //string connectionString = @"Data Source=192.168.0.104,49170;Initial Catalog=beta_2 ;User ID=sa;Password=sa";
            string connectionString = @"Data Source=.;Initial Catalog=beta_2;Integrated Security=True";
            return connectionString;
        }
        
        public int RunQuerryInBranch(SqlCommand cmd)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection());
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                int BranchID = Int32.Parse(cmd.Parameters["@BranchID"].Value.ToString());
                con.Close();
                return BranchID;
            }
            catch (Exception e)
            {
                MessageBox.Show("run querry in branch a  ganjam hoise \n\n" + e, "baal hoy nai!!");
                throw;
            }

        }

        public void RunUpdateInBranch(SqlCommand cmd)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection());
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                //int BranchID = Int32.Parse(cmd.Parameters["@BranchID"].Value.ToString());
                con.Close();
               // return BranchID;
            }
            catch (Exception e)
            {
                MessageBox.Show("run querry in branch a  ganjam hoise \n\n" + e, "baal hoy nai!!");
                throw;
            }

        }

        public int RunQuerryInEmployee(SqlCommand cmd)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection());
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                int employeeID = int.Parse(cmd.Parameters["@EmployeeID"].Value.ToString());
                con.Close();
                return employeeID;
            }
            catch (Exception e)
            {
                MessageBox.Show("problem occured" + e);
                throw;
            }
            
        }

        public int RunQueryInDepartment(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(connection());
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            int DepartmentID = int.Parse(cmd.Parameters["@DepartmentID"].Value.ToString());
            con.Close();
            return DepartmentID;
        }

        public BranchModel GetDataFromBranch(SqlCommand cmd, BranchModel branch)
        {
            //try
            //{
                //BranchModel branch =  new BranchModel();
                SqlConnection con = new SqlConnection(connection());
                cmd.Connection = con;
                con.Open();
            SqlDataReader reader = null;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                branch.BranchName = (reader["BranchName"].ToString());
                branch.Contact = (reader["Contact"].ToString());
                branch.Address = (reader["Address"].ToString());
            }
                //cmd.ExecuteNonQuery();
                //branch.BranchName = cmd.Parameters["@BranchName"].Value.ToString();
                //branch.Address = cmd.Parameters["@Address"].Value.ToString();
                //branch.Contact = cmd.Parameters["@Contact"].Value.ToString();
                con.Close();
                return branch;
            //}
            //catch (Exception e )
            //{
            //    MessageBox.Show("error in MDB");
            //    throw;
            //}
           
        }
    }
}
