using ATP2016Project.Model;
using ATP2016Project.View;
using ATP2016Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using System.Collections;

namespace ATP2016Project.Controller
{
    public class Generate3dMazeCommand : ACommand
    {

        public Generate3dMazeCommand(IModel imodel, IView iview) : base(imodel, iview)
        {

        }

        public override void DoCommand(params string[] parameters)
        {
            int[] a = new int[parameters.Length - 1];
            int value;
            for (int i = 1; i <= a.Length; i++)
            {
                int.TryParse(parameters[i], out value);
                a[i - 1] = value;
            }
            m_view.Output(m_model.GetGenerate3dMaze(parameters[0], a));
        }


        public override string GetName()
        {
            throw new NotImplementedException();
        }
    }
}