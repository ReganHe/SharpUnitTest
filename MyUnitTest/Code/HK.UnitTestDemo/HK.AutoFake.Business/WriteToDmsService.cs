using System.IO;
using HK.AutoFake.ExternalService.Services;

namespace HK.AutoFake.Business
{
    public class WriteToDmsService
    {
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
            var service = new ExternalDmsService();
            return service.Write(filePath, byteContent);
        }
    }
}
