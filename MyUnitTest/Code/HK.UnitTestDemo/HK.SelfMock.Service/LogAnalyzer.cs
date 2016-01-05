namespace HK.SelfMock.Service
{
    public class LogAnalyzer
    {
        private IWebService _service;

        public LogAnalyzer(IWebService service)
        {
            _service = service;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                _service.LogError("FileName too short:" + fileName);
            }
        }
    }
}
