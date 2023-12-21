namespace Itec102.StudentManagementSystem
{
    public static class Action
    {
        public static void Handle(string choice)
        {
            switch (choice)
            {
                case "Login":
                    CurrentUser.Login();
                    break;
                case "Register":
                    CurrentUser.Register();
                    break;
            }
        }
    }
}