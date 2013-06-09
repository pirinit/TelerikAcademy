using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CalendarSystem
{
    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionary<string, EventItem> eventsByTitle = 
            new MultiDictionary<string, EventItem>(true);

        private readonly OrderedMultiDictionary<DateTime, EventItem> eventsByDate = 
            new OrderedMultiDictionary<DateTime, EventItem>(true);

        public int Count
        {
            get
            {
                return this.eventsByTitle.KeyValuePairs.Count;
            }
        }

        public void AddEvent(EventItem eventItem)
        {
            string eventTitleLowerCase = eventItem.Title.ToLowerInvariant();
            this.eventsByTitle.Add(eventTitleLowerCase, eventItem);
            this.eventsByDate.Add(eventItem.Date, eventItem);
        }

        public int DeleteEventsByTitle(string title)
        {
            string eventTitleLowerCase = title.ToLowerInvariant();
            var eventItemsToDelete = this.eventsByTitle[eventTitleLowerCase];
            int deletedElementsCount = eventItemsToDelete.Count;
            foreach (var eventItem in eventItemsToDelete)
            {
                this.eventsByDate.Remove(eventItem.Date, eventItem);
            }

            this.eventsByTitle.Remove(eventTitleLowerCase);

            return deletedElementsCount;
        }

        public IEnumerable<EventItem> ListEvents(DateTime date, int count)
        {
            var matchingEvents = this.eventsByDate.RangeFrom(date, true).Values;
            return matchingEvents.Take(count);
        }
    }
}
