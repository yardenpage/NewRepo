using ATP2016Project.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    ICommand c;
                    m_commands.Add(m_input.ToString(), c);
                }
            }
        }

        public void Start()
        {
            Console.WriteLine("Command started!\n");
            PrintInstructions();
            string userCommand;
            while (true)
            {
                Console.Write(">>");
                userCommand = Console.ReadLine();
                if (userCommand == "exit")
                {
                    break;
                }

                byte[] buffer = new byte[2048];
                int bytes;
                Console.WriteLine("Insert your command: \n");
                bytes = m_input.Read(buffer, 0, buffer.Length);
                if (m_commands.ContainsKey(m_input.ToString()))
                {
                    m_commands[m_input.ToString()].DoCommand();
                }
                else
                {
                    Output("Unrecognized command!");
                   
                }
            }
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Enter calculation in 'X [operator] Y' format, ror example '3 + 5' or '6 * 8'.");
            Console.WriteLine("Press 'exit' to finish.");
            Console.WriteLine("");
        }

        public void Output(string output)
        {
            Console.WriteLine(output);
            m_output.Write("Unrecognized command!");
        }
    }
}
