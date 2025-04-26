using System;
using System.Collections.ObjectModel;

namespace TestingOnConsole
{
    public class WorkSchedule
    {
        public string Date { get; set; }
        public string DayOfWeek => DateTime.Parse(Date).DayOfWeek.ToString();
        public string ChangeId { get; set; }
        public string[] EmployeeId { get; set; }
        public int EmployeeIdCount => EmployeeId.Length;
        public string ClientCounter { get; set; }
    }

    public class WorkSchedulePrediction
    {
        public string Date { get; set; }
        public string DayOfWeek => DateTime.Parse(Date).DayOfWeek.ToString();
        public string ChangeId { get; set; }
        public int EmployeeIdCount { get; set; } = 0; // Default value is 0
    }

    internal class Program
    {
        public static string AddNewDay(string date, int addedDays)
        {
            DateTime parsedDate = DateTime.Parse(date);
            DateTime nextDay = parsedDate.AddDays(addedDays);
            return nextDay.ToString("yyyy-MM-dd");
        }

        static void Main(string[] args)
        {
            var workSchedules = new ObservableCollection<WorkSchedule>
            {
                new WorkSchedule { Date = "2024-04-01", ChangeId = "1", EmployeeId = new string[] { "1", "2" }, ClientCounter = "35" },
                new WorkSchedule { Date = "2024-04-01", ChangeId = "2", EmployeeId = new string[] { "3", "4", "5" }, ClientCounter = "72" },
                new WorkSchedule { Date = "2024-04-01", ChangeId = "3", EmployeeId = new string[] { "6", "7" }, ClientCounter = "42" },
                new WorkSchedule { Date = "2024-04-02", ChangeId = "1", EmployeeId = new string[] { "1", "2" }, ClientCounter = "31" },
                new WorkSchedule { Date = "2024-04-02", ChangeId = "2", EmployeeId = new string[] { "3", "4", "5" }, ClientCounter = "68" },
                new WorkSchedule { Date = "2024-04-02", ChangeId = "3", EmployeeId = new string[] { "6", "7" }, ClientCounter = "52" },
                new WorkSchedule { Date = "2024-04-03", ChangeId = "1", EmployeeId = new string[] { "1", "2" }, ClientCounter = "28" },
                new WorkSchedule { Date = "2024-04-03", ChangeId = "2", EmployeeId = new string[] { "3", "4", "5" }, ClientCounter = "77" },
                new WorkSchedule { Date = "2024-04-03", ChangeId = "3", EmployeeId = new string[] { "6", "7" }, ClientCounter = "45" },
                new WorkSchedule { Date = "2024-04-04", ChangeId = "1", EmployeeId = new string[] { "1", "2" }, ClientCounter = "22" },
                new WorkSchedule { Date = "2024-04-04", ChangeId = "2", EmployeeId = new string[] { "3", "4", "5" }, ClientCounter = "66" },
                new WorkSchedule { Date = "2024-04-04", ChangeId = "3", EmployeeId = new string[] { "6", "7" }, ClientCounter = "41" },
                new WorkSchedule { Date = "2024-04-05", ChangeId = "1", EmployeeId = new string[] { "1", "2" }, ClientCounter = "33" },
                new WorkSchedule { Date = "2024-04-05", ChangeId = "2", EmployeeId = new string[] { "3", "4", "5" }, ClientCounter = "80" },
                new WorkSchedule { Date = "2024-04-05", ChangeId = "3", EmployeeId = new string[] { "6", "7", "8" }, ClientCounter = "55" },
                new WorkSchedule { Date = "2024-04-06", ChangeId = "1", EmployeeId = new string[] { "1", "2", "8" }, ClientCounter = "45" },
                new WorkSchedule { Date = "2024-04-06", ChangeId = "2", EmployeeId = new string[] { "3", "4", "5" }, ClientCounter = "73" },
                new WorkSchedule { Date = "2024-04-06", ChangeId = "3", EmployeeId = new string[] { "6", "7", "8" }, ClientCounter = "70" }
            };

            var workSchedulePredictions = new ObservableCollection<WorkSchedulePrediction>();

            int addedDays = 1;

            for (int i = 1; i <= workSchedules.Count; i++)
            {
                // First day += 2 (every Sunday is skipped)
                if (i == 1)
                {
                    addedDays = 2;
                }

                string nextDay = AddNewDay(workSchedules[workSchedules.Count - 1].Date, addedDays);
                string changeId = workSchedules[i - 1].ChangeId;

                var prediction = new WorkSchedulePrediction
                {
                    Date = nextDay,
                    ChangeId = changeId
                    // EmployeeIdCount remains default (0)
                };

                workSchedulePredictions.Add(prediction);

                if (i % 3 == 0)
                {
                    addedDays += 1;
                }
            }

            // Displaying the initial collection
            Console.WriteLine("Date       DayOfWeek ChangeId ClientCounter  EmployeeIdCount");
            foreach (var schedule in workSchedules)
            {
                Console.WriteLine($"{schedule.Date} {schedule.DayOfWeek,-10} {schedule.ChangeId,-8} {schedule.ClientCounter,-13} {schedule.EmployeeIdCount}");
            }

            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("Next section:");
            Console.WriteLine("-------------------------------\n");

            // Displaying the prediction collection
            Console.WriteLine("Date       DayOfWeek ChangeId EmployeeIdCount");
            foreach (var prediction in workSchedulePredictions)
            {
                Console.WriteLine($"{prediction.Date} {prediction.DayOfWeek,-10} {prediction.ChangeId,-8} {prediction.EmployeeIdCount}");
            }

        }
    }
}
