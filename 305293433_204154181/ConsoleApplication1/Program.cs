using ATP2016Project.Model.Algorithms.Compression;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.Model.Algorithms.Search;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            //testSearchAlgorithms();
            testCompress();
            Console.ReadLine();

        }

        private static void testMaze2dGenerator(IMazeGenerator mg)
        {
            AMaze maze;
            ArrayList testP = new ArrayList();
            int x = 20; //example length parameter 
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
            Console.ReadLine();

        }
        private static void testMaze3dGenerator(IMazeGenerator mg)
        {
            AMaze maze;
            ArrayList testP = new ArrayList();
            int x = 10; //example length parameter 
            int y = 15; //example height parameter
            int z = 6; //example width parameter
            testP.Add(x);
            testP.Add(y);
            testP.Add(z);
            //Console.WriteLine(mg.measureAlgorithmTime(testP));
            maze = mg.generate(testP);
            Position start = maze.getStartPosition();
            start.print();
            Position end = maze.getGoalPosition();
            end.print();
            maze.print();
            Console.ReadLine();
        }

        private static void testSearchAlgorithms()
        {
            AMaze maze;
            int nums = 1;
            ArrayList P = new ArrayList();
            int x = 12; //example length parameter 
            int y = 18; //example height parameter
            int z = 4; //example width parameter
            P.Add(x);
            P.Add(y);
            P.Add(z);
            //the maze surrounded walls- in each edge of the 3D maze
            // if the value of x or y or z is 0 the cell is a wall
            AMazeGenerator generator = new MyMaze3dGenerator();
            maze = generator.generate(P);
            ISearchable maze3d = new SearchableMaze3d((Maze3d)maze);

            AState startState = maze3d.GetStartState();
            AState goalState = maze3d.GetGoalState();

            Console.WriteLine("**********************");
            Console.WriteLine("Search Algorithms Test");
            Console.WriteLine("**********************");
            Console.WriteLine();
            Console.WriteLine("To Start the test press ENTER");
            Console.ReadLine();

            ASearchingAlgorithm bfs = new BreadthFirstSearch();
            Solution solutionbfs = bfs.Solve(maze3d);

            ASearchingAlgorithm dfs = new DepthFirstSearch();
            Solution solutiondfs = dfs.Solve(maze3d);


            if (solutionbfs.IsSolutionExists())
            {
                Console.WriteLine("************************");
                Console.WriteLine("Solution of the 3D maze:");
                Console.WriteLine("************************");
                Console.WriteLine();
                Console.WriteLine("Start position: " + startState.GetState());
                Console.WriteLine("Goal position: " + goalState.GetState());
                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();

                Console.WriteLine("************");
                Console.WriteLine("BFS solution");
                Console.WriteLine("************");
                Console.WriteLine();

                Console.WriteLine("The Corrdinates of the Path's Solution by BFS algorithm:");
                foreach (AState state in solutionbfs.GetSolutionPath())
                {
                    if (state.Equals(startState))
                        Console.WriteLine("Step number: " + nums + "- Start position");
                    else
                    {
                        if (state.Equals(goalState))
                            Console.WriteLine("Step number: " + nums + "- Goal position");
                        else
                            Console.WriteLine("Step number: " + nums);
                    }
                    //state.PrintState();           //option to present the position in the maze
                    state.PrintCorrdinates();
                    nums++;
                }
                Console.WriteLine();
                Console.WriteLine(string.Format("Number of Moves to goal state in the BFS algorithm: {0}", solutionbfs.GetSolutionSteps()));
                Console.WriteLine();

                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                Console.WriteLine("************");
                Console.WriteLine("DFS solution");
                Console.WriteLine("************");
                Console.WriteLine();

                nums = 1;
                Console.WriteLine("The Corrdinates of the Path's Solution by DFS algorithm:");
                foreach (AState state in solutiondfs.GetSolutionPath())
                {
                    if (state.Equals(startState))
                        Console.WriteLine("Step number: " + nums + "- Start position");
                    else
                    {
                        if (state.Equals(goalState))
                            Console.WriteLine("Step number: " + nums + "- Goal position");
                        else
                            Console.WriteLine("Step number: " + nums);
                    }
                    //state.PrintState();           //option to present the position in the maze
                    state.PrintCorrdinates();
                    nums++;
                }
                Console.WriteLine();
                Console.WriteLine(string.Format("Number of Moves to goal state in the DFS algorithm: {0}", solutiondfs.GetSolutionSteps()));
                Console.WriteLine();

                Console.WriteLine("Press ENTER to perform the numbers of generated States");
                Console.ReadLine();
                nums = 1;

                Console.WriteLine(string.Format("Number of Total States generated by BFS: {0}", bfs.GetNumberOfGeneratedNodes()));
                Console.WriteLine(string.Format("Number of Total States generated by DFS: {0}", dfs.GetNumberOfGeneratedNodes()));
                Console.WriteLine();

                Console.WriteLine("Press ENTER to perform the solving times");
                Console.ReadLine();


                Console.WriteLine(string.Format("Solving time BFS (miliseconds): {0}", bfs.GetSolvingTimeMiliseconds()));
                Console.WriteLine(string.Format("Solving time DFS (miliseconds): {0}", dfs.GetSolvingTimeMiliseconds()));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No Solution found!");
            }
            Console.WriteLine("The test finished, press ENTER to exit");
            Console.ReadLine();
            Console.WriteLine("Bye Bye");
            Thread.Sleep(400);
        }

        private static void testCompress()
        {
            Maze3d maze; //... generate it
            AMazeGenerator generator = new MyMaze3dGenerator();
            ArrayList testP = new ArrayList();
            int x = 10; //example length parameter 
            int y = 15; //example height parameter
            int z = 6; //example width parameter
            testP.Add(x);
            testP.Add(y);
            testP.Add(z);
            //Console.WriteLine(mg.measureAlgorithmTime(testP));
            maze = (Maze3d)generator.generate(testP);
                         // save the maze to a file – compressed
            using (FileStream fileOutStream = new FileStream("1.maze", FileMode.Create))
            {
                using (Stream outStream = new MyCompressorStream(fileOutStream, MyCompressorStream.status.compress))
                {
                    ((MyCompressorStream)outStream).Write(maze.toByteArray(),0,255);
                    outStream.Flush();
                }
            }
            byte[] mazeBytes;
            using (FileStream fileInStream = new FileStream("1.maze", FileMode.Open))
            {
                using (Stream inStream = new MyCompressorStream(fileInStream, MyCompressorStream.status.decompress))
                {
                    mazeBytes = new byte[maze.toByteArray().Length];
                    inStream.Read(mazeBytes,0,mazeBytes.Length);
                }
            }
            Maze3d loadedMaze = new Maze3d(mazeBytes);
            Console.WriteLine(loadedMaze.Equals(maze));

        }

    }
}
