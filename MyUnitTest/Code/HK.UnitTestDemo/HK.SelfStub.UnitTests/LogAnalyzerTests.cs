using System;
using HK.SelfStub.ExternalService.Services;
using HK.SelfStub.Service;
using Xunit;

namespace HK.SelfStub.UnitTests
{
    public class LogAnalyzerTest
    {
        [Fact]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            var myFakeManager = new FakeExtensionManager
            {
                WillBeValid = true
            };
            var logAnalyzer = new LogAnalyzer(myFakeManager);
            var result = logAnalyzer.IsValidLogFileName("short.ext");
            Assert.True(result);
        }

        [Fact]
        public void IsValidFileName_NameNotSupportedExtension_ReturnsFalse()
        {
            var myFakeManager = new FakeExtensionManager
            {
                WillBeValid = false
            };
            var logAnalyzer = new LogAnalyzer(myFakeManager);
            var result = logAnalyzer.IsValidLogFileName("short.ext");
            Assert.False(result);
        }

        [Fact]
        public void IsValidFileName_ThrowException_ThrowException()
        {
            var myFakeManager = new FakeExtensionManager
            {
                WillThrowException = new Exception("this is a fake exception")
            };
            var logAnalyzer = new LogAnalyzer(myFakeManager);
            Assert.Throws<Exception>(() => logAnalyzer.IsValidLogFileName("short.ext"));
        }
    }
}
