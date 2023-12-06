using System.Net.NetworkInformation;

namespace Itec102
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
            var LogoutBox = new Box(57, 13, 35, 3);
            LogoutBox.CreateBox();

            Console.SetCursorPosition(65,14);
            Console.WriteLine("You've been logout.");

            Console.SetCursorPosition(61,22);
            Console.WriteLine("Press any key to continue...");
            Console.SetCursorPosition(89,22);
        }
    }
}