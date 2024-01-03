namespace Itec102.StudentManagementSystem
{
    public class Status
    {
        public static void Display(string userStatus)
        {
            if (userStatus == "enrolled")
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
                        string currentUser = Session.GetCurrentUser();
                        string currentUserYear = Session.GetCurrentUserYear(currentUser);
                        string currentUserSection = Session.GetCurrentUserSection(currentUser);

                        CertifcateOfRegistration.Display(currentUserYear, currentUserSection);
                        break;  
                    }

                    case "Logout":
                    {
                        Message.LogoutSuccess();
                        Console.ReadKey();
                        Application.Run("re-login");
                        break;
                    }
                }
            }

            else if (userStatus == "pending")
            {
                Message.Pending();
                Application.Run("re-login");
            }

            else if (userStatus == "rejected")
            {
                Message.Rejected();
                Application.Run("re-login");
            }
        }
    }
}