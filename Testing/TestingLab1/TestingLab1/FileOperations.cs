using System;
using System.IO;
using System.Linq;

namespace TestingLab1
{
    public class FileOperations
    {
        private readonly StreamReader streamReader;
        private readonly string[] delimiters = { " ", ".", ",", "?", "!", "(", ")", ":", ";", Environment.NewLine };

        public FileOperations(StreamReader streamReader)
            => this.streamReader = streamReader ?? throw new ArgumentNullException($"{nameof(streamReader)} instance was null");

        public string ReverseEveryTwoWords()
        {
            var source = streamReader.ReadToEnd();

            return string.Join(" ", source
                                        .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                                        .Select((word, i) => new { Value = word, Index = i })
                                        .GroupBy(x => x.Index / 2)
                                        .Select(group => group.Select(x => x.Value).Reverse().ToArray())
                                        .SelectMany(x => x)
                );
        }
    }
}