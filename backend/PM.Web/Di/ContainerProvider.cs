using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using PM.Web.config;
using PM.Web.Data;
using System.Diagnostics;

namespace PM.Web.Di
{
    public class ContainerProvider
    {
        private IConfiguration Configuration { get; }

        private readonly ConfigService _configService;

        public ContainerProvider(IConfiguration configuration = null)
        {
            _configService = new ConfigService();
            _configService.LoadConfig(configuration);
            Configuration = _configService.Configuration;
        }

        public IContainer GetContainer(IServiceCollection services = null)
        {
            services = services ?? new ServiceCollection();
            services.AddDbContext<PMContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddAutofac();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<RootDiModule>();
            IContainer container = builder.Build();

            return container;
        }
    }
}
