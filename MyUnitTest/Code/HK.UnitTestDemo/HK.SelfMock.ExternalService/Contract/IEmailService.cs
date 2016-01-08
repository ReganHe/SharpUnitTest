namespace HK.SelfMock.ExternalService.Contract
{
  public  interface IEmailService
  {
      void SendEmail(string to, string subject, string body);
  }
}
