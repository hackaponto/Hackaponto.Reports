using Dapper;
using Hackaponto.Reports.Domain.Models;
using Hackaponto.Reports.Infrastructure.DbEntities;
using Hackaponto.Reports.Infrastructure.SqlQueries;
using Hackaponto.Reports.UseCases.Interfaces.Repositories;
using Pottencial.Financial.Border.Repositories.Helpers;
using System.Text;

namespace Hackaponto.Reports.Infrastructure.Repositories
{
    public class UserWorkdayRepository(IRepositoryHelper repositoryHelper) : IUserWorkdayRepository
    {
        private readonly IRepositoryHelper _repositoryHelper = repositoryHelper;

        public IEnumerable<UserWorkday> GetAll(Guid userId, int year, int month)
        {
            using var connection = _repositoryHelper.GetPsqlConnection();
            connection.Open();

            var initialDate = new DateOnly(year, month, 1);
            var finalDate = initialDate.AddMonths(1).AddDays(-1);

            var query = new StringBuilder();
            var parameters = new DynamicParameters();

            query.Append(DbQueries.GetJustWorkdays);
            query.AppendLine("  WHERE ");
            query.AppendLine($"  u.user_id = '{userId.ToString()}' and ");
            query.AppendLine($"  u.\"date\" >= '{initialDate.ToString("yyyy-MM-dd")}' and ");
            query.AppendLine($"  u.\"date\" <= '{finalDate.ToString("yyyy-MM-dd")}' ");

            query.AppendLine("ORDER BY u.date");

            var workdays = new List<UserWorkday>();
            foreach(var workdayDbEntity in connection.Query<UserWorkdayDbEntity>(query.ToString()))
            {
                UserWorkday workday = workdayDbEntity;

                workday.ClockingEvents = connection.Query<ClockingEvent>($"SELECT id, user_id as userId, date, time, type FROM cloking_events WHERE user_id = '{workday.UserId}' AND date = '{workday.Date}' ORDER BY time DESC");
                workdays.Add(workday);
            }

            return workdays;
        }

        public IEnumerable<UserWorkday> Get(Guid userId, int year, int month)
        {
            using var connection = _repositoryHelper.GetPsqlConnection();
            connection.Open();

            var initialDate = new DateOnly(year, month, 1);
            var finalDate = initialDate.AddMonths(1).AddDays(-1);

            var query = new StringBuilder();
            var parameters = new DynamicParameters();

            query.Append(DbQueries.GetJustWorkdays);
            query.AppendLine("  WHERE ");
            query.AppendLine($"  u.user_id = '{userId.ToString()}' and ");
            query.AppendLine($"  u.\"date\" >= '{initialDate.ToString("yyyy-MM-dd")}' and ");
            query.AppendLine($"  u.\"date\" <= '{finalDate.ToString("yyyy-MM-dd")}' ");

            query.AppendLine("ORDER BY u.date");

            var workdays = new List<UserWorkday>();
            foreach (var workdayDbEntity in connection.Query<UserWorkdayDbEntity>(query.ToString()))
            {
                UserWorkday workday = workdayDbEntity;

                workday.ClockingEvents = connection.Query<ClockingEvent>($"SELECT id, user_id as userId, date, time, type FROM cloking_events WHERE user_id = '{workday.UserId}' AND date = '{workday.Date}' ORDER BY time ASC");
                workdays.Add(workday);
            }

            return workdays;
        }
    }
}
