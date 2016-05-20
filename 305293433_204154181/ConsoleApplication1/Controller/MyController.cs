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
        private Dictionary<string, string[]> parameters;
        /// <summary>
        /// constructor of MyController
        /// </summary>
        /// <param name="model"></param>
        /// <param name="view"></param>
        public MyController()
        {
        }
        /// <summary>
        /// set the given model
        /// </summary>
        /// <param name="model"></param>
        public void SetModel(IModel model)
        {
            m_model = model;
        }
        /// <summary>
        /// set the given view
        /// </summary>
        /// <param name="view"></param>
        public void SetView(IView view)
        {
            m_view = view;
            m_view.SetCommands(GetCommands());
            m_view.SetParameters(GetParameters());
        }
        /// <summary>
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

        public Dictionary<string, string[]> GetParameters()
        {
            parameters = new Dictionary<string, string[]>();
            ArrayList parstring = new ArrayList();
            string[] s1 = new string[1];
            s1[0] = "<path>";
            string[] s2 = new string[4];
            s2[0] = "<maze name>";
            s2[1] = "<width value>";
            s2[2] = "<length value>";
            s2[3] = "<hight value>";
            string[] s3 = new string[1];
            s3[0] = "<maze name>";
            string[] s4 = new string[2];
            s4[0] = "<maze name>";
            s4[1] = "<file path>";
            string[] s5 = new string[2];
            s5[0] = "<file path>";
            s5[1] = "<maze name>";
            string[] s6 = new string[1];
            s6[0] = "<file path>";
            string[] s7 = new string[0];
            parameters.Add("dir", s1);          
            parameters.Add("generate3dmaze", s2);          
            parameters.Add("display", s3);          
            parameters.Add("savemaze", s4);
            parameters.Add("loadmaze", s5);
            parameters.Add("mazesize", s3);
            parameters.Add("filesize", s6);
            parameters.Add("solvemaze", s3);
            parameters.Add("displaysolution", s3);
            parameters.Add("exit", s7); 
            return parameters;
        }
        /// display the output
        /// </summary>
        /// <param name="output">string to output</param>
        public void Output(string output)
        {
            m_view.Output(output);
        }


    }
}
