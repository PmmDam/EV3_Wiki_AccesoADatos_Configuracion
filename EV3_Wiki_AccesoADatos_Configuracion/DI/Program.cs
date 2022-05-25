using EV3_Wiki_AccesoADatos_Configuracion.Factories;
using EV3_Wiki_AccesoADatos_Configuracion.Interfaces;
using EV3_Wiki_AccesoADatos_Configuracion.Models.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EV3_Wiki_AccesoADatos_Configuracion.DI
{
    internal class Program
    {

        static string appConfigJsonPath = Path.Combine(Environment.CurrentDirectory, "Data", "AppConfig.json");
        static string dataLayerJsonPath = Path.Combine(Environment.CurrentDirectory, "Data", "DataLayer.json");

        static void Main(string[] args)
        {

            ConfigurationBuilder configBuilder = new ConfigurationBuilder();

            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile(appConfigJsonPath);
            configBuilder.AddJsonFile(dataLayerJsonPath);
            configBuilder.AddCommandLine(args);

            IConfiguration configTree = configBuilder.Build();

            ServiceCollection services = new ServiceCollection();

            // Configuracion
            services.AddOptions<ConfigModel>();
            services.Configure<ConfigModel>(configTree);
            // Dependencias
            services.AddSingleton<IOrchestrator, Orchestrator>();
            services.AddSingleton<ISqlServerFactory, SqlServerFactory>();
            services.AddSingleton<IProductManagerFactory, ProductManagerFactory>();

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                IOrchestrator orchestrator = serviceProvider.GetService<IOrchestrator>();
                orchestrator.Play();
            }

            
        }
    }
}