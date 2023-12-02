using System.Net.NetworkInformation;

namespace Itec102
{
    public class Account
    {
        public static void Login()
        {
            while (true)
            {
                Console.SetCursorPosition(50, 8);
                Console.WriteLine("Username: ");

                string username = Inputs.GetUsername();

                if (Validate.Username(username))
                {
                    while (true)
                    {
                        Console.SetCursorPosition(50,12);
                        Console.WriteLine("Password: ");

                        string password = Inputs.GetPassword();

                        if (Validate.Password(username, password))
                        {
                             break;
                        }

                        // else
                        // {   
                        //     Console.SetCursorPosition(50,16);
                        //     AnimateProgressBar(45,5,65,11);
                        //     Console.SetCursorPosition(68,17);
                        //     textbox_incorrect();
                        //     continue;
                        // }
                    }
                }

                // else
                // {
                //     UsernotFound();
                //     continue;
                // }
            }
        }
    }
}