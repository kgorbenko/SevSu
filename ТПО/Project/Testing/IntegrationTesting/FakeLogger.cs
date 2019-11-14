using System;
using System.Collections.Generic;
using System.Text;
using Testing.Util;

namespace Testing.IntegrationTesting
{
    public class FakeLogger : ILogger
    {
        public bool LogCalled { get; private set; } = false;

        public void Log(string message)
        {
            LogCalled = true;
        }

        public void Dispose() { }
    }
}