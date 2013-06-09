using System;
using System.Linq;
using System.Text;

internal static class Messages
{
    internal static StringBuilder Output { get; set; }

    internal static void EventAdded()
    {
        Output.Append("Event added" + System.Environment.NewLine);
    }

    internal static void EventDeleted(int x)
    {
        if (x == 0)
        {
            NoEventsFound();
        }
        else
        {
            Output.AppendFormat("{0} events deleted{1}", x, System.Environment.NewLine);
        }
    }

    internal static void NoEventsFound()
    {
        Output.Append("No events found" + System.Environment.NewLine);
    }

    internal static void PrintEvent(Event eventToPrint)
    {
        if (eventToPrint != null)
        {
            Output.Append(eventToPrint + System.Environment.NewLine);
        }
    }
}