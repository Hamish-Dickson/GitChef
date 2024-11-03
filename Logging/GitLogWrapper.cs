using System.Diagnostics;
using GitChef.Enums;

namespace GitChef.Logging;

internal static class GitLogWrapper
{
    internal static void Log(DataReceivedEventArgs eventArgs, Status status)
    {
        if (string.IsNullOrWhiteSpace(eventArgs.Data)) return;

        Console.ResetColor();

        if (status is Status.Error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Git Error: ");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Git Message: ");
        }
        
        Console.ResetColor();
        Console.WriteLine(eventArgs.Data);
    }
}