using System.Text.RegularExpressions;

namespace Itec102.StudentManagementSystem
{
    public class Validate
    {
        public static bool Username(string username)
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
                    if (string.Equals(storedUsername, username, StringComparison.Ordinal))
                    {
                        return true;
                    }
                }
            return false;
        }

        public static bool Password(string user, string password)
        {
            string[] lines = File.ReadAllLines("data/users.csv");

                // Iterate through each line to find the username
                foreach (var line in lines)
                {
                    // Split the line into fields assuming comma (,) as the separator
                    string[] fields = line.Split(',');

                    // Assuming the username is in the first column
                    string storedPassword = fields[4].Trim();
                    string storedUsername = fields[0].Trim();

                    // Compare the stored username with the input username (case-sensitive)
                    if (Security.VerifyPassword(password, storedPassword) && string.Equals(storedUsername, user, StringComparison.Ordinal))
                    {
                        return true;
                    }
                }

            return false;
        }
        public static bool UniqueUsername(string info)
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

        public static string Year()
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

        public static bool Email(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(email);

            return match.Success;
        }

        public static string Section()
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
                else if (char.IsLetter(key.KeyChar))
                {
                    string tempInput = input + key.KeyChar;
                    if (Regex.IsMatch(tempInput, "^[aA-dD]$"))
                    {
                        input = tempInput;
                        Console.Write(char.ToUpper(key.KeyChar));
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
    }
}
