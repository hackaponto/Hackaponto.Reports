using Hackaponto.Reports.Application.Settings;
using Microsoft.Extensions.Options;
using Npgsql;
using Pottencial.Financial.Border.Repositories.Helpers;

namespace Hackaponto.Reports.Application.Helpers
{
    public class RepositoryHelper(IOptions<DbConnection> dbConnectionStrings) : IRepositoryHelper
    {
        private readonly DbConnection _dbConnectionStrings = dbConnectionStrings.Value;

        public NpgsqlConnection GetPsqlConnection()
        {
            string connectionString = $"Host={_dbConnectionStrings.Host};Database={_dbConnectionStrings.Database};UserId={_dbConnectionStrings.Username};Password={_dbConnectionStrings.Password};";

            return new NpgsqlConnection(connectionString);
        }
    }
}
