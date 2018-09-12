using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        #region Fields

        private ITimeConverter berlinClock = new TimeConverter();
        private String theTime;

        #endregion

        #region Public members

        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            string currentBerlinClockOutput = berlinClock.ConvertTime(theTime);

            Assert.AreEqual(currentBerlinClockOutput, theExpectedBerlinClockOutput);
        }

        #endregion
    }
}
