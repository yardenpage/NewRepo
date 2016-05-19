using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016Project.Controller;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using System.Collections;

namespace ATP2016Project.View
{/// <summary>
/// interface IView
/// </summary>
    public interface IView
    {
        /// <summary>
        /// start the runnimg
        /// </summary>
        void Start();
        /// <summary>
        /// display an output
        /// </summary>
        /// <param name="output"></param>
        void Output(string output);
        /// <summary>
        /// diaplay a maze
        /// </summary>
        /// <param name="maze"></param>
        void DisplayMaze(AMaze maze);
        /// <summary>
        /// set the given command dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        void SetCommands(Dictionary<string, ACommand> dictionary);
        void SetParameters(Dictionary<string, ArrayList> parameters);
    }
}
