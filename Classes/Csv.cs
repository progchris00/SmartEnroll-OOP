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
                string HashedPassword = Security.HashPassword(information[4]);

                sw.WriteLine($"{information[0]},{myTI.ToTitleCase(information[1])},{myTI.ToTitleCase(information[2])},{information[3]},{HashedPassword},user,{information[5]},{information[6].ToUpper()},{information[7].ToUpper()}");
            }
        }
    }
}