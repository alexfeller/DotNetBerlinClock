using DotNetBerlinClock.Domain.Classes;
using DotNetBerlinClock.Domain.Interfaces;
using DotNetBerlinClock.IoC.StructureMapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DotNetBerlinClock.Tests
{
    [TestClass()]
    public class BerlinClockTest
    {
        private IBerlinClock _clock;

        [TestInitialize]
        public void Initialize()
        {
            Initializer.Initialize();
            _clock = IoCContainerFactory.Current.GetInstance<IBerlinClock>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _clock = null;
        }

        [TestMethod()]
        public void BerlinClockTest_IfLengthOfTheHour1ArrayIsCorrect_True()
        {
            Assert.IsTrue(_clock.Hour1.Count() == 4);
        }

        [TestMethod()]
        public void BerlinClockTest_IfLengthOfTheHour2ArrayIsCorrect_True()
        {
            Assert.IsTrue(_clock.Hour2.Count() == 4);
        }

        [TestMethod()]
        public void BerlinClockTest_IfLengthOfTheMinute1ArrayIsCorrect_True()
        {
            Assert.IsTrue(_clock.Minute1.Count() == 11);
        }

        [TestMethod()]
        public void BerlinClockTest_IfLengthOfTheMinute2ArrayIsCorrect_True()
        {
            Assert.IsTrue(_clock.Minute2.Count() == 4);
        }

        [TestMethod()]
        public void SetTest_IfTimeIsInCorrectFormat_True()
        {
            var time = new Time(24, 59, 59);

            _clock.Set(time);

            Assert.IsTrue(_clock.Second == LampType.White);

            Assert.IsTrue(_clock.Hour1.Where(lamp => lamp == LampType.Red).Count() == 4);
            Assert.IsTrue(_clock.Hour2.Where(lamp => lamp == LampType.Red).Count() == 4);

            Assert.IsTrue(_clock.Minute1.Where(lamp => (lamp == LampType.Yellow || lamp == LampType.Red)).Count() == 11);
            Assert.IsTrue(_clock.Minute2.Where(lamp => lamp == LampType.Yellow).Count() == 4);
        }
    }
}