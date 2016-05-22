using System;
using System.Collections.Generic;
using ATP2016Project.Controller;
using System.Collections;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.Model.Algorithms.Search;
using System.IO;
using ATP2016Project.Model.Algorithms.Compression;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Security.Permissions;

namespace ATP2016Project.Model
{
    /// <summary>
    ///  MyModel implement IModel interface
    /// </summary>
    public class MyModel : IModel
    {

        private IController m_controller;
        private Dictionary<string, AMaze> MazesDic;
        private Dictionary<string, string> MazesSol;
        private IMazeGenerator generator;
        private ISearchingAlgorithm alg;
        /// <summary>
        /// constructor of  MyModel
        /// </summary>
        /// <param name="controller"></param>
        public MyModel(IController controller)
        {
            m_controller = controller;
            MazesDic = new Dictionary<string, AMaze>();
            MazesSol = new Dictionary<string, string>();
        }

        /// <summary>
        /// get files and dirs in the given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetDir(string path)
        {
            string[] files;
            string[] dirs;
            string filesDirs = "";
            try
            {
                files = Directory.GetFiles(path);//get files at this path
                foreach (string file in files)//print all files
                {
                    filesDirs += file + "\n";
                }
            }
            catch (Exception)
            {
                filesDirs = "invalid path";
            }
            try
            {
                dirs = Directory.GetDirectories(path);//get dirs at this path
                foreach (string dirr in dirs)
                {
                    filesDirs += dirr + "\n";
                }
            }
            catch (Exception)
            {
                filesDirs = "invalid path";
            }
            return filesDirs;
        }
        /// <summary>
        /// function to display a maze in the given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public AMaze GetDisplay(string name)
        {
            Console.WriteLine("in my model");
            if (MazesDic.ContainsKey(name))
            {
                Console.WriteLine("inside the dic");
                return MazesDic[name];
            }
            return null;
        }
        /// <summary>
        /// display the solution
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetDisplaySolution(string name)
        {
            if (MazesSol.ContainsKey(name))
            {
                return MazesSol[name];
            }
            else
            {
                return ("the maze " + name + " isn't exist");
            }
        }
        /// <summary>
        /// exit 
        /// </summary>
        /// <returns></returns>
        public void GetExit()
        {
            generator.stop();
            alg.stop();
            //to cheack all the files are closed
        }
        /// <summary>
        /// function to display the size of a file in the path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetFileSize(string path)
        {
            if (File.Exists(path))
            {
                string name = Path.GetFileName(path);
                FileInfo f = new FileInfo(path);
                long size = f.Length;
                return size.ToString();
            }
            else return null;

        }
        /// <summary>
        /// function that generate 3dmaze
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void GetGenerate3dMaze(string name, int[] parameters)
        {
            ArrayList points = new ArrayList();
            for (int i = 0; i < parameters.Length; i++)
            {
                points.Add(parameters[i]);
            }
            generator = new MyMaze3dGenerator();
            AMaze maze = generator.generate(points);
            if (MazesDic.ContainsKey(name))
            {
                MazesDic[name] = maze;
            }
            else
            {
                MazesDic.Add(name, maze);
            }
            m_controller.Output("maze " + name + " is ready");
        }
        /// <summary>
        /// function that load the maze from a file and call it in his name
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        public void GetLoadMaze(string path, string name)
        {
            //Console.WriteLine("enter path");
            //Console.WriteLine(path);
            //Console.WriteLine("enter name");
            //Console.WriteLine(name);
            int r = 0;
            bool flag = true;
            List<byte> decompressed = new List<byte>();
            //  if (File.Exists(path))
            // {
            //
            FileInfo fInfo = new FileInfo(path);

            if (fInfo.Exists)
            {
                ///
                try
                {
                    using (FileStream file = new FileStream(path, FileMode.Open))
                    {

                        byte[] byteMaze = new byte[2];
                        MyMaze3DCompressor m = new MyMaze3DCompressor();
                        while ((r = file.Read(byteMaze, 0, 2)) != 0)
                        {
                            byte[] decompressbyteMaze;
                            decompressbyteMaze = m.decompress(byteMaze);
                            for (int j = 0; j < decompressbyteMaze.Length; j++)
                            {
                                decompressed.Add(decompressbyteMaze[j]);
                            }
                            Array.Clear(byteMaze, 0, byteMaze.Length);
                        }
                        byte[] bytemaze = decompressed.ToArray();
                        Maze3d mazeToAdd = new Maze3d(bytemaze);
                        MazesDic.Add(name, mazeToAdd);
                  //      if (MazesDic.Count > 0)
                    //        Console.WriteLine("good job");
                       
                    }
                }
                catch (Exception)
                {
                    m_controller.Output("problem creation file");
                }

            }
            else
            {
                m_controller.Output("this file is not exist");
            }
        }
        /// <summary>
        /// function to get the maze size in bytes and display it
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetMazeSize(string name)
        {
            return ("The size of the maze " + name + " in Bytes is " + (((Maze3d)MazesDic[name]).toByteArray()).Length);
        }
        /// <summary>
        /// this function save in the path a compress maze
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public void GetSaveMaze(string name, string path)
        {
            try
            {
                using (FileStream fileOutStream = new FileStream(path, FileMode.Create))
                {
                    using (Stream outStream = new MyCompressorStream(fileOutStream, MyCompressorStream.status.compress))
                    {
                        if (MazesDic.ContainsKey(name))
                        {
                            AMaze maze = MazesDic[name];//get the maze object from dic
                            byte[] byteMaze = ((Maze3d)maze).toByteArray();
                            ((MyCompressorStream)outStream).Write(byteMaze, 0, byteMaze.Length);
                            outStream.Flush();
                            m_controller.Output("the maze " + name + " save in the given path.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                m_controller.Output("invalid path");
            }
        }
        /// <summary>
        /// function to display the solution of the maze given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void GetSolveMaze(string name)
        {
            alg = new BreadthFirstSearch();
            Solution solution;
            if (MazesDic.ContainsKey(name))
            {
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
                m_controller.Output("solution for " + name + " is ready");
            }
            else
            {
                m_controller.Output("the maze " + name + " isn't exist");
            }
        }

        #region Generate and Solve In Threads
        public void GenerateInNewThread(string name, int[] parameters)
        {
            new Thread(() =>
            {
                GetGenerate3dMaze(name, parameters);
            }).Start();
        }

        public void SolveInNewThread(string name)
        {
            new Thread(() =>
            {
                GetSolveMaze(name);
            }).Start();
        }

        #endregion

    }
}