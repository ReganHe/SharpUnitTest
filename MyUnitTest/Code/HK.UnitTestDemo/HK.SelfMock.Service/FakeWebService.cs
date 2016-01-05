using System;

namespace HK.SelfMock.Service
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
