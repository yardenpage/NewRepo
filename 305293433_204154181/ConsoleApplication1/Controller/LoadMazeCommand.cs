using ATP2016Project.Model;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{/// <summary>
/// this class inherit ACommand- commnd to load a maze from current path
/// </summary>
    public class LoadMazeCommand : ACommand
    {
        /// <summary>
        /// constructor of LoadMazeCommand
        /// </summary>
        /// <param name="imodel"></param>
        /// <param name="iview"></param>
        public LoadMazeCommand(IModel imodel, IView iview) : base(imodel, iview)
        {

        }
        /// <summary>
        /// function that load the maze from a file and call it in his name
        /// </summary>
        /// <param name="parameters">path'name</param>
        public override void DoCommand(params string[] parameters)
        {
            m_model.GetLoadMaze(parameters[1], parameters[2]);

        }
        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>
        public override string GetName()
        {
            return "loadmaze";
        }
    }
}
