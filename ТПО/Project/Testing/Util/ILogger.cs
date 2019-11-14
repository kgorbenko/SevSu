using System;

namespace Testing.Util
{
    public interface ILogger : IDisposable
    {
        void Log(string message);
    }
}