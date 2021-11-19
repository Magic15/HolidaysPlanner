using System;
using System.Collections.Generic;
using System.Linq;

namespace HolidaysPlanner
{
    // test2
    public class DateItem
    {
        public DateItem(DateTime dateStart, DateTime dateEnd)
        {
            this.dateStart = dateStart;
            this.dateEnd = dateEnd;
        }

        DateTime dateStart;
        public DateTime DateStart
        {
            get => dateStart; set => dateStart = value;
        }

        DateTime dateEnd;
        public DateTime DateEnd { get => dateEnd; set => dateEnd = value; }

        private List<DateTime> GetDays(DateTime start, DateTime end)
        {
            List<DateTime> dateList = new List<DateTime>();
            for (DateTime i = dateStart; i <= dateEnd; i.AddDays(1))
            {
                dateList.Add(i);
                i = i.AddDays(1);
            }
            return dateList;
        }

        public int GetMyHolidaysDaysWithoutWeekendsAndCelebrations(List<DateTime> freeDays)
        {
            var days = GetDays(dateStart, dateEnd);
            var weekendsAndCelebritiesCount = days.Where(d => d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday || freeDays.Contains(d)).Count();
            //var dayBeforeStart = dateStart.AddDays(-1);
            //var dayAfterStart = dateStart.AddDays(-1);
            return days.Count - weekendsAndCelebritiesCount;
        }
        public int GetDaysCount(List<DateTime> freeDays)
        {
            return GetDays(dateStart, dateEnd).Count;
        }
    }
}
