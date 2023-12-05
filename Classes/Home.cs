namespace Itec102
{
    public class Home
    {
        public static void Load()
        {
            string[] choices = { "Schedule", "Logout" };
            string message = "Choose option: ";
            string status = "Logout";

            string userState = "Login";

            var HomeMenu = new Menu(choices, message, status);
            HomeMenu.ShowMenu(userState);
        }
    }
}