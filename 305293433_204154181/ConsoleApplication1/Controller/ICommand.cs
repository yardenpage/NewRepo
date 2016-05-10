﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{
    public interface ICommand
    {
        void DoCommand(params string[] parameters);
        string GetName();
    }
}
