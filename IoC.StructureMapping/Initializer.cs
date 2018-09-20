using Autofac;
using DotNetBerlinClock.Domain.Classes;
using DotNetBerlinClock.Domain.Interfaces;
using DotNetBerlinClock.Infrastructure;

namespace DotNetBerlinClock.IoC
{
    public static class Initializer
    {
        public static void Initialize()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<BerlinClock>().As<IBerlinClock>();
            containerBuilder.RegisterType<TimeConverter>().As<ITimeConverter>();

            var build = containerBuilder.Build();

            IoCContainerFactory.Current = new IoCContainerImplementation(build);
        }
    }
}
