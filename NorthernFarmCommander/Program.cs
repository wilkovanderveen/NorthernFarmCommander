using System.Drawing;

namespace NorthernFarmCommander
{
    public class BorderConstants
    {
        public const char TopLeft = '\u2554';
        public const char HorizontalDoubleLine = '\u2550';
        public const char HorizontalSingleLine = '\u2500';
        public const char TopRight = '\u2557';
        public const char VerticalDoubleLine = '\u2551';
        public const char RightConnectedHorizonalLine = '\u2562';
        public const char LeftConnectedHorizonalLine = '\u255F';
        public const char BottomLeft = '\u255A';
        public const char BottomRight = '\u255D';
    }

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

    internal class Program
    {
        static void Main(string[] args)
        {
            var panelWidth = Console.WindowWidth / 2;
            var panelHeight = 20;

            var leftPanel = new Panel(0, 0, panelWidth, panelHeight, ConsoleColor.Blue, ConsoleColor.DarkBlue);
            leftPanel.Draw();

            var currentFolderDisplayName = Directory.GetCurrentDirectory();
            var currentDirectory = new DirectoryInfo(currentFolderDisplayName);
            var currenDrive = new DriveInfo(currentDirectory.Root.FullName);

            if (currentFolderDisplayName.Length > panelWidth - 4)
            {
                currentFolderDisplayName = currentFolderDisplayName.Substring(0, panelWidth - 7) + "...";
            }

            var folderNameLeft = (panelWidth / 2) - (currentFolderDisplayName.Length / 2);
            Console.SetCursorPosition(folderNameLeft, 0);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write(currentFolderDisplayName);

            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            // Write columns

            Console.SetCursorPosition(0, panelHeight + 1);
        }
    }
}