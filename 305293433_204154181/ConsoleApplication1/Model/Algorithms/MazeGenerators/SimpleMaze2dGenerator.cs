using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    public class SimpleMaze2dGenerator : AMazeGenerator
    {
        private static Random random_y = new Random(); //a random object for choosing a random neighbour
        /// <summary>
        /// generate a simple maze 2d
        /// </summary>
        /// <param name="points"> the measures of the wanted maze </param>
        /// <returns> a new maze </returns>
        public override AMaze generate(ArrayList points)
        {
            if (points.Count != 2 || (int)points[0] < 1 || (int)points[1] < 1)
            {
                Console.WriteLine("illegal input of points.");
                return new Maze2d(0, 0);
            }
            else
            {
                //add the corrdinates to the local array points
                m_points.Add(points[0]);
                m_points.Add(points[1]);

                //get the points to give them meaningfull names
                int x = (int)m_points[0];
                int y = (int)m_points[1];

                //create a 2d maze
                AMaze mazeToGenerate = new Maze2d(x, y);

                //get the board of the maze
                Cell[,] board = ((Maze2d)mazeToGenerate).getBoard();

                Position p; //hold the start/ end point
                p = new Position2d(0, 1);
                mazeToGenerate.Start = p; //define the start position to the local variable
                board[mazeToGenerate.Start.x, mazeToGenerate.Start.y].myvalue = Cell.status.path; //open the way of start point
                if (x % 2 == 0) //choose the end point following the parity
                {
                    p = new Position2d(x - 3, y - 1);
                }
                else
                {
                    p = new Position2d(x - 2, y - 1);
                }
                mazeToGenerate.End = p; //define the end position to the local variable
                board[mazeToGenerate.End.x, mazeToGenerate.End.y].myvalue = Cell.status.path; //open the way of end point

                int xToBuild, yToBuild;
                for (xToBuild = 1; xToBuild < x - 1; xToBuild++)
                {
                    if (xToBuild % 2 == 1) // convert all the odd x cells to path
                    {
                        for (int tempY = 1; tempY < y - 1; tempY++)
                        {
                            board[xToBuild, tempY].myvalue = Cell.status.path;
                        }
                    }
                    else //if x is even
                    {
                        yToBuild = random_y.Next(1, y - 2); //get a random y corrdinate to break his wall
                        for (int tempY = 1; tempY < y - 1; tempY++)
                        {
                            if (tempY == yToBuild)
                                board[xToBuild, tempY].myvalue = Cell.status.path;
                        }
                    }
                }
                return mazeToGenerate;
            }
        }
    }

}
