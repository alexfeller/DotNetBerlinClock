
using DotNetBerlinClock.Domain.Interfaces;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DotNetBerlinClock.Domain.Classes
{
    /// <summary>
    /// Represents an instant in time in 24 hours format, expressed as hour, minute and second.
    /// <see href="https://en.wikipedia.org/wiki/24-hour_clock">Wikipedia article.</see>
    /// </summary>
    public class Time : ITime
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the Time class to a specified hour, minute and second.
        /// </summary>
        /// <param name="hour">The hours (0 through 24).</param>
        /// <param name="minute">The minutes (0 through 59).</param>
        /// <param name="second">The seconds (0 through 59).</param>
        public Time(int hour, int minute, int second)
        {
            if (hour < 0 || hour > 24)
            {
                throw new ArgumentOutOfRangeException("hour", Resources.Error.InvalidHourFormat);
            }

            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException("minute", Resources.Error.InvalidMinuteFormat);
            }

            if (second < 0 || second > 59)
            {
                throw new ArgumentOutOfRangeException("second", Resources.Error.InvalidSecondFormat);
            }

            Hour = hour;
            Minute = minute;
            Second = second;
        }

        #endregion

        #region Public members

        /// <summary>
        /// Convert specified string representation of a time to its Time equivalent.
        /// </summary>
        /// <param name="aTime">Time in the format 'HH:mm:ss'. 24 is allowed to represent the hours.</param>
        /// <returns>Time representation as BerlinClock.Time</returns>
        public static Time Parse(string aTime)
        {
            string time = Regex.Replace(aTime, @"24:(\d\d:\d\d)$", "00:$1");

            if (!DateTime.TryParseExact(time,
                "HH:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime dateTime))
            {
                throw new FormatException(Resources.Error.InvalidTimeFormat);
            }

            int hour = dateTime.Hour;

            if (time != aTime)
            {
                hour = 24;
            }

            return new Time
            (
                hour,
                dateTime.Minute,
                dateTime.Second
            );
        }

        #endregion

        #region Public properties

        /// <inheritdoc/>
        public int Hour { get; private set; }

        /// <inheritdoc/>
        public int Minute { get; private set; }

        /// <inheritdoc/>
        public int Second { get; private set; }

        #endregion
    }
}