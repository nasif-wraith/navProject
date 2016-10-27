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
        #region private field
        private UserModel _currentUser;
        private Form _prevForm;
        #endregion
        #region ctor
        public Rank()
        {
            InitializeComponent();
        }

        public Rank(UserModel currentUser, Form prevForm)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _prevForm = prevForm;
        }
        #endregion

        #region events or callback
        private void addRank_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
