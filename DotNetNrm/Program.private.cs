using NStandard;

namespace DotNetNrm
{
    internal partial class Program
    {
        private static string GetTextWithNumber(int number, NpmRegistry source) => $"  {number,2}.  {source.Name,-16} {source.Url}";
        private static string GetTextWithNumberPing(int number, NpmRegistry source, string ping) => $"  {number,2}.  {source.Name,-16} ({ping})  {source.Url}";
        private static string GetText(NpmRegistry source) => $"  [ ]  {source.Name,-16} {source.Url}";

        private static void Highlight(int top, NpmRegistry source, int option, bool highlight)
        {
            using (ConsoleContext.Begin())
            {
                var _top = top + option;
                var context = ConsoleContext.Current;
                Console.WriteLine(_top);
                Console.SetCursorPosition(0, _top);
                Console.ForegroundColor = highlight ? ConsoleColor.Green : context.ForegroundColor;
                Console.WriteLine(GetText(source));

                if (highlight)
                {
                    Console.SetCursorPosition(3, _top);
                }
            }
        }

    }
}