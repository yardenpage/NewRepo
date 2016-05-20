﻿using System;
using System.Collections.Generic;
using ATP2016Project.Controller;
using System.Collections;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.Model.Algorithms.Search;
using System.IO;
using ATP2016Project.Model.Algorithms.Compression;
using System.Runtime.CompilerServices;
using System.Threading;

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
                    //Console.WriteLine(file);
                    filesDirs += file + "\n";
                }
                dirs = Directory.GetDirectories(path);//get dirs at this path
                foreach (string dirr in dirs)
                {
                    filesDirs += dirr + "\n";
                }
            }
            catch (Exception)
            {
                filesDirs="Invalid path";
            }
            return filesDirs;
        }
        /// <summary>
        /// function to display a maze in the given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AMaze GetDisplay(string name)
        {
            if (MazesDic.ContainsKey(name))
            {
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
            return null;
        }
        /// <summary>
        /// exit 
        /// </summary>
        /// <returns></returns>
        public string GetExit()
        {
            throw new NotImplementedException();
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
            else
                return null;
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
            m_controller.Output("maze " + name + " is ready");
        }
        /// <summary>
        /// function that load the maze from a file and call it in his name
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        public void GetLoadMaze(string path, string name)
        {
            if (File.Exists(path))
            {
                FileStream file = new FileStream(path, FileMode.Open);
                MyCompressorStream compressor = new MyCompressorStream(file, MyCompressorStream.status.decompress);
                int size = (((Maze3d)MazesDic[name]).toByteArray()).Length;
                byte[] byteMaze = new byte[size];
                string sizeToRead = GetFileSize(path);
                compressor.Read(byteMaze, 0, Int32.Parse(sizeToRead));
                Maze3d mazeToAdd = new Maze3d(byteMaze);
                MazesDic[name] = mazeToAdd;
            }
            else
            {
                Console.WriteLine("this file isn't exist");
            }
        }
        /// <summary>
        /// function to get the maze size in bytes and display it
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetMazeSize(string name)
        {
            return "The size of the maze " + name + " in Bytes is " + (((Maze3d)MazesDic[name]).toByteArray()).Length;
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
                FileStream file = new FileStream(path, FileMode.Create);
                MyCompressorStream compressor = new MyCompressorStream(file, MyCompressorStream.status.compress);
                AMaze maze = MazesDic[name];//get the maze object from dic
                byte[] byteMaze = ((Maze3d)maze).toByteArray();
                compressor.Write(byteMaze, 0, byteMaze.Length);
                m_controller.Output("the maze " + name + " save in the given path.");
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
            ASearchingAlgorithm alg = new BreadthFirstSearch(); ;
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