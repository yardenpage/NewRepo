using ATP2016Project.Model;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{/// <summary>
/// interface of IController
/// </summary>
    public interface IController
    {/// <summary>
    /// set the given model
    /// </summary>
    /// <param name="model"></param>
        void SetModel(IModel model);
        /// <summary>
        /// set the given view
        /// </summary>
        /// <param name="view"></param>
        void SetView(IView view);
        /// <summary>
        /// return the command dictionary
        /// </summary>
        /// <returns></returns>
        Dictionary<string, ICommand> getCommands();
        /// <summary>
        /// display the output
        /// </summary>
        /// <param name="output">string to output</param>
        void Output(string output);
    }
}
