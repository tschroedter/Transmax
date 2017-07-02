using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Transmax.Common.Extensions;

namespace Transmax.Common.Tests.Extensions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class StringExtensionsTests
    {
        [Test]
        public void InjectTest()
        {
            const string expected = "Text: Hello World!";
            string actual = "Text: {0} {1}!".Inject("Hello",
                                                    "World");

            Assert.AreEqual(expected,
                            actual);
        }
    }
}