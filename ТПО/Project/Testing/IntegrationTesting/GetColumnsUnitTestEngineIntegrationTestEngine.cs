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
                this.logger.Log($"Test {nameof(TestThatLogMethodGetsCalled)}.");
                var logger = new FakeLogger();
                var unitTestEngine = new GetColumnsUnitTestEngine(logger, UnitTestConstants.TestSuite);
                this.logger.Log("Passing logger.");
                this.logger.Log("Running unit tests.");
                unitTestEngine.Run();
                bool result = logger.LogCalled;
                if (result == true)
                {
                    this.logger.Log("Test passed.");
                }
                else
                {
                    this.logger.Log("Test failed.");
                }
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
                this.logger.Log($"Test {nameof(TestThatAllTestSuiteTestsAreRunning)}.");
                var logger = new FileLogger(new StreamWriter(UnitTestConstants.Path));
                var unitTestEngine = new GetColumnsUnitTestEngine(logger, UnitTestConstants.TestSuite);
                this.logger.Log("Passing logger.");
                this.logger.Log("Running unit tests.");
                unitTestEngine.Run();
                logger.Dispose();
                this.logger.Log("Checking file content.");
                bool result = true;
                using (var streamReader = new StreamReader(UnitTestConstants.Path))
                {
                    foreach (var test in UnitTestConstants.TestSuite)
                    {
                        var fileLine = streamReader.ReadLine();
                        if (!fileLine.StartsWith($"Test {test.Name}"))
                        {
                            result = false;
                        }
                    }
                }
                if (result == true)
                {
                    this.logger.Log("Test passed.");
                }
                else
                {
                    this.logger.Log("Test failed.");
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