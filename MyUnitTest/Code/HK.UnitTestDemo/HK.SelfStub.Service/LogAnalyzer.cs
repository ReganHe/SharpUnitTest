namespace HK.SelfStub.Service
{
    public class LogAnalyzer
    {
        private readonly IExtensionManager _manager;

        public LogAnalyzer(IExtensionManager manager)
        {
            _manager = manager;
        }

        public bool IsValidLogFileName(string fileName)
        {
            return _manager.IsValid(fileName);
        }
    }
}
