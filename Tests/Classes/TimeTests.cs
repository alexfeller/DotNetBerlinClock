using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.Tests
{
    [TestClass()]
    public class TimeTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TimeTest_IfHourLessThenZero_ThrowsArgumentOutOfRange()
        {
            new Time(-1, 0, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TimeTest_IfHourGreaterThen24_ThrowsArgumentOutOfRange()
        {
            new Time(25, 0, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TimeTest_IfMinuteLessThenZero_ThrowsArgumentOutOfRange()
        {
            new Time(0, -1, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TimeTest_IfMinuteGreaterThen59_ThrowsArgumentOutOfRange()
        {
            new Time(0, 60, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TimeTest_IfSecondLessThenZero_ThrowsArgumentOutOfRange()
        {
            new Time(0, 0, -1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TimeTest_IfSecondGreaterThen59_ThrowsArgumentOutOfRange()
        {
            new Time(0, 0, 60);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ParseTest_IfTimeIsInWrongFormat_ThrowsFormatException()
        {
            string timeToParse = "24/10/11";
            Time.Parse(timeToParse);
        }

        [TestMethod()]
        public void ParseTest_IfTimeIsCorrect_True()
        {
            string timeToParse = "24:10:11";
            var time = Time.Parse(timeToParse);

            Assert.IsTrue(time.Hour == 24);
            Assert.IsTrue(time.Minute == 10);
            Assert.IsTrue(time.Second == 11);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ParseTest_IfTimeIsWrong_ThrowsFormatException()
        {
            string timeToParse = "25:60:60";
            Time.Parse(timeToParse);
        }
    }
}