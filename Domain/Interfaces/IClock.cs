namespace DotNetBerlinClock.Domain.Interfaces
{
    public interface IClock<T> where T : ITime
    {
        #region Members

        /// <summary>
        /// Set clock time.
        /// </summary>
        /// <param name="time">An instant in time.</param>
        void Set(T time);

        #endregion
    }
}
