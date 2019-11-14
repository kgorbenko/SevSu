using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Testing.Util;
using Testing.Model;

namespace Testing.UnitTesting
{
    public class GetColumnsUnitTestEngine : ITestEngine
    {
        private ILogger Logger { get; set; }
        private IEnumerable<GetColumnsUnitTestDto> TestSuite { get; set; }

        public GetColumnsUnitTestEngine(ILogger logger, IEnumerable<GetColumnsUnitTestDto> testSuite)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            TestSuite = testSuite ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Run()
        {
            foreach (var test in TestSuite)
            {
                try
                {
                    var actual = test.Input.GetColumns();
                    var result = actual.SequenceEqual(test.Expected, new Int32ArrayEqualityComparer());

                    Logger.Log($"Test {test.Name}," + 
                               $"result:{result}" + 
                               $"{(result ? "" : $",expected: {PrintArrayCollection(test.Expected)} actual:{PrintArrayCollection(actual)}")}");
                }
                catch (Exception e)
                {
                    Logger.Log($"Test {test.Name}," +
                               $"result:{false}," +
                               $"Exception: {e.Message}");
                }
            }
        }

        private string PrintArrayCollection(IEnumerable<int[]> collection)
        {
            var stringBuilder = new StringBuilder("{ ");

            foreach (var array in collection)
            {
                stringBuilder.Append("[ ");
                foreach (var item in array)
                {
                    stringBuilder.Append($"{item} ");
                }
                stringBuilder.Append("] ");
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
    }
}