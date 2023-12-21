namespace Itec102.StudentManagementSystem
{
    public class Date
    {
        public static void DisplayToday()
        {
            DateTime currentDate = DateTime.Now;
            string DateToday = currentDate.ToString("MMMM/dd/yyyy");
            string DayToday = currentDate.ToString("dddd");

            Console.SetCursorPosition(80, 7); 
            Console.WriteLine($"{DayToday}, {DateToday}");
        }
    }
}