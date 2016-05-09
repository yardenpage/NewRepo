using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    public class MyMaze3dGenerator : AMazeGenerator
    {
        private static Random rand = new Random(); //a random object for choosing a random x
        /// <summary>
        /// generate a new simple maze
        /// </summary>
        /// <param name="points"> the measures of the new maze </param>
        /// <returns> a maze </returns>
        public override AMaze generate(ArrayList points)
        {
            if (points.Count != 3 || (int)points[0] < 3 || (int)points[1] < 3 || (int)points[2] < 3)
            {
                Console.WriteLine("illegal input of points.");
                return new Maze3d(0, 0, 0);
            }
            else
            {
                //add the corrdinates to the local array points
                m_points.Add(points[0]);
                m_points.Add(points[1]);
                m_points.Add(points[2]);

                //get the points to give them meaningfull names
                int x = (int)m_points[0];
                int y = (int)m_points[1];
                int z = (int)m_points[2];
                int ry;
                //create a 3d maze
                Maze3d mazeToGenerate = new Maze3d(x, y, z);

                //create an array for the 2d corrdinates
                ArrayList points2d = new ArrayList();
                points2d.Add(x);
                points2d.Add(y);
                //block the most low and high levels of the maze- the maze will become like a dice
                //for the first and last floor by z min and max block it to be a border
                for (int i = 0; i < z; i++)// create 2dmaze z times
                {
                    DFS2dGenerator mg = new DFS2dGenerator();
                    mazeToGenerate.maze3D[i] = (Maze2d)mg.generate(points2d);
                    if (i == 0 || i == z - 1)
                    {
                        for (int k = 0; k < x; k++)
                        {
                            for (int j = 0; j < y; j++)
                            {
                                mazeToGenerate.maze3D[i].Maze[k, j].myvalue = Cell.status.border;
                            }
                        }
                    }
                }
                Position p3;
                for (int i = 1; i < z - 1; i++)// create 2dmaze z times
                {
                    //removes start and end points
                    mazeToGenerate.maze3D[i].Maze[mazeToGenerate.maze3D[i].End.x, mazeToGenerate.maze3D[i].End.y].myvalue = Cell.status.border;
                    mazeToGenerate.maze3D[i].Maze[mazeToGenerate.maze3D[i].Start.x, mazeToGenerate.maze3D[i].Start.y].myvalue = Cell.status.border;
                    if (i == 1) //if the z is the first floor put remain his start point
                    {
                        ry = rand.Next(y - 1);
                        while (mazeToGenerate.maze3D[i].Maze[1, ry].myvalue != Cell.status.path)
                        {
                            ry = rand.Next(y - 1);
                        }
                        p3 = new Position3d(1, ry, 0);
                        mazeToGenerate.Start = p3;
                        mazeToGenerate.maze3D[0].Start = p3;
                        mazeToGenerate.maze3D[0].Maze[1, ry].myvalue = Cell.status.path;
                    }
                    else if (i == z - 2) //if the z is the last floor remains his end point
                    {
                        ry = rand.Next(y - 1);
                        while (mazeToGenerate.maze3D[i].Maze[x - 2, ry].myvalue != Cell.status.path && mazeToGenerate.maze3D[i].Maze[x - 3, ry].myvalue != Cell.status.path)
                        {
                            ry = rand.Next(y - 1);
                        }
                        if (mazeToGenerate.maze3D[i].Maze[x - 2, ry].myvalue == Cell.status.path)
                        {
                            p3 = new Position3d(x - 2, ry, z - 1);
                            mazeToGenerate.End = p3;
                            mazeToGenerate.maze3D[z - 1].End = p3;
                            mazeToGenerate.maze3D[z - 1].Maze[x - 2, ry].myvalue = Cell.status.path;
                        }
                        else
                        {
                            p3 = new Position3d(x - 3, ry, z - 1);
                            mazeToGenerate.End = p3;
                            mazeToGenerate.maze3D[z - 1].End = p3;
                            mazeToGenerate.maze3D[z - 1].Maze[x - 3, ry].myvalue = Cell.status.path;
                        }
                    }

                }

                return mazeToGenerate;
            }
        }
    }
}