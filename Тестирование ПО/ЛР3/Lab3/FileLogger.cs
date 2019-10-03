using System;
using System.IO;

namespace Lab3
{
    public class FileLogger : ILogger
    {
        private StreamWriter streamWriter;
        
        public FileLogger(StreamWriter writer)
        {
            streamWriter = writer ?? throw new ArgumentNullException("StreamWriter instance was null");
        }

        public void Log(string message)
        {
            if (message != null && !string.IsNullOrWhiteSpace(message))
            {
                streamWriter.WriteLine(message);
                streamWriter.Flush();
            }
        }
    }
}
