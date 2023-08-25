using NorthernFarmCommander.UI.Components;

namespace NorthernFarmCommander
{
    public class Column
    {
        public Column(string name, int width, int height, ConsoleColor backgroundColor, ConsoleColor titleColor, ConsoleColor foregroundColor)
        {
            Name = name;
            Width = width;
            Height = height;
            BackgroundColor = backgroundColor;
            TitleColor = titleColor;
            ForegroundColor = foregroundColor;
        }

        public string Name { get; }
        public int Width { get; }
        public int Height { get; }
       
        public ConsoleColor BackgroundColor { get; }
        public ConsoleColor TitleColor { get; }
        public ConsoleColor ForegroundColor { get; }

        public void Draw(bool drawSeparator = true)
        {           
            Console.BackgroundColor = BackgroundColor; 
            Console.ForegroundColor = TitleColor;

            var oldPosition = Console.GetCursorPosition();
            var left = Console.GetCursorPosition().Left + Width;
            Console.SetCursorPosition(left, Console.GetCursorPosition().Top);

            if (drawSeparator)
                Console.Write(BorderConstants.VerticalSingleLine);

            Console.SetCursorPosition(oldPosition.Left, Console.GetCursorPosition().Top);
            var nameLeft = Console.GetCursorPosition().Left + (Width / 2) - (Name.Length / 2);
            Console.SetCursorPosition(nameLeft, Console.GetCursorPosition().Top);
            Console.Write(Name);
            Console.SetCursorPosition(left, Console.GetCursorPosition().Top);

            if (drawSeparator)
            {
                for (int y = 1; y < Height; y++)
                {
                    Console.SetCursorPosition(left, y + 1);
                    Console.Write(BorderConstants.VerticalSingleLine);
                }
            }
           
            Console.SetCursorPosition(left, oldPosition.Top);


        }

    }
}