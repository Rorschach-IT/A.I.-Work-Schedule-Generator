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
        }
    }
}
