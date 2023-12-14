using System.Globalization;

namespace Itec102
{
    public static class Csv
    {
        public static void Register(List<string> information)
        {
        TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            string filePath = "data/users.csv";

            using (StreamWriter sw = File.AppendText(filePath))
            {
                string HashedPassword = Security.HashPassword(information[3]);

                sw.WriteLine($"{information[0]},{myTI.ToTitleCase(information[1])},{myTI.ToTitleCase(information[2])},{HashedPassword},user,{information[4]},{information[5].ToUpper()},{information[6].ToUpper()}");
            }
        }
    }
}