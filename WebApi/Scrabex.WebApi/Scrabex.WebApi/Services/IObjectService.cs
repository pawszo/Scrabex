namespace Scrabex.WebApi.Services
{
    //public interface IObjectService<Model,CreateDto,Dto>
    public interface IObjectService<Model,CreateDto,Dto>

    {
        bool TryAdd(CreateDto dto, out Dto creationResult);
        bool TryGet(int id, out Dto foundObject);
        Task<IEnumerable<Dto>> GetAll();
        bool TryUpdate(int id, IDictionary<string, object> properties, out Dto updateResult);
        bool TryDelete(int id, out Dto removedObject);
    }
}