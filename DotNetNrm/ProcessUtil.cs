using System.Diagnostics;

namespace NStandard.Windows
{
    public static class ProcessUtil
    {
        public static Process Run(string fileName, string arguments)
        {
            var exe = (
                from path in Environment.GetEnvironmentVariables()["Path"]!.ToString()!.Split(';')
                let file = Path.Combine(path, fileName)
                where File.Exists(file)
                select file
            ).FirstOrDefault();

            if (exe is null) throw new ArgumentException($"The file ({fileName}) can not be found.", nameof(fileName));

            var process = Process.Start(new ProcessStartInfo
            {
                FileName = exe,
                UseShellExecute = true,
                Arguments = arguments,
            })!;

            return process;
        }
    }
}
