namespace DotNetBerlinClock.Domain.Interfaces
{
    public interface IIoCContainer
    {
        T GetInstance<T>();
    }
}
