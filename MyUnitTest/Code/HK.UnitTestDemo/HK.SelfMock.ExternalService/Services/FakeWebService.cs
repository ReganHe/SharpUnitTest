using System;
using HK.SelfMock.ExternalService.Contract;

namespace HK.SelfMock.ExternalService.Services
{
    public class FakeWebService : IWebService
    {
        public string LastError;
        public Exception ToThrow;
        public void LogError(string message)
        {
            if (ToThrow != null)
            {
                throw ToThrow;
            }

            LastError = message;
        }
    }
}
