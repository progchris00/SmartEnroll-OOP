using System.Net.NetworkInformation;
using Figgle;

namespace Itec102.StudentManagementSystem
{
    public class Message
    {
        public static void UsernameNotFound()
        {
            var MessageBox = new Box(63, 13, 25, 3);
            string message = "User Not Found!";

            MessageBox.CreateBox();

            Console.SetCursorPosition(68, 14);
            Console.WriteLine(message);
        }

        public static void RegistrationSuccess()
        {
            Console.SetCursorPosition(54,50);
            Console.WriteLine("Registration Success! Press enter to Login.");
            Console.ReadKey();
        }

        public static void LoginSuccess()
        {
            var LoginSuccessBox = new Box(57, 19, 35, 3);
            LoginSuccessBox.CreateBox();

            Console.SetCursorPosition(68,20);
            Console.WriteLine("Login Success");

            Console.SetCursorPosition(61,22);
            Console.WriteLine("Press any key to continue...");
            Console.SetCursorPosition(89,22);
            Console.ReadKey();
        }

        public static void IncorrectPassword()
        {
            var IncorrectPasswordBox = new Box(57, 19, 35, 3);
            IncorrectPasswordBox.CreateBox();

            Console.SetCursorPosition(66,20);
            Console.WriteLine("Incorrect Password");
        }

        public static void LogoutSuccess()
        {
            var MainBox = new Box(40,5,70,20);
            
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("                                             SmartEnroll"));

            MainBox.CreateBox();

            var LogoutMessageBox = new Box(57, 13, 35, 3);
            LogoutMessageBox.CreateBox();

            Console.SetCursorPosition(65,14);
            Console.WriteLine("You've been logout.");

            Console.SetCursorPosition(61,22);
            Console.WriteLine("Press any key to continue...");
            Console.SetCursorPosition(89,22);
        }

        public static void Pending()
        {
            var MainBox = new Box(40,5,70,20);

            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("                                             SmartEnroll"));

            MainBox.CreateBox();
            Profile.Load("user");
            Date.DisplayToday();

            Console.SetCursorPosition(54,12);
            Console.WriteLine("We're currently processing your enrollment.");

            Console.SetCursorPosition(59,14);
            Console.WriteLine("Please wait for further updates.");

            Console.SetCursorPosition(62,22);
            Console.WriteLine("Press any key to logout...");
            Console.SetCursorPosition(88,22);

            Console.ReadKey();
        }
        public static void Rejected()
        {
            var MainBox = new Box(40,5,70,20);
            
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("                                             SmartEnroll"));

            MainBox.CreateBox();
            Profile.Load("user");
            Date.DisplayToday();

            Console.SetCursorPosition(52,12);
            Console.WriteLine("Your enrollment application has been declined.");

            Console.SetCursorPosition(57,14);
            Console.WriteLine("Kindly contact admin for assistance.");

            Console.SetCursorPosition(62,22);
            Console.WriteLine("Press any key to logout...");
            Console.SetCursorPosition(88,22);

            Console.ReadKey();
        }

        public static void NoPending()
        {
            var MainBox = new Box(40,5,70,20);
            
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("                                             SmartEnroll"));

            MainBox.CreateBox();
            Date.DisplayToday();

            Console.SetCursorPosition(65,12);
            Console.WriteLine("You've all caught up.");

            Console.SetCursorPosition(63,14);
            Console.WriteLine("No pending enrollees yet.");

            Console.SetCursorPosition(61,22);
            Console.WriteLine("Press any key to go back...");
            Console.SetCursorPosition(88,22);

            Console.ReadKey();
        }
    }
}