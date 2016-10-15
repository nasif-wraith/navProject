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
            _employeeRegistrationView = new EmployeeRegistrationView(_currentUser);
            _userAdd = new UserAdd(_currentUser);
            _rank = new Rank(_currentUser);
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
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHideUserInfo(false);
            //_employeeRegistrationView = new EmployeeRegistrationView(_currentUser);
            // Set the Parent Form of the Child window.
            _employeeRegistrationView.MdiParent = this;
            // Display the new form.
            _employeeRegistrationView.Show();
            _employeeRegistrationView.FormClosed += showBasicUserInfo;
            _rank.Hide();
            _userAdd.Hide();
        }

        private void showBasicUserInfo(object sender, FormClosedEventArgs e)
        {
           // throw new NotImplementedException();
            showHideUserInfo(true);
        }
        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showHideUserInfo(false);
            //UserAdd userObj = new UserAdd(_currentUser);
            _userAdd.MdiParent = this;
            _userAdd.Show();
            _rank.Hide();
            _employeeRegistrationView.Hide();
            _userAdd.FormClosed += showBasicUserInfo;


        }
        private void LogoutExitLink_Click(object sender, EventArgs e)
        {
            formClose();
        }
        #endregion

        private void rankAdd_Click(object sender, EventArgs e)
        {
            showHideUserInfo(false);
            //Rank rank = new Rank(_currentUser);
            _rank.MdiParent = this;
            _rank.Show();
            _userAdd.Hide();
            _rank.FormClosed += showBasicUserInfo;
            _employeeRegistrationView.Hide();
        }

      

       

       

        

      
    }
}
