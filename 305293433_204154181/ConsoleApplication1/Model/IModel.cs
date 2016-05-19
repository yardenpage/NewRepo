using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.Model.Algorithms.Search;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model
{
    /// <summary>
    /// interface of  IModel
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// get files and dirs in the given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string GetDir(string path);
        /// <summary>
        /// function that generate 3dmaze
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
         void GetGenerate3dMaze(string name, params int[] parameters);
        /// <summary>
        /// function to display a maze in the given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        AMaze GetDisplay(string name);
        /// <summary>
        /// this function save in the path a compress maze
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        void GetSaveMaze(string name, string path);
        /// <summary>
        /// function that load the maze from a file and call it in his name
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        void GetLoadMaze(string path, string name);
        /// <summary>
        /// function to get the maze size in bytes and display it
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string GetMazeSize(string name);
        /// <summary>
        /// function to display the size of a file in the path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string GetFileSize(string path);
        /// <summary>
        /// function to display the solution of the maze given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        void GetSolveMaze(string name);
        /// <summary>
        /// display the solution
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string GetDisplaySolution(string name);
        /// <summary>
        /// exit 
        /// </summary>
        /// <returns></returns>
        string GetExit();

        void GenerateInNewThread(string name, int[] parameters);

        void SolveInNewThread(string name);
    }
}
