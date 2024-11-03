namespace GitChef.Parsers
{
    internal static class CommandParser
    {
        private static readonly Dictionary<string, string> CommandMap = new()
        {
            { "cook", "commit" },
            { "pantry", "fetch" },
            { "serve", "push" },
            { "eat", "pull" },
            { "taste", "status" },
            { "portion", "branch" },
            { "blend", "merge" },
            { "order", "checkout" },
            { "recipe", "clone" },
            { "prep", "init" },
            { "reviews", "log" },
            { "butcher", "bisect" },
            { "proof", "rebase" },
            { "scrap", "reset" },
            { "fridge", "stash" },
            { "season", "add" },
            { "itsbloodyraw", "revert" },
            { "namedish", "tag" },
        };

        internal static bool TryParseGitChefCommand(string command, out string chefArgs)
        {
            return CommandMap.TryGetValue(command, out chefArgs);
        }
    }
}