namespace GeneticAlgorithm.Model
{
    public class WorkScheduleModel
    {
        public DateTime Date { get; set; }
        public string DayOfWeek => Date.DayOfWeek.ToString();
        public string? ChangeId { get; set; }
        public int[]? EmployeeId { get; set; }
        //public required string Name { get; set; }
        //public required string LastName { get; set; }
        public string? ClientCounter { get; set; }
    }
}
