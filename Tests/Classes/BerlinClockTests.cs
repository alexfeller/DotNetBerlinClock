using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BerlinClock.Tests
{
    [TestClass()]
    public class BerlinClockTest
    {
        [TestMethod()]
        public void BerlinClockTest_IfLengthOfTheHour1ArrayIsCorrect_True()
        {
            IBerlinClock clock = new BerlinClock();
            Assert.IsTrue(clock.Hour1.Count() == 4);
        }

        [TestMethod()]
        public void BerlinClockTest_IfLengthOfTheHour2ArrayIsCorrect_True()
        {
            IBerlinClock clock = new BerlinClock();
            Assert.IsTrue(clock.Hour2.Count() == 4);
        }

        [TestMethod()]
        public void BerlinClockTest_IfLengthOfTheMinute1ArrayIsCorrect_True()
        {
            IBerlinClock clock = new BerlinClock();
            Assert.IsTrue(clock.Minute1.Count() == 11);
        }

        [TestMethod()]
        public void BerlinClockTest_IfLengthOfTheMinute2ArrayIsCorrect_True()
        {
            IBerlinClock clock = new BerlinClock();
            Assert.IsTrue(clock.Minute2.Count() == 4);
        }

        [TestMethod()]
        public void SetTest_IfTimeIsInCorrectFormat_True()
        {
            var time = new Time(24, 59, 59);

            IBerlinClock clock = new BerlinClock();
            clock.Set(time);

            Assert.IsTrue(clock.Second == LampType.White);

            Assert.IsTrue(clock.Hour1.Where(lamp => lamp == LampType.Red).Count() == 4);
            Assert.IsTrue(clock.Hour2.Where(lamp => lamp == LampType.Red).Count() == 4);

            Assert.IsTrue(clock.Minute1.Where(lamp => (lamp == LampType.Yellow || lamp == LampType.Red)).Count() == 11);
            Assert.IsTrue(clock.Minute2.Where(lamp => lamp == LampType.Yellow).Count() == 4);
        }
    }
}