namespace Itec102
{
    public class Inputs
    {
        public static string GetUsername()
        {
            var UsernameField = new Box(50, 9, 50, 3);
            string username;

            UsernameField.CreateBox();
            Console.SetCursorPosition(50 + 2, 9 + 1);

            return username = Console.ReadLine();
        }

        public static string GetPassword()
        {
            var PasswordField = new Box(50, 13, 50, 3);
            string password;

            PasswordField.CreateBox();
            Console.SetCursorPosition(50 + 2, 13 + 1);

            return password = Console.ReadLine();
        } 
    }
}