namespace Itec102.StudentManagementSystem
{
    public class Date
    {
        public static void DisplayToday(string DayToday, string DateToday)
        {
            Console.SetCursorPosition(80, 7); 
            Console.WriteLine($"{DayToday}, {DateToday}");
        }
    }
}