using Autofac;
using DotNetBerlinClock.Domain.Interfaces;
using System;

namespace DotNetBerlinClock.IoC.StructureMapping
{
    public class IoCContainerImplementation : IIoCContainer
    {
        #region Constructor

        public IoCContainerImplementation(IContainer container)
        {
            if(container is null)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
        }

        #endregion

        #region Public members

        public T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }

        #endregion

        #region Fields

        private readonly IContainer _container;

        #endregion

    }
}
