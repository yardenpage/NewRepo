﻿using ATP2016Project.Model;
using ATP2016Project.View;
using ATP2016Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{
    public class Dir : ACommand
    {
        public Dir(IModel imodel, IView iview) :base(imodel, iview)
        {

        }
        public override void DoCommand(params string[] parameters)
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
