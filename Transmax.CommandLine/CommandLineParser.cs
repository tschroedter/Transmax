using System.Diagnostics.CodeAnalysis;
using Fclp;
using JetBrains.Annotations;
using Transmax.CommandLine.Interfaces;
using Transmax.Common.Interfaces;

namespace Transmax.CommandLine
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class CommandLineParser
        : ICommandLineParser
    {
        private static readonly IApplicationArguments Empty = new ApplicationArguments();

        private readonly ITransmaxConsole m_Console;
        private readonly ITransmaxLogger m_Logger;
        private readonly FluentCommandLineParser<ApplicationArguments> m_Parser;

        public CommandLineParser(
            [NotNull] ITransmaxLogger logger,
            [NotNull] ITransmaxConsole console)
        {
            m_Console = console;
            m_Logger = logger;
            m_Parser = CreateParser();
            ApplicationArguments = Empty;
        }

        public void Parse(string[] args)
        {
            var result = m_Parser.Parse(args);

            if (!result.HasErrors)
            {
                ApplicationArguments = m_Parser.Object;
                HasError = false;
            }
            else
            {
                m_Console.WriteLine(result.ErrorText);
                m_Logger.Error(result.ErrorText);
                ApplicationArguments = Empty;
                HasError = true;
            }
        }

        public IApplicationArguments ApplicationArguments { get; private set; }

        public bool HasError { get; private set; }

        private static FluentCommandLineParser<ApplicationArguments> CreateParser()
        {
            var parser = new FluentCommandLineParser<ApplicationArguments>();

            parser.Setup(arg => arg.Filename)
                .As('f',
                    "filename")
                .WithDescription("The name of the CSV file containing a list of names and their scores.")
                .SetDefault("student.txt");

            return parser;
        }
    }
}