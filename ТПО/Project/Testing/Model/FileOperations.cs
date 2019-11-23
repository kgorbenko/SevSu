using System;
using System.IO;
using System.Linq;

namespace Testing.Model
{
    public class TextOperations
    {
        private readonly StreamReader streamReader;
        private readonly string[] delimiters = { " ", ".", ",", "?", "!", "(", ")", ":", ";", Environment.NewLine };

        public TextOperations(StreamReader streamReader)
        { 
            this.streamReader = streamReader ?? throw new ArgumentNullException(nameof(streamReader));
        }

        public string ReverseEveryTwoWords()
        {
            var source = streamReader.ReadToEnd();

            return string.Join(" ", source
                                        .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                                        .Select((word, i) => new { Value = word, Index = i })
                                        .GroupBy(x => x.Index / 2)
                                        .Select(group => group.Select(x => x.Value).Reverse())
                                        .SelectMany(x => x)
            );
        }
    }
}