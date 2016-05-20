using ATP2016Project.Controller;
using ATP2016Project.Model;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{/// <summary>
/// this class inherit ACommand- commnd to get the maze size in bytes
/// </summary>
    public class MazeSizeCommand : ACommand
    {/// <summary>
     /// constructor of MazeSizeCommand
     /// </summary>
     /// <param name="imodel"></param>
     /// <param name="iview"></param>
        public MazeSizeCommand(IModel imodel, IView iview) :base(imodel, iview)
        {

        }
        /// <summary>
        /// function to get the maze size in bytes and display it
        /// </summary>
        /// <param name="parameters"></param>
        public override void DoCommand(params string[] parameters)
        {
            m_view.Output(m_model.GetMazeSize(parameters[0]));
        }
        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>
        public override string GetName()
        {
           return "mazesize";
        }
    }
}
