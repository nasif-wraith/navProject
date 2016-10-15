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
    public partial class EmployeeRegistrationView : Form
    {
        private UserModel _currentUser;
        public EmployeeRegistrationView()
        {
            InitializeComponent();
        }
        public EmployeeRegistrationView(UserModel currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }
    }
}
