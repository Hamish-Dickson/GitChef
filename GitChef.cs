using System.Diagnostics;
using GitChef.Enums;
using GitChef.Logging;
using GitChef.Parsers;

namespace GitChef
{
    public static class GitChef
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a GitChef command.");
                return;
            }
            
            string command = args[0];
            if (!CommandParser.TryParseGitChefCommand(command, out string gitCommand))
            {
                Console.WriteLine("'GitChef " + command + "' is not valid. Please provide a valid GitChef command.");
                return;
            }
            
            string[] gitArgs = args.Length > 1 ? args.Take(Range.StartAt(1)).ToArray() : [];
            gitArgs = ArgumentParser.ParseArguments(gitArgs);
            
            RunGitCommand(gitCommand, gitArgs);
        }

        private static void RunGitCommand(string gitCommand, string[] gitArgs)
        {
            string arguments = $"{gitCommand} {string.Join(" ", gitArgs)}";
            ChefLogger.LogInitialisationMessage(arguments);
            
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using Process? process = Process.Start(startInfo);
                if (process is null)
                {
                    throw new ApplicationException("Failed to start git command.");
                }
                
                process.OutputDataReceived += (sender, e) =>
                {
                    GitLogWrapper.Log(e, Status.Info);

                };
                process.ErrorDataReceived += (sender, e) =>
                {
                    GitLogWrapper.Log(e, Status.Error);
                };
                
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                ChefLogger.LogExitMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running git command: {ex.Message}");
            }
        }
    }
}

