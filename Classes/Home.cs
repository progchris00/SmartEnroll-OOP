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
            int indexChoices = HomeMenu.ShowMenu(userState);

            switch (choices[indexChoices])
            {
                case "Schedule":
                {
                    break;
                }
                case "Logout":
                {
                    Message.LogoutSuccess();
                    Console.ReadKey();
                    Account.Login();
                    break;
                }
            }
        }
    }
}