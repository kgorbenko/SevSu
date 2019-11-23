using Testing.Util;

namespace Testing.IntegrationTesting
{
    public class FakeLogger : ILogger
    {
        public bool LogCalled { get; private set; }
        
        public void Log(string message)
        {
            LogCalled = true;
        }

        public void Dispose() { }
    }
}