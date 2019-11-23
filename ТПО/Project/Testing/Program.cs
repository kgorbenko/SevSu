using Testing.Util;
using Testing.UnitTesting;
using System.IO;
using Testing.IntegrationTesting;

namespace Testing
{
    public static class Program
    {
        private enum Labs
        {
            Lab3,
            Lab4
        }
        
        public static void Main(string[] args)
        {
            const Labs option = Labs.Lab4;

            switch (option)
            {
                case Labs.Lab3:
                {
                    var fileLogger = new FileLogger(new StreamWriter(UnitTestConstants.Path));
                    var testEngine = new GetColumnsUnitTestEngine(fileLogger, UnitTestConstants.TestSuite);
                    testEngine.Run();
                    break;
                }
                case Labs.Lab4:
                {
                    var fileLogger = new FileLogger(new StreamWriter(IntegrationTestConstants.Path));
                    var testEngine = new GetColumnsUnitTestEngineIntegrationTestEngine(fileLogger);
                    testEngine.Run();
                    break;
                }
            }
        }
    }
}