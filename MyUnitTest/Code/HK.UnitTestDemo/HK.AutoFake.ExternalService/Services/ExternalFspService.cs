using System;
using HK.AutoFake.ExternalService.Contract;

namespace HK.AutoFake.ExternalService.Services
{
    public class ExternalFspService : IImageWritor
    {
        public bool Write(string filePath, byte[] fileContent)
        {
            throw new NotImplementedException();
        }
    }
}
