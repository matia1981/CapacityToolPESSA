using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.ApplicationMethods
{
    public static class LoggingClass
    {
        private const string _logFileName = @"c:\pavilion\applicationlog.txt";

        public static void WriteLog(string message, string type, string method)
        {
            System.IO.File.AppendAllText(_logFileName, string.Format("\n******* {0} ******\n", type));
            System.IO.File.AppendAllText(_logFileName, DateTime.Now.ToString() + "\n");
            System.IO.File.AppendAllText(_logFileName, method + "\n");
            System.IO.File.AppendAllText(_logFileName, message + "\n");            
        }
    }
}
