using System;
using System.Linq;
using System.Globalization;
using Store.Data.Constants;

namespace Store.Services.Utilities
{
    public static class DateTimeUtilities
    {
        public static DateTime StartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0, DateTimeKind.Utc);
        }

        public static DateTime StartOfWeek(DateTime date, DayOfWeek startOfWeek)
        {
            int difference = (7 + (date.DayOfWeek - startOfWeek)) % 7;
            return date.AddDays(-1 * difference).Date;
        }

        public static DateTime EndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999, DateTimeKind.Utc);
        }

        public static DateTime EndOfWeek(this DateTime date, DayOfWeek startOfWeek)
        {
            int difference = (7 - (date.DayOfWeek - startOfWeek)) % 7;
            return date.AddDays(1 * difference).Date;
        }

        public static DateTime ConvertTimeStamp(double timeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(timeStamp).ToLocalTime();

            return dateTime;
        }

        public static long ReverseTimeStamp(DateTime time)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, time.Kind);
            return System.Convert.ToInt64((time - date).TotalSeconds);
        }

        public static DateTime ToMongoQuery(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);
        }

        public static DateTime ToLocalTime(DateTime time)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(time.ToUniversalTime(), TimeZoneInfo.FindSystemTimeZoneById(CommonConstants.TIME_ZONE_ID));
        }

        public static DateTime GetLocalTime(bool isDated = false)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(isDated ? DateTime.UtcNow.Date : DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(CommonConstants.TIME_ZONE_ID));
        }

        public static int GetNumberOfParticularDaysInMonth(int year, int month, DayOfWeek dayOfWeek)
        {
            DateTime startDate = new DateTime(year, month, 1);
            int totalDays = startDate.AddMonths(1).Subtract(startDate).Days;

            int answer = Enumerable.Range(1, totalDays)
                                .Select(item => new DateTime(year, month, item))
                                .Where(date => date.DayOfWeek == dayOfWeek)
                                .Count();

            return answer;
        }

        public static int GetWeekNumberInYear(DateTime date)
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            int weekNumber = currentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNumber;
        }
    }
}

