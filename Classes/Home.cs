using System.ComponentModel.Design;
using System.Runtime;
using Figgle;

namespace Itec102.StudentManagementSystem
{
    public class Home
    {

        public static void Load()
        {
            string CurrentUser = Session.GetCurrentUser();
            string CurrentUserRole = Session.GetCurrentUserRole(CurrentUser);

            if (CurrentUserRole == "admin")
            {
                Views.Admin();
            }
            else if (CurrentUserRole == "user")
            {
                Views.User();
            }
        }
    }
}