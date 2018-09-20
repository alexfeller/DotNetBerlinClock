using DotNetBerlinClock.Domain.Interfaces;
using DotNetBerlinClock.Domain.Classes;
using System;

namespace DotNetBerlinClock.Infrastructure
{
    public class TimeConverter : ITimeConverter
    {
        #region Constructor

        public TimeConverter()
        {
            _iocContainer = IoCContainerFactory.Current;
        }

        #endregion

        #region Public members

        /// <inheritdoc/>
        public string ConvertTime(string aTime)
        {
            if (String.IsNullOrEmpty(aTime))
            {
                throw new ArgumentNullException("aTime");
            }

            Time time = Time.Parse(aTime);

            var clock = _iocContainer.GetInstance<IBerlinClock>();
            clock.Set(time);

            return clock.ToString();
        }

        #endregion

        #region Fields

        private static IIoCContainer _iocContainer;

        #endregion
    }
}