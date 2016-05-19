﻿using ATP2016Project.Controller;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using System;
using System.Collections;
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
        private Dictionary<string, ArrayList> m_commandsparameters;
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
        /// start the runnimg
        /// </summary>
        public void Start()
        {
            
            Console.WriteLine("Command started!\n");
            PrintInstructions();
            string userCommand;
            string[] partedCommand;
            string[] parameters;
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
                        try {
                            parameters = new string[partedCommand.Length - 1];
                            for (int i = 1; i < parameters.Length; i++)
                            {
                                parameters[i - 1] = partedCommand[i];
                            }
                            if (parameters.Length == m_commandsparameters[command].Count)
                                m_commands[command].DoCommand(partedCommand);
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (Exception)
                        {
                            Output("Invalid number of parameters!");
                        }
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
        private void PrintInstructions()
        {
            Console.WriteLine("Command Line Interface (CLI) started!");
            Console.WriteLine("");
            Console.WriteLine("Enter the name of the command to execute.");
            Console.WriteLine("");
            Console.WriteLine("Available Commands:");
            int count = 1;
            foreach (KeyValuePair <string, ArrayList> value in m_commandsparameters)
            {
                Console.Write(count+".  ");
                Console.Write(value.Key);
                Console.Write(" ");
                for(int i=0; i<value.Value.Count; i++)
                {
                    Console.Write(value.Value[i]+" ");
                }
                count++;
            }
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
        public void SetParameters(Dictionary<string, ArrayList> parameters)
        {
            m_commandsparameters = parameters;
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
