using System.Reflection.PortableExecutable;

namespace Itec102.StudentManagementSystem
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
                    string section = fields[8].Trim();
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
        public static string GetCurrentUserYear(string CurrentUser)
        {
            string[] users = {};
            users = File.ReadAllLines("data/users.csv");

            foreach (var user in users)
            {
                string[] fields = user.Split(',');
                
                if (fields[0] == CurrentUser)
                {
                    string year = fields[6].Trim();
                    return year;
                }
            }
            return null;
        }
        public static string GetCurrentUserStatus(string CurrentUser)
        {
            string[] users = {};
            users = File.ReadAllLines("data/users.csv");

            foreach (var user in users)
            {
                string[] fields = user.Split(',');
                
                if (fields[0] == CurrentUser)
                {
                    string status = fields[9].Trim();
                    return status;
                }
            }
            return null;
        }
    }
}