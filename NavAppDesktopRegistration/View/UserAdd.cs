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
    public partial class UserAdd : Form
    {
        #region private field
        private UserModel _currentUser;
        private Form _prevform;
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
            user.IsSuperAdmin = superAdmin_check.Checked;
            user.IsAdmin = admin_check.Checked;
            user.IsActive = Active_check.Checked;

        }
        #endregion

    }
}
