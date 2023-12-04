namespace Itec102
{
    public class Interface
    {
        public static void Load()
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