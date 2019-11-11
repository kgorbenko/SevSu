using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab3
{
    public class TestEngine
    {
        private ILogger           Logger    { get; set; }
        private IEnumerable<Test> TestSuite { get; set; }

        public TestEngine(ILogger logger, IEnumerable<Test> testSuite)
        {
            Logger    = logger    ?? throw new ArgumentNullException("Logger instance was null");
            TestSuite = testSuite ?? throw new ArgumentNullException("Test suite was null");
        }

        public void TestEquality()
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