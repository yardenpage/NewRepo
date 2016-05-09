using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    /// <summary>
    /// interface of maze generator classes
    /// </summary>
    public interface IMazeGenerator
    {
        /// <summary>
        /// generate method of a maze
        /// </summary>
        /// <param name="points"> the corrdinates of the maze </param>
        /// <returns> a maze </returns>
        AMaze generate(ArrayList points);
        /// <summary>
        /// calculates the running time of the algorithm
        /// </summary>
        /// <param name="points"> array of the corrdinates </param>
        /// <returns> string of the time </returns>
        string measureAlgorithmTime(ArrayList points);
    }
}