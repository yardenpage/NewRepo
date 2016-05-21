using ATP2016Project.Model;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{/// <summary>
/// this class inherit ACommand- save in the path a compress maze
/// </summary>
    public class SaveMazeCommand : ACommand
    {/// <summary>
     /// constructor of SaveMazeCommand
     /// </summary>
     /// <param name="imodel"></param>
     /// <param name="iview"></param>
        public SaveMazeCommand(IModel imodel, IView iview) :base(imodel, iview)
        {

        }/// <summary>
         /// this function save in the path a compress maze
         /// </summary>
         /// <param name="parameters">name'path</param>
        public override void DoCommand(params string[] parameters)
        {
            m_view.Output(m_model.GetSaveMaze(parameters[0], parameters[1]));
        }
        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>

        public override string GetName()
        {
           return "savemaze";
        }
        public void Output(string s)
        {
            m_view.Output(s);
        }
    }
}
