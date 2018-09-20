using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetBerlinClock.IoC;
using DotNetBerlinClock.Domain.Classes;
using DotNetBerlinClock.Domain.Interfaces;

namespace DotNetBerlinClock.Applications
{
    [Binding]
    public class TheBerlinClockSteps
    {
        #region Constructor

        public TheBerlinClockSteps()
        {
            Initializer.Initialize();
            _berlinClock = IoCContainerFactory.Current.GetInstance<ITimeConverter>(); 
        }

        #endregion

        #region Fields

        private readonly ITimeConverter _berlinClock;
        private String theTime;

        #endregion

        #region Public members

        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string expectedBerlinClockOutput)
        {
            string currentBerlinClockOutput = _berlinClock.ConvertTime(theTime);

            Assert.AreEqual(currentBerlinClockOutput, expectedBerlinClockOutput);
        }

        #endregion
    }
}
