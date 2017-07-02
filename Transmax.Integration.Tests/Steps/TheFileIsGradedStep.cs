using System.Diagnostics.CodeAnalysis;
using TechTalk.SpecFlow;
using Transmax.Integration.Tests.Steps.Common;

namespace Transmax.Integration.Tests.Steps
{
    [Binding]
    [ExcludeFromCodeCoverage]
    public class TheFileIsGradedStep
        : BaseStep
    {
        [When(@"the file is graded")]
        public void WhenTheFileIsGraded()
        {
            GraderRunner.Grade(SourceFilename);
        }
    }
}