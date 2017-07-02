using System.Collections.Generic;
using JetBrains.Annotations;

namespace Transmax.Common.Interfaces
{
    public interface ITransmaxFile
    {
        IEnumerable<string> ReadLines([NotNull] string filename);

        void WriteAllLines([NotNull] string filename,
            [NotNull] IEnumerable<string> lines);
    }
}