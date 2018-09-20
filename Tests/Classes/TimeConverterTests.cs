using DotNetBerlinClock.Domain.Classes;
using DotNetBerlinClock.Domain.Interfaces;
using DotNetBerlinClock.IoC.StructureMapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotNetBerlinClock.Tests
{
  
    [TestClass()]
    public class TimeConverterTests
    {
        private ITimeConverter _timeConverter;

        [TestInitialize]
        public void Initialize()
        {
            Initializer.Initialize();
            _timeConverter = IoCContainerFactory.Current.GetInstance<ITimeConverter>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _timeConverter = null;
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertTimeTest_IfArgumentIsNull_ArgumentNullException()
        {
            string time = null;
            _timeConverter.ConvertTime(time);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertTimeTest_IfArgumentIsEmpty_ArgumentNullException()
        {
            string time = "";
            _timeConverter.ConvertTime(time);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ConvertTimeTest_IfTimeIsInWrongFormat_ThrowsFormatException()
        {
            string time = "13-17-11";
            _timeConverter.ConvertTime(time);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ConvertTimeTest_IfTimeIsWrong_ThrowsFormatException()
        {
            string time = "25:00:00";
            _timeConverter.ConvertTime(time);
        }

        [TestMethod()]
        public void ConvertTimeTest_IfStringRepresentationOfTheTimeIsCorrect_True()
        {
            string newLine = Environment.NewLine;

            string time = "13:17:11";

            var expectedTimeText = String.Format("O{0}RROO{0}RRRO{0}YYROOOOOOOO{0}YYOO", newLine);

            string convertedTime = _timeConverter.ConvertTime(time);

            Assert.IsTrue(convertedTime == expectedTimeText);
        }
    }
}