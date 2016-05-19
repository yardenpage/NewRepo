using ATP2016Project.Model;
using ATP2016Project.View;
using ATP2016Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{/// <summary>
/// this class inherit ACommand- commnd to get files and dirs in the given path
/// </summary>
    public class DirCommand : ACommand
    {/// <summary>
     /// constructor of DirCommand
     /// </summary>
     /// <param name="imodel"></param>
     /// <param name="iview"></param>
        public DirCommand(IModel imodel, IView iview) : base(imodel, iview)
        {

        }
        /// <summary>
        /// function that get the files and dirs in the given path and display them
        /// </summary>
        /// <param name="parameters">path</param>
        public override void DoCommand(params string[] parameters)
        {
            m_view.Output(m_model.GetDir(parameters[0]));
            //  m_view.Output(m_model.GetDir(parameters[1]));
        }
        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>
        public override string GetName()
        {
            return "dir";
        }

    }
}
