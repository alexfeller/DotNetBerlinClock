using Autofac;
using DotNetBerlinClock.Domain.Interfaces;

namespace DotNetBerlinClock.IoC.StructureMapping
{
    public class IoCContainerImplementation : IIoCContainer
    {
        private readonly IContainer Container;

        public IoCContainerImplementation(IContainer container)
        {
            Container = container;
        }

        public T GetInstance<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
