using Microsoft.Extensions.DependencyInjection;

namespace ari.legacy_lead_migrator {
	class Program {
		static void Main(string[] args) {
			var serviceProvider = ConfigureService.Configure();

			serviceProvider.GetService<App>().Run();
		}
	}
}