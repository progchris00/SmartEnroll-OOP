namespace Itec102
{
    public class Profile
    {
        public static void Load(string current_user)
        {
            var ProfileBox = new Box(112, 7, 45, 15);
            ProfileBox.CreateBox();

            Console.SetCursorPosition(116, 9);
            Console.WriteLine("Hello, xxchrisxx");

            Console.SetCursorPosition(116, 12);
            Console.WriteLine("Name: Christian Ortiz");

            Console.SetCursorPosition(116, 14);
            Console.WriteLine("Year: 1st year");

            Console.SetCursorPosition(116, 16);
            Console.WriteLine("Course: BSCS - 1B");
        }
    }
}