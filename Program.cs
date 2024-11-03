using System.Diagnostics;

namespace GitChef
{
    public static class Processor
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a valid GitChef command.");
                return;
            }
            string command = args[0];
            string[] gitArgs = args.Length > 1 ? args.Take(Range.StartAt(1)).ToArray() : new string[0];

            string gitCommand = CommandBuilder.ChefCommandToGit(command);
            gitArgs = ArgumentParser.ParseArguments(gitArgs);
            
            RunGitCommand(gitCommand, gitArgs);
        }

        private static void RunGitCommand(string gitCommand, string[] gitArgs)
        {
            string arguments = $"{gitCommand} {string.Join(" ", gitArgs)}";
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
                
                process.OutputDataReceived += (sender, e) => Console.WriteLine("Git Error: " + e.Data);
                process.ErrorDataReceived += (sender, e) => Console.WriteLine("Git Error: " + e.Data);
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running git command: {ex.Message}");
            }
        }
    }
}

