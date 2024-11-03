namespace GitChef
{
    public static class CommandBuilder
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
    
        internal static string ChefCommandToGit(string chefArgs)
        {
            return CommandMap.GetValueOrDefault(chefArgs) ?? throw new InvalidOperationException($"{chefArgs} is not a valid GitChef argument.");
        }
    }
}