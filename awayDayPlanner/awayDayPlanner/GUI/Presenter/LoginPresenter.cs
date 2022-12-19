﻿using awayDayPlanner.GUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using awayDayPlanner.GUI.Model;

namespace awayDayPlanner.GUI
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly ILoginModel _model;

        public LoginPresenter(ILoginView view, ILoginModel model)
        {
            _view = view;
            view.Presenter = this;
            _model = model;
        }

        public void Register()
        {
            _model.Register();
        }

        public void Close()
        {
            _model.Close();
        }
    }
}
