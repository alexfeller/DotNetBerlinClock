namespace DotNetBerlinClock.Domain.Interfaces
{
    public interface ITime
    {
        #region Properties

        /// <summary>
        /// Gets the hour component of the time represented by this instance.
        /// </summary>
        int Hour { get; }

        /// <summary>
        /// Gets the minute component of the time represented by this instance.
        /// </summary>
        int Minute { get; }

        /// <summary>
        /// Gets the second component of the time represented by this instance.
        /// </summary>
        int Second { get; }

        #endregion
    }
}
