using Microsoft.Extensions.Logging;

namespace CustomElementsApp.ViewModels
{
    public class CalendarViewModel
    {
        public int CurrentMonth { get; set; }
        public int CurrentYear { get; set; }
        public List<CalendarEventViewModel> Events { get; set; }

        public CalendarViewModel()
        {
            CurrentMonth = DateTime.Now.Month;
            CurrentYear = DateTime.Now.Year;
            Events = [];
        }

        // Метод для вычисления количества дней в месяце
        public int DaysInMonth => DateTime.DaysInMonth(CurrentYear, CurrentMonth);

        // Метод для получения первого дня недели текущего месяца
        public DayOfWeek FirstDayOfWeek => new DateTime(CurrentYear, CurrentMonth, 1).DayOfWeek;

        // Новые поля для действия и контроллера
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
    }
}

