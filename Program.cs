namespace Itec102
{
    public class SmartEnroll
    {
        static void Main()
        {
            string[] choices = { "Login", "Register" };

            var LoginRegisterMenu = new Menu(choices, "Hello", "Login");

            LoginRegisterMenu.ShowMenu();

        }
    }
}