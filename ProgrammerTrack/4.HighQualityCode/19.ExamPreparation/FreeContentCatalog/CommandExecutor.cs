using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeContentCatalog
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    catalog.Add(new Content(ContentType.Book, command.Parameters));
                    output.AppendLine("Book added");
                    break;
                case CommandType.AddMovie:
                    catalog.Add(new Content(ContentType.Movie, command.Parameters));
                    output.AppendLine("Movie added");
                    break;
                case CommandType.AddSong:
                    catalog.Add(new Content(ContentType.Song, command.Parameters));
                    output.AppendLine("Song added");
                    break;
                case CommandType.AddApplication:
                    catalog.Add(new Content(ContentType.Application, command.Parameters));
                    output.AppendLine("Application added");
                    break;
                case CommandType.Update:
                    ProcessUpdateCommand(command, catalog, output);
                    break;
                case CommandType.Find:
                    ProcessFindCommand(command, catalog, output);
                    break;
                default:
                    {
                        throw new InvalidOperationException("Unknown command!");
                    }
            }
        }
  
        private void ProcessFindCommand(ICommand command, ICatalog catalog, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                string message = string.Format("Invalid parameters count!({0})", command.Parameters.Length);
                throw new FormatException(message);
            }

            string title = command.Parameters[0];
            int maxElementsToList = int.Parse(command.Parameters[1]);

            IEnumerable<IContent> foundContent = catalog.GetListContent(title, maxElementsToList);

            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
        }
  
        private void ProcessUpdateCommand(ICommand command, ICatalog catalog, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                string message = string.Format("Invalid parameters count!({0})", command.Parameters.Length);
                throw new FormatException(message);
            }

            output.AppendLine(String.Format("{0} items updated", catalog.UpdateContent(command.Parameters[0], command.Parameters[1])));
        }
    }
}