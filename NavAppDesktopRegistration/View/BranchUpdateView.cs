using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavAppDesktopRegistration
{
    public partial class BranchUpdateView : Form
    {
        #region private var
        private UserModel _currentUser;
        private Form _prevform;
        BranchModel branchModel;
        DatabaseHelper dbhelper;
        
        #endregion

        #region ctor

        public BranchUpdateView()
        {
            InitializeComponent();
        }

        public BranchUpdateView(UserModel currentUser, Form prevForm)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _prevform = prevForm;
        }
        #endregion

        #region event or callback

        private void btnGetBranchID_Click(object sender, EventArgs e)
        {
            branchModel = new BranchModel();
            branchModel.BranchID =Int32.Parse(tbBranchID.Text);
            dbhelper = new DatabaseHelper();
            branchModel = dbhelper.SelectAllFromBranch(branchModel, _currentUser);
            //branchModel.BranchName = tbBranchName.Text;
            //branchModel.Address = tbBranchAddress.Text;
            //branchModel.Contact = tbContact.Text;
            tbBranchAddress.Text = branchModel.Address;
            tbBranchName.Text = branchModel.BranchName;
            tbContact.Text = branchModel.Contact;
            branchModel = null;
        }

        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            branchModel = new BranchModel();
            dbhelper = new DatabaseHelper();

            branchModel.BranchID = Int32.Parse(tbBranchID.Text);
            branchModel.BranchName = tbBranchName.Text;
            branchModel.Address = tbBranchAddress.Text;
            branchModel.Contact = tbContact.Text;
            //int ID = 
                dbhelper.UpdateInBranch(branchModel, _currentUser);
            MessageBox.Show("success");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
