using ATP2016Project.Controller;
using ATP2016Project.Model;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{
    public abstract class ACommand: ICommand
    {
        protected IView m_view;
        protected IModel m_model;

        public ACommand(IModel imodel, IView iview)
        {
            m_view = iview;
            m_model = imodel;
            
        }
        public abstract void DoCommand(params string[] parameters);
        public abstract string GetName();
    }
}
