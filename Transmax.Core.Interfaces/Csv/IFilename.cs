using JetBrains.Annotations;

namespace Transmax.Core.Interfaces.Csv
{
    public interface IFilename
    {
        [NotNull]
        string Filename { get; set; }
    }
}