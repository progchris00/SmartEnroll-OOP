using System.Diagnostics.Tracing;

namespace Itec102.StudentManagementSystem
{
    public class Profile
    {
        public static void Load(string role)
        {
            string[] lines = File.ReadAllLines("data/users.csv");

            string[] fields = null;

            string CurrentUser = Session.GetCurrentUser();

            // Iterate through each line to find the username
            foreach (var line in lines)
            {
                // Split the line into fields assuming comma (,) as the separator
                fields = line.Split(',');

                // Assuming the username is in the first column
                string storedUsername = fields[0].Trim();
                
                if (storedUsername.Equals(CurrentUser, StringComparison.OrdinalIgnoreCase))
                {
                    // If the username is found, exit the loop
                    break;
                }
            }

            var ProfileBox = new Box(112, 7, 45, 15);
            ProfileBox.CreateBox();

            Console.SetCursorPosition(116, 9);
            Console.WriteLine($"Hello, {fields[0]}");

            Console.SetCursorPosition(116, 12);
            Console.WriteLine($"Name: {fields[1]} {fields[2]}");

            Console.SetCursorPosition(116, 14);
            Console.WriteLine($"Year: {fields[6]}st year");

            Console.SetCursorPosition(116, 16);
            Console.WriteLine($"Course: {fields[7]} - {fields[6]}{fields[8]}");
        }
    }
}