using System.Diagnostics;

namespace MessageBoardWebApp.Services
{
    public class MockMailService : IMailService
    {
        bool IMailService.SendMail(string from, string to, string subject, string body)
        {
            Debug.WriteLine($"Sending mail From: '{from}' Message: '{body}'");

            return true;
        }
    }
}