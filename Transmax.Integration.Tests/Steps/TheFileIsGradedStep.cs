using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using TechTalk.SpecFlow;
using Transmax.Integration.Tests.Steps.Common;

namespace Transmax.Integration.Tests.Steps
{
    [Binding]
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class TheFileIsGradedStep
        : BaseStep
    {
        [UsedImplicitly]
        [When(@"the file is graded")]
        public void WhenTheFileIsGraded()
        {
            GraderRunner.Grade(SourceFilename);
        }
    }
}