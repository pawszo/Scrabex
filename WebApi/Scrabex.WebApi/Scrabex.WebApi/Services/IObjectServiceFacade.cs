using Microsoft.EntityFrameworkCore;
using Scrabex.WebApi.Mappers;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Services
{
    public interface IObjectServiceFacade
    {
        bool TryGet<M, R>(int id, IMapper<M,R> mapper, DbContext context, out R foundObject)
            where M : EntityBase
            where R : EntityBase;

        bool TryAdd<M, C, R>(C creationDto, IMapper<M,C,R> mapper, DbContext context, out R addedObject)
            where M : EntityBase
            where C : class, new()
            where R : EntityBase;

        bool TryAddAll<M, C, R>(IEnumerable<C> creationDtos, IMapper<M, C, R> mapper, DbContext context, out IList<R> addedObjects)
            where M : EntityBase
            where C : class, new()
            where R : EntityBase;

        bool TryUpdate<M, C, R, U>(int id, U updateDto, IMapper<M, C, R, U> mapper, DbContext context, out R updatedObject)
            where M : EntityBase
            where R : EntityBase
            where U : IEntity, new()
            where C : class, new();

        bool TryUpdateAll<M, C, R, U>(IDictionary<int, U> updateDtos, IMapper<M, C, R, U> mapper, DbContext context, out IList<R> updatedObjects)
            where M : EntityBase
            where R : EntityBase
            where U : IEntity, new()
            where C : class, new();
    }
}
