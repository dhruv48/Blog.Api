using Blog.Api.Services.Interface;
using Blog.Common.Models;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Api.Services.Implement
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"Template/{0}.html";
        private readonly SMTPConfigModel _sMTPConfigModel;
        public EmailService(IOptions<SMTPConfigModel> _smtpConfig)
        {
            _sMTPConfigModel = _smtpConfig.Value;
        }


        public async Task SendEmailTest(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = "This is test email from Blog Company";
            userEmailOptions.Body = GetEmailBody("TestEmail");

            await SendEmail(userEmailOptions);
        }

        private async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_sMTPConfigModel.SenderAddress, _sMTPConfigModel.SenderDisplayName),
                IsBodyHtml = _sMTPConfigModel.IsHtmlBody
            };

            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toEmail);
            }
            NetworkCredential networkCredential = new NetworkCredential(_sMTPConfigModel.UserName, _sMTPConfigModel.Password);
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _sMTPConfigModel.Host,
                Port = _sMTPConfigModel.Port,
                EnableSsl = _sMTPConfigModel.EnableSSL,
                UseDefaultCredentials = _sMTPConfigModel.useDefaultCredentials,
                Credentials = networkCredential
            };

            mail.BodyEncoding = Encoding.Default;
            await smtpClient.SendMailAsync(mail);
        }

        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }

      
        
    }
}
