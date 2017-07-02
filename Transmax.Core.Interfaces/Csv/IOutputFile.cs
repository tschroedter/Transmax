using System.Collections.Generic;
using JetBrains.Annotations;

namespace Transmax.Core.Interfaces.Csv
{
    public interface IOutputFile
        : IFilename
    {
        void WriteAllLines([NotNull] IEnumerable <string> lines);
    }
}