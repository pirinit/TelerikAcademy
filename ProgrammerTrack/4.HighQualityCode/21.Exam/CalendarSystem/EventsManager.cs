using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarSystem
{
    public class EventsManager : IEventsManager
    {
        private readonly List<EventItem> events = new List<EventItem>();

        public void AddEvent(EventItem eventItem)
        {
            this.events.Add(eventItem);
        }

        public int DeleteEventsByTitle(string title)
        {
            return this.events.RemoveAll(
                e => e.Title.ToLowerInvariant() == title.ToLowerInvariant());
        }

        public IEnumerable<EventItem> ListEvents(DateTime date, int count)
        {
            return (from eventItem in this.events
                    where eventItem.Date >= date
                    orderby eventItem.Date, eventItem.Title, eventItem.Location
                    select eventItem).Take(count);
        }
    }
}
