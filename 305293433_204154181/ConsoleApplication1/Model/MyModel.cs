using ATP2016Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016Project.Controller;

namespace ATP2016Project.Model
{
    public class MyModel : IModel
    {
        private IController controller;

        public MyModel(IController controller)
        {
            this.controller = controller;
        }

        public string GetDir(string path)
        {
            throw new NotImplementedException();
        }

        public string GetDisplay(string name)
        {
            throw new NotImplementedException();
        }

        public string GetDisplayCrossSectionBy(int index, string name)
        {
            throw new NotImplementedException();
        }

        public string GetDisplaySolution(string name)
        {
            throw new NotImplementedException();
        }

        public string GetExit()
        {
            throw new NotImplementedException();
        }

        public string GetFileSize(string path)
        {
            throw new NotImplementedException();
        }

        public string GetGenerate3dMaze(string name, params int[] parameters)
        {
            throw new NotImplementedException();
        }

        public string GetLoadMaze(string path, string name)
        {
            throw new NotImplementedException();
        }

        public string GetMazeSize(string name)
        {
            throw new NotImplementedException();
        }

        public string GetSaveMaze(string name, string path)
        {
            throw new NotImplementedException();
        }

        public string GetSolveMaze(string name, Algorithms a)
        {
            throw new NotImplementedException();
        }
    }
}
