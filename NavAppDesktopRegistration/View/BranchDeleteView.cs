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
    public partial class BranchDeleteView : Form
    {
        private UserModel _currentUser;
        private Form _previousForm;
        BranchModel branchModel;
        DatabaseHelper dbhelper;
        public BranchDeleteView()
        {
            InitializeComponent();
        }

        public BranchDeleteView(UserModel CurrentUser, Form previousForm)
        {
            InitializeComponent();
            _currentUser = CurrentUser;
            _previousForm = previousForm;
        }

        private void btnGetBranchID_Click(object sender, EventArgs e)
        {
           
            branchModel = new BranchModel();
            branchModel.BranchID = Int32.Parse(tbBranchID.Text);
            dbhelper = new DatabaseHelper();
            branchModel = dbhelper.SelectAllFromBranch(branchModel, _currentUser);
            //branchModel.BranchName = tbBranchName.Text;
            //branchModel.Address = tbBranchAddress.Text;
            //branchModel.Contact = tbContact.Text;
            tbBranchAddress.Text = branchModel.Address;
            tbBranchName.Text = branchModel.BranchName;
            tbContact.Text = branchModel.Contact;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            branchModel = new BranchModel();
            dbhelper = new DatabaseHelper();

            branchModel.BranchID = Int32.Parse(tbBranchID.Text);
            dbhelper.DeleteFromBranch(branchModel);
        }
    }
}
