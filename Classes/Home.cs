using System.Runtime;

namespace Itec102
{
    public class Home
    {
        public static void Load()
        {

            string[] choices = { "Schedule", "Logout" };
            string message = "Choose an option: ";
            string status = "Logout";

            string userState = "Login";

            var HomeMenu = new Menu(choices, message, status);
            int indexChoices = HomeMenu.ShowMenu(userState);

            switch (choices[indexChoices])
            {
                case "Schedule":
                {
                    Schedule.Show("1A");
                    break;  
                }

                case "Logout":
                {
                    Message.LogoutSuccess();
                    Console.ReadKey();

                    Application.Run();

                    break;
                }
            }
        }
    }
}