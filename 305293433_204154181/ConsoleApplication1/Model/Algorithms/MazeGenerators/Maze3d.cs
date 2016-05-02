using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{

    public class Maze3d : AMaze
    {
        private Maze2d[] maze3d;
        /// <summary>
        /// maze 3d constructor
        /// </summary>
        /// <param name="x">width</param>
        /// <param name="y">length</param>
        /// <param name="z">the number of floors</param>
        public Maze3d(int x, int y, int z)
        {
            maze3d = new Maze2d[z];// declare the number of floors
            for (int i = 0; i < z; i++)
            {
                maze3d[i] = new Maze2d(x, y);
            }
        }
        /// <summary>
        /// copy constructor of 3d maze
        /// </summary>
        /// <param name="maze"></param>
        public Maze3d(Maze3d maze)
        {
            maze3d = maze.maze3D;
            start = maze.start;
            end = maze.end;
        }
        /// <summary>
        /// property of a maze 3d
        /// </summary>
        public Maze2d[] maze3D
        {
            get
            {
                return maze3d;
            }
            set
            {
                maze3d = value;
            }
        }
        /// <summary>
        /// print a maze 3d
        /// </summary>
        public override void print()
        {
            for (int i = 0; i < maze3d.Length; i++) //print each 2d maze
            {
                maze3d[i].print();
                Console.WriteLine();
            }
        }
    }
}
