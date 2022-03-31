namespace Scrabex.WebApi.Services
{
    public interface IHashService
    {
        byte[] GetHash(string key);
    }
}
