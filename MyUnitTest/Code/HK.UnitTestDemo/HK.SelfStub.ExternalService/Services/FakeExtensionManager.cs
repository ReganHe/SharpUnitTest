using System;
using HK.SelfStub.ExternalService.Contract;

namespace HK.SelfStub.ExternalService.Services
{
    public class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid { get; set; }

        public Exception WillThrowException { get; set; }

        public bool IsValid(string fileName)
        {
            if (WillThrowException != null)
            {
                throw WillThrowException;
            }

            return WillBeValid;
        }
    }
}
