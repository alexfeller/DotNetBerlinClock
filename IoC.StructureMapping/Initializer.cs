using Autofac;
using DotNetBerlinClock.Domain.Classes;
using DotNetBerlinClock.Domain.Interfaces;
using DotNetBerlinClock.Services;

namespace DotNetBerlinClock.IoC.StructureMapping
{
    /// <summary>
    /// Registration of the service components.
    /// </summary>
    public static class Initializer
    {
        #region Public members

        /// <summary>
        /// Register the service components.
        /// </summary>
        public static void Initialize()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<BerlinClock>().As<IBerlinClock>();
            containerBuilder.RegisterType<TimeConverter>().As<ITimeConverter>();

            var build = containerBuilder.Build();

            IoCContainerFactory.Current = new IoCContainerImplementation(build);
        }

        #endregion
    }
}
