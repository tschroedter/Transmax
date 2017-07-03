using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Transmax.Core.Interfaces;
using Transmax.Core.Interfaces.Csv;

namespace Transmax.Core.Csv
{
    [UsedImplicitly]
    public class LinqGrader
        : IGrader
    {
        public LinqGrader(
            [NotNull] IInputFileColumnIndices indices,
            [NotNull] IInputFile input,
            [NotNull] IOutputFile output)
        {
            m_Indices = indices;
            m_Input = input;
            m_Output = output;
        }

        [NotNull]
        private readonly IInputFileColumnIndices m_Indices;

        [NotNull]
        private readonly IInputFile m_Input;

        [NotNull]
        private readonly IOutputFile m_Output;

        public void Process()
        {
            try
            {
                Grade();
            }
            catch ( Exception exception )
            {
                throw new GraderException(exception.Message,
                                          exception);
            }
        }

        public string SourceFilename
        {
            get
            {
                return m_Input.Filename;
            }
            set
            {
                m_Input.Filename = value;
            }
        }

        public string DestinationFilename
        {
            get
            {
                return m_Output.Filename;
            }
            set
            {
                m_Output.Filename = value;
            }
        }

        private void Grade()
        {
            var input = m_Input.ReadLines()
                               .SelectMany(line => line.Split('\r'))
                               .Where(csvLine => !string.IsNullOrWhiteSpace(csvLine))
                               .Select(csvLine => new
                                                  {
                                                      data = csvLine.Trim().Split(',')
                                                  })
                               .Where(parts => parts.data.Length == 3)
                               .Select(s => new
                                            {
                                                Surname = s.data [m_Indices.Surname].Trim(),
                                                FirstName = s.data [m_Indices.FirstName].Trim(),
                                                Score = ConvertScore.ToInt32(s.data [m_Indices.Score])
                                            })
                               .OrderByDescending(x => x.Score)
                               .ThenBy(x => x.Surname.ToUpper())
                               .ThenBy(x => x.FirstName.ToUpper());

            IEnumerable <string> lines = input.Select(x => x.Surname + "," + x.FirstName + "," + x.Score);

            m_Output.WriteAllLines(lines);
        }
    }
}