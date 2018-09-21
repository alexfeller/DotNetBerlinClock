namespace DotNetBerlinClock.Domain.Interfaces
{
    // Creates, wires dependencies and manages lifetime for the service components. 
    public interface IIoCContainer
    {
        #region Members

        /// <summary>
        /// Retrieve a service from the context.
        /// </summary>
        /// <typeparam name="T">The service to retrieve.</typeparam>
        /// <returns>The component instance that provides the service.</returns>
        T GetInstance<T>();

        #endregion
    }
}
