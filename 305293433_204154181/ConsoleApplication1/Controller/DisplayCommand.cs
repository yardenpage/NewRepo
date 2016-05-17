using ATP2016Project.Model;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{/// <summary>
 /// this class inherit ACommand- commnd to display a maze in the given name
 /// </summary>
    public class DisplayCommand : ACommand
    {/// <summary>
     /// cinstructor of DisplayCommand
     /// </summary>
     /// <param name="imodel"></param>
     /// <param name="iview"></param>
        public DisplayCommand(IModel imodel, IView iview) : base(imodel, iview)
        {

        }
        /// <summary>
        /// function to display a maze in the given name
        /// </summary>
        /// <param name="parameters"></param>
        public override void DoCommand(params string[] parameters)
        {
           m_model.GetDisplay(parameters[1]);
            
        }
        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>
        public override string GetName()
        {
            return "display";
        }
    }
}
