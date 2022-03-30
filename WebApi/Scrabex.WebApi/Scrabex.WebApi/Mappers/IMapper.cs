using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Mappers
{
    public interface IMapper<M,C,R,U> : IMapper<M,C,R>
        where C : class, new()
        where M : EntityBase
        where R : EntityBase
        where U : IEntity, new()
    {
        void UpdateModel(M model, U updateDto);
    }

    public interface IMapper<M,C,R> : IMapper<M,R>
        where C : class, new()
        where M : EntityBase
        where R : EntityBase
    {
        M CreateModel(C dto);
    }

    public interface IMapper<M,R> 
        where M : EntityBase
        where R : EntityBase
    {
        R MapToDto(M model);
    }
}
