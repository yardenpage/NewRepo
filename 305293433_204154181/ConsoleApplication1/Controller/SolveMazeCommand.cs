using ATP2016Project.Model;
using ATP2016Project.Model.Algorithms.Search;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{/// <summary>
/// this class inherit ACommand- to find the solution by a given algorithem
/// </summary>
    public class SolveMazeCommand : ACommand
    {/// <summary>
     /// constructor of SolveMazeCommand
     /// </summary>
     /// <param name="imodel"></param>
     /// <param name="iview"></param>
        public SolveMazeCommand(IModel imodel, IView iview) :base(imodel, iview)
        {

        }/// <summary>
         /// function to find the solution by a given algorithem
         /// </summary>
         /// <param name="parameters"></param>
        public override void DoCommand(params string[] parameters)
        {
            m_view.Output(m_model.GetSolveMaze(parameters[0]));
        }
        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>
        public override string GetName()
        {
            return "solvemaze";
        }
    }
}
