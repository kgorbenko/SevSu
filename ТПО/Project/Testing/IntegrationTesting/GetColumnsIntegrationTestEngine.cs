using Testing.Util;
using System.IO;
using Testing.UnitTesting;
using System;

namespace Testing.IntegrationTesting
{
    public class GetColumnsUnitTestEngineIntegrationTestEngine
    {
        private readonly ILogger logger;
        
        public GetColumnsUnitTestEngineIntegrationTestEngine(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public void Run()
        {
            TestThatLogMethodGetsCalled();
            TestThatAllTestSuiteTestsAreRunning();
        }

        private bool TestThatLogMethodGetsCalled()
        {
            try
            {
                logger.Log($"Test {nameof(TestThatLogMethodGetsCalled)}.");
                var fakeLogger = new FakeLogger();
                var unitTestEngine = new GetColumnsUnitTestEngine(fakeLogger, UnitTestConstants.TestSuite);
                logger.Log("Passing logger.");
                logger.Log("Running unit tests.");
                unitTestEngine.Run();
                var result = fakeLogger.LogCalled;
                logger.Log(result ? "Test passed." : "Test failed.");
                return result;
            }
            catch
            {
                return false;
            }
        }

        private bool TestThatAllTestSuiteTestsAreRunning()
        {
            try
            {
                logger.Log($"Test {nameof(TestThatAllTestSuiteTestsAreRunning)}.");
                var fakeLogger = new FileLogger(new StreamWriter(UnitTestConstants.Path));
                var unitTestEngine = new GetColumnsUnitTestEngine(fakeLogger, UnitTestConstants.TestSuite);
                logger.Log("Passing logger.");
                logger.Log("Running unit tests.");
                unitTestEngine.Run();
                fakeLogger.Dispose();
                logger.Log("Checking file content.");
                var result = true;
                using (var streamReader = new StreamReader(UnitTestConstants.Path))
                {
                    foreach (var test in UnitTestConstants.TestSuite)
                    {
                        var fileLine = streamReader.ReadLine();
                        if (fileLine != null && !fileLine.StartsWith($"Test {test.Name}"))
                        {
                            result = false;
                        }
                    }
                }
                if (result)
                {
                    logger.Log("Test passed.");
                }
                else
                {
                    logger.Log("Test failed.");
                }
                return result;
            }
            catch
            {
                return false;
            }
        }
    }
}