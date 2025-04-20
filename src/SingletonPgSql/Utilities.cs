using System;

internal static class Utilities
{
		internal static void SetTitle(string title)
        {
			Console.WriteLine();
            Console.WriteLine("=====================================================");
            Console.WriteLine("\t" + title);
            Console.WriteLine("=====================================================");
			Console.WriteLine();
        }
        
        internal static void ShowMenu(string title)
        {
            ShowMenu(title, null);
        }

        internal static void ShowMenu(String title, string[] collection)
        {
            Console.Clear();

            int width = Console.WindowWidth - 4;
            int i = 0;
            Console.WriteLine("+" + new string('-', width - 2) + "+");
            Console.WriteLine("|" + CenterText(title, width - 2) + "|");
            Console.WriteLine("|" + new string(' ', width - 2) + "|");
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    i++;
                    Console.WriteLine("| " + AlignLeftText(i + ")  " + item, width - 3) + "|");
                }
                Console.WriteLine("| " + AlignLeftText("0. Exit", width - 3) + "|");
            }
            Console.WriteLine("|" + new string(' ', width - 2) + "|");
            Console.WriteLine("+" + new string('-', width - 2) + "+");
        }

        internal static void PrintLabel(string label, string value)
        {
            Console.WriteLine("\t{0}\t{1}",label,value);
        }

        internal static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress [Enter] to continue...");
            Console.ReadLine();
        }

        internal static void PrintMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine("\t========================================\n");
            Console.WriteLine("\t" + message);
            Console.WriteLine("\t========================================\n");
            Console.WriteLine();
        }
#region Private Members
        static string CenterText(string text, int width)
        {
            if (text.Length >= width)
                return text.Substring(0, width); // Truncate if text is longer than width

            int spaces = width - text.Length;
            int padLeft = spaces / 2;
            int padRight = spaces - padLeft;

            return new string(' ', padLeft) + text + new string(' ', padRight);
        }

        static string AlignLeftText(string text, int width)
        {
            if (text.Length >= width)
                return text.Substring(0, width); // Truncate if text is longer than width

            int spaces = width - text.Length;
            return text + new string(' ', spaces);
        }

        internal static int? ReadLineAsInt()
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || input.Length == 0)
                return null;
            else
                return Convert.ToInt32(input);
        }

        internal static string Scanf(string message)
        {
            Console.Write("\t[ " + message + " ]\t");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || input.Length == 0)
                return null;
            return input;
        }
#endregion

} //end class
