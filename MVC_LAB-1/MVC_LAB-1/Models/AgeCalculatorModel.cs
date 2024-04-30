namespace MVC_LAB_1.Models
{
    public static class AgeCalculatorModel
    {
        public class AgeCalculationModel
        {
            public DateTime BirthDate { get; set; }

            public DateTime CurrentDate { get; set; }

            public int Age { get; set; }

            public int DaysToBirthday { get; set; }
        }
    }
}
