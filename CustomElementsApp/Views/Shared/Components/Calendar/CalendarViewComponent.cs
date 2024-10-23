using CustomElementsApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomElementsApp.Views.Shared.Components.Calendar
{
    public class CalendarViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(int month, int year, string actionName, string controllerName, List<CalendarEventViewModel> events)
        {
            // Убедимся, что переданы корректные параметры
            if (month < 1)
            {
                month = 12;
                year--;
            }
            else if (month > 12)
            {
                month = 1;
                year++;
            }

            var model = new CalendarViewModel
            {
                CurrentMonth = month,
                CurrentYear = year,
                Events = events,
                ActionName = actionName, // Добавим это в модель
                ControllerName = controllerName // Добавим это в модель
            };

            return View("Default", model);
        }
    }
}
