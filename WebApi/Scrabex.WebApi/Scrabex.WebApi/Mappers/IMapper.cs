using Scrabex.WebApi.Dtos;

namespace Scrabex.WebApi.Mappers
{
    public interface IMapper<Model,CreateDto,Dto>
    {
        Model MapToModel(CreateDto dto);
        Dto MapToDto(Model model);
    }

}
