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
            [NotNull] IInputFile input,
            [NotNull] IOutputFile output)
        {
            m_Input = input;
            m_Output = output;
        }

        private const string ExceptionMessage = "Can't grade student file!";

        private const int ColumnFirstName = 0;
        private const int ColumnSurname = 1;
        private const int ColumnScore = 2;

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
                throw new GraderException(ExceptionMessage,
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
                               .Select(s => new
                                            {
                                                Surname = s.data [ ColumnSurname ].Trim(),
                                                FirstName = s.data [ ColumnFirstName ].Trim(),
                                                Score = Convert.ToInt32(s.data [ ColumnScore ])
                                            })
                               .OrderByDescending(x => x.Score)
                               .ThenBy(x => x.Surname.ToUpper())
                               .ThenBy(x => x.FirstName.ToUpper());

            IEnumerable <string> lines = input.Select(x => x.Surname + ", " + x.FirstName + ", " + x.Score);

            m_Output.WriteAllLines(lines);
        }
    }
}