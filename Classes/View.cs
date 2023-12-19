using System.Security.Cryptography.X509Certificates;

namespace Itec102
{
    public class Views
    {
        public static void User()
        {

            string[] choices = new string[] { "Schedule", "Logout" };

            string message = "Choose an option: ";
            string status = "Logout";

            string userState = "Login";

            var HomeMenu = new Menu(choices, message, status);
            int indexChoices = HomeMenu.ShowMenu(userState);

            switch (choices[indexChoices])
            {
                case "Schedule":
                {
                    CertifcateOfRegistration.Display("1A");
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

        public static void Admin()
        {

            string[] choices = new string[] { "All", "BSCS 1-A", "BSCS 1-B" };

            string message = "View currently enrolled students";
            string status = "Logout";

            string userState = "Login";

            var Menu = new Menu(choices, message, status);
            int indexChoices = Menu.AdminMenu(userState);

            string selectedChoice = choices[indexChoices];
            Csv.LoadUsers(selectedChoice);
        }
    }
}