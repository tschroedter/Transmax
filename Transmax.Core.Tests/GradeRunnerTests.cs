using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;
using Transmax.Common.Interfaces;
using Transmax.Core.Csv;
using Transmax.Core.Interfaces;

namespace Transmax.Core.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class GradeRunnerTests
    {
        [SetUp]
        public void Setup()
        {
            m_Automocker = new NSubstituteAutoMocker <GradeRunner>();
            m_Logger = m_Automocker.Get <ITransmaxLogger>();
            m_Grader = m_Automocker.Get <IGrader>();
            m_Console = m_Automocker.Get <ITransmaxConsole>();

            m_Sut = m_Automocker.ClassUnderTest;
        }

        private NSubstituteAutoMocker <GradeRunner> m_Automocker;
        private ITransmaxLogger m_Logger;
        private IGrader m_Grader;
        private GradeRunner m_Sut;
        private ITransmaxConsole m_Console;

        [Test]
        public void Grade_Calls_Process()
        {
            // Arrange
            // Act
            m_Sut.Grade("students.txt");

            // Assert
            m_Grader.Received().Process();
        }

        [Test]
        public void Grade_Handles_GraderException()
        {
            // Arrange
            m_Grader.When(x => x.Process())
                    .Do(x =>
                        {
                            throw new GraderException("test",
                                                      new Exception());
                        });

            // Act"
            m_Sut.Grade("students.txt");

            // Assert
            m_Logger.Received().Fatal(Arg.Any <string>(),
                                      Arg.Any <GraderException>());

            m_Console.Received().WriteLine(Arg.Any <string>());
        }

        [Test]
        public void Grade_Sets_DestinationFilename_For_Filename_Only()
        {
            // Arrange
            var filename = "students.txt";
            var expected = "students-graded.txt";

            // Act
            m_Sut.Grade(filename);

            // Assert
            Assert.AreEqual(expected,
                            m_Grader.DestinationFilename);
        }

        [Test]
        public void Grade_Sets_DestinationFilename_For_Fullname()
        {
            // Arrange
            var filename = @"C:\Temp\students.txt";
            var expected = @"C:\Temp\students-graded.txt";

            // Act
            m_Sut.Grade(filename);

            // Assert
            Assert.AreEqual(expected,
                            m_Grader.DestinationFilename);
        }


        [Test]
        public void Grade_Sets_SourceFilename_For_Filename_Only()
        {
            // Arrange
            var filename = "students.txt";

            // Act
            m_Sut.Grade(filename);

            // Assert
            Assert.AreEqual(filename,
                            m_Grader.SourceFilename);
        }

        [Test]
        public void Grade_Sets_SourceFilename_For_Fullname()
        {
            // Arrange
            var filename = @"C:\Temp\students.txt";

            // Act
            m_Sut.Grade(filename);

            // Assert
            Assert.AreEqual(filename,
                            m_Grader.SourceFilename);
        }
    }
}