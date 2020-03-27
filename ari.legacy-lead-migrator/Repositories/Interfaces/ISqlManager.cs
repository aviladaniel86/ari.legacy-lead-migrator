using System.Data;
using System.Threading.Tasks;

namespace ari.legacy_lead_migrator.Repositories.Interfaces {
	public interface ISqlManager {
		Task<IDbConnection> GetConnectionAsync();
	}
}
