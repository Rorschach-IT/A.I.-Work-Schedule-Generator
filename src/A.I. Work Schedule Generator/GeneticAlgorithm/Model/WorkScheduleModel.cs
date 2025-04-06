namespace GeneticAlgorithm.Model
{
    public class WorkScheduleModel
    {
        public required DateTime Date { get; set; }
        public string DayOfWeek => Date.DayOfWeek.ToString();
        public required string ChangeId { get; set; }
        public required string PESEL { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string ClientCounter { get; set; }
    }
}
