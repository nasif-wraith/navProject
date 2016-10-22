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
        private BranchModel _branchModel;
        private DatabaseHelper _dbhelper;
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
            _branchModel = new BranchModel();
            _branchModel.BranchName = txtBranchName.Text;
            _branchModel.Address = txtBranchAddress.Text;
            _branchModel.Contact = txtContact.Text;
            _dbhelper = new DatabaseHelper();
            int id = _dbhelper.InsertInBranch(_branchModel,_currentUser);
            MessageBox.Show("Successfully Saved into Database" + id, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
