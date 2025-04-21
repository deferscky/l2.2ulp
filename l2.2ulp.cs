using System;
using System.IO;

class Program
{
    static void Main()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        int fileCount = 1;

        Console.WriteLine("Вводите строки. Для завершения нажмите ESC.\n");

        while (true)
        {
            Console.Write($"Строка {fileCount}: ");
            string input = ReadLineWithEscape();

            if (input == null) // Если нажат ESC
            {
                Console.WriteLine("\nЗавершение работы...");
                break;
            }

            string filePath = Path.Combine(desktopPath, $"file{fileCount}.txt");
            File.WriteAllText(filePath, input);
            fileCount++;
        }
    }

    static string ReadLineWithEscape()
    {
        string input = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                return null;
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                {
                    input = input.Remove(input.Length - 1);
                    Console.Write("\b \b");
                }
            }
            else if (key.Key != ConsoleKey.Enter)
            {
                input += key.KeyChar;
                Console.Write(key.KeyChar);
            }

        } while (key.Key != ConsoleKey.Enter);

        return input;
    }
}
