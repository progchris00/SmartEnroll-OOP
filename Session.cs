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
    }
}