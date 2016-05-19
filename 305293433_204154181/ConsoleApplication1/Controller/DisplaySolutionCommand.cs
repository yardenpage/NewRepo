using ATP2016Project.Model;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{/// <summary>
/// this class inherit ACommand- commnd to display solution of the maze in the given name
/// </summary>
    public class DisplaySolutionCommand : ACommand
    {
        /// <summary>
        /// constructor of  DisplaySolutionCommand
        /// </summary>
        /// <param name="imodel"></param>
        /// <param name="iview"></param>
        public DisplaySolutionCommand(IModel imodel, IView iview) :base(imodel, iview)
        {

        }
        /// <summary>
        /// function to display the solution of the maze given name
        /// </summary>
        /// <param name="parameters"></param>
        public override void DoCommand(params string[] parameters)
        {
            string s = m_model.GetDisplaySolution(parameters[0]);
            if(s==null)
                m_view.Output("maze name" + parameters[0] + "doesn't exist!");
            else
                m_view.Output(s);
        }
        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>
        public override string GetName()
        {
          return  "display solution";
        }
    }
}
