namespace GitChef
{
    public static partial class ArgumentParser
    {
        public static string[] ParseArguments(string[] args)
        {
            List<string> parsedArgs = new();
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