using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Threading.Tasks;

public class SendGridService
{
    private SendGridClient _client;
    public SendGridService()
    {
        _client = new SendGridClient(Settings.SendGridKey);
    }
    public void SendEmail(Email email)
    {
        ExecuteAsync(email).Wait();
    }

    public async Task ExecuteAsync(Email email)
    {
        var from = new EmailAddress(Settings.FromEmail, Settings.FromName);
        var to = new EmailAddress(email.EmailAddress);
        var htmlContent = email.Body;
        var msg = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, null);
        foreach (var attachment in email.Attachments)
        {
            var bytes = File.ReadAllBytes(attachment.Path);
            msg.AddAttachment(attachment.Name, Convert.ToBase64String(bytes));
        }
        var response = await _client.SendEmailAsync(msg);
    }
}
