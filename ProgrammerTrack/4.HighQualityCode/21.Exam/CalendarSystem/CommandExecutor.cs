using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CalendarSystem
{
    public class CommandExecutor
    {
        private readonly IEventsManager eventsManager;

        public CommandExecutor(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        public IEventsManager EventsManager
        {
            get
            {
                return this.eventsManager;
            }
        }

        public void ProcessCommand(Command command, StringBuilder output)
        {
            switch (command.Name)
            {
                case "AddEvent":
                    this.ProcessAddEventcommand(command, output);
                    break;
                case "DeleteEvents":
                    this.ProcessDeleteEventCommand(command, output);
                    break;
                case "ListEvents":
                    this.ProcessListEventsCommand(command, output);
                    break;
                default:
                    throw new ArgumentException("Unknown command " + command.Name);
            }
        }

        private void ProcessListEventsCommand(Command command, StringBuilder output)
        {
            if (command.Paramms.Length == 2)
            {
                var date = DateTime.ParseExact(command.Paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var maxEventsToList = int.Parse(command.Paramms[1]);
                var events = this.eventsManager.ListEvents(date, maxEventsToList).ToList();

                if (!events.Any())
                {
                    output.AppendLine("No events found");
                }

                foreach (var eventItem in events)
                {
                    output.AppendLine(eventItem.ToString());
                }

                // bottleneck  - calling .ToString method of the StringBuilder and
                // then adding the result to other StringBuilder in the main method of the program
                // or even worse - using Console.WriteLine every time
                // solution - passing single StringBuilder to every method and adding its output there
            }
            else
            {
                throw new ArgumentException("Incorrect number of parameters " + command.Paramms.Length);
            }
        }

        private void ProcessDeleteEventCommand(Command command, StringBuilder output)
        {
            if (command.Paramms.Length == 1)
            {
                int deletedEventsCount = this.eventsManager.DeleteEventsByTitle(command.Paramms[0]);

                if (deletedEventsCount == 0)
                {
                    output.AppendLine("No events found");
                    return;
                }

                string result = string.Format("{0} events deleted", deletedEventsCount);
                output.AppendLine(result);
            }
            else
            {
                throw new ArgumentException("Incorrect number of parameters " + command.Paramms.Length);
            }
        }

        private void ProcessAddEventcommand(Command command, StringBuilder output)
        {
            if (command.Paramms.Length == 2)
            {
                DateTime date = DateTime.ParseExact(command.Paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                string title = command.Paramms[1];
                var newEventItem = new EventItem(title, date, null);        
        
                this.eventsManager.AddEvent(newEventItem);

                output.AppendLine("Event added");
            }
            else if (command.Paramms.Length == 3)
            {
                DateTime date = DateTime.ParseExact(command.Paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                string title = command.Paramms[1];
                string location = command.Paramms[2];
                var newEventItem = new EventItem(title, date, location);        
        
                this.eventsManager.AddEvent(newEventItem);

                output.AppendLine("Event added");
            }
            else
            {
                throw new ArgumentException("Incorrect number of parameters " + command.Paramms.Length);
            }
        }
    }
}