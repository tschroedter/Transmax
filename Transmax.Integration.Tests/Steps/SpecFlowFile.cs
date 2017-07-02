using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using JetBrains.Annotations;
using Transmax.Common.Extensions;

namespace Transmax.Integration.Tests.Steps
{
    [ExcludeFromCodeCoverage]
    public class SpecFlowFile
    {
        private readonly FileInfo m_Info;

        public SpecFlowFile(
            [NotNull] string filename)
        {
            m_Info = new FileInfo(filename);
        }

        public string FullName => m_Info.FullName;
        public bool Exists => m_Info.Exists;

        public void Delete()
        {
            if (!m_Info.Exists)
                return;

            Console.WriteLine("Trying to delete file '{0}'...".Inject(m_Info.FullName));
            m_Info.Delete();
            Console.WriteLine("...done!");
        }

        public void WriteAllLines(IEnumerable<string> lines)
        {
            File.WriteAllLines(m_Info.FullName, lines);
        }

        public IEnumerable<string> ReadAllLines()
        {
            return File.ReadAllLines(m_Info.FullName);
        }
    }
}