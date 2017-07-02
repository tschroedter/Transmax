using System.Collections.Generic;
using JetBrains.Annotations;
using Transmax.Common.Interfaces;
using Transmax.Core.Interfaces;
using Transmax.Core.Interfaces.Csv;

namespace Transmax.Core.Csv
{
    [UsedImplicitly]
    public class OutputFile
        : BaseFile,
            IOutputFile
    {
        [NotNull] private readonly ITransmaxConsole m_Console;

        [NotNull] private readonly IApplicationMode m_Mode;

        public OutputFile(
            [NotNull] IApplicationMode mode,
            [NotNull] ITransmaxConsole console,
            [NotNull] ITransmaxFile file)
            : base(file)
        {
            m_Mode = mode;
            m_Console = console;
        }

        public void WriteAllLines(IEnumerable<string> lines)
        {
            // ReSharper disable PossibleMultipleEnumeration
            File.WriteAllLines(Filename,
                lines);

            if (m_Mode.IsRelease)
                return;

            foreach (var line in lines)
            {
                m_Console.WriteLine(line);
            }
            // ReSharper restore PossibleMultipleEnumeration
        }
    }
}