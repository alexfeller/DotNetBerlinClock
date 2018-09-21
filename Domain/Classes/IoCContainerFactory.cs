using DotNetBerlinClock.Domain.Interfaces;

namespace DotNetBerlinClock.Domain.Classes
{
    /// <summary>
    /// Service components factory.
    /// </summary>
    public static class IoCContainerFactory
    {
        #region Public properties

        /// <summary>
        /// Service components container.
        /// </summary>
        public static IIoCContainer Current { get; set; }

        #endregion
    }
}
