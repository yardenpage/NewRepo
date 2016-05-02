using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    /// <summary>
    /// interface of a maze classes
    /// </summary>
    public interface IMaze
    {
        /// <summary>
        /// get the start position
        /// </summary>
        /// <returns> position of the start</returns>
        Position getStartPosition();
        /// <summary>
        /// get the goal position
        /// </summary>
        /// <returns> position of the goal </returns>
        Position getGoalPosition();
        /// <summary>
        /// print the maze
        /// </summary>
        void print();
    }
}