using System;

namespace HK.SelfStub.Service
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
