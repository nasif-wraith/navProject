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
    public partial class Rank : Form
    {
        private UserModel _currentUser;
        public Rank()
        {
            InitializeComponent();
        }

        public Rank(UserModel currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
