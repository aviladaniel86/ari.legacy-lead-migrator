using System;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ari.legacy_lead_migrator.Repositories.Interfaces;

namespace ari.legacy_lead_migrator.Repositories {
	public class SqlManager : ISqlManager {
		private readonly string _connectionString;

		public SqlManager(string connectionString) {
			_connectionString = connectionString;
		}

		public async Task<IDbConnection> GetConnectionAsync() {
			try {
				var connection = new SqlConnection(_connectionString);

				await connection.OpenAsync().ConfigureAwait(false);

				return connection;

			} catch (Exception ex) {

			}
			return null;
		}
	}
}