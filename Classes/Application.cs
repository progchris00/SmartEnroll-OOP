using System.Speech.Synthesis;

namespace Itec102.StudentManagementSystem
{
    public class Application
    {
        public static void Run()
        {
            // Speak("Welcome to SmartEnroll.");

            string userState = "Logout";
            string[] choices = { "Login", "Register" };
            string message = "Choose an option: ";
            string status = "Logout";

            var LoginRegisterMenu = new Menu(choices, message, status);

            int indexChoices = LoginRegisterMenu.ShowMenu(userState);

            Action.Handle(choices[indexChoices]);
        }
    }
}