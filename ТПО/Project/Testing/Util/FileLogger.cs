using System;
using System.IO;

namespace Testing.Util
{
    public class FileLogger : ILogger
    {
        private readonly StreamWriter streamWriter;
        
        public FileLogger(StreamWriter streamWriter)
        {
            this.streamWriter = streamWriter ?? throw new ArgumentNullException(nameof(streamWriter));
        }

        public void Dispose()
        {
            streamWriter.Dispose();
        }

        public void Log(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            streamWriter.WriteLine(message);
            streamWriter.Flush();
        }
    }
}