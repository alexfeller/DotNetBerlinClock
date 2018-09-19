using DotNetBerlinClock.Domain.Interfaces;

namespace DotNetBerlinClock.Domain.Classes
{
    public static class IoCContainerFactory
    {
        public static IIoCContainer Current { get; set; }
    }
}
