using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void TestValidCommandLine()
        {
            string inputLine = "AddEvent 2012-01-21T20:00:00 | party Viki | home";
            Command command = Command.Parse(inputLine);
            string[] expectedParams =
            {
                "2012-01-21T20:00:00",
                "party Viki",
                "home"
            };

            Assert.AreEqual("AddEvent", command.Name);
            CollectionAssert.AreEqual(expectedParams, command.Paramms);
        }

        [TestMethod]
        public void TestValidCommandLineManyWhiteSpaces()
        {
            string inputLine = "AddEvent        2012-01-21T20:00:00     |    party Viki |    home       ";
            Command command = Command.Parse(inputLine);
            string[] expectedParams =
            {
                "2012-01-21T20:00:00",
                "party Viki",
                "home"
            };

            Assert.AreEqual("AddEvent", command.Name);
            CollectionAssert.AreEqual(expectedParams, command.Paramms);
        }

        [TestMethod]
        public void TestValidCommandLineNeighboringParamsSeparators()
        {
            string inputLine = "AddEvent        2012-01-21T20:00:00 |||   party Viki home    ";
            Command command = Command.Parse(inputLine);
            string[] expectedParams =
            {
                "2012-01-21T20:00:00",
                "party Viki home"
            };

            Assert.AreEqual("AddEvent", command.Name);
            CollectionAssert.AreEqual(expectedParams, command.Paramms);
        }

        [TestMethod]
        public void TestValidCommandLineMissingParamsSeparator()
        {
            string inputLine = "AddEvent        2012-01-21T20:00:00    party Viki home    ";
            Command command = Command.Parse(inputLine);
            string[] expectedParams =
            {
                "2012-01-21T20:00:00    party Viki home",
            };

            Assert.AreEqual("AddEvent", command.Name);
            CollectionAssert.AreEqual(expectedParams, command.Paramms);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInValidCommandLine()
        {
            string inputLine = "AddEvent2012-01-21T20:00:00_|_partyViki_|_home";
            Command.Parse(inputLine);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNullCommandLine()
        {
            string inputLine = null;
            Command.Parse(inputLine);
        }
    }
}