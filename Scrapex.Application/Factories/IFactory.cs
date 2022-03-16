namespace Scrapex.Application.Factories
{
    public interface IFactory<T>
    {
        T Create();
    }
}