using Microsoft.AspNetCore.Mvc;
using static MVC_LAB_1.Models.AgeCalculatorModel;

namespace MVC_LAB_1.Controllers
{
    public class AgeCalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DetermineAgeAndDaysToBirthday(AgeCalculationModel model)
        {
            model.Age = CalculateAge(model.BirthDate, model.CurrentDate);
            model.DaysToBirthday = CalculateDaysToBirthday(model.BirthDate, model.CurrentDate);

            return View("Index", model);
        }

        private int CalculateAge(DateTime birthDate, DateTime currentDate)
        {
            int age = currentDate.Year - birthDate.Year;
            return age;
        }

        private int CalculateDaysToBirthday(DateTime birthDate, DateTime currentDate)
        {
            DateTime nextBirthday = birthDate.AddYears(CalculateAge(birthDate, currentDate) + 1);
            return (int)(nextBirthday - currentDate).TotalDays;
        }
    }
}
