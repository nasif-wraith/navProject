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
    public partial class RegistrationFormMain : Form
    {
        #region private Field
        private UserModel _currentUser;
        private Form _previousForm;
        private EmployeeRegistrationView _employeeRegistrationView ;
        private UserAdd _userAdd;
        private Rank _rank ;
        private BranchCreateView _branch;
        private DepartmentCreateView _dept;
        #endregion

        #region Ctor
        public RegistrationFormMain()
        {
            InitializeComponent();

        }
        public RegistrationFormMain(UserModel currentUser, Form prevForm)
            
        {
            InitializeComponent();
            _currentUser = currentUser;
            _previousForm = prevForm;
            initAllForm();
        }

        public void initAllForm()
        {
            _employeeRegistrationView = new EmployeeRegistrationView(_currentUser, _previousForm);
            _userAdd = new UserAdd(_currentUser,_previousForm);
            _rank = new Rank(_currentUser,_previousForm);
            _branch = new BranchCreateView(_currentUser, _previousForm);
            _dept = new DepartmentCreateView(_currentUser, _previousForm);
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        void formClose()
        {
            //this.Hide();
            //_previousForm.Show();
            this.Close();
        }
        void showHideUserInfo(bool isShow)
        {
            if(isShow)
            {
                UserNameLabel.Visible = isShow;
                UserPicBox.Visible = isShow;
                LogoutExitLink.Visible = isShow;
                RankLabel.Visible = isShow;
                VersionInfoLabel.Visible = isShow;
                CompanyInfo.Visible = isShow;
                CenterPictureBox.Visible = isShow;
            }
            else
            {
                UserNameLabel.Visible = isShow;
                UserPicBox.Visible = isShow;
                LogoutExitLink.Visible = isShow;
                RankLabel.Visible = isShow;
                VersionInfoLabel.Visible = isShow;
                CompanyInfo.Visible = isShow;
                CenterPictureBox.Visible = isShow;
            }

        }
        #endregion

        #region private Event or CallBack
        private void MinimizedBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            formClose();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formClose();
        }
        

        private void showBasicUserInfo(object sender, FormClosedEventArgs e)
        {
           // throw new NotImplementedException();
            showHideUserInfo(true);
        }
        
        private void LogoutExitLink_Click(object sender, EventArgs e)
        {
            formClose();
        }
        #endregion

        #region one instance will open methods
        private void RankAddMS_Click(object sender, EventArgs e)
        {
            if (_branch != null)
            {
                _branch.Hide();
            }
            if (_userAdd != null)
            {
                _userAdd.Hide();
            }
            if (_dept != null)
            {
                _dept.Hide();
            }
            if (_employeeRegistrationView != null)
            {
                _employeeRegistrationView.Hide();
            }
            showHideUserInfo(false);
            //_rank = new Rank(_currentUser, _previousForm);
            _rank.MdiParent = this;
            _rank.Show();
            _rank.FormClosed += showBasicUserInfo;
            
        }
        private void BranchAddMS_Click(object sender, EventArgs e)
        {
            if (_rank != null)
            {
                _rank.Hide();
            }
            if (_userAdd != null)
            {
                _userAdd.Hide();
            }
            if (_dept != null)
            {
                _dept.Hide();
            }
            if (_employeeRegistrationView != null)
            {
                _employeeRegistrationView.Hide();
            }          
            showHideUserInfo(false);
            //_branch = new BranchCreateView(_currentUser, _previousForm);
            //_branch.MdiParent = this;
            _branch.Show();
            _branch.FormClosed += showBasicUserInfo;
            
        }
        private void EmployeeAddMS_Click(object sender, EventArgs e)
        {
            
            showHideUserInfo(false);
            //_employeeRegistrationView = new EmployeeRegistrationView(_currentUser,_previousForm);
            // Set the Parent Form of the Child window.
            _employeeRegistrationView.MdiParent = this;
            // Display the new form.
            _employeeRegistrationView.Show();
            _employeeRegistrationView.FormClosed += showBasicUserInfo;
            if (_rank!=null)
            {
                _rank.Hide();
            }
            if (_userAdd != null)
            {
                _userAdd.Hide();
            }
            if (_dept != null)
            {
                _dept.Hide();
            }
            if (_branch !=null)
            {
                _branch.Hide();
            }
            
        }
        private void AddDepartmentMS_Click(object sender, EventArgs e)
        {
            if (_branch != null)
            {
                _branch.Hide();
            }
            if (_userAdd != null)
            {
                _userAdd.Hide();
            }
            if (_rank != null)
            {
                _rank.Hide();
            }
            if (_employeeRegistrationView != null)
            {
                _branch.Hide();
            }
            showHideUserInfo(false);
            //_dept = new DepartmentCreateView(_currentUser, _previousForm);
            _dept.MdiParent = this;
            _dept.Show();
            _dept.FormClosed += showBasicUserInfo;
        }
        private void UserAddMS_Click(object sender, EventArgs e)
        {
            if (_branch != null)
            {
                _branch.Hide();
            }
            if (_rank != null)
            {
                _rank.Hide();
            }
            if (_dept != null)
            {
                _dept.Hide();
            }
            if (_employeeRegistrationView != null)
            {
                _employeeRegistrationView.Hide();
            }
            showHideUserInfo(false);

            //_userAdd = new UserAdd(_currentUser, _previousForm);
            _userAdd.MdiParent = this;
            _userAdd.Show();
            _userAdd.FormClosed += showBasicUserInfo;
        }
        #endregion

      
    }
}
