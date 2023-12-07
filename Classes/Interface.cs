namespace Itec102
{
    public class Application
    {
        public static void Run()
        {
            string userState = "Logout";
            string[] choices = { "Login", "Register" };
            string message = "Choose an option: ";
            string status = "Logout";

            var LoginRegisterMenu = new Menu(choices, message, status);

            int indexChoices = LoginRegisterMenu.ShowMenu(userState);

            Action.HandleAction(choices[indexChoices]);
        }
    }
}