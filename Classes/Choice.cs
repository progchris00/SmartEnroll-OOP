using System.Reflection.PortableExecutable;

namespace Itec102.StudentManagementSystem
{
    public class Choice
    {
        public static string selecetedChoice;
        public static void Set(string choice)
        {
            selecetedChoice = choice;
        }

        public static string Get()
        {
            return selecetedChoice;
        }
    }
}