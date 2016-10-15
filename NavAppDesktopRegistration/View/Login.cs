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
    public partial class Login : Form
    {
        #region Private Fields
        
        private UserModel _currentUser;

        #endregion

        #region Ctor
        public Login()
        {
           InitializeComponent();
           Init();
        } 
        #endregion

        #region Private Event CallBack 
        private void CloseBtn_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loginbtn_MouseEnter(object sender, EventArgs e)
        {

        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            //Check here Login Success or Not then
            //if success then 
           
            this.Hide();
            new RegistrationFormMain(_currentUser, this).Show();                       
        } 
        #endregion

        #region Private Mothods

        #endregion

        #region Public Method
        public void Init()
        {
            _currentUser = new UserModel();
        }
        #endregion
    }
}
