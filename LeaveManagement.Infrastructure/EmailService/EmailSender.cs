using LeaveManagement.Application.Contracts.Email;
using LeaveManagement.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace LeaveManagenemt.Infrastructure.EmailService;

public class EmailSender:IEmailSender
{
    public EmailSetting _emailSetting { get; }

    public EmailSender(IOptions<EmailSetting> emailSetting)
    {
        _emailSetting = emailSetting.Value;
    }
    
    public async Task<bool> SendEmail(EmailMessage email)
    {
        var client = new SendGridClient(_emailSetting.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress
        {
            Email = _emailSetting.FromAddress,
            Name = _emailSetting.FromName
        };
        var messaage = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(messaage);

        return response.IsSuccessStatusCode;
    }
}