using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Scrabex.WebApi.Mappers;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Services
{
    public class ObjectServiceFacade : IObjectServiceFacade
    {
        public bool TryGet<M,R>(int id, IMapper<M,R> mapper, DbContext context, out R foundObject) 
            where M : EntityBase
            where R : EntityBase

        {
            foundObject = default;
            var retrievedObject = context.Find<M>(id);

            if (retrievedObject == null)
                return false;

            foundObject = mapper.MapToDto(retrievedObject);
            return foundObject != null;
        }

        public bool TryAdd<M, C, R>(C creationDto, IMapper<M,C,R> mapper, DbContext context, out R addedObject)
            where M : EntityBase
            where C : class, new()
            where R : EntityBase

        {
            addedObject = default;
            var entity = context.Add(mapper.CreateModel(creationDto));
            if (entity.Entity == null)
                return false;

            context.SaveChanges();

            addedObject = mapper.MapToDto(entity.Entity);
            return addedObject != null;
        }

        public bool TryUpdate<M, C, R, U>(int id, U updateDto, IMapper<M, C, R, U> mapper, DbContext context, out R updatedObject)
            where M : EntityBase
            where C: class, new()
            where R : EntityBase
            where U : IEntity, new()
        {
            updatedObject = null;

            var entity = context.Find<M>(id);
            if (entity == null)
                return false;

            mapper.UpdateModel(entity, updateDto);
            var updatedEntity = context.Update(entity);

            if (updatedEntity.State == EntityState.Unchanged)
                return false;

            updatedObject = mapper.MapToDto(updatedEntity.Entity);
            return true;
        }

        public bool TryAddAll<M, C, R>(IEnumerable<C> creationDtos, IMapper<M, C, R> mapper, DbContext context, out IList<R> addedObjects)
            where M : EntityBase
            where C : class, new()
            where R : EntityBase
        {
            addedObjects = new List<R>();
            foreach(var dto in creationDtos)
            {
                if(!TryAdd(dto, mapper, context, out var addedObject))
                {
                    return false;
                }

                addedObjects.Add(addedObject);
            }
            return !addedObjects.Any(p => p == null);
        }

        public bool TryUpdateAll<M,C,R,U>(IDictionary<int,U> updateDtosMap, IMapper<M, C, R, U> mapper, DbContext context, out IList<R> updatedObjects)
            where M : EntityBase
            where C : class, new()
            where R : EntityBase
            where U : IEntity, new()
        {
            updatedObjects = new List<R>();

            foreach (var entry in updateDtosMap)
            {
                if (!TryUpdate(entry.Key, entry.Value, mapper, context, out var updatedObject))
                    return false;

                updatedObjects.Add(updatedObject);
            }
            return true;
        }
    }
}
