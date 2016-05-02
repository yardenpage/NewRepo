using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.Model.Algorithms.Search;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project
{
    class Program
    {

        static void Main(string[] args)
        {
          
            AMazeGenerator mA = new DFS2dGenerator();
            AMazeGenerator mB = new MyMaze3dGenerator();
            AMazeGenerator mC = new SimpleMaze2dGenerator();

            //testMaze2dGenerator(mA);
            //testMaze3dGenerator(mB);
            testSearchAlgorithms();
            Console.ReadLine();

        }

        private static void testMaze2dGenerator(IMazeGenerator mg)
        {
            AMaze maze;
            ArrayList testP = new ArrayList();
            int x = 22; //example length parameter 
            int y = 30; //example height parameter
            testP.Add(x); 
            testP.Add(y);
            Console.WriteLine(mg.measureAlgorithmTime(testP));
            maze = mg.generate(testP);

            Position start = maze.getStartPosition();
            start.print();
            Position end = maze.getGoalPosition();
            end.print();
            maze.print();

        }
        private static void testMaze3dGenerator(IMazeGenerator mg)
        {
            AMaze maze;
            ArrayList testP = new ArrayList();
            int x = 8; //example length parameter 
            int y = 8; //example height parameter
            int z = 4; //example width parameter
            testP.Add(x);
            testP.Add(y);
            testP.Add(z);
            Console.WriteLine(mg.measureAlgorithmTime(testP));
            maze = mg.generate(testP);
            Position start = maze.getStartPosition();
            start.print();
            Position end= maze.getGoalPosition();
            end.print();
            maze.print();
        }

        private static void testSearchAlgorithms()
        {
            AMaze maze;
            ArrayList P = new ArrayList();
            int x = 8; //example length parameter 
            int y = 8; //example height parameter
            int z = 4; //example width parameter
            P.Add(x);
            P.Add(y);
            P.Add(z);
            AMazeGenerator generator = new MyMaze3dGenerator();
            maze = generator.generate(P);
            ISearchable maze3d = new SearchableMaze3d((Maze3d)maze);

            AState startState = maze3d.GetStartState();

            Console.WriteLine("Problem to solve");
            Console.WriteLine("***************");
            startState.PrintState();

            ASearchingAlgorithm bfs = new BreadthFirstSearch();
            Solution solutionbfs = bfs.Solve(maze3d);

            ASearchingAlgorithm dfs = new DepthFirstSearch();
            Solution solutiondfs = dfs.Solve(maze3d);

            if (solutionbfs.IsSolutionExists())
            {
                Console.WriteLine("Solution found:");
                Console.WriteLine("***************");

                foreach (AState state in solutionbfs.GetSolutionPath())
                {
                    //state.PrintState();
                    state.PrintCorrdinates();
                }
            }
            else
            {
                Console.WriteLine("No Solution found!");
            }

            Console.WriteLine("");
            Console.WriteLine(string.Format("Moves to goals state - bfs: {0}", solutionbfs.GetSolutionSteps()));
            Console.WriteLine(string.Format("Moves to goals state - dfs: {0}", solutiondfs.GetSolutionSteps()));
            Console.WriteLine(string.Format("Nodes generated bfs: {0}", bfs.GetNumberOfGeneratedNodes()));
            Console.WriteLine(string.Format("Nodes generated dfs: {0}", dfs.GetNumberOfGeneratedNodes()));
            Console.WriteLine(string.Format("Solving time bfs (miliseconds): {0}", bfs.GetSolvingTimeMiliseconds()));
            Console.WriteLine(string.Format("Solving time dfs (miliseconds): {0}", dfs.GetSolvingTimeMiliseconds()));

            Console.ReadLine();
        }
    }
}
