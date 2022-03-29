using Microsoft.EntityFrameworkCore;
using Scrabex.WebApi.Mappers;

namespace Scrabex.WebApi.Services
{
    public interface IObjectServiceFacade
    {
        bool TryGet<ET, CDTO, DTO>(int id, IMapper<ET,CDTO,DTO> mapper, DbContext context, out DTO foundObject)
            where ET : class, new()
            where DTO : class, new()
            where CDTO : class, new();

        bool TryAdd<ET, CDTO, DTO>(CDTO creationDto, IMapper<ET,CDTO,DTO> mapper, DbContext context, out DTO addedObject)
            where ET : class, new()
            where CDTO : class, new()
            where DTO : class, new();

        bool ValidateTransaction<ET>(ET entity, DbContext dbContext) where ET : class, new();
        bool ValidateTransaction<ET>(ET entity) where ET : class, new();
    }
}
