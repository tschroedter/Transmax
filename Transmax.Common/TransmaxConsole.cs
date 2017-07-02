using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Transmax.Common.Interfaces;

namespace Transmax.Common
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class TransmaxConsole
        : ITransmaxConsole
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}