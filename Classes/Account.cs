using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

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
            int messageBoxTop = 14;
            int messagePosition = 15;

            var MainBox = new Box(40,5,70,50);
            MainBox.CreateBox();

            List<string> AccountInformation = new List<string> { "Username:", "First Name:", "Last Name:", "Email:", "Password:", "Year:", "Course:", "Section:" };
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
                    if (item == "Password:")
                    {
                        info = Inputs.MaskPassword();

                        if (string.IsNullOrEmpty(info))
                        {
                            // Display an error message for an empty password
                            var EmptyPasswordBox = new Box(56, messageBoxTop, 39, 3);
                            EmptyPasswordBox.CreateBox();
                            Console.SetCursorPosition(58, messagePosition);
                            Console.WriteLine("Password cannot be empty, try again.");

                            // Move the cursor to the password input position
                            Console.SetCursorPosition(startVertical + 2, startHorizontal + 1);
                        }

                        else if(info.Count() < 8)
                        {
                            var WeakPasswordBox = new Box(58, messageBoxTop, 38, 3);
                            WeakPasswordBox.CreateBox();
                            Console.SetCursorPosition(60, messagePosition);
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
                        info = ValidateYear();
                    }

                    else
                    {
                        // For other inputs (non-password)
                        info = Console.ReadLine().Trim(); // Trim to remove leading and trailing whitespaces

                        if (string.IsNullOrEmpty(info))
                        {
                            var EmptyInput = new Box(59, messageBoxTop, 35, 3);
                            EmptyInput.CreateBox();
                            Console.SetCursorPosition(60, messagePosition);
                            Console.WriteLine("Input cannot be empty, try again.");

                            Console.SetCursorPosition(startVertical + 2, startHorizontal + 1);
                        }
                        else if (item == "Username:" && CheckforDuplicate(info))
                        {
                            var UsedUsername = new Box(59, messageBoxTop, 35, 3);
                            UsedUsername.CreateBox();
                            Console.SetCursorPosition(64, messagePosition);
                            Console.WriteLine("Username already in use.");

                            InfoBox.CreateBox();
                            Console.SetCursorPosition(startVertical + 2, startHorizontal + 1);
                        }

                        else if (item == "Email:" && !ValidateEmail(info))
                        {
                            var InvalidEmailBox = new Box(59, messageBoxTop, 35, 3);
                            InvalidEmailBox.CreateBox();
                            Console.SetCursorPosition(63, messagePosition);
                            Console.WriteLine("Please enter a valid email.");

                            InfoBox.CreateBox();
                            Console.SetCursorPosition(startVertical + 2, startHorizontal + 1);
                        }
                    }

                } while (string.IsNullOrEmpty(info) || (item == "Username:" && CheckforDuplicate(info)) || (item == "Password:") && (info.Count() < 8) || item == "Email:" && !ValidateEmail(info));

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

            Application.Run();
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

        public static string ValidateYear()
        {
            string input = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        input = input.Substring(0, input.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (char.IsDigit(key.KeyChar))
                {
                    string tempInput = input + key.KeyChar;
                    if (Regex.IsMatch(tempInput, "^[1-4]$"))
                    {
                        input = tempInput;
                        Console.Write(key.KeyChar);
                    }
                    else
                    {
                        Console.Beep();
                    }
                }
                else
                {
                    Console.Beep();
                }
            }
            return input;
        }

        public static bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(email);

            return match.Success;
        }
    }
}