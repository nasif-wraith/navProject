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
    public partial class DepartmentCreateView : Form
    {
        #region private fields
        private UserModel _currentUser;
        private Form _prevForm;
        DatabaseHelper dbHelper;
        //private static DepartmentCreateView instance;
        #endregion

        #region ctor
        public DepartmentCreateView()
        {
            InitializeComponent();
        }
        public DepartmentCreateView(UserModel currentUser, Form prevForm)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _prevForm = prevForm;
        }
        #endregion

        

        #region public methods

        //public static DepartmentCreateView Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new DepartmentCreateView();
        //        }
        //        return instance;
        //    }
        //}

        #endregion

        #region event or callback
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dbHelper = new DatabaseHelper();
            DepartmentModel dept = new DepartmentModel();
            dept.DepartmentName = txtDepartmentName.Text;
            dept.CreatedBy = _currentUser.UserID;
            dept.CreatedDate = DateTime.Now;
            dept.ModifiedBy = _currentUser.UserID;
            dept.ModifiedDate = DateTime.Now;
            string connectionString = @"Data Source=DESKTOP-AG0F2UT\NASIF;Initial Catalog=FInal_navy;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            int DepartmentID = dbHelper.InsertIntoDepartment(dept,_currentUser);
            MessageBox.Show("new Department Created.\nDepartment ID : " + DepartmentID, "Success", MessageBoxButtons.OK);
        }
        #endregion
    }
}
