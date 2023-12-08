namespace Itec102
{
    public static class Csv
    {
        public static void Register(List<string> information)
        {
            string filePath = "data/users.csv";

            using (StreamWriter sw = File.AppendText(filePath))
            {
                string HashedPassword = Security.HashPassword(information[3]);

                sw.WriteLine($"{information[0]},{information[1]},{information[2]},{HashedPassword},user,{information[4]},{information[5]}");
            }
        }
    }
}