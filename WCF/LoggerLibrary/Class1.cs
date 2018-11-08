using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary
{
    public static class Logger
    {
        public static string Path = @"C:\Users\andriy1234\source\repos\MyChat\WCF\WCF\bin\Debug\loh.txt";

        public static void Log(string msg)
        {
            using (StreamWriter sw = new StreamWriter(Path, true))
            {
                sw.WriteLine($"{DateTime.Now}: {msg}");
            }
        }
    }
}
