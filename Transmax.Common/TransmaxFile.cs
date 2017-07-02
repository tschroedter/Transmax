using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using JetBrains.Annotations;
using Transmax.Common.Interfaces;

namespace Transmax.Common
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class TransmaxFile
        : ITransmaxFile
    {
        public void WriteAllLines(string filename,
            IEnumerable<string> lines)
        {
            File.WriteAllLines(filename,
                lines);
        }

        public IEnumerable<string> ReadLines(string filename)
        {
            return File.ReadLines(filename);
        }
    }
}