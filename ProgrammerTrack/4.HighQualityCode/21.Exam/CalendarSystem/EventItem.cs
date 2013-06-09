using System;

namespace CalendarSystem
{
    public class EventItem : IComparable<EventItem>
    {
        public EventItem(string title, DateTime date, string location)
        {
            this.Title = title;
            this.Date = date;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public override string ToString()
        {
            string format = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";
            if (this.Location != null)
            {
                format += " | {2}";
            }

            string eventAsString = string.Format(format, this.Date, this.Title, this.Location);
            return eventAsString;
        }

        public int CompareTo(EventItem other)
        {
            int datesCompared = DateTime.Compare(this.Date, other.Date);
            if (datesCompared != 0)
            {
                return datesCompared;
            }

            // bottleneck - a lot of unnecessary comparison is done for each char in the title
            // and only the last one matters. There is no need of the foreach loop - deleted.
            int titlesCompared = string.Compare(this.Title, other.Title);

            if (titlesCompared != 0)
            {
                return titlesCompared;
            }

            int locationsCompared = string.Compare(this.Location, other.Location);

            return locationsCompared;
        }
    }
}
