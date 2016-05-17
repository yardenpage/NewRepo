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
    /// <summary>
    /// an abstact class that implement ICommand interface
    /// </summary>
    public abstract class ACommand: ICommand
    {
    
        protected IView m_view;
        protected IModel m_model;
        /// <summary>
        /// constructor of ACommand
        /// </summary>
        /// <param name="imodel"></param>
        /// <param name="iview"></param>
        public ACommand(IModel imodel, IView iview)
        {
            m_view = iview;
            m_model = imodel;
            
        }/// <summary>
        /// function that call the model implimentation and disply it if its neccesry
        /// </summary>
        /// <param name="parameters"></param>
        public abstract void DoCommand(params string[] parameters);
        /// <summary>
        /// return the name of the command
        /// </summary>
        /// <returns>name</returns>
        public abstract string GetName();
    }
}
