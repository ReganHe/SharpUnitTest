using System;

namespace HK.SelfMock.Service
{
    public class LogAnalyzer2
    {
        private readonly IWebService _webService;
        private readonly IEmailService _emailService;
        public LogAnalyzer2(IWebService service, IEmailService emailService)
        {
            _webService = service;
            _emailService = emailService;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    _webService.LogError("FileName too short:" + fileName);
                }
                catch (Exception e)
                {
                    _emailService.SendEmail("someone@somewhere.com", "can't log", e.Message);
                }
            }
        }
    }
}
