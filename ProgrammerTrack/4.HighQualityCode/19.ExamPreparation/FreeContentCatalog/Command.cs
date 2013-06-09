using System;
using System.Linq;
using System.Text;

namespace FreeContentCatalog
{
    public class Command : ICommand
    {
        readonly char[] paramsSeparators = { ';' };
        readonly char commandEnd = ':';

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
            this.Parse();
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();
            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.Type = this.ParseCommandType(this.Name);
        }

        public CommandType ParseCommandType(string commandName)
        {
            CommandType type;

            switch (commandName.Trim())
            {
                case "Add book":
                    type = CommandType.AddBook;
                    break;
                case "Add movie":
                    type = CommandType.AddMovie;
                    break;
                case "Add song":
                    type = CommandType.AddSong;
                    break;
                case "Add application":
                    type = CommandType.AddApplication;
                    break;
                case "Update":
                    type = CommandType.Update;
                    break;
                case "Find":
                    type = CommandType.Find;
                    break;
                default:
                    {
                        string message = string.Format("Invalid command name! ({0}).", commandName.Trim());
                        throw new InvalidOperationException(message);
                    }
            }

            return type;
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex);
            return name;
        }

        public string[] ParseParameters()
        {
            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 1);

            string[] parameters = paramsOriginalForm.Split(paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(commandEnd);

            return endIndex;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} ", this.Name);

            foreach (string param in this.Parameters)
            {
                sb.AppendFormat("{0} ", param);
            }
            return sb.ToString();
        }
    }
}