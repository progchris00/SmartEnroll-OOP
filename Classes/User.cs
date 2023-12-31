using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;

namespace Itec102.StudentManagementSystem
{
    public class CurrentUser
    {
        public static void Login()
        {

            var mainBox = new Box(40,5,70,20);
            mainBox.CreateBox();

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
                            Message.LoginSuccess();;
                            Session.SetCurrentUser(username);
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

                    var registrationMenu = new Menu(choices, message, status);

                    int indexChoices = registrationMenu.ShowMenu(userState);

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
            int messageBoxTop = 14;
            int messagePosition = 15;

            var MainBox = new Box(40,5,70,50);
            MainBox.CreateBox();

            List<string> AccountInformation = new List<string> { "Username:", "First Name:", "Last Name:", "Email:", "Password:", "Year:", "Course:", "Section:" };
            List<string> InputInformation = new List<string>();

            int startVertical = 50;
            int startHorizontal = 9;

            int left = 50;
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
                    if (item == "Password:")
                    {
                        info = Inputs.MaskPassword();

                        if (string.IsNullOrEmpty(info))
                        {
                            // Display an error message for an empty password
                            var EmptyPasswordBox = new Box(56, messageBoxTop, 40, 3);
                            EmptyPasswordBox.CreateBox();
                            Console.SetCursorPosition(58, messagePosition);
                            Console.WriteLine("Password cannot be empty, try again.");

                            // Move the cursor to the password input position
                            Console.SetCursorPosition(startVertical + 2, startHorizontal + 1);
                        }

                        else if(info.Count() < 8)
                        {
                            var WeakPasswordBox = new Box(56, messageBoxTop, 40, 3);
                            WeakPasswordBox.CreateBox();
                            Console.SetCursorPosition(59, messagePosition);
                            Console.WriteLine("Please create a stronger password.");

                            InfoBox.CreateBox();
                            // Move the cursor to the password input position
                            Console.SetCursorPosition(startVertical + 2, startHorizontal + 1);
                        }

                        else
                        {
                            // Add the password to the list and exit the loop
                            InputInformation.Add(info);
                            break;
                        }
                    }

                    else if(item == "Year:")
                    {
                        info = Validate.Year();
                    }

                    else if(item == "Section:")
                    {
                        info = Validate.Section();
                    }

                    else
                    {
                        // For other inputs (non-password)
                        info = Console.ReadLine().Trim(); // Trim to remove leading and trailing whitespaces

                        if (string.IsNullOrEmpty(info))
                        {
                            var EmptyInput = new Box(55, messageBoxTop, 39, 3);
                            EmptyInput.CreateBox();
                            Console.SetCursorPosition(58, messagePosition);
                            Console.WriteLine("Input cannot be empty, try again.");

                            Console.SetCursorPosition(startVertical + 2, startHorizontal + 1);
                        }
                        else if (item == "Username:" && Validate.UniqueUsername(info))
                        {
                            var UsedUsername = new Box(55, messageBoxTop, 39, 3);
                            UsedUsername.CreateBox();
                            Console.SetCursorPosition(63, messagePosition);
                            Console.WriteLine("Username already in use.");

                            InfoBox.CreateBox();
                            Console.SetCursorPosition(startVertical + 2, startHorizontal + 1);
                        }

                        else if (item == "Email:" && !Validate.Email(info))
                        {
                            var InvalidEmailBox = new Box(55, messageBoxTop, 39, 3);
                            InvalidEmailBox.CreateBox();
                            Console.SetCursorPosition(61, messagePosition);
                            Console.WriteLine("Please enter a valid email.");

                            InfoBox.CreateBox();
                            Console.SetCursorPosition(startVertical + 2, startHorizontal + 1);
                        }
                    }

                } while (string.IsNullOrEmpty(info) || (item == "Username:" && Validate.UniqueUsername(info)) || (item == "Password:") && (info.Count() < 8) || item == "Email:" && !Validate.Email(info));

                if(item != "Password:")
                {
                    InputInformation.Add(info);
                }

                startHorizontal += 5;
                messageBoxTop += 5;
                messagePosition += 5;
                top += 5;
            }

            Message.RegistrationSuccess();
            Csv.Register(InputInformation);

            Application.Run("re-login");
        }

        public static void UpdateStatus(string decision, string currentEnrollee)
        {
            string status = "pending";

            string filePath = "data/users.csv";

            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values.Length > 9 && values[9] == status && values[0] == currentEnrollee)
                    {
                        values[9] = decision;
                    }

                    string updatedLine = string.Join(",", values);
                    lines.Add(updatedLine);
                }
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}