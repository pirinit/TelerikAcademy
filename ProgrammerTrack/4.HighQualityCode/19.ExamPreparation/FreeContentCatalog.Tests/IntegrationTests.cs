using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreeContentCatalog.Tests
{
    [TestClass]
    public class IntegrationTests
    {
//        [TestMethod]
//        public void SampleInputTest()
//        {
//            string[] inputs =
//            {
//                "Find: One; 3",
//                "Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org",
//                "Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info",
//                "Add song: One; Metallica; 8771120; http://goo.gl/dIkth7gs",
//                "Add movie: The Secret; Drew Heriot, Sean Byrne & others (2006); 832763834; http://t.co/dNV4d",
//                "Find: One; 1",
//                "Add movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/",
//                "Find: One; 10",
//                "Update: http://www.introprogramming.info; http://introprograming.info/en/",
//                "Find: Intro C#; 1",
//                "Update: http://nakov.com; sftp://www.nakov.com"
//            };

//            StringBuilder output = new StringBuilder();
//            Catalog catalog = new Catalog();
//            ICommandExecutor commandExecutor = new CommandExecutor();

//            List<ICommand> commands = new List<ICommand>();
//            foreach (string input in inputs)
//            {
//                commands.Add(new Command(input));
//            }

//            foreach (ICommand command in commands)
//            {
//                commandExecutor.ExecuteCommand(catalog, command, output);
//            }

//            string expected = @"No items found
//Application added
//Book added
//Song added
//Movie added
//Song: One; Metallica; 8771120; http://goo.gl/dIkth7gs
//Movie added
//Movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/
//Song: One; Metallica; 8771120; http://goo.gl/dIkth7gs
//1 items updated
//Book: Intro C#; S.Nakov; 12763892; http://introprograming.info/en/
//0 items updated
//";
//            string actual = output.ToString();

//            Assert.AreEqual(expected, actual);
//        }
    }
}