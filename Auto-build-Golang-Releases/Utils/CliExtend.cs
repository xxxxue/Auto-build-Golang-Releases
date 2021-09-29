using System;

namespace Furion.Tools.CommandLine
{
    public static class CliExtend
    {
        public static void WriteSplitLine(string content = "")
        {
            if (content != "")
            {
                content = " " + content + " ";
            }

            Cli.EmptyLine();
            Cli.WriteLine($"==========================={content}===========================", ConsoleColor.Gray);
            Cli.EmptyLine();
        }

        public static void ResetLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}