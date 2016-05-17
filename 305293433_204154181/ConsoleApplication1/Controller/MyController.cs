using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016Project.View;
using ATP2016Project.Model;

namespace ATP2016Project.Controller
{
    public class MyController : IController
    {
        private IModel m_model;
        private IView m_view;

        public MyController(IModel model, IView view)
        {
            m_model = model;
            m_view = view;
            m_view.SetCommands(GetCommands());
        }
        private Dictionary<string, ACommand> GetCommands()
        {
            Dictionary<string, ACommand> commands = new Dictionary<string, ACommand>();
            ACommand dir = new DirCommand(m_model, m_view);
            ACommand display = new DisplayCommand(m_model, m_view);
            ACommand displaysolution = new DisplaySolutionCommand(m_model, m_view);
            ACommand exit = new ExitCommand(m_model, m_view);
            ACommand filesize = new FileSizeCommand(m_model, m_view);
            ACommand generate3dmaze = new Generate3dMazeCommand(m_model, m_view);
            ACommand loadmaze = new LoadMazeCommand(m_model, m_view);
            ACommand mazesize = new MazeSizeCommand(m_model, m_view);
            ACommand savemaze = new SaveMazeCommand(m_model, m_view);
            ACommand solvemaze = new SolveMazeCommand(m_model, m_view);
            commands.Add(dir.GetName(), dir);
            commands.Add(display.GetName(), display);
            commands.Add(displaysolution.GetName(), displaysolution);
            commands.Add(exit.GetName(), exit);
            commands.Add(filesize.GetName(), filesize);
            commands.Add(generate3dmaze.GetName(), generate3dmaze);
            commands.Add(loadmaze.GetName(), loadmaze);
            commands.Add(mazesize.GetName(), mazesize);
            commands.Add(savemaze.GetName(), savemaze);
            commands.Add(solvemaze.GetName(), solvemaze);
            return commands;
        }
        public Dictionary<string, ICommand> getCommands()
        {
            throw new NotImplementedException();
        }

        public void Output(string output)
        {
            throw new NotImplementedException();
        }

        public void SetModel(IModel model)
        {
            throw new NotImplementedException();
        }

        public void SetView(IView view)
        {
            throw new NotImplementedException();
        }
    }
}
