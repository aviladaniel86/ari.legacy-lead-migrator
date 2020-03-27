using ari.legacy_lead_migrator.Repositories;
using ari.legacy_lead_migrator.Repositories.Interfaces;
using ari.legacy_lead_migrator.Services;
using ari.legacy_lead_migrator.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ari.legacy_lead_migrator {
	public static class ConfigureService {
		public static IConfiguration Configuration { get; set; }

		internal static IServiceProvider Configure() {
			IServiceCollection services = new ServiceCollection();

			ConfigureServices(services);

			return services.BuildServiceProvider();
		}

		private static void ConfigureServices(IServiceCollection services) {
			var configs = LoadConfiguration();

			services.AddSingleton(configs);
			services.AddSingleton<App>();
			services.AddSingleton<ISqlManager>(new SqlManager(Configuration.GetConnectionString("CustomerProfiles")));
			services.AddSingleton<IMigratorService, MigratorService>();
			services.AddSingleton<IMigratorRepository, MigratorRepository>();
		}

		private static IConfiguration LoadConfiguration() {
			return Configuration = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(AppContext.BaseDirectory))
				.AddJsonFile("appsettings.json", true, true)
				.Build();
		}
	}
}