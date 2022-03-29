namespace Scrabex.WebApi.Controllers
{
    public interface IControllerFacade
    {
        IEnumerable<T> GetAll<T>() where T : new();
    }
}
