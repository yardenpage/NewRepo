using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    public class Maze2d : AMaze
    {
        private int m_x;
        private int m_y;
        private Cell[,] maze;
        /// <summary>
        /// constructor of 2d maze
        /// </summary>
        /// <param name="x"> the width </param>
        /// <param name="y"> the length </param>
        public Maze2d(int x, int y)
        {
            m_x = x;
            m_y = y;

            maze = new Cell[x, y];
            //create a maze with a frame of border and inside walls which can be break
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    maze[i, j] = new Cell(i, j);
                    Position2d p = new Position2d(i, j);
                    maze[i, j].Position = p;
                    if (i == 0) //the left wall
                    {
                        maze[i, j].myvalue = Cell.status.border;
                    }
                    else if (i == x - 1) //right wall
                    {
                        maze[i, j].myvalue = Cell.status.border;
                    }
                    else if (j == 0 || j == y - 1) //up and down walls
                        maze[i, j].myvalue = Cell.status.border;
                    else
                        maze[i, j].myvalue = Cell.status.wall;
                }
            }
        }
        /// <summary>
        /// copy constructor of a 2d maze
        /// </summary>
        /// <param name="m"> a maze to copy </param>
        public Maze2d(Maze2d m)//copy constractor
        {
            m_x = m.x;
            m_y = m.y;
            maze = new Cell[x, y];
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    maze[i, j] = m.maze[i, j];
        }
        /// <summary>
        /// property of a cell's maze
        /// </summary>
        public Cell[,] Maze
        {
            get
            {
                return maze;
            }
            set
            {
                maze = value;
            }
        }
        /// <summary>
        /// property of the cell's width
        /// </summary>
        public int x
        {
            get
            {
                return m_x;
            }
            set
            {
                m_x = value;
            }
        }
        /// <summary>
        /// property of the cell's length
        /// </summary>
        public int y
        {
            get
            {
                return m_y;
            }
            set
            {
                m_y = value;
            }
        }

        /// <summary>
        /// get the cell's board
        /// </summary>
        /// <returns> a arrary of cells</returns>
        public Cell[,] getBoard() //return an array of all the cells in the currnt maze
        {
            return maze;
        }
        /// <summary>
        /// check if this maze is equal to another
        /// </summary>
        /// <param name="other">the other maze to compare</param>
        /// <returns>true or false</returns>
        public bool maze_equals(Maze2d other) //check if two mazes are the same
        {

            for (int i = 0; i < other.maze.GetLength(0); i++)
            {
                for (int j = 0; j < other.maze.GetLength(1); j++)
                {
                    if (other.maze[i, j].myvalue != this.maze[i, j].myvalue)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// print the maze
        /// </summary>
        public override void print()
        {
            for (int i = maze.GetLength(1) - 1; i >= 0; i--)
            {
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                    if (start.x == j && start.y == i && maze[j, i].myvalue == Cell.status.path) //case it is start point
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" S ");
                        Console.ResetColor();
                    }
                    else if (end.x == j && end.y == i && maze[j, i].myvalue == Cell.status.path) //case it is end point
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" E ");
                        Console.ResetColor();
                    }
                    else //case it is not start point or end point
                    {
                        if (maze[j, i].myvalue == Cell.status.path)
                        {

                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("   ");
                            Console.ResetColor();
                        }

                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("XXX");
                            Console.ResetColor();
                        }
                    }

                }
                Console.WriteLine();
            }
        }
        public override List<byte> getPrint()
        {
            List<byte> ans = new List<byte>();
            for (int i = maze.GetLength(1) - 1; i >= 0; i--)
            {
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                        if (maze[j, i].myvalue == Cell.status.path)
                        {
                             ans.Add(0);
                        }
                        else
                        {
                            ans.Add(1);
                        }
                 }
           }
            return ans;
        }
    }
}