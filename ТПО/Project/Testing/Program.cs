using Testing.Util;
using Testing.UnitTesting;
using System.IO;
using Testing.IntegrationTesting;

namespace Lab3
{
    public static class Program
    {
        private enum Labs
        {
            Lab3,
            Lab4
        }
        
        static void Main(string[] args)
        {
            var option = Labs.Lab4;

            if (option == Labs.Lab3)
            {
                var fileLogger = new FileLogger(new StreamWriter(UnitTestConstants.Path));
                var testEngine = new GetColumnsUnitTestEngine(fileLogger, UnitTestConstants.TestSuite);
                testEngine.Run();
            }

            if (option == Labs.Lab4)
            {
                var fileLogger = new FileLogger(new StreamWriter(IntegrationTestConstants.Path));
                var testEngine = new GetColumnsUnitTestEngineIntegrationTestEngine(fileLogger);
                testEngine.Run();
            }
        }
    }
}