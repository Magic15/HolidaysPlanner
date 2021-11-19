using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace HolidaysPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            //bin/debug
            string workingDirectory = Environment.CurrentDirectory;
            //bin/
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            string projectDirectory2 = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            string workFreeDaysCsvDirectory = $"{projectDirectory2}\\Data\\WorkFreeDays.csv";
            string planningDaysCsvDirectory = $"{projectDirectory2}\\Data\\PlanningDays.csv";

            string dateFormat = "dd.MM.yyyy";
            var provider = new CultureInfo("pl-PL");

            List<DateTime> workFreeDays = new List<DateTime>();
            using (var reader = new StreamReader(workFreeDaysCsvDirectory))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var date = DateTime.ParseExact(line, dateFormat, provider);
                    workFreeDays.Add(date);
                }
            }

            List<DateItem> dateItems = new List<DateItem>();
            using (var reader = new StreamReader(planningDaysCsvDirectory))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    List<string> splitLine = line.Split(",").ToList();
                    var dateStart = DateTime.ParseExact(splitLine[0].ToString(), dateFormat, provider);
                    var dateEnd = DateTime.ParseExact(splitLine[1].ToString(), dateFormat, provider);
                    dateItems.Add(new DateItem(dateStart, dateEnd));
                }
            }
            var sumWithoutWeekendAndCelebrations = 0;
            foreach(var item in dateItems)
            {
                sumWithoutWeekendAndCelebrations+= item.GetMyHolidaysDaysWithoutWeekendsAndCelebrations(workFreeDays);
            }
            /*
            var sumAll = 0;
            foreach (var item in dateItems)
            {
                sumWithoutWeekendAndCelebrations += item.Get
            }
            */
            Console.WriteLine($"Ilość dni wolnych nie licząc świąt i weekendów: {sumWithoutWeekendAndCelebrations}");
            //Console.WriteLine($"Ilość dni wolnych licząc święta i weekendy: {sum}");
        }       
    }
}
