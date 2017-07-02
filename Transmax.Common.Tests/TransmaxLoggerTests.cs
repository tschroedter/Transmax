using System;
using System.Diagnostics.CodeAnalysis;
using NLog;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;

namespace Transmax.Common.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class TransmaxLoggerTests
    {
        [SetUp]
        public void Setup()
        {
            m_Exception = new Exception("Test");
            m_Message = "Test";

            m_Automocker = new NSubstituteAutoMocker<TransmaxLogger>();
            m_Logger = m_Automocker.Get<ILogger>();

            m_Sut = m_Automocker.ClassUnderTest;
        }

        private Exception m_Exception;
        private string m_Message;
        private NSubstituteAutoMocker<TransmaxLogger> m_Automocker;
        private ILogger m_Logger;
        private TransmaxLogger m_Sut;

        [Test]
        public void Debug_Calls_Logger_For_Message()
        {
            // Arrange
            // Act
            m_Sut.Debug(m_Message);

            // Assert
            m_Logger.Received().Debug(m_Message);
        }

        [Test]
        public void Error_Calls_Logger_For_Exception_And_Message()
        {
            // Arrange
            // Act
            m_Sut.Error(m_Message,
                m_Exception);

            // Assert
            m_Logger.Received().Error(m_Exception,
                m_Message);
        }

        [Test]
        public void Error_Calls_Logger_For_Message()
        {
            // Arrange
            // Act
            m_Sut.Error(m_Message);

            // Assert
            m_Logger.Received().Error(m_Message);
        }

        [Test]
        public void Fatal_Calls_Logger_For_Exception_And_Message()
        {
            // Arrange
            // Act
            m_Sut.Fatal(m_Message,
                m_Exception);

            // Assert
            m_Logger.Received().Fatal(m_Exception,
                m_Message);
        }

        [Test]
        public void Fatal_Calls_Logger_For_Message()
        {
            // Arrange
            // Act
            m_Sut.Fatal(m_Message);

            // Assert
            m_Logger.Received().Fatal(m_Message);
        }
    }
}