namespace GitChef
{
    internal static partial class ArgumentParser
    {
        internal static string[] ParseArguments(string[] args)
        {
            List<string> parsedArgs = [];
            foreach (string arg in args)
            {
                if (arg.Contains(' '))
                {
                    parsedArgs.Add('"' + arg + '"');
                }
                else
                {
                    parsedArgs.Add(arg);
                }
            }
            
            return parsedArgs.ToArray();
        }
    }
}