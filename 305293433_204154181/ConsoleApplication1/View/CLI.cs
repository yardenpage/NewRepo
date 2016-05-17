using ATP2016Project.Controller;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ATP2016Project.View
{
    public class CLI : IView
    {
        private IController m_controller;
        private Stream m_input;
        private Stream m_output;

        private Dictionary<string, ICommand> m_commands;

        public CLI(IController controller)
        {
            m_controller = controller;
            m_input = Console.OpenStandardInput();
            m_output = Console.OpenStandardOutput();
            m_commands = new Dictionary<string, ICommand>();
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

        public void SetInput(Stream input)
        {
            m_input = input;
        }

        public void SetOutput(Stream output)
        {
            m_output = output;
        }

        public void SetCommands(Dictionary<string, ICommand> commands)
        {
            m_commands = commands;
        }

        

        public void Start()
        {
            Console.WriteLine("Command started!\n");
            PrintInstructions();
            string userCommand;
            byte[] array;

            while (true)
            {
                array = Encoding.UTF8.GetBytes(">>");
                m_output.Write(array, 0, 2);
                StreamReader reader = new StreamReader(m_input);
                userCommand = reader.ReadLine().Trim();
                if (userCommand == "exit")
                {
                    break;
                }
                else
                {
                    try
                    {
                        if (m_commands.ContainsKey(userCommand))
                        {
                            m_commands[userCommand].DoCommand();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        Output("Unrecognized command!");
                    }
                }
            }
            //    stdout.Write(buffer, 0, bytes);
            //    Console.WriteLine("before ans");
            //    ans = System.Text.Encoding.UTF8.GetString(buffer, 0, bytes - 2);
            //    Console.WriteLine(ans);
            //    Console.WriteLine("after ans");
            //    if (ans.Equals("exit"))
            //        Console.WriteLine("this is the end");
            //    //   ans = buffer.ToString();
            //}
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Command Line Interface (CLI) started!");
            Console.WriteLine("");
            Console.WriteLine("Enter the name of the command to execute.");
            //Console.WriteLine(String.Format("Available operators:{0}sum (summation){0}sub (substraction){0}div (division){0}mult (multiplication){0}pow (power){0}save <path>{0}load <path>", "\n"));
            Console.WriteLine("");
            Console.WriteLine("Press 'exit' to finish.");
        }

        public void DisplayMaze(AMaze maze)
        {
            maze.print();
        }

        public void Output(string output)
        {
            byte[] outString = System.Text.Encoding.UTF8.GetBytes(output.ToCharArray());
            m_output.Write(outString, 0, outString.Length);
        }
    }
}
