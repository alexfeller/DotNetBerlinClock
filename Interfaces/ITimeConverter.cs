namespace BerlinClock
{
    public interface ITimeConverter
    {
        #region Members

        /// <summary>
        /// Convert specified string representation of a time to its 'Berlin clock' time equivalent.
        /// </summary>
        /// <param name="aTime">Time in the format 'HH:mm:ss'. 24 is allowed to represent the hours.</param>
        /// <returns>'Berlin clock' time representation.</returns>
        string ConvertTime(string aTime);

        #endregion
    }
}