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

                string username = Inputs.Login_Username();

                if (Validate.Username(username))
                {
                    while (true)
                    {
                        Console.SetCursorPosition(50,12);
                        Console.WriteLine("Password: ");

                        string password = Inputs.Login_Password();

                        if (Validate.Password(username, password))
                        {
                            Console.WriteLine("password correct");
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

                else
                {
                    var MainBox = new Box(40,5,70,20);

                    string[] choices = { "Yes", "No" };
                    string message = "Register account?";
                    string status = "Logout";

                    var RegOrLogMenu = new Menu(choices, message, status);

                    int indexChoices = RegOrLogMenu.Reg_Log_Menu();

                    switch (choices[indexChoices])
                    {
                        
                        case "Yes":
                        {
                            MainBox.CreateBox();
                            Register();
                            break;
                        }
                        case "No":
                        {
                            continue;
                        }
                    }
                }
            }
        }

        public static List<string> Register()
        {
            List<string> AccountInformation = new List<string> { "Username:", "First Name:", "Last Name:", "Password:", "Year:", "Course:" };
            List<string> InputInformation = new List<string>();

            int startVertical = 53;
            int startHorizontal = 9;

            int left = 53;
            int top = 8;

            foreach (var item in AccountInformation)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine(item);

                var InfoBox = new Box(startVertical, startHorizontal, 50, 3);
                InfoBox.CreateBox();

                Console.SetCursorPosition(startVertical + 2, startHorizontal + 1);
                string info;

                do
                {
                    info = Console.ReadLine().Trim(); // Trim to remove leading and trailing whitespaces
                    if (string.IsNullOrEmpty(info))
                    {
                        Console.WriteLine("Input cannot be empty. Please enter again.");
                        Console.SetCursorPosition(startVertical + 2, startHorizontal + 1);
                    }
                } while (string.IsNullOrEmpty(info));

                InputInformation.Add(info);

                startHorizontal += 5;
                top += 5;
            }

            return InputInformation;
        }
    }
}