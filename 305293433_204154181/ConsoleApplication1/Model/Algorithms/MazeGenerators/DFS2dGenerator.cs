using ATP2016Project.Model.Algorithms.MazeGenerators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    public class DFS2dGenerator : AMazeGenerator
    {
        private static Random rand = new Random(); //a random object for choosing a random neighbour
        private Boolean stopFlag = false;
        /// <summary>
        /// constructor of a DFS 2d maze
        /// </summary>
        public DFS2dGenerator() : base()
        {
        }
        /// <summary>
        /// generate a maze following the given points
        /// </summary>
        /// <param name="points"> the measures of the wanted maze </param>
        /// <returns> a maze </returns>
        public override AMaze generate(ArrayList points)
        {
            if (points.Count != 2 || (int)points[0] < 3 || (int)points[1] < 3)
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
                int width = (int)m_points[0];
                int height = (int)m_points[1];

                //create a 2d maze
                AMaze mazeToGenerate = new Maze2d(width, height);

                //get the board of the maze
                Cell[,] board = ((Maze2d)mazeToGenerate).getBoard();

                //stack that hold the all points we allready visit
                Stack<Position2d> positionStack = new Stack<Position2d>();

                //list that hold all the possible neighbours to visit
                List<Position2d> neighbours;

                //hold the current point we deal with
                Position2d currCell;

                //save the enter/ exits point on the frame
                Position pEdge;

                //save the start point to navigate from
                Position2d enter;

                if (width % 2 == 0 && height % 2 == 1) //case the x is even and y is odd
                {
                    board[0, 1].myvalue = Cell.status.path;
                    pEdge = new Position2d(0, 1);
                    enter = new Position2d(1, 1);
                }
                else if (width % 2 == 0 && height % 2 == 0) //case the x is even and y is even
                {
                    board[0, 1].myvalue = Cell.status.path;
                    pEdge = new Position2d(0, 1);
                    enter = new Position2d(1, 1);
                }
                else if (width % 2 == 1 && height % 2 == 0) //case the x is odd and y is even
                {
                    board[0, 1].myvalue = Cell.status.path;
                    pEdge = new Position2d(0, 1);
                    enter = new Position2d(1, 1);
                }
                else //case the x is odd and y is odd
                {
                    board[0, 1].myvalue = Cell.status.path;
                    pEdge = new Position2d(0, 1);
                    enter = new Position2d(1, 1);
                }

                mazeToGenerate.Start = pEdge; //define the start position to the local variable
                board[mazeToGenerate.Start.x, mazeToGenerate.Start.y].myvalue = Cell.status.path; //open the path of the start corrdinate of the frame
                board[enter.x, enter.y].myvalue = Cell.status.path; //open the path of the enter corrdinate in the maze

                //choose the end point acorrding to the dimension
                if ((width % 2 == 0 && height % 2 == 1))  //case the x is even and y is odd
                {
                    pEdge = new Position2d(width - 1, height - 2);
                }
                else if (width % 2 == 0 && height % 2 == 0) //case the x is even and y is even
                {
                    board[width - 3, height - 2].myvalue = Cell.status.path;
                    pEdge = new Position2d(width - 3, height - 1);
                }
                else if (width % 2 == 1 && height % 2 == 0) //case the x is odd and y is even
                {
                    board[width - 2, height - 2].myvalue = Cell.status.path;
                    pEdge = new Position2d(width - 2, height - 1);
                }
                else //case the x is odd and y is odd
                {
                    pEdge = new Position2d(width - 2, height - 1);
                }

                mazeToGenerate.End = pEdge; //define the end position to the local variable
                board[mazeToGenerate.End.x, mazeToGenerate.End.y].myvalue = Cell.status.path;  //open the path of the end corrdinate of the frame

                int x = mazeToGenerate.Start.x;
                int y = mazeToGenerate.Start.y;
                positionStack.Push(enter);

                while (positionStack.Count > 0 && !stopFlag) //stop when we check all the "neighbours points" of the possible points to visit at the maze
                {
                    currCell = positionStack.Pop();
                    board[currCell.x, currCell.y].visit = Cell.Visit.visit; //mark the point as "visited"
                    neighbours = getNeighbours(board, currCell); //enter all the possible neighbours to a list
                    if (neighbours.Count > 0)
                    {
                        //each time move 2 steps- the first step hold -n1, the second -n2
                        int n1 = rand.Next(neighbours.Count);
                        int n2;
                        if (n1 % 2 == 1)
                        {
                            n2 = n1;
                            n1 = n1 - 1;
                        }
                        else
                            n2 = n1 + 1;
                        Position2d temp = neighbours[n2];
                        board[neighbours[n1].x, neighbours[n1].y].visit = Cell.Visit.visit; //mark the one step points as "visited"
                        board[neighbours[n1].x, neighbours[n1].y].myvalue = Cell.status.path; //mark the one step points as "path"
                        board[neighbours[n2].x, neighbours[n2].y].myvalue = Cell.status.path; //mark the two step points as "path"
                        positionStack.Push(currCell);
                        positionStack.Push(temp);
                    }
                }
                if (stopFlag == true)
                    return null;
                return mazeToGenerate;
            }
        }
        /// <summary>
        /// get the neighbours of the current cell
        /// </summary>
        /// <param name="board"> the board </param>
        /// <param name="currCell"> the current cell </param>
        /// <returns> list of positions of all the neighbours</returns>
        private List<Position2d> getNeighbours(Cell[,] board, Position2d currCell)
        {
            //get all the ligal neighbours of a cell
            List<Position2d> neighbours = new List<Position2d>();
            if ((currCell.y - 2 >= 1) && (board[currCell.x, currCell.y - 2].myvalue != Cell.status.border) && (board[currCell.x, currCell.y - 2].visit == Cell.Visit.notvisit))
            {
                neighbours.Add(board[currCell.x, currCell.y - 1].Position);
                neighbours.Add(board[currCell.x, currCell.y - 2].Position);
            }
            if ((currCell.y + 2 < board.GetLength(1)) && (board[currCell.x, currCell.y + 2].myvalue != Cell.status.border) && (board[currCell.x, currCell.y + 2].visit == Cell.Visit.notvisit))
            {
                neighbours.Add(board[currCell.x, currCell.y + 1].Position);
                neighbours.Add(board[currCell.x, currCell.y + 2].Position);
            }
            if ((currCell.x - 2 >= 0) && (board[currCell.x - 2, currCell.y].myvalue != Cell.status.border) && (board[currCell.x - 2, currCell.y].visit == Cell.Visit.notvisit))
            {
                neighbours.Add(board[currCell.x - 1, currCell.y].Position);
                neighbours.Add(board[currCell.x - 2, currCell.y].Position);
            }
            if ((currCell.x + 2 < board.GetLength(0)) && (board[currCell.x + 2, currCell.y].myvalue != Cell.status.border) && (board[currCell.x + 2, currCell.y].visit == Cell.Visit.notvisit))
            {
                neighbours.Add(board[currCell.x + 1, currCell.y].Position);
                neighbours.Add(board[currCell.x + 2, currCell.y].Position);
            }
            return neighbours;
        }
        public override void stop()
        {
            stopFlag = true;
        }
    }
}
