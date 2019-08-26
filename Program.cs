using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecryptBatti
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = args[0];
            string source = args[1];
            string target = args[2];

            bool startWithK = command.StartsWith("/k");

            Directory.CreateDirectory(target);
            
            foreach(var file in Directory.GetFiles(source))
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                string executeCommand =  startWithK ? command : "/C " + command; 
                process.StartInfo.Arguments = string.Format(executeCommand, "\"" + file + "\"", "\"" + target + "\"");
                process.Start();
            }
        }
    }
}
