using System.Collections.Generic;
using JetBrains.Annotations;

namespace Transmax.Core.Interfaces.Csv
{
    public interface IInputFile
        : IFilename
    {
        [NotNull]
        IEnumerable<string> ReadLines();
    }
}