using System.Diagnostics.CodeAnalysis;
using Autofac;
using JetBrains.Annotations;
using TechTalk.SpecFlow;
using Transmax.CommandLine;
using Transmax.Common;
using Transmax.Core;
using Transmax.Core.Interfaces;
using Transmax.Integration.Tests.Steps;

namespace Transmax.Integration.Tests
{
    [Binding]
    [ExcludeFromCodeCoverage]
    public class GradeScoresSteps
    {
        [AfterScenario]
        [UsedImplicitly]
        public void AfterScenario()
        {
            var source = ( string ) ScenarioContext.Current [ "SourceFilename" ];
            var sourceFile = new SpecFlowFile(source);
            sourceFile.Delete();

            var destination = ( string ) ScenarioContext.Current [ "DestinationFilename" ];
            var destinationFile = new SpecFlowFile(destination);
            destinationFile.Delete();
        }

        [BeforeScenario]
        [UsedImplicitly]
        public void BeforeScenario()
        {
            IContainer container = CreateContainer();


            var runner = container.Resolve <IGradeRunner>();

            ScenarioContext.Current [ "IContainer" ] = container;
            ScenarioContext.Current [ "IGradeRunner" ] = runner;
            ScenarioContext.Current [ "SourceFilename" ] = "students.txt";
            ScenarioContext.Current [ "DestinationFilename" ] = "students-graded.txt";
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
    }
}