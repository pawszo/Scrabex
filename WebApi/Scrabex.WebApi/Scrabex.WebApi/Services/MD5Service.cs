using Scrabex.WebApi.Adapters;
using System.Security.Cryptography;

namespace Scrabex.WebApi.Services
{
    public class MD5Service : IHashService
    {
        private readonly IConfigAdapter _config;
        private readonly MD5 _service;

        public MD5Service(IConfigAdapter config)
        {
            _config = config;
            _service = MD5.Create();
        }

        public string GetHash(string key) => _config.GlobalEncoding.GetString(_service.ComputeHash(SaltedBytes(key)));

        private byte[] SaltedBytes(string phrase) => _config.GlobalEncoding.GetBytes($"{phrase}{_config.Salt}");
     }
}
