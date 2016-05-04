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
            int x = 5; //example length parameter 
            int y = 5; //example height parameter
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
            int nums = 1;
            string input;
            ArrayList P = new ArrayList();
            int x = 4; //example length parameter 
            int y = 4; //example height parameter
            int z = 5; //example width parameter
            P.Add(x);
            P.Add(y);
            P.Add(z);
            AMazeGenerator generator = new MyMaze3dGenerator();
            maze = generator.generate(P);
            ISearchable maze3d = new SearchableMaze3d((Maze3d)maze);

            AState startState = maze3d.GetStartState();

            Console.WriteLine("Solution of the maze:");
            Console.WriteLine("*********************");
            //startState.PrintState();

            ASearchingAlgorithm bfs = new BreadthFirstSearch();
            Solution solutionbfs = bfs.Solve(maze3d);

            ASearchingAlgorithm dfs = new DepthFirstSearch();
            Solution solutiondfs = dfs.Solve(maze3d);

            if (solutionbfs.IsSolutionExists())
            {
                Console.WriteLine("Solution found:");
                Console.WriteLine("***************");
                Console.WriteLine();
                Console.WriteLine("To perform the Corrdinates of the Path's Solution by BFS, press enter"); 
                input = Console.ReadLine();
                if (input == "")
                {
                    Console.WriteLine("The Corrdinates of the Path's Solution by BFS algorithm:");
                    foreach (AState state in solutionbfs.GetSolutionPath())
                    {
                        Console.WriteLine("Step number: " + nums);
                        state.PrintState();
                        //state.PrintCorrdinates();
                        nums++;
                    }
                }
                //nums = 1;
                //Console.WriteLine("To perform the State of the Path's by BFS, press enter");
                //input = Console.ReadLine();
                //if (input == "")
                //{
                //    Console.WriteLine("The Corrdinates of the Path's Solution by BFS algorithm:");
                //    foreach (AState state in solutionbfs.GetSolutionPath())
                //    {
                //        Console.WriteLine("Step number: " + nums);
                //        state.PrintState();
                //        //state.PrintCorrdinates();
                //        nums++;
                //    }
                //}
                Console.WriteLine(string.Format("Number of Moves to goals state - bfs: {0}", solutionbfs.GetSolutionSteps()));
                nums = 1;
                Console.WriteLine();

                Console.WriteLine("To perform the Corrdinates of the Path's Solution by DFS, press enter");
                input = Console.ReadLine();
                if (input == "")
                {
                    Console.WriteLine("The Corrdinates of the Path's Solution by DFS algorithm:");
                    foreach (AState state in solutiondfs.GetSolutionPath())
                    {
                        Console.WriteLine("Step number: " + nums);
                        state.PrintState();
                        //state.PrintCorrdinates();
                        nums++;
                    }
                }
                //nums = 1;
                //Console.WriteLine("To perform the State of the Path's by DFS, press enter");
                //input = Console.ReadLine();
                //if (input == "")
                //{
                //    Console.WriteLine("The Corrdinates of the Path's Solution by DFS algorithm:");
                //    foreach (AState state in solutionbfs.GetSolutionPath())
                //    {
                //        Console.WriteLine("Step number: " + nums);
                //        state.PrintState();
                //        //state.PrintCorrdinates();
                //        nums++;
                //    }
                //}
                Console.WriteLine(string.Format("Number of Moves to goals state -dfs: {0}", solutiondfs.GetSolutionSteps()));
                nums = 1;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No Solution found!");
            }

            Console.WriteLine("");
            Console.WriteLine("To perform the Number of Total States generated by BFS, press enter");
            input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine();
                Console.WriteLine(string.Format("Number of Total States generated by BFS: {0}", bfs.GetNumberOfGeneratedNodes()));
                Console.WriteLine();
            }
            Console.WriteLine("To perform the Number of Total States generated by DFS, press enter");
            input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine();
                Console.WriteLine(string.Format("Number of Total States generated by DFS: {0}", dfs.GetNumberOfGeneratedNodes()));
                Console.WriteLine();
            }
            Console.WriteLine("To perform the Solving time BFS, press enter");
            input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine();
                Console.WriteLine(string.Format("Solving time BFS (miliseconds): {0}", bfs.GetSolvingTimeMiliseconds()));
                Console.WriteLine();
            }
            Console.WriteLine("To perform the Solving time DFS, press enter");
            input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine();
                Console.WriteLine(string.Format("Solving time DFS (miliseconds): {0}", dfs.GetSolvingTimeMiliseconds()));
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
