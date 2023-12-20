using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using Figgle;

namespace Itec102.StudentManagementSystem
{
    public class Menu
    {
        private string[] choices;
        private string message;
        private string status;

        public Menu(string[] choices, string message, string status)
        {
            this.choices = choices;
            this.message = message;
            this.status = status;
        }
        public int ShowMenu(string userState)
        {
            DateTime currentDate = DateTime.Now;
            string DateToday = currentDate.ToString("MMMM/dd/yyyy");
            string DayToday = currentDate.ToString("dddd");

            var MainBox = new Box(40,5,70,20);
            var LeftBox = new Box(0,7,38,8);

            int selectedIndex = 0;
            ConsoleKeyInfo keyInfo;
            
            do
            {
                Console.Clear();
                Console.WriteLine(FiggleFonts.Standard.Render("                                              SmartEnroll"));

                MainBox.CreateBox();
                // Draw the box on the left side
                LeftBox.CreateBox();
                
                if (userState == "UserNotFound")
                {
                    Message.UsernameNotFound();
                }

                else if (userState == "Login")
                {
                    string CurrentUserRole = Session.GetCurrentUserRole(Session.GetCurrentUser());

                    Schedule.DisplayToday(DayToday, DateToday);
                    Profile.Load(CurrentUserRole);

                }

                // Print the message inside the box
                Console.SetCursorPosition(2, 9);
                Console.WriteLine(message);

                // Print the choices inside the box
                for (int i = 0; i < choices.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    }

                    // Print each choice inside the box
                    Console.SetCursorPosition(2, 11 + i);
                    Console.WriteLine(choices[i]);

                    Console.ResetColor();
                }

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow && selectedIndex > 0)
                    {
                        selectedIndex--;
                    }

                else if (keyInfo.Key == ConsoleKey.DownArrow && selectedIndex < choices.Length - 1)
                    {
                        selectedIndex++;
                    }

            } while (keyInfo.Key != ConsoleKey.Enter);

        return selectedIndex;
        }
    
        public int AdminMenu(string status)
        {
            DateTime currentDate = DateTime.Now;
            string DateToday = currentDate.ToString("MMMM/dd/yyyy");
            string DayToday = currentDate.ToString("dddd");

            var MainBox = new Box(40,5,70,20);

            int selectedIndex = 0;
            ConsoleKeyInfo keyInfo;
            
            do
            {
                Console.Clear();
                Console.WriteLine(FiggleFonts.Standard.Render("                                              SmartEnroll"));

                MainBox.CreateBox();

                Schedule.DisplayToday(DayToday, DateToday);

                // Print the message inside the box
                Console.SetCursorPosition(59, 9);
                Console.WriteLine(message);

                // Print the choices inside the box
                for (int i = 0; i < choices.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    }

                    if (choices[i] == "All")
                    {
                        Console.SetCursorPosition(73, 12 + i);
                        Console.WriteLine(choices[i]);
                    }
                    else
                    {
                        Console.SetCursorPosition(71, 12 + i);
                        Console.WriteLine(choices[i]);
                    }

                    Console.ResetColor();

                }

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow && selectedIndex > 0)
                    {
                        selectedIndex--;
                    }

                else if (keyInfo.Key == ConsoleKey.DownArrow && selectedIndex < choices.Length - 1)
                    {
                        selectedIndex++;
                    }

            } while (keyInfo.Key != ConsoleKey.Enter);

        return selectedIndex;
        }
    }
}
