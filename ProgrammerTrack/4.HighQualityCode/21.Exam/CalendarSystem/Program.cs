using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarSystem
{
    public class Program
    {
        static void Main()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            CommandExecutor commandExecutor = new CommandExecutor(eventsManager);

            List<string> input = ReadInput();
            StringBuilder output = new StringBuilder();

            foreach (string line in input)
            {
                Command command = Command.Parse(line);
                commandExecutor.ProcessCommand(command, output);
            }

            // bottleneck - consecutive using of Console.WriteLine method
            // using StringBuilder is a better solution
            Console.Write(output.ToString());
        }

        private static List<string> ReadInput()
        {
            List<string> commands = new List<string>();
            string input = Console.ReadLine();

            while (input != "End" && input != null)
            {
                commands.Add(input);
                input = Console.ReadLine();
            }

            return commands;
        }
    }
}