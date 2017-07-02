using System;
using JetBrains.Annotations;
using NLog;
using Transmax.Common.Interfaces;

namespace Transmax.Common
{
    [UsedImplicitly]
    public class TransmaxLogger
        : ITransmaxLogger
    {
        public TransmaxLogger(
            [NotNull] ILogger logger)
        {
            m_Logger = logger;
        }

        [NotNull]
        private readonly ILogger m_Logger;

        // todo add more methods on demand, see NLog.ILogger

        public void Debug(string message)
        {
            m_Logger.Debug(message);
        }

        public void Error(string message)
        {
            m_Logger.Error(message);
        }

        public void Error(string message,
                          Exception exception)
        {
            m_Logger.Error(exception,
                           message);
        }

        public void Fatal(string message)
        {
            m_Logger.Fatal(message);
        }

        public void Fatal(string message,
                          Exception exception)
        {
            m_Logger.Fatal(exception,
                           message);
        }
    }
}