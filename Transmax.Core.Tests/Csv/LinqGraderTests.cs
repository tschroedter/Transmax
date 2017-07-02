using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;
using Transmax.Core.Csv;
using Transmax.Core.Interfaces.Csv;

namespace Transmax.Core.Tests.Csv
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class LinqGraderTests
    {
        [SetUp]
        public void Setup()
        {
            m_Automocker = new NSubstituteAutoMocker<LinqGrader>();
            m_Input = m_Automocker.Get<IInputFile>();
            m_Output = m_Automocker.Get<IOutputFile>();

            m_Sut = m_Automocker.ClassUnderTest;
        }

        private NSubstituteAutoMocker<LinqGrader> m_Automocker;
        private IInputFile m_Input;
        private LinqGrader m_Sut;
        private IOutputFile m_Output;

        private IEnumerable<string> CreateResult()
        {
            return new[]
            {
                "BUNDY, TED, 88",
                "SMITH, ALLAN, 85",
                "SMITH, FRANCIS, 85",
                "KING, MADISON, 83"
            };
        }

        private IEnumerable<string> CreateResultUpperLowerCase()
        {
            return new[]
            {
                "BUNDY, TED, 88",
                "SMITH, allan, 85",
                "smith, francis, 85",
                "king, MADISON, 83"
            };
        }

        private IEnumerable<string> CreateLines()
        {
            return new[]
            {
                "TED, BUNDY, 88",
                "ALLAN, SMITH, 85",
                "MADISON, KING, 83",
                "FRANCIS, SMITH, 85"
            };
        }

        private IEnumerable<string> CreateLinesUpperLowerCase()
        {
            return new[]
            {
                "TED, BUNDY, 88",
                "allan, SMITH, 85",
                "MADISON, king, 83",
                "francis, smith, 85"
            };
        }

        private IEnumerable<string> CreateInvalidMissingColumn()
        {
            return new[]
            {
                "TED, BUNDY"
            };
        }

        [Test]
        public void DestinationFilename_Get_Set()
        {
            // Arrange
            var expected = "filename";

            // Act
            m_Sut.DestinationFilename = expected;

            // Assert
            Assert.AreEqual(expected,
                m_Sut.DestinationFilename);
        }

        [Test]
        public void Process_Can_Throw_Custom_Exception()
        {
            // Arrange
            m_Input.When(x => x.ReadLines())
                .Do(x => { throw new Exception("test"); });

            // Act
            // Assert
            Assert.Throws<GraderException>(() => m_Sut.Process());
        }


        [Test]
        public void Process_OrdersBy_Score_Surname_Lastname()
        {
            // Arrange
            m_Input.ReadLines().Returns(CreateLines());
            var expected = CreateResult();

            // Act
            m_Sut.Process();

            // Assert
            m_Output.Received()
                .WriteAllLines(Arg.Is<IEnumerable<string>>(x => x.SequenceEqual(expected)));
        }

        [Test]
        public void Process_OrdersBy_Score_Surname_Lastname_Upper_Lower_Case()
        {
            // Arrange
            m_Input.ReadLines().Returns(CreateLinesUpperLowerCase());
            var expected = CreateResultUpperLowerCase();

            // Act
            m_Sut.Process();

            // Assert
            m_Output.Received()
                .WriteAllLines(Arg.Is<IEnumerable<string>>(x => x.SequenceEqual(expected)));
        }

        [Test]
        public void Process_Returns_Empty_For_Empty_File()
        {
            // Arrange
            m_Input.ReadLines().Returns(new string[0]);
            var expected = new string[0];

            // Act
            m_Sut.Process();

            // Assert
            m_Output.Received()
                .WriteAllLines(Arg.Is<IEnumerable<string>>(x => x.SequenceEqual(expected)));
        }

        [Test]
        public void SourceFilename_Get_Set()
        {
            // Arrange
            var expected = "filename";

            // Act
            m_Sut.SourceFilename = expected;

            // Assert
            Assert.AreEqual(expected,
                m_Sut.SourceFilename);
        }
    }
}