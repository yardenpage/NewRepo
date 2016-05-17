using ATP2016Project.Model;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{/// <summary>
/// this class inherit ACommand- commnd to get a size of a file
/// </summary>
    public class FileSizeCommand : ACommand
    {/// <summary>
     /// constructor of FileSizeCommand
     /// </summary>
     /// <param name="imodel"></param>
     /// <param name="iview"></param>
        public FileSizeCommand(IModel imodel, IView iview) :base(imodel, iview)
        {

        }
        /// <summary>
        /// function to display the size of a file in the path
        /// </summary>
        /// <param name="parameters"></param>
        public override void DoCommand(params string[] parameters)
        {
            m_view.Output(m_model.GetFileSize(parameters[1]));
        }
        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>
        public override string GetName()
        {
            return "filesize";
        }
    }
}
