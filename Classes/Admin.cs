using System.Security.Cryptography.X509Certificates;

namespace Itec102.StudentManagementSystem
{
    public class AdminOption
    {
        public static void Enrolled()
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
                Enrolled();
            }
            else
            {
                Message.LogoutSuccess();
                Console.ReadKey();
                Application.Run();
            }
        } 

        public static void Pending()
        {
            Console.WriteLine("Working");
        }
    }
}