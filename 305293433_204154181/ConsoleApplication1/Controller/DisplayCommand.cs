using ATP2016Project.Model;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{
    public class DisplayCommand : ACommand
    {
        public DisplayCommand(IModel imodel, IView iview) :base(imodel, iview)
        {

        }
        public override void DoCommand(params string[] parameters)
        {
            AMaze maze = m_model.GetDisplay(parameters[0]);
            m_view.DisplayMaze(maze);
        }

        public override string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
