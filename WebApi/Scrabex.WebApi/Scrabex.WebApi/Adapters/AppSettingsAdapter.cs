using Scrabex.WebApi.Enums;
using System.Text;

namespace Scrabex.WebApi.Adapters
{
    public class AppSettingsAdapter : IConfigAdapter
    {

        public string Salt { get; }

        public byte[] JwtKey { get; }

        public Encoding GlobalEncoding { get; }

        public string DevConnectionString { get; }

        public string ProdConnectionString { get; }

        public string HttpsPort { get; }

        public string HttpPort { get; }

        public IConfiguration RawConfig { get; }

        public int TokenExpiration { get; }
        public AccessLevel DefaultAccessLevelOnRegister { get; }

        public AppSettingsAdapter(IConfiguration config)
        {
            RawConfig = config;
            Salt = RawConfig["Auth:Salt"];
            GlobalEncoding = Encoding.GetEncoding(RawConfig["Settings:Encoding"]) ?? Encoding.ASCII;
            JwtKey = GlobalEncoding.GetBytes(RawConfig["Auth:JwtKey"]);
            DevConnectionString = RawConfig["ConnectionStrings:Dev"];
            ProdConnectionString = RawConfig["ConnectionStrings:Prod"];
            HttpsPort = RawConfig["https_port"];
            HttpPort = RawConfig["http_port"];
            TokenExpiration = int.TryParse(RawConfig["Auth:TokenExpiration_s"], out var time) ? time : 3600;
            DefaultAccessLevelOnRegister = int.TryParse(RawConfig["Access:DefaultAccessLevelOnRegister"], out int level) ? (AccessLevel)level : AccessLevel.Unconfirmed;
        }
    }
}
