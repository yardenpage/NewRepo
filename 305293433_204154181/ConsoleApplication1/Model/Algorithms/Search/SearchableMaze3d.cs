using ATP2016Project.Model.Algorithms.MazeGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    public class SearchableMaze3d : ISearchable
    {

        private Maze3d m_maze3d;

        public SearchableMaze3d(Maze3d maze)
        {
            m_maze3d = new Maze3d(maze);
        }

        public AState GetStartState()
        {
            Position3d start = (Position3d)m_maze3d.getStartPosition();
            AState state = new MazeState(null, start, m_maze3d);
            return state;
        }

        public AState GetGoalState()
        {
            Position3d goal = (Position3d)m_maze3d.getGoalPosition();
            AState state = new MazeState(null, goal, m_maze3d);
            return state;
        }

        public IEnumerable<AState> GetAllSuccessors(AState state)
        {
            List<AState> successors = new List<AState>();
            MazeState mazeState = (MazeState)state;

            //get all the ligal neighbours of a cell
            List<Position2d> neighbours = new List<Position2d>();
            //check the up neighbour- if is inside the maze and there is a path
            if ((mazeState.z + 1 < m_maze3d.maze3D.Length) && (m_maze3d.maze3D[mazeState.z + 1].Maze[mazeState.x, mazeState.y].myvalue == Cell.status.path))
            {
                Position3d p = new Position3d(mazeState.x, mazeState.y, mazeState.z + 1);
                MazeState nstate = new MazeState(mazeState, p, m_maze3d);
                successors.Add(nstate);
            }
            //check the forward neighbour- if is inside the maze and there is a path
            if ((mazeState.y + 1 < m_maze3d.maze3D[0].y) && (m_maze3d.maze3D[mazeState.z].Maze[mazeState.x, mazeState.y + 1].myvalue == Cell.status.path))
            {
                Position3d p = new Position3d(mazeState.x, mazeState.y + 1, mazeState.z);
                MazeState nstate = new MazeState(mazeState, p, m_maze3d);
                successors.Add(nstate);
            }

            //check the right neighbour- if is inside the maze and there is a path
            if ((mazeState.x + 1 < m_maze3d.maze3D[0].x) && (m_maze3d.maze3D[mazeState.z].Maze[mazeState.x + 1, mazeState.y].myvalue == Cell.status.path))
            {
                Position3d p = new Position3d(mazeState.x + 1, mazeState.y, mazeState.z);
                MazeState nstate = new MazeState(mazeState, p, m_maze3d);
                successors.Add(nstate);
            }

            //check the down neighbour- if is inside the maze and there is a path
            if ((mazeState.z - 1 >= 0) && (m_maze3d.maze3D[mazeState.z - 1].Maze[mazeState.x, mazeState.y].myvalue == Cell.status.path))
            {
                Position3d p = new Position3d(mazeState.x, mazeState.y, mazeState.z - 1);
                MazeState nstate = new MazeState(mazeState, p, m_maze3d);
                successors.Add(nstate);
            }

            //check the backward neighbour- if is inside the maze and there is a path
            if ((mazeState.y - 1 >= 0) && (m_maze3d.maze3D[mazeState.z].Maze[mazeState.x, mazeState.y - 1].myvalue == Cell.status.path))
            {
                Position3d p = new Position3d(mazeState.x, mazeState.y - 1, mazeState.z);
                MazeState nstate = new MazeState(mazeState, p, m_maze3d);
                successors.Add(nstate);
            }

            //check the left neighbour- if is inside the maze and there is a path
            if ((mazeState.x - 1 >= 0) && (m_maze3d.maze3D[mazeState.z].Maze[mazeState.x - 1, mazeState.y].myvalue == Cell.status.path))
            {
                Position3d p = new Position3d(mazeState.x - 1, mazeState.y, mazeState.z);
                MazeState nstate = new MazeState(mazeState, p, m_maze3d);
                successors.Add(nstate);
            }
            return successors;
        }

    }
}
