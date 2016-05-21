using ATP2016Project.Model;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{/// <summary>
/// this class inherit ACommand- commnd to exit
/// </summary>
    public class ExitCommand : ACommand
    {/// <summary>
     /// constructor of ExitCommand
     /// </summary>
     /// <param name="imodel"></param>
     /// <param name="iview"></param>
        public ExitCommand(IModel imodel, IView iview) :base(imodel, iview)
        {

        }
        /// <summary>
        /// commend that exit 
        /// </summary>
        /// <param name="parameters"></param>
        public override void DoCommand(params string[] parameters)
        {
            m_model.GetExit();
        }
        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>
        public override string GetName()
        {
            return "exit";
        }
    }
}
