namespace Itec102.StudentManagementSystem
{
    public static class Action
    {
        public static void Handle(string choice)
        {
            switch (choice)
            {
                case "Login":
                    User.Login();
                    break;
                case "Register":
                    User.Register();
                    break;
            }
        }
    }
}