using Npgsql;
using System.Data;

namespace Pottencial.Financial.Border.Repositories.Helpers
{
    public interface IRepositoryHelper
    {
        int CommandTimeout => 60;

        public NpgsqlConnection GetPsqlConnection();
    }
}