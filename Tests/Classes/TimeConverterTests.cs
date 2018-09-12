using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.Tests
{
    [TestClass()]
    public class TimeConverterTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertTimeTest_IfArgumentIsNull_ArgumentNullException()
        {
            var timeConverter = new TimeConverter();

            string time = null;
            timeConverter.ConvertTime(time);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertTimeTest_IfArgumentIsEmpty_ArgumentNullException()
        {
            var timeConverter = new TimeConverter();

            string time = "";
            timeConverter.ConvertTime(time);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ConvertTimeTest_IfTimeIsInWrongFormat_ThrowsFormatException()
        {
            string time = "13-17-11";

            var timeConverter = new TimeConverter();
            timeConverter.ConvertTime(time);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ConvertTimeTest_IfTimeIsWrong_ThrowsFormatException()
        {
            string time = "25:00:00";

            var timeConverter = new TimeConverter();
            timeConverter.ConvertTime(time);
        }

        [TestMethod()]
        public void ConvertTimeTest_IfStringRepresentationOfTheTimeIsCorrect_True()
        {
            var timeConverter = new TimeConverter();

            string newLine = Environment.NewLine;

            string time = "13:17:11";

            var expectedTimeText = String.Format("O{0}RROO{0}RRRO{0}YYROOOOOOOO{0}YYOO", newLine);

            string convertedTime = timeConverter.ConvertTime(time);

            Assert.IsTrue(convertedTime == expectedTimeText);
        }
    }
}