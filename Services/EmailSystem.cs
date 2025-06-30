using System.Net;
using System.Net.Mail;

namespace FFCProject.Services
{
    public class EmailSystem
    {
        private readonly string smtpHost;
        private readonly int smtpPort;
        private readonly string smtpUser;
        private readonly string smtpPass;
        private readonly bool enableSsl;

        public EmailSystem(string host, int port, string user, string pass, bool ssl = true)
        {
            smtpHost = host;
            smtpPort = port;
            smtpUser = user;
            smtpPass = pass;
            enableSsl = ssl;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body, bool isHtml = true)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient(smtpHost, smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(smtpUser, smtpPass);
                    smtp.EnableSsl = enableSsl;

                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress(smtpUser, "FFC Login System"),
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
