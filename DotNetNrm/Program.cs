using System.CommandLine;

namespace DotNetNrm
{
    internal partial class Program
    {
        private static readonly NpmRegistry[] _registries = new[]
        {
            new NpmRegistry { Name = "npm", Url = "https://registry.npmjs.org/" },
            new NpmRegistry { Name = "yarn", Url = "https://registry.yarnpkg.com/" },
            new NpmRegistry { Name = "tencent", Url = "https://mirrors.cloud.tencent.com/npm/" },
            new NpmRegistry { Name = "cnpm", Url = "https://r.cnpmjs.org/" },
            new NpmRegistry { Name = "taobao", Url = "https://registry.npmmirror.com/" },
            new NpmRegistry { Name = "npmMirror", Url = "https://skimdb.npmjs.com/registry/" },
        };

        static void Main(string[] args)
        {
            if (!OperatingSystem.IsWindows()) throw new PlatformNotSupportedException("Only windows is supported.");

#pragma warning disable CA1416 // Validate platform compatibility
            Console.BufferHeight = 9001;
#pragma warning restore CA1416 // Validate platform compatibility

            var rootCommand = new RootCommand(".NET tool of NPM registry manager.");
            rootCommand.SetHandler(context =>
            {
                SelectNpmRegistry();
            });

            var pingCommand = new Command("ping", "Show the response time for all registries.");
            rootCommand.AddCommand(pingCommand);
            pingCommand.SetHandler(context =>
            {
                PingRegistries();
            });

            var lsCommand = new Command("ls", "List all the registries.");
            rootCommand.AddCommand(lsCommand);
            lsCommand.SetHandler(context =>
            {
                ListRegistries();
            });

            var useOption = new Option<string>("use", "Change registry to registry.");
            rootCommand.AddOption(useOption);
            rootCommand.SetHandler(registryName =>
            {
                if (registryName is not null)
                {
                    var registry = _registries.FirstOrDefault(x => x.Name == registryName);
                    if (registry is not null) SetNpmRegistry(registry);
                    else Console.Error.WriteLine($"The registry ({registryName}) can not be found.");
                }
                else
                {
                    SelectNpmRegistry();
                }
            }, useOption);

            rootCommand.Invoke(args);
        }

    }
}