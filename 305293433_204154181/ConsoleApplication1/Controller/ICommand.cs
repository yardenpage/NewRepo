using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{/// <summary>
/// interface of ICommand
/// </summary>
    public interface ICommand
    {/// <summary>
    /// function that call the implement of the modelto the command and display it
    /// </summary>
    /// <param name="parameters"></param>
        void DoCommand(params string[] parameters);
        /// <summary>
        /// get the name
        /// </summary>
        /// <returns></returns>
        string GetName();
    }
}
