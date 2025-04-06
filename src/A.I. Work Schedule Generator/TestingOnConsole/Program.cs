using System;

namespace TestingOnConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dateValue = new DateTime(2008, 6, 12);
            Console.WriteLine(dateValue.DayOfWeek.ToString());
        }
    }
}
