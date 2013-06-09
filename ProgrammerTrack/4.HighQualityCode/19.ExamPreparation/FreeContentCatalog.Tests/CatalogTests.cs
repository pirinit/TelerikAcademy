using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

namespace FreeContentCatalog.Tests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void AddSingleContentItemCheckExistance()
        {
            Catalog catalog = new Catalog();

            var book = new Content(ContentType.Book, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            catalog.Add(book);
            var list = catalog.GetListContent("Intro C#", 10);

            int expected = 1;
            int actual = list.Count();

            Assert.AreEqual(expected, actual);
            Assert.AreSame(book, list.First());
        }

        [TestMethod]
        public void AddThreeDuplicatingContentItemsCheckCount()
        {
            Catalog catalog = new Catalog();

            catalog.Add(new Content(ContentType.Book, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
            catalog.Add(new Content(ContentType.Book, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
            catalog.Add(new Content(ContentType.Book, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
            var list = catalog.GetListContent("Intro C#", 10);

            int expected = 3;
            int actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeDifferentContentItemsWithSameTitle()
        {
            Catalog catalog = new Catalog();

            catalog.Add(new Content(ContentType.Book, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
            catalog.Add(new Content(ContentType.Movie, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
            catalog.Add(new Content(ContentType.Application, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));

            var list = catalog.GetListContent("Intro C#", 10);

            int expected = 3;
            int actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeDifferentContentItemsDifferentTitle()
        {
            Catalog catalog = new Catalog();

            catalog.Add(new Content(ContentType.Book, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
            catalog.Add(new Content(ContentType.Movie, new string[] { "Some movie", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
            catalog.Add(new Content(ContentType.Song, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));

            var list = catalog.GetListContent("Intro C#", 10);

            int expected = 2;
            int actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryToRetrieveNonExistingContentItems()
        {
            Catalog catalog = new Catalog();

            catalog.Add(new Content(ContentType.Book, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
            catalog.Add(new Content(ContentType.Movie, new string[] { "Some movie", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
            catalog.Add(new Content(ContentType.Song, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));

            var list = catalog.GetListContent("non-existing content", 10);

            int expected = 0;
            int actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryToRetrieveTenContentItemsFifteenMatching()
        {
            Catalog catalog = new Catalog();

            for (int i = 0; i < 5; i++)
            {
                catalog.Add(new Content(ContentType.Book, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
                catalog.Add(new Content(ContentType.Song, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
                catalog.Add(new Content(ContentType.Application, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
            }

            var list = catalog.GetListContent("Intro C#", 10);

            int expected = 10;
            int actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RetrieveTenContentItemsTwelveMatchingSortTest()
        {
            Catalog catalog = new Catalog();

            for (int i = 0; i < 3; i++)
            {
                catalog.Add(new Content(ContentType.Book, new string[] { "Intro C#", "S.Nakov", "12763892" + i, "http://www.introprogramming.info" }));
                catalog.Add(new Content(ContentType.Song, new string[] { "Intro C#", "S.Nakov", "12763892" + i * 10, "http://www.introprogramming.info" }));
                catalog.Add(new Content(ContentType.Application, new string[] { "Intro C#", "S.Nakov", "12763892" + i * 20, "http://www.introprogramming.info" }));
            }

            var list = catalog.GetListContent("Intro C#", 7);

            string[] expected =
            {
                "Application: Intro C#; S.Nakov; 127638920; http://www.introprogramming.info",
                "Application: Intro C#; S.Nakov; 1276389220; http://www.introprogramming.info",
                "Application: Intro C#; S.Nakov; 1276389240; http://www.introprogramming.info",
                "Book: Intro C#; S.Nakov; 127638920; http://www.introprogramming.info",
                "Book: Intro C#; S.Nakov; 127638921; http://www.introprogramming.info",
                "Book: Intro C#; S.Nakov; 127638922; http://www.introprogramming.info",
                "Song: Intro C#; S.Nakov; 127638920; http://www.introprogramming.info"
            };
            string[] actual = list.ToArray().Select(x => x.ToString()).ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateUrlThreeContentItems()
        {
            Catalog catalog = new Catalog();

            catalog.Add(new Content(ContentType.Book, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
            catalog.Add(new Content(ContentType.Movie, new string[] { "Some movie", "S.Nakov", "12763892", "http://www.introprogramming.info" }));
            catalog.Add(new Content(ContentType.Song, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));

            int updatedCount = catalog.UpdateContent("http://www.introprogramming.info", "newUrl");
            int expected = 3;

            Assert.AreEqual(expected, updatedCount);

            updatedCount = catalog.UpdateContent("http://www.introprogramming.info", "newUrl");
            expected = 0;

            Assert.AreEqual(expected, updatedCount);
        }
    }
}