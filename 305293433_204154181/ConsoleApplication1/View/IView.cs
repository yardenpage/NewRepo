using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016Project.Controller;
using ATP2016Project.Model.Algorithms.MazeGenerators;

namespace ATP2016Project.View
{
    public interface IView
    {
        void Start();
        void Output(string output);
        void DisplayMaze(AMaze maze);
        void SetCommands(Dictionary<string, ACommand> dictionary);
    }
}
