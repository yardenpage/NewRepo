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

        public Maze3d(byte[] b)
        {
            maze3d = new Maze2d[b[2]];// declare the number of floors
            for (int i = 0; i < b[2]; i++)
            {
                maze3d[i] = new Maze2d(b[0], b[1]);
            }
            Position startMaze = new Position3d(b[3], b[4], b[5]);
            Start = startMaze;
            Position endMaze = new Position3d(b[6], b[7], b[8]);
            End =endMaze;

            int count = 9;
            for (int z = 0; z < b[2]; z++)
            {
                for (int y = b[1] - 1; y >= 0; y--)
                {
                    for (int x = 0; x < b[0]; x++)
                    {
                        if (b[count] == 0) {
                            maze3d[z].Maze[x, y].myvalue = Cell.status.path;
                        }
                        else
                        {
                            if(x==0 || x==b[0]-1 || y==0 || y==b[1]-1 || z==0 || z==b[2]-1)
                                maze3d[z].Maze[x, y].myvalue = Cell.status.border;
                            else
                                maze3d[z].Maze[x, y].myvalue = Cell.status.wall;
                        }
                        count++;
                    }
                }
            }
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
        /// 
        public override bool Equals(AMaze other) //check if two mazes are the same
        {
            Maze3d Other = (Maze3d)other;
            if (Other.maze3D[0].x != maze3d[0].x || Other.maze3D[0].y != maze3d[0].y || Other.maze3D.Length != maze3d.Length)
                return false;
            for (int k = 0; k < Other.maze3d.Length; k++)
            {
                    if (!(Other.maze3D[k].Equals(maze3d[k])))
                    {
                        return false;
                    }
            }
            return true;
        }

        public override void print()
        {
            for (int i = 0; i < maze3d.Length; i++) //print each 2d maze
            {
                maze3d[i].print();
                Console.WriteLine();
            }
        }

        public override List<byte> getPrint()
        {
            List<byte> ans = new List<byte>();
            for (int i = 0; i < maze3d.Length; i++)
            {
                ans.AddRange(maze3d[i].getPrint());
            }
            return ans;
        }

        public byte[] toByteArray()
        {
            List<byte> byteMaze = new List<byte>();
            byteMaze.Add((byte)maze3D[0].Maze.GetLength(0));
            byteMaze.Add((byte)maze3D[0].Maze.GetLength(1));
            byteMaze.Add((byte)maze3D.Length);
            byteMaze.Add((byte)Start.x);
            byteMaze.Add((byte)Start.y);
            byteMaze.Add((byte)(((Position3d)Start).z));
            byteMaze.Add((byte)End.x);
            byteMaze.Add((byte)End.y);
            byteMaze.Add((byte)(((Position3d)End).z));
            byteMaze.AddRange(getPrint());
            return byteMaze.ToArray();
        }

        public Maze2d Getmaze2dBySection(char c, int index)
        {
            Maze2d maze2d;
            if (c == 'z' || c=='Z')
                return maze3d[index];
            else
            {
                if (c == 'x' || c== 'X')
                {
                    maze2d = new Maze2d(maze3d[0].y, maze3d.Length);
                    for (int j= maze3d.Length-1; j>=0; j--)
                    {
                        for(int i=0; i< maze3d[0].y; i++)
                        {
                            maze2d.Maze[i, j] = maze3d[j].Maze[index, i];
                        }
                    }
                    return maze2d;
                }
                else if (c == 'y' || c=='Y')
                {
                    maze2d = new Maze2d(maze3d[0].x, maze3d.Length);
                    for (int j = maze3d.Length - 1; j >= 0; j--)
                    {
                        for (int i = 0; i < maze3d[0].x; i++)
                        {
                            maze2d.Maze[i, j] = maze3d[j].Maze[i, index];
                        }
                    }
                    return maze2d;
                }

            }
            return new Maze2d(0, 0);
        }
    }
}
