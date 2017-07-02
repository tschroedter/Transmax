using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Transmax.Core.Interfaces.Csv;

namespace Transmax.Core.Csv
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public abstract class BaseFile
        : IFilename
    {
        protected BaseFile(
            [NotNull] ITransmaxFile file)
        {
            File = file;
            Filename = string.Empty;
        }

        [NotNull]
        protected readonly ITransmaxFile File;

        public string Filename { get; set; }
    }
}