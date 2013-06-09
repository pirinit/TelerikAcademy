using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void IntegrationTest_0()
        {
            string inputFileName = @"..\..\IntegrationTests\test.000.001.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.000.001.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_1()
        {
            string inputFileName = @"..\..\IntegrationTests\test.001.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.001.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_2()
        {
            string inputFileName = @"..\..\IntegrationTests\test.002.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.002.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_3()
        {
            string inputFileName = @"..\..\IntegrationTests\test.003.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.003.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_4()
        {
            string inputFileName = @"..\..\IntegrationTests\test.004.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.004.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_5()
        {
            string inputFileName = @"..\..\IntegrationTests\test.005.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.005.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_6()
        {
            string inputFileName = @"..\..\IntegrationTests\test.006.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.006.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_7()
        {
            string inputFileName = @"..\..\IntegrationTests\test.007.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.007.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_8()
        {
            string inputFileName = @"..\..\IntegrationTests\test.008.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.008.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        //the following test are too slow to run them frequently

        [TestMethod]
        public void IntegrationTest_9()
        {
            string inputFileName = @"..\..\IntegrationTests\test.009.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.009.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_10()
        {
            string inputFileName = @"..\..\IntegrationTests\test.010.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.010.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_11()
        {
            string inputFileName = @"..\..\IntegrationTests\test.011.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.011.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_12()
        {
            string inputFileName = @"..\..\IntegrationTests\test.012.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.012.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_13()
        {
            string inputFileName = @"..\..\IntegrationTests\test.013.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.013.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_14()
        {
            string inputFileName = @"..\..\IntegrationTests\test.014.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.014.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_15()
        {
            string inputFileName = @"..\..\IntegrationTests\test.015.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.015.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        [TestMethod]
        public void IntegrationTest_16()
        {
            string inputFileName = @"..\..\IntegrationTests\test.016.in.txt";
            string outputFileName = @"..\..\IntegrationTests\test.016.out.txt";

            AssertExternalTests(inputFileName, outputFileName);
        }

        private void AssertExternalTests(string inputFileName, string outputFileName)
        {
            StreamReader inputStreamInput = new StreamReader(inputFileName);
            StreamReader inputStreamOutput = new StreamReader(outputFileName);
            List<string> lines = new List<string>();
            string expected = null;
            try
            {
                lines = new List<string>();
                string line = inputStreamInput.ReadLine();
                while (line != "End" && line != null)
                {
                    lines.Add(line);
                    line = inputStreamInput.ReadLine();
                }

                expected = inputStreamOutput.ReadToEnd();

            }
            finally
            {
                inputStreamInput.Dispose();
                inputStreamOutput.Dispose();
            }

            IEventsManager eventsManager = new EventsManagerFast();
            CommandExecutor commandExecutor = new CommandExecutor(eventsManager);

            StringBuilder actual = new StringBuilder();

            foreach (string line in lines)
            {
                Command command = Command.Parse(line);
                commandExecutor.ProcessCommand(command, actual);
            }

            string actualString = actual.ToString();
            Assert.AreEqual(expected, actualString);
        }
    }
}
