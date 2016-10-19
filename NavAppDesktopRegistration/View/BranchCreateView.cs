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
    public partial class BranchCreateView : Form
    {
        #region private var
        private UserModel _currentUser;
        private Form _prevform;
        //private static BranchCreateView instance = null;
        #endregion

        #region ctro
        public BranchCreateView()
        {
            InitializeComponent();
        }

        public BranchCreateView(UserModel currentUser, Form prevForm)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _prevform = prevForm;
        }
        #endregion

        #region public methods
        //public static BranchCreateView Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new BranchCreateView();
        //        }
        //        return instance;
        //    }
        //}
        #endregion

        #region callback or event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            BranchModel branchModel = new BranchModel();
            branchModel.BranchName = txtBranchName.Text;
            branchModel.Address = txtBranchAddress.Text;
            branchModel.Contact = txtContact.Text;
            //branchModel.DepartmentID = Int32.Parse(txtDepartmentID.Text);

            //string connectionString = @"Data Source=DESKTOP-AG0F2UT\NASIF;Initial Catalog=FInal_navy;Integrated Security=True";
            string connectionString = @"Data Source=192.168.0.107,49170;Initial Catalog=FInal_navy ;User ID=sa;Password=sa";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Branch_in", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchName", branchModel.BranchName);
            cmd.Parameters.AddWithValue("@Address", branchModel.Address);
            cmd.Parameters.AddWithValue("@Contact", branchModel.Contact);
            //cmd.Parameters.AddWithValue("@DepartmentID", branchModel.DepartmentID);
            cmd.Parameters.AddWithValue("@CreatedBy", _currentUser.UserID);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedBy", _currentUser.UserID);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            //SqlParameter BranchId = new SqlParameter()
            //{
            //    ParameterName = "@BranchID",
            //    Value = -1,
            //    Direction = ParameterDirection.Output
            //};
            //cmd.Parameters.Add(BranchId);
            cmd.Parameters.Add("@BranchID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int NewQuoteNumber = int.Parse(cmd.Parameters["@BranchID"].Value.ToString());
            con.Close();

        }
        #endregion
    }
}
