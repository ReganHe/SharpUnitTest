using System;
using HK.SelfMock.Service;
using Xunit;

namespace HK.SelfMock.UnitTests
{
    public class LogAnalyzer2Test
    {
        [Fact]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            var stubService = new FakeWebService
            {
                ToThrow = new Exception("fake exception")
            };
            var mockEmail = new FakeEmailService();
            var log = new LogAnalyzer2(stubService, mockEmail);
            const string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);
            var expectedEmail = new
            {
                Body = "fake exception",
                To = "someone@somewhere.com",
                Subject = "can't log"
            };
            Assert.Equal(expectedEmail.Body, mockEmail.Body);
        }
    }
}
