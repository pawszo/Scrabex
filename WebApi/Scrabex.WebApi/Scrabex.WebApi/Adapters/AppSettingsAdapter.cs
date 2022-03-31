using System.Text;

namespace Scrabex.WebApi.Adapters
{
    public class AppSettingsAdapter : IConfigAdapter
    {
        public AppSettingsAdapter(IConfiguration config)
        {
            RawConfig = config;
            Salt = RawConfig["Auth:Salt"];
            GlobalEncoding = Encoding.GetEncoding(RawConfig["Settings:Encoding"]) ?? Encoding.UTF8;
            JwtKey = GlobalEncoding.GetBytes(RawConfig["Auth:JwtKey"]);
            DevConnectionString = RawConfig["ConnectionStrings:Dev"];
            ProdConnectionString = RawConfig["ConnectionStrings:Prod"];
            HttpsPort = RawConfig["https_port"];
            HttpPort = RawConfig["http_port"];
            TokenExpiration = int.TryParse(RawConfig["Auth:TokenExpiration_s"], out var time) ? time : 3600;
        }

        public string Salt { get; }

        public byte[] JwtKey { get; }

        public Encoding GlobalEncoding { get; }

        public string DevConnectionString { get; }

        public string ProdConnectionString { get; }

        public string HttpsPort { get; }

        public string HttpPort { get; }

        public IConfiguration RawConfig { get; }

        public int TokenExpiration { get; }
    }
}
