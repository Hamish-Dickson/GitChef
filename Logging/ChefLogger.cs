using System.Diagnostics;
using System.Reflection;

namespace GitChef.Logging;

internal static class ChefLogger
{
    internal static void LogInitialisationMessage(string message)
    {
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        var productVersion = FileVersionInfo.GetVersionInfo(assemblyLocation).ProductVersion?.Split('+')[0];
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("GitChef v"+ productVersion + " running command: " + message);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Yes Chef!");
        Console.ResetColor();
    }

    internal static void LogExitMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("GitChef: Service is Finished!");
        Console.ResetColor();
    }
}