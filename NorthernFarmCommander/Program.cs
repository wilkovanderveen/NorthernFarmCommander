using NorthernFarmCommander.UI.Components;

namespace NorthernFarmCommander
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var panelWidth = Console.WindowWidth / 2;
            var panelHeight = 20;
            var panelBackgroundColor = ConsoleColor.Blue;

            var leftPanel = new Panel(0, 0, panelWidth, panelHeight, panelBackgroundColor, ConsoleColor.DarkBlue);
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

            var table = new Table(panelBackgroundColor, ConsoleColor.Yellow, Console.ForegroundColor, leftPanel.Width, 17);

            table.AddColumn("Name", 42);
            table.AddColumn("Size", 28);
            table.AddColumn("Date", 30);

            table.Draw();

            var tableData = currentDirectory.GetFileSystemInfos();

            Console.SetCursorPosition(1, 2);
            var itemNumber = 1;

            var currentPosition = Console.GetCursorPosition();

            foreach (var item in tableData.Take(17))
            {
                var currentFileSystemInfoDisplayName = item.Name;
                if (currentFileSystemInfoDisplayName.Length > 26)

                    currentFileSystemInfoDisplayName = item.Name.Substring(0, 22) + "...";

                Console.Write(currentFileSystemInfoDisplayName);

                Console.SetCursorPosition(currentPosition.Left + table.Columns.ElementAt(0).Width + 1, currentPosition.Top - 1 + itemNumber);

                if (item is FileInfo fileInfo)
                {
                    var formattedFileSize = fileInfo.Length.ToString("###,###");
                    Console.SetCursorPosition(currentPosition.Left + table.Columns.ElementAt(0).Width + 1 + table.Columns.ElementAt(1).Width + formattedFileSize.Length, currentPosition.Top + itemNumber);
                    
                    Console.Write(formattedFileSize);
                }

                if (item is DirectoryInfo directoryInfo)
                {
                    Console.Write(string.Concat('\u25C4', "SUB-DIRECTORY", '\u25B6'));
                }

                Console.SetCursorPosition(currentPosition.Left + 43, currentPosition.Top + itemNumber - 1);
                Console.Write(item.CreationTime.ToString("dd-MM-yyyy hh:mm"));

                Console.SetCursorPosition(1, currentPosition.Top + itemNumber);

                itemNumber++;
            }

            Console.SetCursorPosition(0, panelHeight + 1);
        }


    }
}