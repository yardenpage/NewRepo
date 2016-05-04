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
        /// <summary>
        /// generate a new simple maze
        /// </summary>
        /// <param name="points"> the measures of the new maze </param>
        /// <returns> a maze </returns>
        public override AMaze generate(ArrayList points)
        {
            if (points.Count != 3 || (int)points[0] < 1 || (int)points[1] < 1 || (int)points[2] < 1)
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

                //create a 3d maze
                Maze3d mazeToGenerate = new Maze3d(x, y, z);

                //create an array for the 2d corrdinates
                ArrayList points2d = new ArrayList();
                points2d.Add(x);
                points2d.Add(y);

                Position p3;
                for (int i = 0; i < z; i++)// create 2dmaze z times
                {
                    DFS2dGenerator mg = new DFS2dGenerator();
                    mazeToGenerate.maze3D[i] = (Maze2d)mg.generate(points2d);

                    if (i == 0) //if the z is the first floor put remain his start point
                    {
                        p3 = new Position3d(mazeToGenerate.maze3D[i].Start.x, mazeToGenerate.maze3D[i].Start.y, 0);
                        mazeToGenerate.Start = p3;
                        mazeToGenerate.maze3D[i].Maze[mazeToGenerate.maze3D[i].End.x, mazeToGenerate.maze3D[i].End.y].myvalue = Cell.status.border;
                    }
                    else if (i == z - 1) //if the z is the last floor remains his end point
                    {
                        p3 = new Position3d(mazeToGenerate.maze3D[i].End.x, mazeToGenerate.maze3D[i].End.y, z - 1);
                        mazeToGenerate.End = p3;
                        mazeToGenerate.maze3D[i].Maze[mazeToGenerate.maze3D[i].Start.x, mazeToGenerate.maze3D[i].Start.y].myvalue = Cell.status.border;
                    }
                    else //if the z isn't the last or the first floor removes his start and end points
                    {
                        mazeToGenerate.maze3D[i].Maze[mazeToGenerate.maze3D[i].End.x, mazeToGenerate.maze3D[i].End.y].myvalue = Cell.status.border;
                        mazeToGenerate.maze3D[i].Maze[mazeToGenerate.maze3D[i].Start.x, mazeToGenerate.maze3D[i].Start.y].myvalue = Cell.status.border;
                    }
                }

                return mazeToGenerate;
            }
        }
    }
}