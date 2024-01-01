using System.Security.Cryptography.X509Certificates;

namespace Itec102.StudentManagementSystem
{
    public class Views
    {
        public static void User()
        {
            string currentUser = Session.GetCurrentUser();
            string currentUserStatus = Session.GetCurrentUserStatus(currentUser);

            Status.Display(currentUserStatus);
        }

        public static void Admin()
        {
            string[] adminMenuChoices = new string[] { "View Enrolled Students", "View Pending Enrollees", "Logout" };

            string adminMenuMessage = "Choose an option";
            string adminMenuStatus = "Logout";

            string adminMenuState = "Login";

            var adminMenu = new Menu(adminMenuChoices, adminMenuMessage, adminMenuStatus);
            int adminIndexChoices = adminMenu.SectionMenu(adminMenuState);

            switch (adminMenuChoices[adminIndexChoices])
            {
                case "View Enrolled Students":
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
            break;
                
            }

            

        }
    }
}