using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace FFCProject.Services
{
    public class EmailSystem
    {
        private readonly EmailSettings _settings;

        public EmailSystem(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body, bool isHtml = true)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient(_settings.SmtpServer, _settings.Port))
                {
                    smtp.Credentials = new NetworkCredential(_settings.SenderEmail, _settings.Password);
                    smtp.EnableSsl = _settings.EnableSsl;

                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress(_settings.SenderEmail, "FFC Login System"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = isHtml
                    };

                    mail.To.Add(toEmail);

                    await smtp.SendMailAsync(mail);
                    Console.WriteLine($"✅ Email sent to {toEmail}");
                    return true;
                }
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine($"❌ SMTP Error: {smtpEx.Message}");
                return false;
            }
            catch (FormatException formatEx)
            {
                Console.WriteLine($"❌ Invalid Email Address: {formatEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ General Error: {ex.Message}");
                return false;
            }
        }
    }
}
