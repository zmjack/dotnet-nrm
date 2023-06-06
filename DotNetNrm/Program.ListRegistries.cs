using NStandard;

namespace DotNetNrm
{
    internal partial class Program
    {
        static void ListRegistries()
        {
            Console.WriteLine("All the npm registries:");
            Console.WriteLine();
            foreach (var (index, registry) in _registries.AsIndexValuePairs())
            {
                Console.WriteLine(GetTextWithNumber(index + 1, registry));
            }
            Console.WriteLine();
        }

    }
}