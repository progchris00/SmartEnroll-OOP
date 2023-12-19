namespace Itec102.StudentManagementSystem
{
    public class Date
    {
        public static void Today(string DayToday, string DateToday)
        {
            DisplayDateToday(DayToday, DateToday);
            bool Wednesday_B = DayToday == "Wednesday" && Session.GetCurrentUserSection(Session.GetCurrentUser()) == "B";

            if (DayToday == "Sunday" || Wednesday_B)
            {
                Console.SetCursorPosition(54, 13); 
                Console.WriteLine("There are no classes scheduled for today.");
            }
            else
            {
                string[] csvFilePath = {};
                csvFilePath = File.ReadAllLines("data/Schedule.csv");
                int top = 13;

                foreach(var SubjectCode in csvFilePath)
                {
                    string[] fields = SubjectCode.Split(',');

                    string SubjectToday = fields[0].Trim();
                    string UserSection = fields[4].Trim();
                    
                    if (SubjectToday == DayToday && UserSection == Session.GetCurrentUserSection(Session.GetCurrentUser())) 
                    {

                        Console.SetCursorPosition(58, 10); 
                        Console.WriteLine("SUBJECT\t\tTIME");

                        string storedSubjectCode = fields[1].Trim();
                        string storedSubjectTitle = fields[2].Trim();
                        string storedTimeDate = fields[3].Trim();

                        Console.SetCursorPosition(58, top); 
                        Console.WriteLine($"{storedSubjectCode,-15}{storedTimeDate}");
                        top += 2;
                    }
                }
            }
        }

        public static void DisplayDateToday(string DayToday, string DateToday)
        {
            Console.SetCursorPosition(80, 7); 
            Console.WriteLine($"{DayToday}, {DateToday}");
        }
    }
}