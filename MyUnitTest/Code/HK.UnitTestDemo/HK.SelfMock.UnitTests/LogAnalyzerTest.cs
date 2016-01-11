using System;
using HK.SelfMock.ExternalService.Services;
using HK.SelfMock.Service;
using Xunit;

namespace HK.SelfMock.UnitTests
{
    public class LogAnalyzerTest
    {
        [Fact]
        public void Analyze_WebServiceThrows_ThrowException()
        {
            var stubService = new FakeWebService
            {
                ToThrow = new Exception("fake exception")
            };

            var log = new LogAnalyzer(stubService);
            const string tooShortFileName = "abc.ext";
            Assert.Throws<Exception>(() => log.Analyze(tooShortFileName));
        }

        [Fact]
        public void Analyzer_TooShortFileName_CallsWebService()
        {
            var mockService = new FakeWebService();
            var log = new LogAnalyzer(mockService);
            const string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);
            Assert.Equal("FileName too short:abc.ext", mockService.LastError);
        }
    }
}
