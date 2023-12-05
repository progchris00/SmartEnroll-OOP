using System.Net.NetworkInformation;

namespace Itec102
{
    public class Account
    {
        public static void Login()
        {
            var MainBox = new Box(40,5,70,20);
            MainBox.CreateBox();
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
                            Animate.ProgressBar();
                            Message.LoginSuccess();
                            Home.Load();

                            break;
                        }

                        else
                        {   
                            Animate.ProgressBar();
                            Message.IncorrectPassword();
                            continue;
                        }
                    }
                }

                else
                {
                    string userState = "UserNotFound";

                    string[] choices = { "No", "Yes" };
                    string message = "Register account?";
                    string status = "Logout";

                    var RegistrationMenu = new Menu(choices, message, status);

                    int indexChoices = RegistrationMenu.ShowMenu(userState);

                    switch (choices[indexChoices])
                    {
                        
                        case "Yes":
                        {
                            Register();
                            break;
                        }
                        case "No":
                        {
                            Login();
                            break;
                        }
                    }
                }
                break;
            }
        }

        public static void Register()
        {
            var MainBox = new Box(40,5,70,20);
            MainBox.CreateBox();

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

                    else if (item == "Username:" && CheckforDuplicate(info))
                    {
                        Console.WriteLine("Username unavailable. Please choose a different username.");
                        InfoBox.CreateBox();
                        Console.SetCursorPosition(startVertical + 2, startHorizontal + 1);
                    }

                } while (string.IsNullOrEmpty(info) || (item == "Username:" && CheckforDuplicate(info)));

                InputInformation.Add(info);

                startHorizontal += 5;
                top += 5;
            }

            Message.RegistrationSuccess();
            Csv.Register(InputInformation);

            Interface.Load();
        }

        public static bool CheckforDuplicate(string info)
        {
            string[] lines = File.ReadAllLines("data/users.csv");

                // Iterate through each line to find the username
                foreach (var line in lines)
                {
                    // Split the line into fields assuming comma (,) as the separator
                    string[] fields = line.Split(',');

                    // Assuming the username is in the first column
                    string storedUsername = fields[0].Trim();

                    // Compare the stored username with the input username (case-sensitive)
                    if (string.Equals(storedUsername, info, StringComparison.Ordinal))
                    {
                        return true;
                    }
                }
            return false;
        }
    }
}