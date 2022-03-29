using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Scrabex.WebApi.Mappers;

namespace Scrabex.WebApi.Services
{
    public class ObjectServiceFacade : IObjectServiceFacade
    {
        public bool ValidateTransaction<ET> (ET entity, DbContext dbContext) where ET : class, new() => entity != null && dbContext.SaveChanges() > 0;
        public bool ValidateTransaction<ET>(ET entity) where ET : class, new() => entity != null;
        public bool TryGet<ET,CDTO,DTO>(int id, IMapper<ET,CDTO,DTO> mapper, DbContext context, out DTO foundObject) 
            where ET : class, new() 
            where DTO : class, new()
            where CDTO : class, new()

        {
            foundObject = default;
            var retrievedObject = context.Find<ET>(id);
            //var retrievedDetail = context.Find<REL>(id);

            if (!ValidateTransaction(retrievedObject))// || !ValidateTransaction(retrievedDetail))
                return false;

            foundObject = mapper.MapToDto(retrievedObject);
            //foundObject.Details = _userDetailMapper.MapToDto(retrievedDetail);
            return foundObject != null;
        }

        public bool TryAdd<ET, CDTO, DTO>(CDTO creationDto, IMapper<ET,CDTO,DTO> mapper, DbContext context, out DTO addedObject)
            where ET : class, new()
            where CDTO : class, new()
            where DTO : class, new()

        {
            addedObject = default;
            var entity = context.Add<ET>(mapper.MapToModel(creationDto));
            if (!ValidateTransaction<ET>(entity.Entity, context))
                return false;

            addedObject = mapper.MapToDto(entity.Entity);
            return addedObject != null;
        }
    }
}
