using System;
using System.Collections.Generic;
using System.IO;
using PrintedEditionMdi.Models;
using Newtonsoft.Json;
using PrintedEditionMdi.Annotations;

namespace PrintedEditionMdi.Utils
{
    public static class PrintedEditionSerializeHelper
    {
        public static IEnumerable<PrintedEdition> Deserialize([NotNull] string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            using var streamReader = File.OpenText(path);
            var json = streamReader.ReadToEnd();

            return JsonConvert.DeserializeObject<PrintedEdition[]>(json);
        }

        public static void Serialize([NotNull] IEnumerable<PrintedEdition> printedEditions, [NotNull] string path)
        {
            if (printedEditions == null) throw new ArgumentNullException(nameof(printedEditions));
            if (path == null) throw new ArgumentNullException(nameof(path));

            var json = JsonConvert.SerializeObject(printedEditions, Formatting.Indented);

            using var streamWriter = new StreamWriter(path);
            streamWriter.Write(json);
        }
    }
}