using System;
using JetBrains.Annotations;

namespace Transmax.Common.Interfaces
{
    public interface ITransmaxLogger
    {
        [UsedImplicitly]
        void Debug(string message);

        [UsedImplicitly]
        void Error(string message);

        [UsedImplicitly]
        void Error([NotNull] string message,
                   [NotNull] Exception exception);

        [UsedImplicitly]
        void Fatal(string message);

        [UsedImplicitly]
        void Fatal([NotNull] string message,
                   [NotNull] Exception exception);
    }
}