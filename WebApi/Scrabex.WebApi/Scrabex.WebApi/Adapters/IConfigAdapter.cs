using Scrabex.WebApi.Enums;
using System.Text;

namespace Scrabex.WebApi.Adapters
{
    public interface IConfigAdapter
    {
        string Salt { get; }
        byte[] JwtKey { get; }
        Encoding GlobalEncoding { get; }
        string DevConnectionString { get; }
        string ProdConnectionString { get; }
        string HttpsPort { get; }
        string HttpPort { get; }
        IConfiguration RawConfig { get; }

        /// <summary>
        /// Measured in seconds
        /// </summary>
        int TokenExpiration { get; }
        AccessLevel DefaultAccessLevelOnRegister { get; }
    }
}
