using NStandard;

namespace DotNetNrm
{
    internal partial class Program
    {
        static void SelectNpmRegistry()
        {
            Console.WriteLine("Select NPM registry to set: ");

            using (ConsoleContext.Begin())
            {
                Console.CursorVisible = false;
                Console.WriteLine();

                var optionTop = Console.CursorTop;
                foreach (var (index, source) in _registries.AsIndexValuePairs())
                {
                    Highlight(optionTop, source, index, false);
                }

                var option = 0;
                using (ConsoleContext.Begin(true))
                {
                    Highlight(optionTop, _registries[0], option, true);

                    ConsoleKeyInfo readKey;
                    while (true)
                    {
                        readKey = Console.ReadKey(true);

                        if (readKey.Key == ConsoleKey.Enter)
                        {
                            var registry = _registries[option];
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("*");
                            break;
                        }

                        if (option > 0 && readKey.Key == ConsoleKey.UpArrow)
                        {
                            Highlight(optionTop, _registries[option], option, false);
                            option--;
                            Highlight(optionTop, _registries[option], option, true);
                        }
                        else if (option < _registries.Length - 1 && readKey.Key == ConsoleKey.DownArrow)
                        {
                            Highlight(optionTop, _registries[option], option, false);
                            option++;
                            Highlight(optionTop, _registries[option], option, true);
                        }
                    }
                }

                Console.WriteLine();
                var selected = _registries[option];
                SetNpmRegistry(selected);
            }
        }

    }
}