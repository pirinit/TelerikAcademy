using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class EventsManagerFastTests
    {
        [TestMethod]
        public void AddSingleEventItemCheckExistance()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime date = new DateTime(2013, 5, 25);
            EventItem eventItem = new EventItem("title", date, "the moon");

            eventsManager.AddEvent(eventItem);

            int expected = 1;
            int actual = eventsManager.Count;

            Assert.AreEqual(expected, actual);

            var retrievedEventItem = eventsManager.ListEvents(date, 10);
            Assert.AreSame(eventItem, retrievedEventItem.First());
        }

        [TestMethod]
        public void AddThreeDuplicatingEventItems()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            EventItem eventItem = new EventItem("title", DateTime.Now, "the moon");

            eventsManager.AddEvent(eventItem);
            eventsManager.AddEvent(eventItem);
            eventsManager.AddEvent(eventItem);

            int expected = 3;
            int actual = eventsManager.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeDifferentEventItems()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime date = new DateTime(2013, 5, 25);

            EventItem eventItem2 = new EventItem("title", date.AddDays(5), "the moon");
            EventItem eventItem3 = new EventItem("title", date.AddDays(8), "the moon");
            EventItem eventItem1 = new EventItem("title", date, "the moon");

            eventsManager.AddEvent(eventItem1);
            eventsManager.AddEvent(eventItem2);
            eventsManager.AddEvent(eventItem3);

            int expected = 3;
            int actual = eventsManager.Count;

            Assert.AreEqual(expected, actual);
            var retrievedEventItem = eventsManager.ListEvents(date, 10);
            //first item should be with the earliest date
            Assert.AreSame(eventItem1, retrievedEventItem.First());
        }

        [TestMethod]
        public void AddThreeSameTitleDifferentDateEventItemsAndListThemBackOrdered()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime date = new DateTime(2013, 5, 25);

            EventItem eventItem2 = new EventItem("title", date.AddDays(5), "the moon");
            EventItem eventItem3 = new EventItem("title", date.AddDays(8), "the moon");
            EventItem eventItem1 = new EventItem("title", date, "the moon");

            eventsManager.AddEvent(eventItem1);
            eventsManager.AddEvent(eventItem2);
            eventsManager.AddEvent(eventItem3);

            var retrievedEventItem = eventsManager.ListEvents(date, 10);
            //check order
            Assert.AreSame(eventItem1, retrievedEventItem.First());
            Assert.AreSame(eventItem2, retrievedEventItem.Skip(1).First());
            Assert.AreSame(eventItem3, retrievedEventItem.Skip(2).First());
        }

        [TestMethod]
        public void AddTenDifferentEventItemsAndListBackTwo()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime date = new DateTime(2013, 5, 25);

            for (int i = 0; i < 10; i++)
            {
                EventItem eventItem2 = new EventItem("title", date.AddDays(5), "the moon");
                eventsManager.AddEvent(eventItem2);
            }

            var retrievedEventItem = eventsManager.ListEvents(date, 2);
            Assert.AreEqual(2, retrievedEventItem.Count());
        }

        [TestMethod]
        public void AddTenDifferentEventItemsDifferentDatesAndListBackLastFive()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime date = new DateTime(2013, 5, 25);

            for (int i = 0; i < 10; i++)
            {
                EventItem eventItem = new EventItem("title", date.AddDays(i), "the moon");
                eventsManager.AddEvent(eventItem);
            }

            var retrievedEventItem = eventsManager.ListEvents(date.AddDays(5),10);
            Assert.AreEqual(5, retrievedEventItem.Count());
        }

        [TestMethod]
        public void AddTenDifferentEventItemsTryToListAfterLastDate()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime date = new DateTime(2013, 5, 25);

            for (int i = 0; i < 10; i++)
            {
                EventItem eventItem = new EventItem("title", date.AddDays(i), "the moon");
                eventsManager.AddEvent(eventItem);
            }

            var retrievedEventItem = eventsManager.ListEvents(date.AddDays(5555), 10);
            Assert.AreEqual(0, retrievedEventItem.Count());
        }

        [TestMethod]
        public void AddTenDifferentEventItemsDeleteOne()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime date = new DateTime(2013, 5, 25);

            for (int i = 0; i < 10; i++)
            {
                EventItem eventItem = new EventItem("title" + i, date.AddDays(i), "the moon");
                eventsManager.AddEvent(eventItem);
            }

            int actual = eventsManager.DeleteEventsByTitle("title5");
            Assert.AreEqual(1, actual);
            Assert.AreEqual(9, eventsManager.Count);
        }

        [TestMethod]
        public void TryToDeleteNonExistingEventItem()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime date = new DateTime(2013, 5, 25);

            for (int i = 0; i < 10; i++)
            {
                EventItem eventItem = new EventItem("title" + i, date.AddDays(i), "the moon");
                eventsManager.AddEvent(eventItem);
            }

            int actual = eventsManager.DeleteEventsByTitle("nonexistingEvent");
            Assert.AreEqual(0, actual);
            Assert.AreEqual(10, eventsManager.Count);
        }

        [TestMethod]
        public void AddTenDifferentEventItemsDeleteTwoCheckMissing()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime date = new DateTime(2013, 5, 25);

            for (int i = 0; i < 10; i++)
            {
                EventItem eventItem = new EventItem("title" + i, date.AddDays(i), "the moon");
                eventsManager.AddEvent(eventItem);
            }
            //check existance
            var retrievedEventItem = eventsManager.ListEvents(date.AddDays(4), 10);
            Assert.AreEqual(6, retrievedEventItem.Count());

            //delete
            int actual = eventsManager.DeleteEventsByTitle("title5");
            actual += eventsManager.DeleteEventsByTitle("title6");
            Assert.AreEqual(2, actual);
            Assert.AreEqual(8, eventsManager.Count);

            //check missing
            retrievedEventItem = eventsManager.ListEvents(date.AddDays(4), 10);
            Assert.AreEqual(4, retrievedEventItem.Count());
        }
    }
}
