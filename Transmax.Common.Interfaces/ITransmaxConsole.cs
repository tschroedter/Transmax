using JetBrains.Annotations;

namespace Transmax.Common.Interfaces
{
    public interface ITransmaxConsole
    {
        void WriteLine([NotNull] string message);
    }
}