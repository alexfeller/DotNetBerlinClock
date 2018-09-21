namespace DotNetBerlinClock.Domain.Interfaces
{
    public interface IIoCContainer
    {
        #region Members

        T GetInstance<T>();

        #endregion
    }
}
