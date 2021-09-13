using System.IO;
using ILogInterface;

namespace OutputLogs
{
    public class FileLog : ILog
    {
        public void Print(string s)
        {
            using (StreamWriter sw = new StreamWriter("OutputLog.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(s);
            }
        }
    }
}