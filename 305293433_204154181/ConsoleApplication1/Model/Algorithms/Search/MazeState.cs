using ATP2016Project.Model.Algorithms.MazeGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    /// <summary>
    /// class of mazestate the inherit astate class
    /// </summary>
    public class MazeState : AState
    {
        /// <summary>
        ///  a maze3d
        /// </summary>
        private Maze3d maze3d;
        /// <summary>
        /// a position3d
        /// </summary>
        private Position3d position3d;
        /// <summary>
        /// constructor ofmaze state
        /// </summary>
        /// <param name="pState">the parent state</param>
        /// <param name="mState">the point of the state</param>
        /// <param name="m">the maze that this atste is a part of</param>
        public MazeState(AState pState, Position3d mState, Maze3d m)
            : base(pState)
        {
            maze3d = m;
            position3d = mState;
            m_state = mState.getPrint();
        }
        /// <summary>
        /// return the board
        /// </summary>
        /// <returns>the bourd</returns>
        public Maze3d getBoard()
        {
            return maze3d;
        }
        /// <summary>
        /// property to posiotion
        /// </summary>
        public Position3d position
        {
            get
            {
                return position3d;
            }
            set
            {
                position3d = value;
            }
        }
        /// <summary>
        /// property to x coordinate of the position
        /// </summary>
        public int x
        {
            get
            {
                return (int)position3d.x;
            }
        }
        /// <summary>
        /// property to y coordinate of the position
        /// </summary>
        public int y
        {
            get
            {
                return (int)position3d.y;
            }
        }
        /// <summary>
        /// property to z coordinate of the position
        /// </summary>
        public int z
        {
            get
            {
                return (int)position3d.z;
            }
        }

        /// <summary>
        /// print the state
        /// </summary>
        public override void PrintState()
        {
            bool isF = false;
            for (int k = 0; k < maze3d.maze3D.Length; k++)
            {
                Console.WriteLine("{");
                for (int i = maze3d.maze3D[k].Maze.GetLength(1) - 1; i >= 0; i--)
                {
                    Console.Write("{");
                    for (int j = 0; j < maze3d.maze3D[k].Maze.GetLength(0); j++)
                    {
                        if (maze3d.maze3D[k].Maze[j, i].myvalue == Cell.status.border || maze3d.maze3D[k].Maze[j, i].myvalue == Cell.status.wall)
                        {
                            if (j != maze3d.maze3D[k].Maze.GetLength(0) - 1)
                                Console.Write("1,");
                            else
                                Console.Write("1");
                        }
                        else
                        {
                            string curr = "(" + j + "," + i + "," + k + ")";
                            if (CompareCorrdinates((maze3d.getStartPosition()).getPrint(), curr))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                if (j != maze3d.maze3D[k].Maze.GetLength(0) - 1)
                                    Console.Write("0,");
                                else
                                    Console.Write("0");
                                Console.ResetColor();
                            }
                            else if (CompareCorrdinates((maze3d.getGoalPosition()).getPrint(), curr))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                if (j != maze3d.maze3D[k].Maze.GetLength(0) - 1)
                                    Console.Write("0,");
                                else
                                    Console.Write("0");
                                Console.ResetColor();
                            }
                            else if (CompareCorrdinates(GetState(), curr))
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                if (j != maze3d.maze3D[k].Maze.GetLength(0) - 1)
                                    Console.Write("0,");
                                else
                                    Console.Write("0");
                                Console.ResetColor();
                            }
                            else
                            {
                                for (int g = 0; g < m_parentsState.Count && !isF; g++)
                                {
                                    if (CompareCorrdinates((GetParentState()[g]).GetState(), curr))
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        if (j != maze3d.maze3D[k].Maze.GetLength(0) - 1)
                                            Console.Write("0,");
                                        else
                                            Console.Write("0");
                                        Console.ResetColor();
                                        isF = true;
                                    }
                                }
                                if (!isF)
                                {
                                    if (j != maze3d.maze3D[k].Maze.GetLength(0) - 1)
                                        Console.Write("0,");
                                    else
                                        Console.Write("0");
                                }
                                else
                                    isF = false;
                            }
                        }

                    }
                    Console.WriteLine("}");
                }
                Console.WriteLine("}");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// check if 2 cordinate are the same
        /// </summary>
        /// <param name="s1">first coordinate</param>
        /// <param name="s2">second coordinate</param>
        /// <returns>return true or false</returns>
        private bool CompareCorrdinates(string s1, string s2)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                    return false;
            }
            return true;
        }
        /// <summary>
        /// print the coordinate of the point
        /// </summary>
        public override string PrintCorrdinates()
        {
            return position3d.getPrint();
        }

    }
}
