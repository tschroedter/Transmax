using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Transmax.Core.Interfaces.Csv;

namespace Transmax.Core.Csv
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class InputFile
        : BaseFile,
          IInputFile
    {
        public InputFile(
            [NotNull] ITransmaxFile file)
            : base(file)
        {
        }

        public IEnumerable <string> ReadLines()
        {
            return File.ReadLines(Filename);
        }
    }
}