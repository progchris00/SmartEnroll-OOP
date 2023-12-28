using System.Globalization;
using Figgle;


namespace Itec102.StudentManagementSystem
{
    public static class Csv
    {
        public static void Register(List<string> information)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            string filePath = "data/users.csv";

            using (StreamWriter sw = File.AppendText(filePath))
            {
                string HashedPassword = Security.HashPassword(information[4]);

                sw.WriteLine($"{information[0]},{myTI.ToTitleCase(information[1])},{myTI.ToTitleCase(information[2])},{information[3]},{HashedPassword},user,{information[5]},{information[6].ToUpper()},{information[7].ToUpper()}");
            }
        }

        public static void LoadUsers(string selectedChoice)
        {
            Console.Clear();
            
            Console.WriteLine(FiggleFonts.Standard.Render("                                             SmartEnroll"));
            var mainBox = new Box(40,5,70,20);
            mainBox.CreateBox();

            Date.DisplayToday();

            string[] lines = File.ReadAllLines("data/users.csv");

            int top = 13;
            
            Console.SetCursorPosition(56, 10); 
            Console.WriteLine("User\t\t\t\tSection");

            foreach (var line in lines)
            {
                string[] fields = line.Split(',');

                string role = fields[5].Trim();

                if (role == "admin")
                {
                    break;
                }

                string section = fields[8].Trim();
                string firstname = fields[1].Trim();
                string lastname = fields[2].Trim();
                string course = fields[7].Trim();
                string year = fields[6].Trim();

                string sectionCourse = $"{course} {year}-{section}";

                string fullname = $"{lastname}, {firstname}";

                if (selectedChoice == "All")
                {
                    if (role == "user")
                    {
                        Console.SetCursorPosition(52, top); 
                        Console.WriteLine($"{fullname, -20}\t\t{course} - {year}{section}");

                        top += 2;
                    }
                }

                else
                {
                    if (role == "user" && sectionCourse == selectedChoice)
                    {
                        Console.SetCursorPosition(52, top); 
                        Console.WriteLine($"{fullname, -20}\t\t{course} - {year}{section}");

                        top += 2;
                    }
                }
            }
        }
    }
}