using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavAppDesktopRegistration
{
    public partial class UserAdd : Form
    {
        #region private field
        private UserModel _currentUser;
        private Form _prevform;
        DatabaseHelper DBhelp;
        #endregion

        #region ctor
        public UserAdd()
        {
            InitializeComponent();
        }
        public UserAdd(UserModel currentUser, Form prevform)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _prevform = prevform;
            showHideMenuItem(_currentUser);
        }

        #endregion

        #region private Method
        void showHideMenuItem(UserModel currentUser)
        {
            if (currentUser.IsAdmin)
            {
                SuperAdminChk.Hide();
                AdminChk.Hide();
            }
        }
        #endregion

        #region event or callBack
        private void AddUser_Click(object sender, EventArgs e)
        {
            
            string password = UserPassword.Text;
            UserModel user = new UserModel();
            user.EmployeeID = Int32.Parse(UserEmployeeID_box.Text);
            user.Password = UserPassword.Text;
            user.PreviousPassword = UserPreviousPassword.Text;
            user.IsSuperAdmin = SuperAdminChk.Checked;
            user.IsAdmin = AdminChk.Checked;
            user.IsActive = Active_check.Checked;
            user.UserName = tbUser_name.Text;

            DBhelp = new DatabaseHelper();
            user.UserID = DBhelp.InsertIntoUser(user, _currentUser);
            MessageBox.Show("uploaded" + user.UserID);




            //string connectionString = @"Data Source=DESKTOP-AG0F2UT\NASIF;Initial Catalog=FInal_navy;Integrated Security=True";
            //SqlConnection con = new SqlConnection(connectionString);
            //con.Open();
            //SqlCommand cmd = new SqlCommand("in_Users", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@EmployeeID", user.EmployeeID);
            //cmd.Parameters.AddWithValue("@IsSuperAdmin", user.IsSuperAdmin);
            //cmd.Parameters.AddWithValue("@Password", user.Password);
            //cmd.Parameters.AddWithValue("@PreviousPasswords", user.PreviousPassword);
            //cmd.Parameters.AddWithValue("@Hierarchy",0 );
            //cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
            //cmd.Parameters.AddWithValue("@CreatedBy", _currentUser.UserID);
            //cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            //cmd.Parameters.AddWithValue("@ModifiedBy", _currentUser.UserID);
            //cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            //cmd.Parameters.AddWithValue("@IsAdmin", user.IsActive);
            //cmd.Parameters.AddWithValue("@UserName", user.UserName);

            //SqlParameter UserId = new SqlParameter()
            //{
            //    ParameterName = "@UserID",
            //    Value = -1,
            //    Direction = ParameterDirection.Output
            //};
            //cmd.Parameters.Add(UserId);

            //cmd.ExecuteNonQuery();
            //con.Close();

           // MessageBox.Show("everything is uploaded", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion

    }
}
