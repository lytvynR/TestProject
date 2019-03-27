using Microsoft.Extensions.Configuration;
using System;

namespace PM.Web.config
{
    public class ConfigService : IConfigService
    {
        public IConfiguration Configuration { get; set; }

        public void LoadConfig(IConfiguration configuration = null)
        {
            Configuration = configuration ?? new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }

    public interface IConfigService
    {

    }
}
