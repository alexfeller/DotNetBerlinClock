using Autofac;
using DotNetBerlinClock.Domain.Interfaces;
using System;

namespace DotNetBerlinClock.IoC.StructureMapping
{
    /// <inheritdoc/>
    public class IoCContainerImplementation : IIoCContainer
    {
        #region Constructor

        /// <summary>
        ///  Initializes a new instance of the IoCContainerImplementation class.
        /// </summary>
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

        /// <inheritdoc/>
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
