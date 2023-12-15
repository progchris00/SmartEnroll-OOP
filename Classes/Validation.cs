namespace Itec102
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
    }
}