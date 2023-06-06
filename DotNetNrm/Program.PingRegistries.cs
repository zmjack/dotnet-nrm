using NStandard;
using System.Net.NetworkInformation;

namespace DotNetNrm
{
    internal partial class Program
    {
        static void PingRegistries()
        {
            var ping = new Ping();

            Console.WriteLine("Ping all the npm registries:");
            Console.WriteLine();
            foreach (var (index, registry) in _registries.AsIndexValuePairs())
            {
                var uri = new Uri(registry.Url);
                var reply = ping.Send(uri.Host);
                var roundtrip = reply.Status == IPStatus.Success
                    ? $"{reply.RoundtripTime,4} ms"
                    : "Timeout";

                Console.WriteLine(GetTextWithNumberPing(index + 1, registry, roundtrip));
            }
            Console.WriteLine();

        }

    }
}