namespace Itec102
{
    public class Box
    {
        private int startVertical;
        private int startHorizontal;
        private int width;
        private int height;

        public Box(int startVertical, int startHorizontal, int width, int height)
        {
            this.startVertical = startVertical;
            this.startHorizontal = startHorizontal;
            this.width = width;
            this.height = height;
        }
        public void CreateBox()
        {
            // For Top Border
            Console.SetCursorPosition(startVertical, startHorizontal);
            Console.Write("┌" + new string('─', width - 2) + "┐");

            // Loop For Middle Border
            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(startVertical, startHorizontal + i);
                Console.Write("│" + new string(' ', width - 2) + "│");
            }

            // For Bottom Border
            Console.SetCursorPosition(startVertical, startHorizontal + height - 1);
            Console.Write("└" + new string('─', width - 2) + "┘");
            
        }
    }
}