namespace NorthernFarmCommander.UI.Components
{
    public class Panel
    {
        public Panel(int left, int top, int width, int height, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
        }

        public int Left { get; }
        public int Top { get; }
        public int Width { get; }
        public int Height { get; }
        public ConsoleColor BackgroundColor { get; }
        public ConsoleColor ForegroundColor { get; }

        public void Draw()
        {
            Console.BackgroundColor = BackgroundColor;

            Console.Write(BorderConstants.TopLeft);
            Console.Write(string.Concat(Enumerable.Repeat(BorderConstants.HorizontalDoubleLine, Width - 1)));
            Console.Write(BorderConstants.TopRight);

            for (int y = 1; y < Height - 2; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(BorderConstants.VerticalDoubleLine);
                Console.Write(string.Concat(Enumerable.Repeat(' ', Width - 1)));
                Console.Write(BorderConstants.VerticalDoubleLine);
            }

            Console.SetCursorPosition(0, Height - 2);
            Console.Write(BorderConstants.VerticalDoubleLine);
            Console.Write(string.Concat(Enumerable.Repeat(BorderConstants.HorizontalSingleLine, Width - 1)));
            Console.Write(BorderConstants.VerticalDoubleLine);

            Console.SetCursorPosition(0, Height - 1);
            Console.Write(BorderConstants.VerticalDoubleLine);
            Console.Write(string.Concat(Enumerable.Repeat(' ', Width - 1)));
            Console.Write(BorderConstants.VerticalDoubleLine);

            Console.SetCursorPosition(0, Height);
            Console.Write(BorderConstants.BottomLeft);
            Console.Write(string.Concat(Enumerable.Repeat(BorderConstants.HorizontalDoubleLine, Width - 1)));
            Console.Write(BorderConstants.BottomRight);
        }
    }
}