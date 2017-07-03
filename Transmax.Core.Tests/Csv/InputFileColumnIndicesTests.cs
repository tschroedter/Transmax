using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Transmax.Core.Csv;

namespace Transmax.Core.Tests.Csv
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class InputFileColumnIndicesTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new InputFileColumnIndices();
        }

        private InputFileColumnIndices m_Sut;

        [Test]
        public void FirstName_Returns_Integer()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(0,
                            m_Sut.FirstName);
        }

        [Test]
        public void Score_Returns_Integer()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(2,
                            m_Sut.Score);
        }

        [Test]
        public void Surname_Returns_Integer()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(1,
                            m_Sut.Surname);
        }
    }
}