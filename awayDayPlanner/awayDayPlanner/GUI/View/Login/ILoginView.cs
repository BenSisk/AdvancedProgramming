﻿using awayDayPlanner.GUI.Presenter.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awayDayPlanner.GUI
{
    public interface ILoginView
    {
        string Username { get;}
        string Password { get;}

        ILoginPresenter Presenter { set; }

        void Message(string message);

        void Reset();
    }
}
