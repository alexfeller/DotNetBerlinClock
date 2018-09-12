using Clock;
using System;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        #region Public members

        /// <inheritdoc/>
        public string ConvertTime(string aTime)
        {
            if (String.IsNullOrEmpty(aTime))
            {
                throw new ArgumentNullException("aTime");
            }

            Time time = Time.Parse(aTime);

            IClock<Time> clock = new BerlinClock();
            clock.Set(time);

            return clock.ToString();
        }

        #endregion
    }
}