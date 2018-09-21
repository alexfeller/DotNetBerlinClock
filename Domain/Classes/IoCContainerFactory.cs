using DotNetBerlinClock.Domain.Interfaces;

namespace DotNetBerlinClock.Domain.Classes
{
    public static class IoCContainerFactory
    {
        #region Public properties

        public static IIoCContainer Current { get; set; }

        #endregion
    }
}
