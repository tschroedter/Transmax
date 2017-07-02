using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Transmax.Common.Interfaces;
using Transmax.Core.Interfaces.Csv;

namespace Transmax.Core.Csv
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public abstract class BaseFile
        : IFilename
    {
        [NotNull] protected readonly ITransmaxFile File;

        protected BaseFile(
            [NotNull] ITransmaxFile file)
        {
            File = file;
            Filename = string.Empty;
        }

        public string Filename { get; set; }
    }
}