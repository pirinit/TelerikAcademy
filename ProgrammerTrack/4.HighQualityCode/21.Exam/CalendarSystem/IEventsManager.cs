using System;
using System.Collections.Generic;

namespace CalendarSystem
{
    public interface IEventsManager
    {
        /// <summary>
        /// Adds an eventItem to the CalendarSystem.
        /// </summary>
        void AddEvent(EventItem eventItem);

        /// <summary>
        /// Deletes all events in the CalendarSystem with matching title.
        /// </summary>
        /// <param name="title">title to match</param>
        /// <returns>count of the deleted events</returns>
        int DeleteEventsByTitle(string title);

        /// <summary>
        /// Lists events that starts after the given date and time.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="count">max count of events to list</param>
        /// <returns>IEnumerable containing at most count events starting after the given date and time</returns>
        IEnumerable<EventItem> ListEvents(DateTime date, int count);
    }
}
