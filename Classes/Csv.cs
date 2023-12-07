namespace Itec102
{
    public static class Csv
    {
        public static void Register(List<string> information)
        {
            string filePath = "data/users.csv";

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{information[0]},{information[1]},{information[2]},{information[3]},user,{information[4]},{information[5]}");
            }
        }
    }
}