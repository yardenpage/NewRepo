using ATP2016Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016Project.Controller;
using System.Collections;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.Model.Algorithms.Search;

namespace ATP2016Project.Model
{
    public class MyModel : IModel
    {

        private IController controller;
        private Dictionary<string, AMaze> MazesDic;
        private Dictionary<string, string> MazesSol;
        public MyModel(IController controller)
        {
            this.controller = controller;
            MazesDic = new Dictionary<string, AMaze>();
        }

        public string GetDir(string path)
        {
            throw new NotImplementedException();
        }

        public AMaze GetDisplay(string name)
        {
            if (MazesDic.ContainsKey(name))
            {
                return MazesDic[name];
            }
            return null;
        }

        public string GetDisplaySolution(string name)
        {
            if (MazesSol.ContainsKey(name))
            {
                return MazesSol[name];
            }
            return null;
        }

        public string GetExit()
        {
            throw new NotImplementedException();
        }

        public string GetFileSize(string path)
        {
            throw new NotImplementedException();
        }

        public string GetGenerate3dMaze(string name, int[] parameters)
        {
            ArrayList points = new ArrayList();
            for (int i = 0; i < parameters.Length; i++)
            {
                points.Add(parameters[i]);
            }
            MyMaze3dGenerator generator = new MyMaze3dGenerator();
            AMaze maze = generator.generate(points);
            if (MazesDic.ContainsKey(name))
            {
                MazesDic[name] = maze;
            }
            else
            {
                MazesDic.Add(name, maze);
            }
            return "maze " + name + " is ready";
        }

        public string GetLoadMaze(string path, string name)
        {
            throw new NotImplementedException();
        }

        public string GetMazeSize(string name)
        {
            return "The size of maze " + name + " in Bytes is " + (((Maze3d)MazesDic[name]).toByteArray()).Length;
        }

        public string GetSaveMaze(string name, string path)
        {
            throw new NotImplementedException();
        }

        public string GetSolveMaze(string name)
        {
            ASearchingAlgorithm alg = new BreadthFirstSearch();;
            Solution solution;
            ISearchable maze3d = new SearchableMaze3d((Maze3d)MazesDic[name]);
            
            solution = alg.Solve(maze3d);
            if (solution.IsSolutionExists())
            {
                if (MazesSol.ContainsKey(name))
                    MazesSol[name] = solution.StringSolutionPath();
                else
                {
                    MazesSol.Add(name, solution.StringSolutionPath());
                }
            }
            return "solution for " + name + " is ready";
        }
    }
}
