using System;
using JetBrains.Annotations;

namespace Transmax.Common.Interfaces
{
    public interface ITransmaxLogger
    {
        void Debug(string message);
        void Error(string message);

        void Error([NotNull] string message,
                   [NotNull] Exception exception);

        void Fatal(string message);

        void Fatal([NotNull] string message,
                   [NotNull] Exception exception);
    }
}