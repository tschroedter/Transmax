using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace Transmax.Common.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ConvertScoreTests
    {
        [TestCase("-1",
            -1)]
        [TestCase("0",
            0)]
        [TestCase("1",
            1)]
        [TestCase("99",
            99)]
        [TestCase("100",
            100)]
        [TestCase("abc",
            int.MinValue)]
        [TestCase("",
            int.MinValue)]
        [TestCase(null,
            int.MinValue)]
        public void ToInt32_Returns_Integer(
            string text,
            int expected)
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(expected,
                            ConvertScore.ToInt32(text));
        }
    }
}