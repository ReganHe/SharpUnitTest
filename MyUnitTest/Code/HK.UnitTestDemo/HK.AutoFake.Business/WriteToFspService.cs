using System.IO;
using HK.AutoFake.ExternalService.Contract;

namespace HK.AutoFake.Business
{
    public class WriteToFspService
    {
        private readonly IImageWritor imageWritor;
        public WriteToFspService(IImageWritor imageWritor)
        {
            this.imageWritor = imageWritor;
        }

        public bool WriteImage(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return false;
            }

            if (!File.Exists(filePath))
            {
                return false;
            }

            byte[] byteContent = File.ReadAllBytes(filePath);
            return this.imageWritor.Write(filePath, byteContent);
        }
    }
}
