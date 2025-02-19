﻿using awayDayPlanner.GUI.Presenter.Login;
using awayDayPlanner.Lib.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awayDayPlanner.GUI
{
    public partial class LoginForm : Form, ILoginView
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public string Username { get { return this.txtUsername.Text; } }
        public string Password { get { return this.txtPassword.Text; } }

        public ILoginPresenter Presenter
        { 
            private get; set; 
        }

        public void Message(string message)
        {
            MessageBox.Show(message);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Presenter.Register();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Presenter.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Presenter.Submit();
        }

        public void Reset()
        {
            Presenter.Reset();
            this.txtUsername.Text = "";
            this.txtPassword.Text = "";
        }

    }
}