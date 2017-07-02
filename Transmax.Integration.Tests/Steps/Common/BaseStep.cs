using TechTalk.SpecFlow;
using Transmax.Core.Interfaces;

namespace Transmax.Integration.Tests.Steps.Common
{
    [Binding]
    public abstract class BaseStep
    {
        protected BaseStep()
        {
            GraderRunner = ( IGradeRunner ) ScenarioContext.Current [ "IGradeRunner" ];
            SourceFilename = ( string ) ScenarioContext.Current [ "SourceFilename" ];
            DestinationFilename = ( string ) ScenarioContext.Current [ "DestinationFilename" ];
        }

        protected IGradeRunner GraderRunner { get; }
        protected string SourceFilename { get; }
        protected string DestinationFilename { get; }
    }
}