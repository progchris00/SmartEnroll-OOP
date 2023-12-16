using System.Reflection.PortableExecutable;

namespace Itec102
{
    public class Session
    {
        public static string currentUser;
        public static void SetCurrentUser(string username)
        {
            currentUser = username;
        }

        public static string GetCurrentUser()
        {
            return currentUser;
        }

        public static string GetCurrentUserSection(string CurrentUser)
        {
            string[] users = {};
            users = File.ReadAllLines("data/users.csv");

            foreach (var user in users)
            {
                string[] fields = user.Split(',');
                
                if (fields[0] == CurrentUser)
                {
                    string section = fields[7].Trim();
                    return section;
                }
            }
            return null;
        }
        public static string GetCurrentUserRole(string CurrentUser)
        {
            string[] users = {};
            users = File.ReadAllLines("data/users.csv");

            foreach (var user in users)
            {
                string[] fields = user.Split(',');
                
                if (fields[0] == CurrentUser)
                {
                    string role = fields[5].Trim();
                    return role;
                }
            }
            return null;
        }
    }
}