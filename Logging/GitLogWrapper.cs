using System.Diagnostics;
using GitChef.Enums;

namespace GitChef;

internal static class GitLogWrapper
{
    internal static void Log(DataReceivedEventArgs eventArgs, Status status)
    {
        if (string.IsNullOrWhiteSpace(eventArgs.Data)) return;

        Console.ResetColor();

        if (status is Status.Error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Git Error: " + eventArgs.Data);
        }
        else
        {
            Console.Write("Git Message: " + eventArgs.Data);
        }
        
        Console.ResetColor();
        Console.WriteLine(eventArgs.Data);
    }
}