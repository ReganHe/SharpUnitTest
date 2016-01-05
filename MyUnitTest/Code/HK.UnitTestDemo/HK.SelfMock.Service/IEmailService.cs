namespace HK.SelfMock.Service
{
  public  interface IEmailService
  {
      void SendEmail(string to, string subject, string body);
  }
}
