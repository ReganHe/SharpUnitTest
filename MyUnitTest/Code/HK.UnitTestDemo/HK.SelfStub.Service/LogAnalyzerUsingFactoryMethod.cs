﻿namespace HK.SelfStub.Service
{
    public class LogAnalyzerUsingFactoryMethod
    {
        public bool IsValidLogFileName(string fileName)
        {
            return GetManager().IsValid(fileName);
        }

        protected virtual IExtensionManager GetManager()
        {
            return new FileExtensionManager();
        }
    }
}
