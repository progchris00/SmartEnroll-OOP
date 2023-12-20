namespace Itec102.StudentManagementSystem
{
    public class Animate
    {
        public static void ProgressBar()
        {
            Console.SetCursorPosition(45, 5 + 11 + 2);

            Console.Write(" Progress: [ ");
            int progressBarLength = 40; // Adjusted for the box borders
            int totalSteps = 50; // Adjust the total number of steps for the animation
            int sleepTime = 10; // Adjust the sleep time between updates (milliseconds)

            for (int currentStep = 1; currentStep <= totalSteps; currentStep++)
            {
                int progress = (int)((double)currentStep / totalSteps * progressBarLength);

                Console.SetCursorPosition(45 + 12, 5 + 11 + 2);
                for (int i = 0; i < progressBarLength; i++)
                {
                    if (i < progress)

                        Console.Write(".");
                    else
                        Console.Write(" ");
                }

                Console.Write($" ] {currentStep}/{totalSteps + " "}");

                Thread.Sleep(sleepTime);
            }
        }
    }
}