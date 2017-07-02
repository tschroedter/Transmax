using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Transmax.Common.Extensions;
using Transmax.Integration.Tests.Steps.Common;

namespace Transmax.Integration.Tests.Steps
{
    [Binding]
    [ExcludeFromCodeCoverage]
    public class GivenTheSourceFileContainsTheFollowingStep
        : BaseStep
    {
        [UsedImplicitly]
        [Given(@"Given the source file contains the following:")]
        public void GivenTheSourceFileContainsTheFollowing(Table table)
        {
            var file = new SpecFlowFile(SourceFilename);
            file.Delete();

            var students = table.CreateSet<StudentScores>();

            var lines = students.Select(s => s.FirstName +
                                             ", " +
                                             s.Surname +
                                             ", " +
                                             s.Score);

            file.WriteAllLines(lines);

            Console.WriteLine("Created file '{0}'!".Inject(file.FullName));
        }
    }
}