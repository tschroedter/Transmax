using System.Diagnostics.CodeAnalysis;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;
using Transmax.Common.Interfaces;
using Transmax.Core.Csv;
using Transmax.Core.Interfaces;

namespace Transmax.Core.Tests.Csv
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class OutputFileTests
    {
        [SetUp]
        public void Setup()
        {
            m_Automocker = new NSubstituteAutoMocker <OutputFile>();
            m_File = m_Automocker.Get <ITransmaxFile>();
            m_Mode = m_Automocker.Get <IApplicationMode>();
            m_Console = m_Automocker.Get <ITransmaxConsole>();

            m_Sut = m_Automocker.ClassUnderTest;
        }

        private NSubstituteAutoMocker <OutputFile> m_Automocker;
        private ITransmaxConsole m_Console;
        private IApplicationMode m_Mode;
        private ITransmaxFile m_File;
        private OutputFile m_Sut;

        [Test]
        public void WriteAllLines_Does_Not_Write_Output_To_Console_In_Release_Mode()
        {
            // Arrange
            m_Mode.IsRelease.Returns(true);

            // Act
            m_Sut.WriteAllLines(new[]
                                {
                                    "line1",
                                    "line2"
                                });

            // Assert
            m_Console.DidNotReceive().WriteLine(Arg.Any <string>());
        }

        [Test]
        public void WriteAllLines_Writes_Output_To_Console_In_Debug_Mode()
        {
            // Arrange
            m_Mode.IsRelease.Returns(false);

            // Act
            m_Sut.WriteAllLines(new[]
                                {
                                    "line1",
                                    "line2"
                                });

            // Assert
            m_Console.Received().WriteLine("line1");
            m_Console.Received().WriteLine("line2");
        }

        [Test]
        public void WriteAllLines_Writes_Output_To_File_In_Debug_Mode()
        {
            // Arrange
            var lines = new[]
                        {
                            "line1",
                            "line2"
                        };
            var filename = "students.txt";

            m_Sut.Filename = filename;
            m_Mode.IsRelease.Returns(false);

            // Act
            m_Sut.WriteAllLines(lines);

            // Assert
            m_File.Received().WriteAllLines(filename,
                                            lines);
        }

        [Test]
        public void WriteAllLines_Writes_Output_To_File_In_Release_Mode()
        {
            // Arrange
            var lines = new[]
                        {
                            "line1",
                            "line2"
                        };
            var filename = "students.txt";

            m_Sut.Filename = filename;
            m_Mode.IsRelease.Returns(true);

            // Act
            m_Sut.WriteAllLines(lines);

            // Assert
            m_File.Received().WriteAllLines(filename,
                                            lines);
        }
    }
}