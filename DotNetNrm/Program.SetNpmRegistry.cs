using NStandard;
using NStandard.Windows;

namespace DotNetNrm
{
    internal partial class Program
    {
        static void SetNpmRegistry(NpmRegistry registry)
        {
            using var process = ProcessUtil.Run("npm", $"config set registry {registry.Url}");
            process.WaitForExit();

            Console.Write($"NPM registry is set to  ");
            using (ConsoleContext.Begin())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{registry.Name} ");
                Console.WriteLine(registry.Url);
            }
        }

    }
}
