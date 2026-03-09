using System.Diagnostics;
namespace PasswordOverview.Consoles;

public class WindowsConsole : IConsole
{
    public string Run(string command)
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c " + command,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string output = process?.StandardOutput.ReadToEnd()??"";
                process?.WaitForExit();
                return output;
            }
        }
        catch
        {
            return "";
        }
    }
}
