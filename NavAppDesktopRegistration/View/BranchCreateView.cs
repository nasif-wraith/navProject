﻿using System;
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
    public partial class BranchCreateView : Form
    {
        #region private var
        private UserModel _currentUser;
        private Form _prevform;
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
     
    }
}