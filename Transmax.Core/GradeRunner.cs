using System.IO;
using JetBrains.Annotations;
using Transmax.Common.Extensions;
using Transmax.Common.Interfaces;
using Transmax.Core.Csv;
using Transmax.Core.Interfaces;

namespace Transmax.Core
{
    [UsedImplicitly]
    public class GradeRunner
        : IGradeRunner
    {
        private const string ExceptionMessageIo = "Grading stopped because of a problem with the file!";
        private const string ExceptionMessageGrader = "Grading stopped because of a problem with the 'Grader'!";
        private readonly ITransmaxConsole m_Console;

        private readonly IGrader m_Grader;
        private readonly ITransmaxLogger m_Logger;

        public GradeRunner(
            [NotNull] ITransmaxLogger logger,
            [NotNull] ITransmaxConsole console,
            [NotNull] IGrader grader)
        {
            m_Logger = logger;
            m_Console = console;
            m_Grader = grader;
        }

        public void Grade(string sourceFilename)
        {
            try
            {
                Process(sourceFilename);
            }
            catch (IOException exception)
            {
                m_Logger.Fatal(ExceptionMessageIo,
                    exception);

                m_Console.WriteLine(ExceptionMessageGrader);
            }
            catch (GraderException exception)
            {
                m_Logger.Fatal(ExceptionMessageGrader,
                    exception);

                m_Console.WriteLine(ExceptionMessageGrader);
            }
        }

        private static string CreateDestinationFilename(string sourceFilename)
        {
            var destinationFilename =
                Path.GetDirectoryName(sourceFilename) +
                Path.DirectorySeparatorChar +
                Path.GetFileNameWithoutExtension(sourceFilename) + "-graded.txt";

            if (destinationFilename.StartsWith(Path.DirectorySeparatorChar.ToString()))
                destinationFilename = destinationFilename.Substring(Path.DirectorySeparatorChar.ToString().Length);

            return destinationFilename;
        }

        private void Process(string sourceFilename)
        {
            var destinationFilename = CreateDestinationFilename(sourceFilename);

            m_Grader.SourceFilename = sourceFilename;
            m_Grader.DestinationFilename = destinationFilename;

            m_Logger.Debug("Started grading file '{0}'...".Inject(m_Grader.SourceFilename));

            m_Grader.Process();

            m_Logger.Debug("Successfully created file '{0}'!".Inject(m_Grader.DestinationFilename));
        }
    }
}