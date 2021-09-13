using System;
using ILogInterface;

namespace OutputLogs
{
    public class ConsoleLog : ILog
    {
        public void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
}