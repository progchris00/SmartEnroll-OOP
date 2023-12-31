using System.ComponentModel;
using System.Reflection;
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

            MainBox.CreateBox();

            int selectedIndex = 0;
            ConsoleKeyInfo keyInfo;
            
            do
            {
                Console.Clear();
                Console.WriteLine(FiggleFonts.Standard.Render("                                             SmartEnroll"));

                MainBox.CreateBox();

                Console.SetCursorPosition(69, 13);
                Console.WriteLine("Hello, Human.");

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

        public int SectionMenu(string status)
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
                Console.WriteLine(FiggleFonts.Standard.Render("                                             SmartEnroll"));
                MainBox.CreateBox();

                Date.DisplayToday();

                // Print the message inside the box
                Console.SetCursorPosition(61, 10);
                Console.WriteLine(message);

                // Print the choices inside the box
                for (int i = 0; i < choices.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    }

                    // for centering the choices of the menu
                    if (choices[i] == "View Enrolled Students")
                    {
                        Console.SetCursorPosition(64, 13 + i);
                        Console.WriteLine(choices[i]);
                    }
                    else if (choices[i] == "Review Pending Enrollees")
                    {
                        Console.SetCursorPosition(63, 14);
                        Console.WriteLine(choices[i]);
                    }
                    else if (choices[i] == "Sign Out")
                    {
                        Console.SetCursorPosition(71, 16);
                        Console.WriteLine(choices[i]);
                    }

                    else if (choices[i] == "All")
                    {
                        Console.SetCursorPosition(73, 13 + i);
                        Console.WriteLine(choices[i]);
                    }

                    else
                    {
                        Console.SetCursorPosition(71, 13 + i);
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

        public int AdminMenu(string userState)
        {
            var LeftBox = new Box(0,7,38,8);

            int selectedIndex = 0;
            ConsoleKeyInfo keyInfo;
            
            do
            {
                Console.Clear();

                Csv.LoadUsers(Choice.Get());

                LeftBox.CreateBox();


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
        public int PendingMenu(string firstname, string lastname, string year, string course, string section, string email)
        {
            var MainBox = new Box(40,5,70,20);

            int selectedIndex = 0;
            ConsoleKeyInfo keyInfo;
            
            do
            {
                Console.Clear();
                Console.WriteLine(FiggleFonts.Standard.Render("                                             SmartEnroll"));
                MainBox.CreateBox();

                Date.DisplayToday();

                // Print the message inside the box
                Console.SetCursorPosition(57, 9);
                Console.WriteLine(message);
                
                Console.SetCursorPosition(45, 12);
                Console.WriteLine($"Enrollees Information:");

                // Print the information of the current user in the box
                Console.SetCursorPosition(45, 14);
                Console.WriteLine($"Full name:\t\t{firstname} {lastname}");
                Console.SetCursorPosition(45, 16);
                Console.WriteLine($"Course: \t\t{course}-{year}{section}");
                Console.SetCursorPosition(45, 18);
                Console.WriteLine($"Email: \t\t{email}");

                // Print the choices inside the box
                for (int i = 0; i < choices.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    }

                    if (choices[i] == "Accept")
                    {
                        Console.SetCursorPosition(67, 21);
                        Console.WriteLine(choices[i]);
                    }

                    else if (choices[i] == "Reject")
                    {
                        Console.SetCursorPosition(77, 21);
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
