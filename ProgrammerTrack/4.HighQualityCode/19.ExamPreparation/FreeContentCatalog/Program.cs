using System;
using System.Collections.Generic;
using System.Text;

namespace FreeContentCatalog
{
    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            List<ICommand> commands = ReadInput();
            foreach (ICommand command in commands)
            {
                commandExecutor.ExecuteCommand(catalog, command, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> ReadInput()
        {
            List<ICommand> commands = new List<ICommand>();
            string input = Console.ReadLine();

            while (input.Trim() != "End")
            {
                commands.Add(new Command(input));
                input = Console.ReadLine();
            }

            return commands;
        }
    }
}