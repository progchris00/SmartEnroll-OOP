namespace Itec102
{
    public class Home
    {
        public static void Load()
        {
            
            string[] choices = { "Schedule", "Logout" };
            string message = "Choose an option: ";
            string status = "Logout";

            string userState = "Login";

            var HomeMenu = new Menu(choices, message, status);
            int indexChoices = HomeMenu.ShowMenu(userState);
            
        while(true)
        {
            switch (choices[indexChoices])
            {
                case "Schedule":
                {
                    schedule_1A.ScheduleA();
                    HomeMenu.ShowMenuUser(userState, status);

                    if (choices.Contains("Logout"))

                       {
                            Load();
                            Console.ReadKey();
                            Message.LogoutSuccess();
                       }
                    
                    break;  
                }
                case "Logout":
                {
                    Message.LogoutSuccess();
                    Console.ReadKey();
                    Account.Login();
                    break;
                }
            }
        }
    }
}
}