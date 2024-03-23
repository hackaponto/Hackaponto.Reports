namespace Hackaponto.Reports.Infrastructure.SqlQueries
{
    public static class DbQueries
    {
        public const string GetWithClockingEvents = @"
select
	c.""id"" as ""Id"",
	c.""time"" as ""Time"",
	c.""type"" as ""Type"",
	u.""user_id"" as ""UserId"",
	u.""date"" as ""Date"",
	u.""total_hours"" as ""TotalWorkHours""
FROM public.user_work_days as u
inner join public.cloking_events as c on u.user_id  = c.user_id  and u.""date""  = c.""date"" 
";

        public const string GetJustClockingEvents = @"
select
	""id"" as ""Id"",
	""date"" as ""Date"",
	""time"" as ""Time"",
	""type"" as ""Type"",
	""user_id"" as ""UserId""
FROM public.cloking_events c
";
        public const string GetJustWorkdays = @"
select
	""user_id"" as ""UserId"",
	""date"" as ""Date"",
	""total_hours"" as ""TotalWorkHours""
FROM public.user_work_days u
";
    }
}
