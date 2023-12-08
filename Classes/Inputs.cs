using System.Text;
namespace Itec102
{
    public class Inputs
    {
        public static string Login_Username()
        {
            var UsernameField = new Box(50, 9, 50, 3);
            string username;

            UsernameField.CreateBox();
            Console.SetCursorPosition(50 + 2, 9 + 1);

            return username = Console.ReadLine();
        }

        public static string Login_Password()
        {
            var PasswordField = new Box(50, 13, 50, 3);
            string password;

            PasswordField.CreateBox();
            Console.SetCursorPosition(50 + 2, 13 + 1);

            password = MaskPassword();
            return password;
        } 

        public static string MaskPassword()
        {
            string input = "";
            ConsoleKeyInfo key;

            do
            {

            key = Console.ReadKey(true);

            // Check if the key pressed is not the Enter key
                if (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        if(input.Length > 0)
                        {
                            Console.Write("\b \b");
                            input = input.Substring(0, input.Length - 1);
                        }
                    }

                    else
                    {
                        Console.Write('*');
                        input += key.KeyChar;
                    }

                }

            } while (key.Key != ConsoleKey.Enter);

            return input;
        }
    }
}