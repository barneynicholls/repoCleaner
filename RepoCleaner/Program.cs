
namespace RepoCleaner
{
    internal class Program
    {
        private static readonly ConsoleColor _colorInfoTitle = ConsoleColor.Green;
        private static readonly ConsoleColor _colorInfo = ConsoleColor.DarkGreen;
        private static readonly ConsoleColor _colorErrorTitle = ConsoleColor.Red;
        private static readonly ConsoleColor _colorError = ConsoleColor.DarkRed;
        private static readonly ConsoleColor _colorSummaryTitle = ConsoleColor.Yellow;
        private static readonly ConsoleColor _colorSummary = ConsoleColor.DarkYellow;
        private static readonly ConsoleColor _colorExit = ConsoleColor.Cyan;

        private static int _found;
        private static int _deleted;

        static void Main(string[] args)
        {
            var originalForeground = Console.ForegroundColor;
            var originalBackground = Console.BackgroundColor;

            Console.BackgroundColor = ConsoleColor.Black;

            _found = 0;
            _deleted = 0;

            foreach (var arg in args)
            {
                if (Directory.Exists(arg))
                {
                    WriteMessage(
                        "Scanning",
                        _colorSummaryTitle,
                        arg,
                        _colorSummary);

                    DeleteBinAndObjDirectories(arg);
                }
            }

            Console.WriteLine();

            WriteMessage(
                "Directories Deleted",
                _colorSummaryTitle,
                $"{_deleted} / {_found}",
                _colorSummary);

            Console.WriteLine();
            Console.ForegroundColor = _colorExit;
            Console.WriteLine("Any Key to exit");

            Console.ForegroundColor = originalForeground;
            Console.BackgroundColor = originalBackground;

            Console.ReadKey();
        }

        private static void WriteMessage(string title, ConsoleColor titleColor, string message, ConsoleColor messageColor)
        {
            Console.ForegroundColor = titleColor;
            Console.Write($"{title}: ");
            Console.ForegroundColor = messageColor;
            Console.WriteLine(message);
        }

        private static void DeleteBinAndObjDirectories(string path)
        {
            var directories = Directory.GetDirectories(path);
            var hasProj = Directory.GetFiles(path, "*.csproj").Any();

            foreach (var dir in directories)
            {
                var name = Path.GetFileName(dir) ?? string.Empty;

                var buildDir = name.Equals("obj", StringComparison.OrdinalIgnoreCase) || name.Equals("bin", StringComparison.OrdinalIgnoreCase);

                if (hasProj && buildDir)
                {
                    _found++;
                    try
                    {
                        WriteMessage(
                            "Deleting",
                            _colorInfoTitle,
                            dir,
                            _colorInfo);

                        Directory.Delete(dir, true);

                        _deleted++;
                    }
                    catch
                    {
                        WriteMessage(
                            "Failed to Delete",
                            _colorErrorTitle,
                            dir,
                            _colorError);
                    }
                    continue;
                }

                DeleteBinAndObjDirectories(dir);
            }
        }
    }
}