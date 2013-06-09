using System;

namespace CalendarSystem
{
    public class Command
    {
        private const char CommandSeparator = ' ';
        private const char ParamsSeparator = '|';
        private static char[] paramsSeparatorArr = { ParamsSeparator };
        
        public Command(string name, string[] parameters)
        {
            this.Name = name;
            this.Paramms = parameters;
        }

        public string Name { get; set; }

        public string[] Paramms { get; set; }

        public static Command Parse(string inputLine)
        {
            if (string.IsNullOrWhiteSpace(inputLine))
            {
                throw new ArgumentException("InputLine can not be null or contains only white spaces.");
            }

            int cmdEndIndex = inputLine.IndexOf(CommandSeparator);
            if (cmdEndIndex == -1)
            {
                throw new ArgumentException("Invalid command line: " + inputLine);
            }

            string cmdName = inputLine.Substring(0, cmdEndIndex);
            string arguments = inputLine.Substring(cmdEndIndex + 1);

            string[] commandArguments = arguments.Split(paramsSeparatorArr, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < commandArguments.Length; i++)
            {
                commandArguments[i] = commandArguments[i].Trim();
            }

            var command = new Command(cmdName, commandArguments);

            return command;
        }
    }
}
