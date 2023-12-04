using Figgle;

namespace Itec102
{
    public class Menu
    {
        private string[] choices;
        private string message;
        private string status;

        public Menu(string[] choices, string message, string status)
        {
            this.choices = choices;
            this.message = message;
            this.status = status;
        }
        public int ShowMenu(string userState)
        {
            var MainBox = new Box(40,5,70,20);
            var LeftBox = new Box(0,7,38,8);

            int selectedIndex = 0;
            ConsoleKeyInfo keyInfo;
            
            do
            {
                Console.Clear();
                Console.WriteLine(FiggleFonts.Standard.Render("                                              SmartEnroll"));

                MainBox.CreateBox();
                // Draw the box on the left side
                LeftBox.CreateBox();
                
                if (userState == "UserNotFound")
                {
                    Message.UsernameNotFound();
                }

                // Print the message inside the box
                Console.SetCursorPosition(2, 9);
                Console.WriteLine(message);

                // Print the choices inside the box
                for (int i = 0; i < choices.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    }

                    // Print each choice inside the box
                    Console.SetCursorPosition(2, 11 + i);
                    Console.WriteLine(choices[i]);

                    Console.ResetColor();
                }

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow && selectedIndex > 0)
                    {
                        selectedIndex--;
                    }

                else if (keyInfo.Key == ConsoleKey.DownArrow && selectedIndex < choices.Length - 1)
                    {
                        selectedIndex++;
                    }

            } while (keyInfo.Key != ConsoleKey.Enter);

        return selectedIndex;
        }
    }
}