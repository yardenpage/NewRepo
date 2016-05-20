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
{/// <summary>
/// this class inherit ACommand- commnd to generate 3dmaze
/// </summary>
    public class Generate3dMazeCommand : ACommand
    {
        /// <summary>
        /// constructor of Generate3dMazeCommand
        /// </summary>
        /// <param name="imodel"></param>
        /// <param name="iview"></param>
        public Generate3dMazeCommand(IModel imodel, IView iview) : base(imodel, iview)
        {

        }
        /// <summary>
        /// function that generate 3dmaze
        /// </summary>
        /// <param name="parameters"></param>
        public override void DoCommand(params string[] parameters)
        {
            int[] a = new int[parameters.Length - 1];
            int value;
            for (int i = 1; i <= a.Length; i++)
            {
                int.TryParse(parameters[i], out value);
                a[i - 1] = value;
            }
            m_model.GenerateInNewThread(parameters[0], a);
            //m_view.Output(m_model.GenerateInNewThread(parameters[0], a));
        }

        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>
        public override string GetName()
        {
            return "generate3dmaze";
        }
        public void Output(String s)
        {
            m_view.Output(s);
        }
    }
}