namespace Itec102
{
    public class SmartEnroll
    {
        static void Main()
        {
            string userState = "Logout";
            string[] choices = { "Login", "Register" };
            string message = "Choose an option: ";
            string status = "Logout";

            var LoginRegisterMenu = new Menu(choices, message, status);

            int indexChoices = LoginRegisterMenu.ShowMenu(userState);

            switch (choices[indexChoices])
            {
                case "Login":
                {
                    Account.Login();
                    break;
                }
                case "Register":
                {
                    Account.Register();
                    break;
                }
            }

        }
    }
}