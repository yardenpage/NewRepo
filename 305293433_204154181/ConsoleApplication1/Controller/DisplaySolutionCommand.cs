using ATP2016Project.Model;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{
    public class DisplaySolutionCommand : ACommand
    {
        public DisplaySolutionCommand(IModel imodel, IView iview) :base(imodel, iview)
        {

        }
        public override void DoCommand(params string[] parameters)
        {
            m_view.Output(m_model.GetDisplaySolution(parameters[0]));
        }

        public override string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
