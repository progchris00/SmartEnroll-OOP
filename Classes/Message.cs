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
            var IncorrectPasswordBox = new Box(57, 19, 35, 3);
            IncorrectPasswordBox.CreateBox();

            Console.SetCursorPosition(66,20);
            Console.WriteLine("Logout Success");
        }

        public static void EmptyInput()
        {
            var EmptyInput = new Box(59, 14, 35, 3);
            EmptyInput.CreateBox();

            Console.SetCursorPosition(60,15);
            Console.WriteLine("Input cannot be empty, try again.");
        }
    }
}