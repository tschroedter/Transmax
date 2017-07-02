using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using JetBrains.Annotations;
using Transmax.Core.Interfaces.Csv;

namespace Transmax.Core.Csv
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class TransmaxFile
        : ITransmaxFile
    {
        public void WriteAllLines(string filename,
                                  IEnumerable <string> lines)
        {
            File.WriteAllLines(filename,
                               lines);
        }

        public IEnumerable <string> ReadLines(string filename)
        {
            return File.ReadLines(filename);
        }
    }
}