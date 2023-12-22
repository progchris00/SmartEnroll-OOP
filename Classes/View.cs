using System.Security.Cryptography.X509Certificates;

namespace Itec102.StudentManagementSystem
{
    public class Views
    {
        public static void User()
        {

            string[] choices = new string[] { "View COR", "Logout" };

            string message = "Choose an option: ";
            string status = "Logout";

            string userState = "Login";

            var HomeMenu = new Menu(choices, message, status);
            int indexChoices = HomeMenu.ShowMenu(userState);

            switch (choices[indexChoices])
            {
                case "View COR":
                {
                    CertifcateOfRegistration.Display("1B");
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

            string[] sectionChoices = new string[] { "All", "BSCS 1-A", "BSCS 1-B" };

            string sectionMessage = "View currently enrolled students";
            string sectionStatus = "Logout";

            string adminState = "Login";

            var Menu = new Menu(sectionChoices, sectionMessage, sectionStatus);
            int indexChoices = Menu.SectionMenu(adminState);

            Choice.Set(sectionChoices[indexChoices]);
            Csv.LoadUsers(Choice.Get());

            string[] adminChoices = new string[] { "View again", "Logout"};

            string adminMessage = "Choose an option:";
            string adminStatus = "Logout";

            var AdminMenu = new Menu(adminChoices, adminMessage, adminStatus);

            int adminChoice = AdminMenu.AdminMenu(adminState);
            string adminSelectedChoice = adminChoices[adminChoice];

            if (adminSelectedChoice == "View again")
            {
                Admin();
            }
            else
            {
                Message.LogoutSuccess();
                Console.ReadKey();
                Application.Run();
            }

        }
    }
}