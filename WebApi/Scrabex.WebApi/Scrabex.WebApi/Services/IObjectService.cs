using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Services
{
    public interface IObjectService<M,C,R,U>
        where M : EntityBase
        where C : class, new()
        where R : EntityBase
        where U : IEntity, new()
    {
        bool TryAdd(C dto, out R creationResult);
        bool TryGet(int id, out R foundObject);
        bool TryGet(R searchedObject, out R foundObject);
        IEnumerable<R> GetAll();
        bool TryUpdate(int id, U dto, out R updateResult);
        bool TryDelete(int id, out R removedObject);
    }
}