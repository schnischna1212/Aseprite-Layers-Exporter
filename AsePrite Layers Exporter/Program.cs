using System;
using System.Diagnostics;

namespace AsePrite_Layers_Exporter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var files = Configuration.GetConfiguredFiles();

            foreach(var aseFile in files)
            {
                Console.WriteLine(aseFile.Command);
                ExecuteCommand(aseFile.Command);
                ExecuteToolChainIfNeeded(aseFile.AppCallAfterConversion);
            }

            Console.ReadLine();
        }

        private static void ExecuteToolChainIfNeeded(string command)
        {
            if (string.IsNullOrEmpty(command) || command == "C:\\PATH_TO_YOUR_NEXT_APPLICATION_IN_TOOLCHAIN\\TOOL.EXE")
            {
                Console.WriteLine("No additional Tool in Toolchain called");
                return;
            }

            ExecuteCommand(command);
        }

        static void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }
    }
}
