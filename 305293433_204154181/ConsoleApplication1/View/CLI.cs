using ATP2016Project.Controller;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ATP2016Project.View
{
    /// <summary>
    /// CLI implements IView interface
    /// </summary>
    public class CLI : IView
    {
        private IController m_controller;
        private Stream m_input;
        private Stream m_output;
        private Dictionary<string, ACommand> m_commands;
        private string m_cursor = ">>";
        /// <summary>
        /// CLI constructor
        /// </summary>
        /// <param name="controller"></param>
        public CLI(IController controller)
        {
            m_controller = controller;
            m_input = Console.OpenStandardInput();
            m_output = Console.OpenStandardOutput();
            m_commands = new Dictionary<string, ACommand>();
            byte[] buffer = new byte[2048];
            int bytes;
            Console.WriteLine("Insert your commands, at the end each command press enter, to pinish enter 'Done': \n");
            while ((bytes = m_input.Read(buffer, 0, buffer.Length)) > 0)
            {
                if (!m_commands.ContainsKey(m_input.ToString()))
                {
                    //ICommand c = new ACommand();
                    //m_commands.Add(m_input.ToString(), c);
                }
            }
        }
        /// <summary>
        /// set input
        /// </summary>
        /// <param name="input"></param>
        public void SetInput(Stream input)
        {
            m_input = input;
        }
        /// <summary>
        /// sat output
        /// </summary>
        /// <param name="output"></param>
        public void SetOutput(Stream output)
        {
            m_output = output;
        }
        /// <summary>
        /// set commands
        /// </summary>
        /// <param name="commands"></param>
        public void SetCommands(Dictionary<string, ACommand> commands)
        {
            m_commands = commands;
        }

        /// <summary>
        /// start the runnimg
        /// </summary>
        public void Start()
        {
            
            Console.WriteLine("Command started!\n");
            PrintInstructions();
            string userCommand;
            string[] partedCommand;
            string command;
            while (true)
            {
                Output("");
                try
                {
                    userCommand = Input().Trim();
                    if (userCommand == "exit") { break; }

                    partedCommand = userCommand.Split(' ');
                    command = partedCommand[0].Trim();

                    if (!m_commands.ContainsKey(command.ToLower()) /*|| splitedCommand.Length != 3*/)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        m_commands[command].DoCommand(partedCommand);
                    }
                }
                catch (Exception)
                    {
                        Output("Unrecognized command!");
                    }
                }
            }

        /// <summary>
        /// print all the instructions
        /// </summary>
        private static void PrintInstructions()
        {
            Console.WriteLine("Command Line Interface (CLI) started!");
            Console.WriteLine("");
            Console.WriteLine("Enter the name of the command to execute.");
            //Console.WriteLine(String.Format("Available operators:{0}sum (summation){0}sub (substraction){0}div (division){0}mult (multiplication){0}pow (power){0}save <path>{0}load <path>", "\n"));
            Console.WriteLine("");
            Console.WriteLine("Press 'exit' to finish.");
        }
        /// <summary>
        /// diaplay a maze
        /// </summary>
        /// <param name="maze"></param>
        public void DisplayMaze(AMaze maze)
        {
            maze.print();
        }
        /// <summary>
        /// display an output
        /// </summary>
        /// <param name="output"></param>
        /* public void Output(string output)
         {
             byte[] outString = System.Text.Encoding.UTF8.GetBytes(output.ToCharArray());
             m_output.Write(outString, 0, outString.Length);
         }*/
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Output(string output)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            StreamWriter streamWriter = new StreamWriter(m_output);
            streamWriter.AutoFlush = true;
            Console.SetCursorPosition(0, Console.CursorTop);
            streamWriter.WriteLine(output);
            streamWriter.WriteLine("");
            streamWriter.Write(m_cursor);
            Console.ResetColor();
        }
        /// <summary>
        /// set the given command dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        public void SetCommands(Dictionary<string, ACommand> commands)
        {
            m_commands = commands;
        }
        /// <summary>
        /// return string of the input
        /// </summary>
        /// <returns></returns>
        public string Input()
        {
            StreamReader streamReader = new StreamReader(m_input);
            return streamReader.ReadLine();
        }
    }
}
