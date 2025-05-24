using System.Collections.ObjectModel;
using GeneticAlgorithm.ExternalClasses;
using GeneticAlgorithm.Model;
using GeneticAlgorithm.NVVM;

namespace GeneticAlgorithm.ViewModel
{
    public class WorkSchedulePredictionViewModel : ViewModelBase
    {
        private ObservableCollection<WorkSchedulePredictionModel> _workSchedulesPredictions = new();
        public ObservableCollection<WorkSchedulePredictionModel> WorkSchedulesPredictions
        {
            get => _workSchedulesPredictions;
            set
            {
                _workSchedulesPredictions = value;
                OnPropertyChanged(nameof(WorkSchedulesPredictions));
            }
        }

        public string AddNewDay(string date, int addedDays)
        {
            DateTime parsedDate = DateTime.Parse(date);
            DateTime nextDay = parsedDate.AddDays(addedDays);
            return nextDay.ToString("yyyy-MM-dd");
        }

        public void LoadWorkSchedulePredictionData(ObservableCollection<WorkScheduleModel> workSchedules)
        {

            int addedDays = 1;

            for (int i = 1; i <= workSchedules.Count; i++)
            {
                if (i == 1)
                {
                    addedDays = 2;
                }

                string nextDay = AddNewDay(workSchedules[workSchedules.Count - 1].Date.ToString("yyyy-MM-dd"), addedDays);
                string changeId = workSchedules[i - 1].ChangeId;

                var prediction = new WorkSchedulePredictionModel
                {
                    Date = nextDay,
                    ChangeId = changeId!
                };

                WorkSchedulesPredictions.Add(prediction);

                if (i % 3 == 0)
                {
                    addedDays += 1;
                }
            }

            var clientCounts = workSchedules.Select(ws => int.Parse(ws.ClientCounter!)).ToList();
            var daysOfWeek = workSchedules.Select(ws => ws.DayOfWeek).ToList();

            var geneticScheduler = new GeneticScheduler();
            var optimizedEmployeeCounts = geneticScheduler.Optimize(clientCounts, daysOfWeek);

            for (int i = 0; i < WorkSchedulesPredictions.Count; i++)
            {
                WorkSchedulesPredictions[i].EmployeeIdCount = optimizedEmployeeCounts[i];
            }

            if (workSchedules.Count == 0)
            {
                throw new Exception("No data inside work schedules predictions");
            }

            // [*]
            var employeePreferences = new EmployeePreferencesViewModel();
            employeePreferences.LoadEmployeePreferencesData();

            if (!employeePreferences.EmployeePreferences.Any())
                throw new Exception("No data inside work employees preferences");

            // Employees and their availability
            List<string> employees = new();
            List<int> employeesUsed = new();

            Dictionary<string, List<string>> availabilityPerDay = new()
            {
                { "Monday", new List<string>() },
                { "Tuesday", new List<string>() },
                { "Wednesday", new List<string>() },
                { "Thursday", new List<string>() },
                { "Friday", new List<string>() },
                { "Saturday", new List<string>() }
            };

            foreach (var pref in employeePreferences.EmployeePreferences)
            {
                employees.Add(pref.Employee);
                employeesUsed.Add(0);
                availabilityPerDay["Monday"].Add(pref.Monday);
                availabilityPerDay["Tuesday"].Add(pref.Tuesday);
                availabilityPerDay["Wednesday"].Add(pref.Wednesday);
                availabilityPerDay["Thursday"].Add(pref.Thursday);
                availabilityPerDay["Friday"].Add(pref.Friday);
                availabilityPerDay["Saturday"].Add(pref.Saturday);
            }

            foreach (var prediction in WorkSchedulesPredictions)
            {
                if (!availabilityPerDay.ContainsKey(prediction.DayOfWeek))
                    continue;

                var availability = availabilityPerDay[prediction.DayOfWeek];
                int sum = 0;

                for (int i = 0; i < employees.Count; i++)
                {
                    if (sum >= prediction.EmployeeIdCount)
                        break;

                    if (employeesUsed[i] >= 6)
                        continue;

                    if (availability[i] == prediction.ChangeId)
                    {
                        prediction.Employees.Add(employees[i]);
                        employeesUsed[i]++;
                        sum++;
                    }
                }
            }
        }
    }
}
