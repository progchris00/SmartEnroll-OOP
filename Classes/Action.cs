namespace Itec102
{
    public static class Action
    {
        public static void HandleAction(string choice)
        {
            switch (choice)
            {
                case "Login":
                    Account.Login();
                    break;
                case "Register":
                    Account.Register();
                    break;
            }
        }
    }
}