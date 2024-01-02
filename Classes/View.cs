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
            string[] adminHomeMenuChoices = new string[] { "View Enrolled Students", "Review Pending Enrollees", "Sign Out" };

            string adminHomeMenuMessage = "Choose an option";
            string adminStatus = "Logout";

            string adminState = "Login";

            var adminHomeMenu = new Menu(adminHomeMenuChoices, adminHomeMenuMessage, adminStatus);
            int adminHomeMenuIndex = adminHomeMenu.SectionMenu(adminState);

            switch (adminHomeMenuChoices[adminHomeMenuIndex])
            {
                case "View Enrolled Students":
                AdminOption.Enrolled();
                break;

                case "Review Pending Enrollees":
                AdminOption.Pending();
                break;

                case "Sign Out":
                Application.Run();
                break;
            }
        }
    }
}