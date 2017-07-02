using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Transmax.Common.Extensions;
using Transmax.Integration.Tests.Steps.Common;

namespace Transmax.Integration.Tests.Steps
{
    [Binding]
    [ExcludeFromCodeCoverage]
    [UsedImplicitly]
    public class TheDestinationFileShouldContainTheFollowingStep
        : BaseStep
    {
        private const int ColumnFirstName = 1;
        private const int ColumnSurname = 0;
        private const int ColumnScore = 2;

        [Then(@"the destination file should contain the following:")]
        [UsedImplicitly]
        public void ThenTheDestinationFileShouldContainTheFollowing(Table table)
        {
            var file = new SpecFlowFile(DestinationFilename);

            if (!file.Exists)
                Assert.Fail("Destination file '{0}' doesn't exists!".Inject(file.FullName));

            var actual =
                file.ReadAllLines()
                    .SelectMany(line => line.Split('\r'))
                    .Where(csvLine => !string.IsNullOrWhiteSpace(csvLine))
                    .Select(csvLine => new
                    {
                        data = csvLine.Trim().Split(',')
                    })
                    .Select(s => new StudentScores
                    {
                        Surname = s.data[ColumnSurname].Trim(),
                        FirstName = s.data[ColumnFirstName].Trim(),
                        Score = s.data[ColumnScore].Trim()
                    });

            table.CompareToSet(actual, true);
        }
    }
}