using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model
{
    public interface IModel
    {
        string GetDir(string path);
        string GetGenerate3dMaze(string name, params int[] parameters);
        string GetDisplay(string name);
        string GetDisplayCrossSectionBy(int index, string name);
        string GetSaveMaze(string name, string path);
        string GetLoadMaze(string path, string name);
        string GetMazeSize(string name);
        string GetFileSize(string path);
        string GetSolveMaze(string name, Algorithms a);
        string GetDisplaySolution(string name);
        string GetExit();
    }
}
