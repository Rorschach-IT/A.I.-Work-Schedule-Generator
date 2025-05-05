namespace GeneticAlgorithm.Model
{
    public class WorkSchedulePredictionModel
    {
        public string Date { get; set; }
        public string DayOfWeek => DateTime.Parse(Date).DayOfWeek.ToString();
        public string ChangeId { get; set; }
        public int EmployeeIdCount { get; set; } = 0;
    }
}
