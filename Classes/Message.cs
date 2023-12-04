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
    }
}