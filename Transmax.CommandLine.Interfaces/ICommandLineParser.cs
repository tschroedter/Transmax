using JetBrains.Annotations;

namespace Transmax.CommandLine.Interfaces
{
    public interface ICommandLineParser
    {
        [NotNull]
        IApplicationArguments ApplicationArguments { get; }

        bool HasError { get; }
        void Parse([NotNull] string[] args);
    }
}