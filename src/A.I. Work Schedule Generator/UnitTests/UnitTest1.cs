namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string fileName1 = "../../../../GeneticAlgorithm/Data/Employee.json";
            string jsonString1 = File.ReadAllText(fileName1);
            Assert.False(string.IsNullOrEmpty(jsonString1));

            string fileName2 = "../../../../GeneticAlgorithm/Data/WorkSchedule.json";
            string jsonString2 = File.ReadAllText(fileName2);
            Assert.False(string.IsNullOrEmpty(jsonString2));
        }
    }
}