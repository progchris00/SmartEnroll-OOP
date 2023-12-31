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
            Console.SetCursorPosition(57,50);
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
            Date.DisplayToday();

            var PendingMessageBox = new Box(57, 13, 35, 3);
            PendingMessageBox.CreateBox();

            Console.SetCursorPosition(65,14);
            Console.WriteLine("Your enrollment is still being process.");

            Console.SetCursorPosition(65,16);
            Console.WriteLine("Please wait for further notice.");

            Console.SetCursorPosition(61,22);
            Console.WriteLine("Press any key to logout...");
            Console.SetCursorPosition(89,22);

            Console.ReadKey();
        }
        public static void Rejected()
        {
            var MainBox = new Box(40,5,70,20);
            
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("                                             SmartEnroll"));

            MainBox.CreateBox();
            Date.DisplayToday();

            var LogoutMessageBox = new Box(57, 13, 35, 3);
            LogoutMessageBox.CreateBox();

            Console.SetCursorPosition(65,14);
            Console.WriteLine("Your enrollment application was rejected");

            Console.SetCursorPosition(65,16);
            Console.WriteLine("If you think this was a mistake, please contact the admin.");

            Console.SetCursorPosition(61,22);
            Console.WriteLine("Press any key to continue...");
            Console.SetCursorPosition(89,22);

            Console.ReadKey();
        }
    }
}