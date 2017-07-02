using System;
using JetBrains.Annotations;

namespace Transmax.Core.Csv
{
    public class GraderException
        : Exception
    {
        public GraderException(
            [NotNull] string message,
            [NotNull] Exception innerException)
            : base(message,
                   innerException)
        {
        }
    }
}