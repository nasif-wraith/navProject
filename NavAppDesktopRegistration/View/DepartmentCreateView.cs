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
    public partial class DepartmentCreateView : Form
    {
        #region private fields
        private UserModel _currentUser;
        private Form _prevForm;
        //private static DepartmentCreateView instance;
        #endregion

        #region ctor
        public DepartmentCreateView()
        {
            InitializeComponent();
        }
        public DepartmentCreateView(UserModel currentUser, Form prevForm)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _prevForm = prevForm;
        }
        #endregion

        #region public methods

        //public static DepartmentCreateView Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new DepartmentCreateView();
        //        }
        //        return instance;
        //    }
        //}

        #endregion
    }
}
