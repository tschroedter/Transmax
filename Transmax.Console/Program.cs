using Autofac;
using JetBrains.Annotations;
using Transmax.CommandLine;
using Transmax.CommandLine.Interfaces;
using Transmax.Common;
using Transmax.Core;
using Transmax.Core.Interfaces;
using static System.Console;

namespace Transmax.Console
{
    /*
     * Attention: 
     * (1) I am using the NuGet package FluentCommandLineParser to process
     *     the command line parameters. This makes it easier to add new 
     *     paramater in the future.
     *
     *     The way of calling the program with parameters is:
     *     grade-scores.exe -f <filename>
     *     or
     *     grade-scores.exe -filename <filename>
     *
     * (2) No CSV file validation is done, I assume at the moment that the 
     *     content of the file is valid!
     * 
     * (2) No performance test done yet (e.g. using large files).
     * 
     */
    public static class Program
    {
        public static void Main(string[] args)
        {
            IContainer container = CreateContainer();

            ICommandLineParser parser = CreateParser(container,
                                                     args);

            if ( parser.HasError )
            {
                WriteLine("Please fix existing errors!");

                return;
            }

            var grader = container.Resolve <IGradeRunner>();
            grader.Grade(parser.ApplicationArguments.Filename);

            WriteLine("Press a key to continue...");
            ReadKey();
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule <LoggingModule>();
            builder.RegisterModule <TransmaxCommonModule>();
            builder.RegisterModule <TransmaxCommandLineModule>();
            builder.RegisterModule <TransmaxCoreModule>();
            IContainer container = builder.Build();
            return container;
        }

        private static ICommandLineParser CreateParser(
            [NotNull] IContainer container,
            [NotNull] string[] args)
        {
            var parser = container.Resolve <ICommandLineParser>();
            parser.Parse(args);
            return parser;
        }
    }
}