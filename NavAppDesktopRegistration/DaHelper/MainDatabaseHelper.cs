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
    public class MainDatabaseHelper
    {
        SqlConnection con;
        public MainDatabaseHelper()
        {
            con = new SqlConnection(connection());
        }
        string connection()
        {
            //string connectionString = @"Data Source=192.168.0.104,49170;Initial Catalog=beta_2 ;User ID=sa;Password=sa";
            string connectionString = @"Data Source=.;Initial Catalog=beta_2;Integrated Security=True";
            return connectionString;
        }

        #region for Branch
        public int RunQuerryInBranch(SqlCommand cmd)
        {
            try
            {
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
        public BranchModel GetDataFromBranch(SqlCommand cmd, BranchModel branch)
        {
            //try
            //{
            //BranchModel branch =  new BranchModel();

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
        #endregion

        #region for Employee
        public int RunQuerryInEmployee(SqlCommand cmd)
        {
            try
            {

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
        #endregion

        #region for Department
        public int RunQueryInDepartment(SqlCommand cmd)
        {

            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            int DepartmentID = int.Parse(cmd.Parameters["@DepartmentID"].Value.ToString());
            con.Close();
            return DepartmentID;
        }
        #endregion

        #region for User
        public int RunQueryInUser(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                int userID = Int32.Parse(cmd.Parameters["@UserID"].Value.ToString());
                con.Close();
                return userID;
            }
            catch (Exception e)
            {
                MessageBox.Show("problem in inserting data" + e.ToString());
                throw;
            }
        }
        #endregion

        public void Delete(SqlCommand cmd, BranchModel branch)
        {
            try
            {
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("error in deleting");
                throw;
            }
            
        }

       


    }
}
