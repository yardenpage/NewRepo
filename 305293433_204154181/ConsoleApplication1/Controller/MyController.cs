using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016Project.View;
using ATP2016Project.Model;
using System.Collections;

namespace ATP2016Project.Controller
{/// <summary>
/// MyController implement IController interface
/// </summary>
    public class MyController : IController
    {
        private IModel m_model;
        private IView m_view;
        private Dictionary<string, ACommand> commands;
        private Dictionary<string, ArrayList> parameters;
        /// <summary>
        /// constructor of MyController
        /// </summary>
        /// <param name="model"></param>
        /// <param name="view"></param>
        public MyController(IModel model, IView view)
        {
            m_model = model;
            m_view = view;
            m_view.SetCommands(GetCommands());
            m_view.SetParameters(GetParameters());
        }/// <summary>
         /// return the command dictionary
         /// </summary>
         /// <returns></returns>
        public Dictionary<string, ACommand> GetCommands()
        {
            commands = new Dictionary<string, ACommand>();
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

        public Dictionary<string, ArrayList> GetParameters()
        {
            parameters = new Dictionary<string, ArrayList>();
            ArrayList parstring = new ArrayList();
            parstring.Add("<path>");
            parameters.Add("dir", parstring);
            parstring.Clear();
            parstring.Add("<maze name>");
            parstring.Add("<width value>");
            parstring.Add("<length value>");
            parstring.Add("<hight value>");
            parameters.Add("generate 3d maze", parstring);
            parstring.Clear();
            parstring.Add("<maze name>");
            parameters.Add("display", parstring);
            parstring.Clear();
            parstring.Add("<maze name>");
            parstring.Add("<file path>");
            parameters.Add("save maze", parstring);
            parstring.Clear();
            parstring.Add("<file path>");
            parstring.Add("<maze name>");
            parameters.Add("load maze", parstring);
            parstring.Clear();
            parstring.Add("<maze name>");
            parameters.Add("maze size", parstring);
            parstring.Clear();
            parstring.Add("<file path>");
            parameters.Add("file size", parstring);
            parstring.Clear();
            parstring.Add("<maze name>");
            parameters.Add("solve maze", parstring);
            parameters.Add("display solution", parstring);
            parstring.Clear();
            parameters.Add("exit", parstring); 
            return parameters;
        }
        /// display the output
        /// </summary>
        /// <param name="output">string to output</param>
        public void Output(string output)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// set the given model
        /// </summary>
        /// <param name="model"></param>
        public void SetModel(IModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// set the given view
        /// </summary>
        /// <param name="view"></param>
        public void SetView(IView view)
        {
            throw new NotImplementedException();
        }
    }
}
