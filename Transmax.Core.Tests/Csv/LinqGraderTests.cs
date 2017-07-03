using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;
using Transmax.Core.Csv;
using Transmax.Core.Interfaces.Csv;
using static System.Console;

namespace Transmax.Core.Tests.Csv
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class LinqGraderTests
    {
        [SetUp]
        public void Setup()
        {
            m_Automocker = new NSubstituteAutoMocker <LinqGrader>();
            m_Indices = m_Automocker.Get <IInputFileColumnIndices>();
            m_Input = m_Automocker.Get <IInputFile>();
            m_Output = m_Automocker.Get <IOutputFile>();

            m_Indices.FirstName.Returns(0);
            m_Indices.Surname.Returns(1);
            m_Indices.Score.Returns(2);

            m_Sut = m_Automocker.ClassUnderTest;
        }

        private NSubstituteAutoMocker <LinqGrader> m_Automocker;
        private IInputFile m_Input;
        private LinqGrader m_Sut;
        private IOutputFile m_Output;
        private IInputFileColumnIndices m_Indices;

        private IEnumerable <string> CreateResult()
        {
            return new[]
                   {
                       "BUNDY,TED,88",
                       "SMITH,ALLAN,85",
                       "SMITH,FRANCIS,85",
                       "KING,MADISON,83"
                   };
        }

        private IEnumerable <string> CreateResultUpperLowerCase()
        {
            return new[]
                   {
                       "BUNDY,TED,88",
                       "SMITH,allan,85",
                       "smith,francis,85",
                       "king,MADISON,83"
                   };
        }

        private IEnumerable <string> CreateLines()
        {
            return new[]
                   {
                       "TED, BUNDY, 88",
                       "ALLAN, SMITH, 85",
                       "MADISON, KING, 83",
                       "FRANCIS, SMITH, 85"
                   };
        }

        private IEnumerable <string> CreateLinesWithOneColumnMissing()
        {
            return new[]
                   {
                       "TED, BUNDY, 88",
                       "ALLAN, SMITH, 85",
                       "MADISON, KING, 83",
                       "FRANCIS, SMITH, 85",
                       "JOE, COOL"
                   };
        }

        private IEnumerable <string> CreateLinesWithOneScoreMissing()
        {
            return new[]
                   {
                       "TED, BUNDY, 88",
                       "ALLAN, SMITH, 85",
                       "MADISON, KING, 83",
                       "FRANCIS, SMITH, 85",
                       "JOE, COOL,"
                   };
        }

        private IEnumerable <string> CreateResultWithOneScoreMissing()
        {
            return new[]
                   {
                       "BUNDY,TED,88",
                       "SMITH,ALLAN,85",
                       "SMITH,FRANCIS,85",
                       "KING,MADISON,83",
                       "COOL,JOE," + int.MinValue
                   };
        }

        private IEnumerable <string> CreateLinesUpperLowerCase()
        {
            return new[]
                   {
                       "TED,BUNDY,88",
                       "allan,SMITH,85",
                       "MADISON,king,83",
                       "francis,smith,85"
                   };
        }

        private bool CompareLines(
            [NotNull] IEnumerable <string> expected,
            [NotNull] IEnumerable <string> actual)
        {
            for ( var i = 0 ; i < actual.Count() ; i++ )
            {
                string expectedAt = expected.ElementAt(i);
                string actualAt = actual.ElementAt(i);

                Write("[{0}] Expected: '{1}' Actual: '{2}'",
                      i,
                      expectedAt,
                      actualAt);

                if ( expectedAt.CompareTo(actualAt) != 0 )
                {
                    WriteLine(" - FAILED");
                    return false;
                }

                WriteLine(" - PASS");
            }

            return true;
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
                   .Do(x =>
                       {
                           throw new Exception("test");
                       });

            // Act
            // Assert
            Assert.Throws <GraderException>(() => m_Sut.Process());
        }

        [Test]
        public void Process_Ignores_Lines_With_Missing_Column()
        {
            // Arrange
            m_Input.ReadLines().Returns(CreateLinesWithOneColumnMissing());
            IEnumerable <string> expected = CreateResult();

            // Act
            m_Sut.Process();

            // Assert
            m_Output.Received()
                    .WriteAllLines(Arg.Is <IEnumerable <string>>(x => CompareLines(expected,
                                                                                   x)));
        }

        [Test]
        public void Process_Ignores_Lines_With_Missing_Score()
        {
            // Arrange
            m_Input.ReadLines().Returns(CreateLinesWithOneScoreMissing());
            IEnumerable <string> expected = CreateResultWithOneScoreMissing();

            // Act
            m_Sut.Process();

            // Assert
            m_Output.Received()
                    .WriteAllLines(Arg.Is <IEnumerable <string>>(x => CompareLines(expected,
                                                                                   x)));
        }


        [Test]
        public void Process_OrdersBy_Score_Surname_Lastname()
        {
            // Arrange
            m_Input.ReadLines().Returns(CreateLines());
            IEnumerable <string> expected = CreateResult();

            // Act
            m_Sut.Process();

            // Assert
            m_Output.Received()
                    .WriteAllLines(Arg.Is <IEnumerable <string>>(x => CompareLines(expected,
                                                                                   x)));
        }

        [Test]
        public void Process_OrdersBy_Score_Surname_Lastname_Upper_Lower_Case()
        {
            // Arrange
            m_Input.ReadLines().Returns(CreateLinesUpperLowerCase());
            IEnumerable <string> expected = CreateResultUpperLowerCase();

            // Act
            m_Sut.Process();

            // Assert
            m_Output.Received()
                    .WriteAllLines(Arg.Is <IEnumerable <string>>(x => CompareLines(expected,
                                                                                   x)));
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
                    .WriteAllLines(Arg.Is <IEnumerable <string>>(x => CompareLines(expected,
                                                                                   x)));
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