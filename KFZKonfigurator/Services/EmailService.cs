using System;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;
using KFZKonfigurator.Base.Logging;
using KFZKonfigurator.BusinessModels.Model;
using KFZKonfigurator.Resources;

namespace KFZKonfigurator.Services
{
    [Log]
    public class EmailService
    {
        public void SendEmail(Order order) {
            try {
                var baseUrl = WebConfigurationManager.AppSettings["BaseUrl"];
                var emailSender = WebConfigurationManager.AppSettings["EmailSender"];
                var smtpServer = WebConfigurationManager.AppSettings["SmtpServer"];
                var smtpPort = WebConfigurationManager.AppSettings["SmtpPort"];
                var smtpPassword = WebConfigurationManager.AppSettings["SmtpPassword"];
                var urlPath = $"Configuration/order/{order.OrderId}";

                var mailMessage = new MailMessage {From = new MailAddress(emailSender)};

                mailMessage.To.Add(order.User.Email);
                mailMessage.Subject = string.Format(KonfiguratorResx.Email_Subject_Format, order.Configuration.Name);
                mailMessage.Body = string.Format(KonfiguratorResx.Email_Body_Format, Environment.NewLine, order.Configuration.Name, order.Price, baseUrl, urlPath);
                mailMessage.IsBodyHtml = true;

                var smtpClient = new SmtpClient(smtpServer, int.Parse(smtpPort)) {
                    Credentials = new NetworkCredential(emailSender, smtpPassword),
                    EnableSsl = true
                };
                smtpClient.Send(mailMessage);
            }
            catch (Exception e) {
                Logger.Error(e);
            }
        }
    }
}