namespace HK.AutoFake.ExternalService.Contract
{
    public interface IImageWritor
    {
        bool Write(string filePath, byte[] fileContent);
    }
}
