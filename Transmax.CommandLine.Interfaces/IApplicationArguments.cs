using JetBrains.Annotations;

namespace Transmax.CommandLine.Interfaces
{
    public interface IApplicationArguments
    {
        [UsedImplicitly]
        string Filename { get; set; }
    }
}