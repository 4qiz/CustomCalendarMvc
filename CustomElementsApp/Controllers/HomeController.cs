using CustomElementsApp.Models;
using CustomElementsApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CustomElementsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<CalendarEventViewModel> events =
        [
            new CalendarEventViewModel{ Title = "Meeting", Date = new DateTime(2024, 10, 25) },
            new CalendarEventViewModel { Title = "Conference", Date = new DateTime(2024, 10, 28) }
        ];

        public ActionResult Index(int? month, int? year)
        {
            // “екуща€ дата, если параметры не переданы
            var currentDate = DateTime.Now;

            // ћес€ц и год переданы из запроса (если нет, беретс€ текущий мес€ц и год)
            int currentMonth = month ?? currentDate.Month;
            int currentYear = year ?? currentDate.Year;

            // ѕередаем мес€ц и год в представление, вместе с событи€ми
            var model = new CalendarViewModel
            {
                CurrentMonth = currentMonth,
                CurrentYear = currentYear,
                Events = events
            };

            return View(model);
        }

        public IActionResult Privacy(int? month, int? year)
        {
            var events = new List<CalendarEventViewModel>
            {
                new CalendarEventViewModel { Title = "Meeting", Date = new DateTime(2024, 10, 25) },
                new CalendarEventViewModel { Title = "Conference", Date = new DateTime(2024, 10, 28) },
                new CalendarEventViewModel { Title = "ƒень рождени€", Date = new DateTime(2024, 11, 26) }
            };

            int currentMonth = month ?? DateTime.Now.Month;
            int currentYear = year ?? DateTime.Now.Year;

            ViewBag.Month = currentMonth;
            ViewBag.Year = currentYear;
            ViewBag.Events = events;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
