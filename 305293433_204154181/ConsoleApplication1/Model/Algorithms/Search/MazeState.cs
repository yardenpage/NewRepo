using ATP2016Project.Model.Algorithms.MazeGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    public class MazeState : AState
    {

        private Maze3d maze3d;
        private Position3d position3d;

        public MazeState(AState pState, Position3d mState, Maze3d m)
            : base(pState)
        {
            maze3d = m;
            position3d = mState;
            m_state = mState.getPrint();
        }

        public Maze3d getBoard()
        {
            return maze3d;
        }

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

        public int x
        {
            get
            {
                return (int)position3d.x;
            }
        }

        public int y
        {
            get
            {
                return (int)position3d.y;
            }
        }

        public int z
        {
            get
            {
                return (int)position3d.z;
            }
        }


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

        private bool CompareCorrdinates(string s1, string s2)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                    return false;
            }
            return true;
        }

        public override void PrintCorrdinates()
        {
            position3d.print();
        }

    }
}
